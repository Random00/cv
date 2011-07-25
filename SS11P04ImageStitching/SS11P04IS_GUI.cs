using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.Structure;
using System.Threading;

namespace SS11P04ImageStitching
{
    public partial class SS11P04IS_GUI : Form
    {

        private Image<Bgr, byte> imageL, imageR;
        private PointF[] featuresL, featuresR;
        private Match[] correspondences;

        public SS11P04IS_GUI()
        {
            //Lädt GUI
            InitializeComponent();

            //Lädt Abgaben in Combo-Box
            List<SS11P04IS_Aufgabe> loesungen = new List<SS11P04IS_Aufgabe>();
            loesungen.Add(new SS11P04IS_Loesung());
			
			imageL = new Image<Bgr, byte>("../../../imageL.jpg");
			imageR = new Image<Bgr, byte>("../../../imageR.jpg");
			imageBoxLeftImage.Image = imageL;
			imageBoxRightImage.Image = imageR;

            comboBox1.Items.AddRange(loesungen.ToArray());
            comboBox1.SelectedIndex = 0;
        }

        /// <summary>
        /// Lädt linkes Bild
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void loadLeftImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                imageL = new Image<Bgr, byte>(openFileDialog1.FileName);
                imageBoxLeftImage.Image = imageL;
            }
        }

        /// <summary>
        /// Lädt rechtes Bild
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void loadRightImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                imageR = new Image<Bgr, byte>(openFileDialog1.FileName);
                imageBoxRightImage.Image = imageR;
            }
        }


        /// <summary>
        /// Findet Feature-Punkte in beiden Bildern und zeigt sie an
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonFindFeatures_Click(object sender, EventArgs e)
        {
            if (imageL != null && imageR != null)
            {
                double a = Convert.ToDouble(numericUpDownA.Value);
                //Methode wählen
                SS11P04IS_Aufgabe loesung = (SS11P04IS_Aufgabe)comboBox1.SelectedItem;
				
                //Featurepunkte finden
				//Feature-Punkte in refImage und tarImage zeichnen
				Image<Bgr, byte> imageLFP = null, imageRFP = null;
				
				var threadL = new Thread(x =>
				{
					featuresL = loesung.findFeaturePoints(imageL, a);
					imageLFP = imageL.Clone();
                	foreach (var point in featuresL)
                	    imageLFP.Draw(new Cross2DF(point, 2, 2), new Bgr(255, 255, 255), 1);
				});
                threadL.Start();
                featuresR = loesung.findFeaturePoints(imageR, a);
                imageRFP = imageR.Clone();
                foreach (var point in featuresR)
                    imageRFP.Draw(new Cross2DF(point, 2, 2), new Bgr(255, 255, 255), 1);
				
				threadL.Join();
				
                //Bilder anzeigen
                imageBoxLeftImage.Image = imageLFP;
                imageBoxRightImage.Image = imageRFP;

                buttonFindCorrespondences.Enabled = true;
            }
        }


        /// <summary>
        /// Findet korrespondierende Featurepunkte in den Bildern und zeigt sie an
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonFindCorrespondences_Click(object sender, EventArgs e)
        {
            //nur was tun, wenn beide Bilder geladen sind
            if (imageL != null && imageR != null)
            {
                //nur was tun, wenn Feature-Punkte schon berechnet
                if (featuresL != null && featuresR != null)
                {
                    //Methode wählen
                    SS11P04IS_Aufgabe loesung = (SS11P04IS_Aufgabe)comboBox1.SelectedItem;
                    int searchRange = Convert.ToInt32(numericUpDownSearchRange.Value);
                    int k = Convert.ToInt32(numericUpDownK.Value);
                    //Matches finden
                    correspondences = loesung.findCorrespondences(imageL, imageR, featuresL, featuresR, searchRange, k);
                    //Korrespondierende Puntke mit einer Linie verbinden
                    Image<Bgr, byte> corImage = imageL.ConcateHorizontal(imageR);
                    int width = imageL.Width;
                    foreach (var match in correspondences)
                        //PointF grob in Point umwandeln (nur zu Anzeigezwecken)
                        corImage.Draw(new LineSegment2D(
                            Point.Truncate(match.p1),
                            new Point((int)match.p2.X + width, (int)match.p2.Y)),
                            new Bgr(255, 255, 255), 1);
                    //Korrespondenzbild anzeigen
                    imageBoxPanorama.Image = corImage;
                    groupBoxPanoramaImage.Text = "Correspondences";
                    buttonFindHomography.Enabled = true;
                }
            }
        }


        /// <summary>
        /// Berechnet aus den Korrespondenzen eine Homographiematrix und zeigt sie an
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonFindHomography_Click(object sender, EventArgs e)
        {
            if (imageL != null && imageR != null && correspondences != null)
            {
                //Methode wählen
                SS11P04IS_Aufgabe loesung = (SS11P04IS_Aufgabe)comboBox1.SelectedItem;
                //Parameter aus GUI lesen
                int ransacSteps = Convert.ToInt32(numericUpDownRansacSteps.Value);
                double ransacThresh = Convert.ToDouble(numericUpDownRansacThresh.Value);
                //Homographie berechnen
                double[,] homography = loesung.ransacH(imageL, imageR, correspondences, ransacSteps, ransacThresh);
                //Homorgraphie anzeigen
                textBox1.Text = homography[0, 0].ToString();
                textBox2.Text = homography[0, 1].ToString();
                textBox3.Text = homography[0, 2].ToString();
                textBox4.Text = homography[1, 0].ToString();
                textBox5.Text = homography[1, 1].ToString();
                textBox6.Text = homography[1, 2].ToString();
                textBox7.Text = homography[2, 0].ToString();
                textBox8.Text = homography[2, 1].ToString();
                textBox9.Text = homography[2, 2].ToString();
                buttonTransformPlusBlend.Enabled = true;
            }
        }

        /// <summary>
        /// Führt das eigentliche Warping und Blending durch
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonTransformPlusBlend_Click(object sender, EventArgs e)
        {
            //Nur was tun, wenn Bilder geladen sind
            if (imageL != null && imageR != null)
            {
                //Methode wählen
                SS11P04IS_Aufgabe loesung = (SS11P04IS_Aufgabe)comboBox1.SelectedItem;
                double[,] homography = new double[3, 3];
                //Homographie aus GUI lesen
                homography[0, 0] = Convert.ToDouble(textBox1.Text);
                homography[0, 1] = Convert.ToDouble(textBox2.Text);
                homography[0, 2] = Convert.ToDouble(textBox3.Text);
                homography[1, 0] = Convert.ToDouble(textBox4.Text);
                homography[1, 1] = Convert.ToDouble(textBox5.Text);
                homography[1, 2] = Convert.ToDouble(textBox6.Text);
                homography[2, 0] = Convert.ToDouble(textBox7.Text);
                homography[2, 1] = Convert.ToDouble(textBox8.Text);
                homography[2, 2] = Convert.ToDouble(textBox9.Text);
                imageBoxPanorama.Image = loesung.blend(imageL, imageR, homography);
            }
        }

        /// <summary>
        /// All-in-one Lösung
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonComputePanorama_Click(object sender, EventArgs e)
        {
            //Nur was tun, wenn Bilder geladen sind
            if (imageL != null && imageR != null)
            {
                //Methode wählen
                SS11P04IS_Aufgabe loesung = (SS11P04IS_Aufgabe)comboBox1.SelectedItem;
                //Parameter lesen
                double a = Convert.ToDouble(numericUpDownA.Value);
                int searchRange = Convert.ToInt32(numericUpDownSearchRange.Value);
                int k = Convert.ToInt32(numericUpDownK.Value);
                int steps = Convert.ToInt32(numericUpDownRansacSteps.Value);
                double thresh = Convert.ToDouble(numericUpDownRansacThresh.Value);
                //Panorama erzeugen
                imageBoxPanorama.Image = loesung.computePanorama(imageL, imageR, a, searchRange, k, steps, thresh);
            }
        }

    }
}
