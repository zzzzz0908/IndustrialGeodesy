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
    }
}
