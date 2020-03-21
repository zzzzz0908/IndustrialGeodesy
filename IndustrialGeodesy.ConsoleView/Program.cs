using IndustrialGeodesy.Math;
using MathNet.Numerics.LinearAlgebra;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace IndustrialGeodesy.ConsoleView
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Point3D> points = new List<Point3D>(25);

            string path = @"E:\Учеба\НИРС магистратура\Плоскость\test.txt";

            string[] input = File.ReadAllLines(path);

            foreach (string i in input)
            {
                double[] coords = Array.ConvertAll(i.Split(' '), temp => Convert.ToDouble(temp, CultureInfo.InvariantCulture));
                points.Add(new Point3D(coords[0], coords[1], coords[2]));
            }

            Point3D center = points.Centroid();

            //points.ForEach(i => i -= center);

            int n = points.Count;
            Matrix<double> X = Matrix<double>.Build.Dense(n, 3);

            Point3D[] points2 = new Point3D[points.Count];

            for (int i = 0; i < n; i++)
            {
                //points[i] -= center;
                points2[i] = points[i] - center;
                X.SetRow(i, points2[i].ToArray());
            }

            var svd = X.Svd();

            Console.WriteLine(svd.VT.Row(2));

            Console.WriteLine(svd.U.ToString());
            Console.WriteLine(svd.S.ToString());
            Console.WriteLine(svd.VT.ToString());

            //Plane plane = new Plane(1, 1, 1, -3);

            //Plane plane2 = new Plane(Vector<double>.Build.DenseOfArray(new double[] { 1, 1, 1 }), new Point3D(1, 1, 1));

            Plane plane = new Plane(svd.VT.Row(2), center);

            foreach (Point3D point in points)
            {
                Console.WriteLine(plane.DistanceTo(point).ToString("0.00"));
            }
        
        }
    }
}
