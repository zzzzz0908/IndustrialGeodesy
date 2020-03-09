using MathNet.Numerics.LinearAlgebra;
using System;
using System.Collections.Generic;
using System.Text;

namespace IndustrialGeodesy.Math
{
    public class Plane
    {
        /// <summary>
        /// The unit normal vector of the plane.
        /// </summary>
        public Vector<double> UnitNormalVector { get; }

        /// <summary>
        /// The distance to the <see cref="Plane"/> along its normal from the origin.
        /// </summary>
        public double D { get; }



        public Plane(Vector<double> normal, Point3D rootPoint)
        {
            if (normal.Count != 3)
            {
                throw new ArgumentException("Размерность вектора нормали на равна 3", nameof(normal));
            }

            UnitNormalVector = normal.Normalize(2);
            D = -UnitNormalVector * rootPoint.ToVector();
        }

        public Plane(double A, double B, double C, double D)
        {
            UnitNormalVector = Vector<double>.Build.DenseOfArray(new double[] { A, B, C }).Normalize(2);
            this.D = D / System.Math.Sqrt(A * A + B * B + C * C);
        }

        public static Plane CreateFromPoints(Point3D p1, Point3D p2, Point3D p3)
        {
            double A = (p2.E - p1.E) * (p3.H - p1.H) - (p2.E - p1.E) * (p2.H - p1.H);
            double B = -(p2.N - p1.N) * (p3.H - p1.H) + (p3.N - p1.N) * (p2.H - p1.H);
            double C = (p2.N - p1.N) * (p3.E - p1.E) - (p3.N - p1.N) * (p2.E - p1.E);
            double D = A * (-p1.N) + B * (-p1.E) + C * (-p1.H);

            return new Plane(A, B, C, D);
        }
    }
}
