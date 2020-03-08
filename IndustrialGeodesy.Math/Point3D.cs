

namespace IndustrialGeodesy.Math
{
	public struct Point3D
	{
		public double N { get; private set; }
		public double E { get; private set; }
		public double H { get; private set; }

		public Point3D(double northing, double easting, double height)
		{
			N = northing;
			E = easting;
			H = height;
		}


		public static Point3D operator +(Point3D p1, Point3D p2)
		{
			return new Point3D(p1.N + p2.N, p1.E + p2.E, p1.H + p2.H);
		}

		public static Point3D operator -(Point3D p1, Point3D p2)
		{
			return new Point3D(p1.N - p2.N, p1.E - p2.E, p1.H - p2.H);
		}


		public double[] ToArray()
		{
			return new double[] { this.N, this.E, this.H };
		}
	}
}
