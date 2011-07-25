﻿using System;
using System.Drawing;
using Emgu.CV;
using Emgu.CV.Structure;

namespace SS11P04ImageStitching
{
    public abstract class SS11P04IS_Aufgabe
    {

        /// <summary>
        /// Berechnet aus imageL und imageR ein Panorama
        /// </summary>
        /// <param name="imageL">Das linke Bild</param>
        /// <param name="imageR">Das rechte Bild</param>
        /// <param name="a">Der Parameter des findFeaturePoints(..) zugrundeliegenden scalar interest measures</param>
        /// <param name="searchRange">Der Suchabschnitt für findCorrespondences(..)</param>
        /// <param name="k">Nachbarschaftsgröße für findCorrespondences(..)</param>
        /// <returns>Das fertige Panorama</returns>
        public Image<Bgr, byte> computePanorama(
            Image<Bgr, byte> imageL, 
            Image<Bgr, byte> imageR,
            double a,
            int searchRange,
            int k,
            int ransacSteps,
            double ransacThresh)
        {
            //Featurepunkte finden
            PointF[] featuresL = findFeaturePoints(imageL, a);
            PointF[] featuresR = findFeaturePoints(imageR, a);
            //Korrespondenzen finden
            Match[] correspondences = findCorrespondences(
                imageL,
                imageR,
                featuresL,
                featuresR,
                searchRange,
                k);
            //Homographie finden
            double[,] homography = ransacH(imageL, imageR, correspondences, ransacSteps, ransacThresh);
            //Blending und Warping
            return blend(imageL, imageR, homography);            
        }

        /// <summary>
        /// Findet in den korrespondierenden Punktepaaren correspondences eine Homographie
        /// </summary>
        /// <param name="imageL">Das linke Bild</param>
        /// <param name="imageR">Das rechte Bild</param>
        /// <param name="correspondences">Menge von korrespondierenden Punktepaaren</param>
        /// <returns>Homographiematrix, die die Transformation zwischen linkem und rechtem Bild beschreibt</returns>
        public abstract double[,] ransacH(
            Image<Bgr, byte> imageL, 
            Image<Bgr, byte> imageR, 
            Match[] correspondences, 
            int ransacSteps, 
            double ransacThresh);


        /// <summary>
        /// Beinhaltet die eigentliche Transformation. Benutzt zum Transformieren eure Implementierung von
        /// transformPerspectiveBL aus P1. Kommentiert ausführlich, nach welchem Mechanismus ihr
        /// die Bilder überblendet
        /// </summary>
        /// <param name="imageL">Das linke Bild</param>
        /// <param name="imageR">Das rechte Bild</param>
        /// <param name="H">Die Transformation zwischen linkem und rechtem Bild</param>
        /// <returns>Das fertige Panoama</returns>
        public abstract Image<Bgr, byte> blend(
            Image<Bgr, byte> imageL,
            Image<Bgr, byte> imageR,
            double[,] H);


        /// <summary>
        /// Eure Implementierung der Funktion aus P3. Wird nicht korrigiert.
        /// </summary>
        /// <param name="image"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public abstract PointF[] findFeaturePoints(Image<Bgr, byte> image, double a);


        /// <summary>
        /// Eure Implementierung der Funktion aus P3. Wird nicht korrigiert.
        /// </summary>
        /// <param name="image"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public abstract Match[] findCorrespondences(
            Image<Bgr, byte> refImage,
            Image<Bgr, byte> tarImage,
            PointF[] refFeatures,
            PointF[] tarFeatures,
            int searchRange,
            int k
            );

        //-----Verwaltungssachen

        //Namen der Autoren
        protected String[] authors;
        //Matrikelnummern der Autoren
        protected int[] matrikelNummern;
        //Benutztes Betriebssystem
        protected OS OS;

        //Die ToString()-Methode wird überschrieben, damit in der Combobox die Namen der Autoren auftauchen
        public override string ToString()
        {
            String groupID = "";
            for (int i = 0; i < authors.Length; i++)
                groupID += authors[i] + " (" + matrikelNummern[i].ToString() + ") - ";
            return groupID + OS.ToString();
        }
    }

    /// <summary>
    /// Ein Match speichert zwei korrespondierende Punkte
    /// </summary>
    public struct Match
    {
        /// <summary>
        /// Source point
        /// </summary>
        public PointF p1;
        /// <summary>
        /// Target point
        /// </summary>
        public PointF p2;

        public Match(PointF p1, PointF p2)
        {
            this.p1 = p1;
            this.p2 = p2;
        }
    }

    /// <summary>
    /// Von euch zur Programmierung verwendetes Betriebssystem
    /// </summary>
    public enum OS
    {
        Windows, Linux, Mac
    }

}
