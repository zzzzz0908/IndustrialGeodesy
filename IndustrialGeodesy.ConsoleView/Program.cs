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

            var center = points.Centroid();

            //points.ForEach(i => i -= center);

            int n = points.Count;
            Matrix<double> X = Matrix<double>.Build.Dense(n, 3);

            for (int i = 0; i < n; i++)
            {
                points[i] -= center;
                X.SetRow(i, points[i].ToArray());
            }

            var svd = X.Svd();

            Console.WriteLine(svd.VT.Row(2));
        }
    }
}
