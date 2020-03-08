using System;
using System.Collections.Generic;
using System.Text;

namespace IndustrialGeodesy.Math
{
    public static class Extensions
    {
        public static Point3D Centroid(this IList<Point3D> points)
        {
            int n = points.Count;

            double northing = 0;
            double easting = 0;
            double height = 0;

            for (int i = 0; i < n; i++)
            {
                northing += points[i].N;
                easting += points[i].E;
                height += points[i].H;
            }

            northing = northing / n;
            easting = easting / n;
            height = height / n;

            return new Point3D(northing, easting, height);
        }
    }
}
