using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Emgu.CV;
using Emgu.CV.Structure;
using MathNet.Numerics.LinearAlgebra;
using System.Drawing;
using Emgu.CV.Features2D;
using System.Windows.Forms;

namespace SS11P04ImageStitching
{
    class SS11P04IS_Loesung : SS11P04IS_Aufgabe
    {
        /// <summary>
        /// Bitte hier Namen und Matrikelnummern eintragen
        /// </summary>
        public SS11P04IS_Loesung()
        {
            authors = new String[2] { "Sebastian Lichtenfels", "Andreas Mantler" };
            matrikelNummern = new int[2] { 366070, 363220 };
            //Nur der Neugier halber
            OS = OS.Linux;
		}
		
		/*
		 * Gute Parameterwerte sind (mit angepasster GUI):
		 * 
		 * a = 0.05
		 * Search Range = 50
		 * k = 5
		 * Ransac Steps = 10000
		 * Ransac Threshold = 0.1
		 * 
		 */
		
        /// <summary>
        /// Berechnet eine Homographie aus korrespondierenden Punktepaaren. Benutzt die Methode aus 
        /// "Computer Vision: Algorithms and Applications" von Richard Szeliski, http://szeliski.org/Book/. Kapitel 6.1,
        /// insbesondere 6.1.3
        /// </summary>
        /// <param name="sourcePoints">Punkte im linken Bild</param>
        /// <param name="targetPoints">Punkte im rechten Bild</param>
        /// <returns>Homographiematrix</returns>
        private double[,] getHomographyFromPoints(double[,] affineMatrix, PointF[] sourcePoints, PointF[] targetPoints)
        {
            //Bezeichnungen orientieren sich an den Bezeichnungein in 6.1.3
            Matrix deltaP, A, b, ri;
            ri = new Matrix(2, 1);
            double lambda = 0;

            //Jacobi Matrix und Transponierte
            Matrix J, Jt;
            //Anzahl der Matches
            int nPoints = sourcePoints.Length;
            //von der Homographie vorausgesagte Position von p (siehe (6.3))
            PointF predLoc;
            //Berechne Initial guess von deltaP: In unserem Fall sind die Bilder fast affin verschoben. 
            //Also ist die affine Schätzung ein guter Anfang
            deltaP = new Matrix(8, 1);
            //double[,] affineMatrix = getHomographyFromPointsOld(sourcePoints, targetPoints);
            deltaP[0, 0] = affineMatrix[0, 0] - 1; //wegen Konvention in 6.1.3, zweiter Absatz
            deltaP[1, 0] = affineMatrix[0, 1];
            deltaP[2, 0] = affineMatrix[0, 2];
            deltaP[3, 0] = affineMatrix[1, 0];
            deltaP[4, 0] = affineMatrix[1, 1] - 1;
            deltaP[5, 0] = affineMatrix[1, 2];
            deltaP[6, 0] = affineMatrix[2, 0];
            deltaP[7, 0] = affineMatrix[2, 1];

            //Algorithmus iterieren
            int iterations = 100;
            A = new Matrix(8, 8);
            b = new Matrix(8, 1);
            for (int step = 0; step < iterations; step++)
            {
                //compute A und B:
                for (int i = 0; i < nPoints; i++)
                {
                    //Jacobimatrix berechnen
                    J = getJacobi(deltaP, sourcePoints[i]);
                    Jt = J.Clone();
                    //Transponierte Jacobimatrix berechnen
                    Jt.Transpose();

                    //sourcePoints[i] mit aktueller Homographie abbilden
                    double[,] thisH = new double[3, 3];
                    thisH[0, 0] = deltaP[0, 0] + 1;
                    thisH[0, 1] = deltaP[1, 0];
                    thisH[0, 2] = deltaP[2, 0];
                    thisH[1, 0] = deltaP[3, 0];
                    thisH[1, 1] = deltaP[4, 0] + 1;
                    thisH[1, 2] = deltaP[5, 0];
                    thisH[2, 0] = deltaP[6, 0];
                    thisH[2, 1] = deltaP[7, 0];
                    thisH[2, 2] = 1;
                    predLoc = projectPoint(thisH, sourcePoints[i]);

                    //ri berechnen (6.10)
                    ri[0, 0] = targetPoints[i].X - predLoc.X;
                    ri[1, 0] = targetPoints[i].Y - predLoc.Y;
                    //A und b updaten (6.9) und (6.10)
                    A.Add(Jt.Multiply(J));
                    b.Add(Jt.Multiply(ri));
                }
                //numerischer Trick (6.18)
                for (int j = 0; j < 8; j++)
                    A[j, j] += A[j, j] * lambda;
                //lasse Schritte, in denen A singulär ist, aus, passiert aber sowieso fast nie
                try
                {
                    //nach deltaP lösen und deltaP auf das aktuelle p (=deltaP) addieren (6.18)
                    deltaP.Add(A.Solve(b));
                }
                catch
                {   }
            }

            //lese deltaP aus
            double[,] homography = new double[3, 3];
            homography[0, 0] = deltaP[0, 0] + 1;
            homography[0, 1] = deltaP[1, 0];
            homography[0, 2] = deltaP[2, 0];
            homography[1, 0] = deltaP[3, 0];
            homography[1, 1] = deltaP[4, 0] + 1;
            homography[1, 2] = deltaP[5, 0];
            homography[2, 0] = deltaP[6, 0];
            homography[2, 1] = deltaP[7, 0];
            homography[2, 2] = 1;
            return homography;
        }

        /// <summary>
        /// Berechnet die Jacobimatrix zur Homographie H
        /// </summary>
        /// <param name="H">Homographiematrix</param>
        /// <param name="x">Punkt x</param>
        /// <returns>Jacobimatrix</returns>
        private Matrix getJacobi(Matrix H, PointF x)
        {
            double[,] jacVals = new double[2, 8];
            //(6.19) berechnen
            double D = H[6, 0] * x.X + H[7, 0] * x.Y + 1;
            double xStrich = (1 + H[0, 0]) * x.X + H[1, 0] * x.Y + H[2, 0];
            double yStrich = H[3, 0] * x.X + (1 + H[4, 0]) * x.Y + H[5, 0];
            xStrich /= D;
            yStrich /= D;

            //Jacobimatrix mit (6.20) berechnen
            jacVals[0, 0] = x.X / D;
            jacVals[0, 1] = x.Y / D;
            jacVals[0, 2] = 1 / D;
            jacVals[0, 3] = 0;
            jacVals[0, 4] = 0;
            jacVals[0, 5] = 0;
            jacVals[0, 6] = (-xStrich * x.X) / D;
            jacVals[0, 7] = (-xStrich * x.Y) / D;

            jacVals[1, 0] = 0;
            jacVals[1, 1] = 0;
            jacVals[1, 2] = 0;
            jacVals[1, 3] = x.X / D;
            jacVals[1, 4] = x.Y / D;
            jacVals[1, 5] = 1 / D;
            jacVals[1, 6] = (-yStrich * x.X) / D;
            jacVals[1, 7] = (-yStrich * x.Y) / D;

            return Matrix.Create(jacVals);
        }

        /// <summary>
        /// Bildet p mittels H ab
        /// </summary>
        /// <param name="H">Homographiematrix</param>
        /// <param name="p">Abzubildener Punkt</param>
        /// <returns>Punkt Hp</returns>
        private PointF projectPoint(double[,] H, PointF p)
        {
            //Berechne Hp
            double x = H[0, 0] * p.X + H[0, 1] * p.Y + H[0, 2];
            double y = H[1, 0] * p.X + H[1, 1] * p.Y + H[1, 2];
            double w = H[2, 0] * p.X + H[2, 1] * p.Y + H[2, 2];
            return new PointF((float)(x / w), (float)(y / w));
        }
		
		/// <summary>
        /// Findet in den korrespondierenden Punktepaaren correspondences eine affine Homographie mittels RANSAC
        /// </summary>
        /// <param name="imageL">Das linke Bild</param>
        /// <param name="imageR">Das rechte Bild</param>
        /// <param name="correspondences">Menge von korrespondierenden Punktepaaren, wobei erwartet wird, dass kein Punktepaar doppelt vorkommt</param>
        /// <returns>affine Homographiematrix, die die Transformation zwischen linkem und rechtem Bild beschreibt</returns>
        public override double[,] ransacH(
            Image<Bgr, byte> imageL,
            Image<Bgr, byte> imageR, 
            Match[] correspondences, 
            int ransacSteps, 
            double ransacThresh)
        {
            Random rng = new Random();
            Matrix L, R, H;

            // Anzahl der Korrespondenzen
            int n = correspondences.Length;

            //Sicherstellen, dass mindestens 3 Korrespondenzen vorhand sind, damit das GLS (sieh unten) eindeutig gelöst werden kann
            if (n < 3) throw new Exception("Nicht genug Korrespondenzen gefunden!");

            // Speicherplätze für ConsensusSets:
            // das aktuell verarbeitete; das mit bisher am meisten Elementen
            List<Match> currConsensusSet, biggestConsensusSet = new List<Match>();

            for (int i = 0; i < ransacSteps; i++)
            {
                // Die Matrizen für das zu lösende GLS mit drei zufälligen, verschiedenen Punkten erstellen:
                List<Match> matches = new List<Match>(); //Speicherplatz für drei zufällig ausgewählte, verschiedene Korrespondenzen
                L = new Matrix(3, 3); // enthält drei Punkte aus dem linken Bild (vgl. linke Matrix des GLS vom Aufgabenblatt)
                R = new Matrix(3, 3); // enthält drei punkte aus dem rechten Bild (vgl. rechte Matrix des GLS vom Aufgabenblatt)
                for (int j = 0; j < 3; j++)
                {
                    int index;
                    do
                        index = rng.Next(n); //zufällige, neue Korrespondenz holen
                    while (matches.Contains(correspondences[index]));
                    matches.Add(correspondences[index]);
                    //Die beiden Punkte der aktuellen Korrespondenz den Matrizen hinzufügen
                    L[j, 0] = correspondences[index].p1.X;
                    L[j, 1] = correspondences[index].p1.Y;
                    L[j, 2] = 1;
                    R[j, 0] = correspondences[index].p2.X;
                    R[j, 1] = correspondences[index].p2.Y;
                    R[j, 2] = 1;
                }

                //lasse Schritte, in denen A singulär ist, aus, passiert aber sowieso fast nie
                try
                {
                    H = R.Solve(L); //Das GLS (vgl. Aufgabenblatt) lösen lassen, um die transponierte Homographie-Matrix zu erhalten
                    H.Transpose(); // Die transponierte Homographie-Matrix transponieren, um die Homographie-Matrix zu erhalten
                }
                catch { continue; }

                // Bestimmen des ConsensusSets:
                currConsensusSet = new List<Match>();
                for (int j = 0; j < n; j++)
                {
                    // Rechter Punkt der aktuellen Korrespondenz mit der Homographie-Matrix transformieren
                    // und den (euklidschen) Abstand zum linken Punkt berechnen
                    PointF rightPointTransformed = new PointF();
                    rightPointTransformed.X = (float)(H[0, 0] * correspondences[j].p2.X + H[0, 1] * correspondences[j].p2.Y + H[0, 2]);
                    rightPointTransformed.Y = (float)(H[1, 0] * correspondences[j].p2.X + H[1, 1] * correspondences[j].p2.Y + H[1, 2]);
                    float z = (float)(H[2, 0] + H[2, 1] + H[2, 2]);
                    rightPointTransformed.X /= z;
                    rightPointTransformed.Y /= z;

                    //Abstand berechnen
                    double distance = Math.Sqrt((correspondences[j].p1.X - rightPointTransformed.X) * (correspondences[j].p1.X - rightPointTransformed.X) + (correspondences[j].p1.Y - rightPointTransformed.Y) * (correspondences[j].p1.Y - rightPointTransformed.Y));

                    // Wenn der Abstand des linken Punktes zum transformierten rechten Punkt noch im Rahmen liegt, hinzufügen:
                    if (distance < ransacThresh)
                        currConsensusSet.Add(correspondences[j]);
                }

                // Es wird das ConsensusSet gesucht, das die meisten Elemente enthält:
                if (currConsensusSet.Count > biggestConsensusSet.Count)
                    biggestConsensusSet = currConsensusSet;
            }

            //Nachdem des größte ConsensusSet gefunden wurde, muss dessen Homographie-Matrix mit Hilfe aller unterstützenden Punkte berechnet werden (analog zu oben)
            //Bei einer Überbestimmung des GLS wendet Solve als Ausgleichsverfahren leastSquares an
            L = new Matrix(biggestConsensusSet.Count, 3);
            R = new Matrix(biggestConsensusSet.Count, 3);
            for (int i = 0; i < biggestConsensusSet.Count; i++)
            {
                L[i, 0] = biggestConsensusSet[i].p1.X;
                L[i, 1] = biggestConsensusSet[i].p1.Y;
                L[i, 2] = 1;
                R[i, 0] = biggestConsensusSet[i].p2.X;
                R[i, 1] = biggestConsensusSet[i].p2.Y;
                R[i, 2] = 1;
            }
            H = R.Solve(L);
            H.Transpose();
			
			//correspondences in das passende Format für getHomographyFromPoints überführen
			var l = new PointF[correspondences.Length];
			var r = new PointF[correspondences.Length];
			for(int i = 0; i < correspondences.Length; i++)
			{
				l[i] = correspondences[i].p2;
				r[i] = correspondences[i].p1;
			}

            //Die gefundene affine Homographie-Matrix nutzen, um eine nicht-affine Matrix zu generieren
			//Ergebnis zurückgeben
            return getHomographyFromPoints(H.CopyToArray(), l, r);
        }

		
		/// <summary>
        /// Diese Funktion transformiert ein Bild anhand einer 3x3-Matrix
        /// </summary>
        /// <param name="destination">Zielbild</param>
        /// <param name="offset">Ausgabeversatz für das Zielbild</param>
        /// <param name="image">Quellbild</param>
        /// <param name="matrix">Transformationsmatrix</param>
        /// <returns></returns>
        private void transformPerspectiveBL(Image<Bgr, byte> destination, Point offset, Image<Bgr, byte> image, double[,] matrix)
        {
            Matrix transMatrix = Matrix.Create(matrix);
            double xd, yd, scale;
            int c1, c2, r1, r2;
            double p, q, g;

            //backward mapping
            transMatrix = transMatrix.Inverse();
            //for faster access, transMatrix[r,c] is also possible and only slightly slower
            double[][] transMatrixData = transMatrix.GetArray();
            for (int r = 0; r < destination.Height; r++)
                for (int c = 0; c < destination.Width; c++)
                {
					int oc = c - offset.X;
					int or = r - offset.Y;
                    //warping, i.e. in MATLAB: [xd, yd, scale]' = transMatrix * [c,r,1]'
                    xd =    transMatrixData[0][0] * oc + transMatrixData[0][1] * or + transMatrixData[0][2];
                    yd =    transMatrixData[1][0] * oc + transMatrixData[1][1] * or + transMatrixData[1][2];
                    scale = transMatrixData[2][0] * oc + transMatrixData[2][1] * or + transMatrixData[2][2];
                    //normalization
                    xd /= scale;
                    yd /= scale;

                    //find four neighbor pixel
                    c1 = (int)Math.Floor(xd);
                    c2 = c1 + 1;
                    r1 = (int)Math.Floor(yd);
                    r2 = r1 + 1;
                    //care for borders
                    if (c1 >= 0 && c2 < image.Width && r1 >= 0 && r2 < image.Height)
                    {
                        for (int d = 0; d < 3; d++)
                        {
                            //bilinear interpolation
                            p = image.Data[r1, c1, d] + (yd - r1) * (image.Data[r2, c1, d] - image.Data[r1, c1, d]);
                            q = image.Data[r1, c2, d] + (yd - r1) * (image.Data[r2, c2, d] - image.Data[r1, c2, d]);
                            g = p + (xd - c1) * (q - p);
                            destination.Data[r, c, d] = (byte)Math.Round(g);
                        }
                    }
               }
        }

		/// <summary>
        /// Diese Funktion transformiert ein Rechteck anhand einer 3x3-Matrix und gibt eine Axisaligned Boundingbox um das Ergebnisviereck zurück
        /// </summary>
        /// <param name="rect">Eingaberechteck</param>
        /// <param name="matrix">Transformationsmatrix</param>
        /// <returns>Axisaligned Boundingbox um das transformierte Rechteck</returns>
		private Rectangle transformPerspectiveBoundingBox(Rectangle rect, double[,] matrix)
		{
			//Eckpunkte des Rechtecks zwischenspeichern
			PointF[] P = new PointF[4]
			{ 
				new PointF(rect.Left, rect.Top),
				new PointF(rect.Right, rect.Top),
				new PointF(rect.Left, rect.Bottom),
				new PointF(rect.Right, rect.Bottom)
			};
			
			//Platz für die transformierten Eckpunkte
			PointF[] tP = new PointF[4];
			
			//Jeden Eckpunkt transformieren und in tP speichern
			for(int i = 0; i < 4; i++)
			{
				float scale = (float)(matrix[2, 0] * P[i].X + matrix[2, 1] * P[i].Y + matrix[2, 2]);
				tP[i] = new PointF(
					(float)(matrix[0, 0] * P[i].X + matrix[0, 1] * P[i].Y + matrix[0, 2]) / scale,
                	(float)(matrix[1, 0] * P[i].X + matrix[1, 1] * P[i].Y + matrix[1, 2]) / scale);
			}
			
			//Minima und Maxima für die Boundingbox bestimmen
			int minX = (int)Math.Floor(Math.Min(Math.Min(tP[0].X, tP[1].X), Math.Min(tP[2].X, tP[3].X)));
			int maxX = (int)Math.Ceiling(Math.Max(Math.Max(tP[0].X, tP[1].X), Math.Max(tP[2].X, tP[3].X)));
			int minY = (int)Math.Floor(Math.Min(Math.Min(tP[0].Y, tP[1].Y), Math.Min(tP[2].Y, tP[3].Y)));
			int maxY = (int)Math.Ceiling(Math.Max(Math.Max(tP[0].Y, tP[1].Y), Math.Max(tP[2].Y, tP[3].Y)));
	
			//Boundingbox zurückgeben
			return new Rectangle(minX, minY, maxX - minX, maxY - minY);
		}

        /// <summary>
        /// Beinhaltet die eigentliche Transformation. Benutzt zum Transformieren eure Implementierung von
        /// transformPerspectiveBL aus P1. Kommentiert ausführlich, nach welchem Mechanismus ihr
        /// die Bilder überblendet
        /// </summary>
        /// <param name="imageL">Das linke Bild</param>
        /// <param name="imageR">Das rechte Bild</param>
        /// <param name="H">Die Transformation zwischen linkem und rechtem Bild</param>
        /// <returns>Das fertige Panoama</returns>
        public override Image<Bgr, byte> blend(Image<Bgr, byte> imageL, Image<Bgr, byte> imageR, double[,] H)
        {
			//Berechnen, wie groß ein neues Image sein muss, um ein mit H transformiertes imageR zu speichern (Boundingbox)
			Rectangle rect = transformPerspectiveBoundingBox(new Rectangle(new Point(0, 0), imageR.Size) , H);

			//Neues Image erzeugen, in das imageL und ein transformiertes imageR reinpassen
			Image<Bgr, byte> both = new Image<Bgr, byte>(
				Math.Max(imageL.Width, rect.Right),
			    Math.Max(imageL.Height, rect.Height)
			);
			
			//Spalte, ab der die beiden Bilder sich überlappen
			int overlapStart = rect.Left;
			//Anzahl an überlappenden Spalten
			int overlapWidth = imageL.Width - overlapStart;
			//rect.Top ist je nach Transformation möglicherweise negativ
			//ist das der fall, muss imageL um yOffset tiefer in both stehen
			int yOffset = Math.Max(0, -rect.Top);
			
			//imageR mit H transformieren, dabei mit dem offset sicherstellen, dass das ganze transformierte Ergebnis im Zielimage "both" steht
			transformPerspectiveBL(both, new Point(0, yOffset), imageR, H);
			
			//Pixel-Farben-Differenzen im Überlappenden bereich (für Fading)
			sbyte[,,] rgbdiffs = new sbyte[imageL.Height, overlapWidth, 3];
			//summed squares der Pixel-Farben-Differenzen (zur Konturfindung, ab der in das rechte Bild gefaded wird)
			ushort[,] diffs = new ushort[imageL.Height, overlapWidth];
			//Berechnung dieser Werte
			for(int y = 0; y < imageL.Height; y++)
				for(int x = 0; x < overlapWidth; x++)
					for(int d = 0; d < 3; d++)
					{
						int diff = imageL.Data[y, x + overlapStart, d] - both.Data[y + yOffset, x + overlapStart, d];
						rgbdiffs[y, x, d] = (sbyte)(diff);
						diffs[y, x] += (ushort)(diff * diff);
					}
		
			//Exponential moving average für einen flüssigen Kantenverlauf von oben nach unten
			float emaX = 0;
			
			for(int y = 0; y < imageL.Height; y++)
			{
				//Variable für Spaltennummer mit kleinster Pixel-Farben-Differenz
				int minX = 0;
				//Variable für kleinsten gefundenen Pixel-Farb-Differenz-Wert
				ushort minDiff = ushort.MaxValue;
				//Variable für durchschnittliche Pixel-Farb-Differenz in dieser Zeile
				float diffAverage = 0;				
				
				for(int x = 0; x < overlapWidth; x++)
				{
					//Pixel-Farb-Differenz aufsummieren
					diffAverage += diffs[y, x];
					//kleinsten Pixel-Farb-Differenz-Wert suchen
					if(diffs[y, x] < minDiff)
					{
						minX = x;
						minDiff = diffs[y, x];
					}
				}
				//Durchschnitt bilden
				diffAverage /= overlapWidth;
				//daraus die Breite des Fading-Übergangs herleiten, denn:
				
				//ist die durchschnittliche Pixel-Farb-Differenz der Zeile eher klein, 
				//ist es wahrscheinlich, dass man sich auf keiner sehr kontrastreichen Zeile befindet
				//auf solchen Zeilen sieht es besser aus, wenn man über längere Strecken faded (z.B. Himmel)

				//ist die durchschnittliche Pixel-Farb-Differenz der Zeile eher groß,
				//ist die Zeile meist Kontrastreicher. In solchen Zeilen fällt es weniger auf,
				//wenn man schnell in das andere Bild zur Ausgabe wechselt
				float fadeDiameter = 100000.0f/diffAverage;
				
				//In der ersten Zeile den Exponential moving average mit dem hier besten Übergangspunkt initialisieren
				if(y == 0) emaX = minX;
				//Exponential moving average mit der besten Übergangsspalte dieser Zeile verrechnen
				//und anschließend so clampen, dass man auf dem Überlappungsbereich noch Platz für das Faden hat
				//( 1px Sicherheitsabstand zu den Rändern ;) )
				emaX = clamp(emaX * 0.9f + minX * 0.1f, fadeDiameter/2 + 1.0f, overlapWidth - fadeDiameter/2 - 1.0f);

				//Pixel dieser Zeile schreiben:
				for(int x = 0; x < imageL.Width; x++)
				{
					if(x > overlapStart)
					{
						//Auf dem Überlappenden Bereich, also
						//Farbdifferenzen zum Pixel des anderen Bildes an dieser stelle holen
						float b = rgbdiffs[y, x - overlapStart, 0], g = rgbdiffs[y, x - overlapStart, 1], r = rgbdiffs[y, x - overlapStart, 2];
						//Lokale Spaltennummer (relativ zum Fading-Anfang)
						float localX = x - overlapStart - emaX + fadeDiameter/2.0f;
						//linearer Fading-Faktor im Bereich 0..1 (0:Pixel des linken Bildes, 1:Pixel des rechten Bildes)
						float f = clamp(localX / fadeDiameter, 0.0f, 1.0f);
						//Fading mit den Differenzen zum anderen Bildpixel
						b *= f; g *= f; r *= f;
						both.Data[y + yOffset, x, 0] = (byte)(imageL.Data[y, x, 0] - b);
						both.Data[y + yOffset, x, 1] = (byte)(imageL.Data[y, x, 1] - g);
						both.Data[y + yOffset, x, 2] = (byte)(imageL.Data[y, x, 2] - r);
					}else{
						//Außerhalb des Überlappenden Bereichs, also
						//Pixel des linken Bildes komplett übernehmen.
						both.Data[y + yOffset, x, 0] = imageL.Data[y, x, 0];
						both.Data[y + yOffset, x, 1] = imageL.Data[y, x, 1];
						both.Data[y + yOffset, x, 2] = imageL.Data[y, x, 2];
					}
				}
			}

			//Endergebnis zurückgeben
			return both;
        }
		
		private const int patchsize = 2;

        /// <summary>
        /// Eure Implementierung der Funktion aus P3. Wird nicht korrigiert.
        /// </summary>
        /// <param name="image"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public override PointF[] findFeaturePoints(Image<Bgr, byte> image, double a)
        {
			
            //zu Graubild konvertieren
			Image<Gray, byte> grayimage = image.Convert<Gray, byte>();

			List<PointF> points = new List<PointF>(); //Liste der FeaturePoints
			float[,,] d = new float[grayimage.Height, grayimage.Width, 2]; //partielle Ableitungen (nach x und y) für jeden Pixel. Schema: d[row, column, {x=0 or y=1}]

            //partielle Ableitungen für jeden Pixel bestimmen mit diskretene Werten in einer patchsize-Umgebung um den jeweiligen Pixel
            //patchsize-Umgebung meint hierbei ein Intervall [p.X-patchsize, p.X+patchsize] für die Ableitung nach x und entsprechend [p.Y-patchsize, p.Y+patchsize] für y für alle Pixel p
            //Der Rand des Bildes (Randsträke = patchsize) wird dabei ausgelassen
			for(int r = patchsize; r < grayimage.Height - patchsize; r++)
			{
				for(int c = patchsize; c < grayimage.Width - patchsize; c++)
				{
					float fx = 0, fy = 0;
                    //Alle Pixel in der patchsize-Umgebung
					for(int i = -patchsize; i <= patchsize; i++)
					{
						if(i == 0) continue; //Den Pixel selbst auslassen
						fy += (float)(image.Data[r+i, c, 0] - image.Data[r, c, 0])/(float)i;
						fx += (float)(image.Data[r, c+i, 0] - image.Data[r, c, 0])/(float)i;
					}
                    //Die errechneten Ableitungen abspeichern
					d[r, c, 0] = fx;
					d[r, c, 1] = fy;
				}
			}

			float[,] R = new float[grayimage.Height, grayimage.Width]; //Scalar interest measures (nach Harris) für jeden Pixel
			double mean = 0; //Durchschnitt aller scalar interest measures (SIM)
			for(int r = patchsize; r < grayimage.Height - patchsize; r++)
			{
				for(int c = patchsize; c < grayimage.Width - patchsize; c++)
				{
                    // Die Einträge der Matrix M. M01 = M10, deshab nur einmal gespeichert.
                    //Aus Performance-Gründen wird nicht die Klasse Matrix verwendet
					float M00 = 0, M01 = 0, M11 = 0; 
                    //Als Nachbarschaft, wähle eine patchsize*patchsize-Nachbarschaft um den aktuellen Pixel
					for(int nr = -patchsize; nr <= patchsize; nr++)
					{
						for(int nc = -patchsize; nc <= patchsize; nc++)
						{
                            //Berechnung der Matrix-Einträge nach Vorlesung
							float fx = d[r+nr, c+nc, 0];
							float fy = d[r+nr, c+nc, 1];
							M00 += fx*fx;
							M11 += fy*fy;
							M01 += fy*fx;
						}
					}
                    //Berechnung des SIM
					float trace = M00 + M11; //Spur der Matrix M
					R[r, c] = M00*M11 - M01*M01 - (float)a*trace*trace; //= det(M) - a * spur(M)^2
					mean += R[r, c]; //Aufsummieren aller SIM
				}
			}
            //Teilen durch Anzahl der Pixel (dies ist nicht der genaue Durchschnittswert, da der Rand des Bildes nicht berücksichtigt wird, aber praktisch gesehen ein guter Schwellenwert für Feature Points)
            mean /= (grayimage.Height-patchsize*2) * (grayimage.Width-patchsize*2); 
			
            //Diejenigen Pixel als FeaturePoints deklarieren, die über dem Schwellenwert (=mean) liegen und die ein lokales Maximum in ihrer patchsize*patchsize-Nachbarschaft darstellen
			for(int r = patchsize; r < grayimage.Height - patchsize; r++)
			{
				for(int c = patchsize; c < grayimage.Width - patchsize; c++)
				{
					if(R[r, c] > mean)
					{
                        bool peak = true;
						for(int nr = -patchsize; nr <= patchsize; nr++)
						{
							for(int nc = -patchsize; nc <= patchsize; nc++)
							{
								if(R[r+nr, c+nc] > R[r, c]) //Für alle Pixel der Nachbarschaft prüfen, ob sie größeren SIM haben als der aktuelle Pixel. Ist dies der Fall, so ist der aktuelle Pixel kein lokales Maximum und daher auch kein Feature Point
									peak = false;
							}
						}
                        if (peak) 
						    points.Add(new PointF(c, r));
					}
				}
			}
            //Die Liste der Feature Points als Array konvertiert zurückgeben
            return points.ToArray();
        }
		
		// Eine einfache clampfunktion, um Bildkoordinaten an den Rändern an ihre Kanten zu clampen
		private int clamp(int v, int min, int max)
		{
			return Math.Min(max, Math.Max(min, v));
		}
		
		// Eine einfache clampfunktion, um Bildkoordinaten an den Rändern an ihre Kanten zu clampen
		private float clamp(float v, float min, float max)
		{
			return Math.Min(max, Math.Max(min, v));
		}

        /// <summary>
        /// Eure Implementierung der Funktion aus P3. Wird nicht korrigiert.
        /// </summary>
        /// <param name="image"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public override Match[] findCorrespondences(Image<Bgr, byte> refImage, Image<Bgr, byte> tarImage, System.Drawing.PointF[] refFeatures, System.Drawing.PointF[] tarFeatures, int searchRange, int k)
        {
			// Listen für Zwischenergebnisse
			List<Match> matches = new List<Match>();
			List<float> distances = new List<float>();
			
			// Die Suchentfernung von der Mitte ist nurnoch halb so groß...
			float searchRadius = searchRange/2.0f;
			
			int rw = refImage.Width - 1, rh = refImage.Height - 1;
			int tw = tarImage.Width - 1, th = tarImage.Height - 1;
			
			double threshold = k * k * 1024.0f;
			
			// Für jeden Referenzpunkt...
			foreach(var refP in refFeatures)
			{
				// Variable für den momentan kleinsten gefundenen SSD-Pixel-"Abstand"
				double minDifference = double.MaxValue;
				// variable für den momentan besten gefundenen Korrespondenten Punkt
				PointF best = tarFeatures[0];
				
				// Für jeden Targetpunkt
				foreach(var tarP in tarFeatures)
				{
					// Prüfe, ob sich dieser Targetpunkt in der searchRange befindet
					// Hier wird ausgenutzt, dass die Punkte der höhe nach abgespeichert wurden
					if(tarP.Y < refP.Y - searchRadius)
						continue;
					if(tarP.Y > refP.Y + searchRadius)
						break;
					
					// Der aktuelle SSD-"Abstand" der Nachbarschaft
					double sumDifference = 0;
					
					// Für die k-Nachbarschaft vom ref- und tar-Punkt:
					for(int c = -k; c <= k; c+=2)
					{
						// momentane Pixelkoordinaten berechnen:
						int rcol = clamp((int)refP.X+c, 0, rw);
						int tcol = clamp((int)tarP.X+c, 0, tw);
						for(int r = -k; r <= k; r+=2)
						{
							// momentane Pixelkoordinaten berechnen:
							int rrow = clamp((int)refP.Y+r, 0, rh);
							int trow = clamp((int)tarP.Y+r, 0, th);
							
							// beide Pixel holen:
							byte rb = refImage.Data[rrow, rcol, 0];
							byte rg = refImage.Data[rrow, rcol, 1];
							byte rr = refImage.Data[rrow, rcol, 2];
									
							byte tb = tarImage.Data[trow, tcol, 0];
							byte tg = tarImage.Data[trow, tcol, 1];
							byte tr = tarImage.Data[trow, tcol, 2];
							
							// SSD-"Abstand" der aktuellen Pixel berechnen:
							sumDifference += (tb-rb)*(tb-rb) + (tg-rg)*(tg-rg) + (tr-rr)*(tr-rr);
						}
					}
					
					// Ist dieser Abstand kleiner/besser?
					if(sumDifference < minDifference)
					{
						// Die besten Ergebnisse aktualisieren:
						minDifference = sumDifference;
						best = tarP;
					}
				}
				
				// Ist dieser Abstand besser als ein Threshold (, der von k abhängt)?
				if(minDifference < threshold)
				{
					// Dann diesen Match zu der Ergebnisliste hinzufügen
					var m = new Match(refP, best);
					matches.Add(m);
					// Und einen Abstand zwischen den Punkten berechnen, um nachher Ausreißer rauszunehmen
					distances.Add((m.p1.X-m.p2.X) * (m.p1.X-m.p2.X) + (m.p1.Y-m.p2.Y) * (m.p1.Y-m.p2.Y));
				}
			}
			
			// Wir haben keine potenziellen Korrespondenzen gefunden
			if(distances.Count == 0)
				return new Match[0];
			
			// Medianberechnung
			List<float> sortedDistances = new List<float>(distances);
			sortedDistances.Sort();
			float distanceMedian = sortedDistances[distances.Count/2];
			
			// Matches, die eine Entfernung haben, die um den Median liegt,
			// (in Abhängigkeit von searchRange) zusammensuchen
			List<Match> finalmatches = new List<Match>();
			for(int i = 0; i < matches.Count; i++)
				if(Math.Abs(distances[i]-distanceMedian) < searchRange * 64.0f)
					finalmatches.Add(matches[i]);

			// Endgültige Funde zurückgeben
			return finalmatches.ToArray();
        }
    }
}
