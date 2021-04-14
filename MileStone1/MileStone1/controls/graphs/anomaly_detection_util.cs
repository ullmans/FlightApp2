using System;
using System.Windows;
using System.Windows.Shapes;
using System.Windows.Media;
using ex1Exam2;

/**
 * the function from the first ex
 */
namespace detection {
	public class anomaly_detection_util {

		public static float avg(float[] x, int size)
		{
			float sum = 0;
			for (int i = 0; i < size; sum += x[i], i++) ;
			return (float)(sum / size);
		}

		// returns the variance of X and Y
		public static float var(float[] x, int size)
		{
			float av = avg(x, size);
			float sum = 0;
			for (int i = 0; i < size; i++)
			{
				sum += x[i] * x[i];
			}
			return (float)(sum / size - av * av);
		}

		// returns the covariance of X and Y
		public static float cov(float[] x, float[] y, int size)
		{
			float sum = 0;
			for (int i = 0; i < size; i++)
			{
				sum += x[i] * y[i];
			}
			sum /= size;

			return (float)(sum - avg(x, size) * avg(y, size));
		}


		// returns the Pearson correlation coefficient of X and Y
		public static float pearson(float[] x, float[] y, int size)
		{
			return (float)cov(x, y, size) / (float)(Math.Sqrt(var(x, size)) * Math.Sqrt(var(y, size)));
		}

		// performs a linear regression and returns the line equation
		public static Line linear_reg(Point[] points, int size)
		{
			float[] x = new float[size];
			float[] y = new float[size];
			for (int i = 0; i < size; i++)
			{
				x[i] = (float)points[i].X;
				y[i] = (float)points[i].Y;
			}
			float a = cov(x, y, size) / var(x, size);
			float b = avg(y, size) - a * (avg(x, size));

			Line linearl = new Line();
			linearl.X1 = points[0].X;
			linearl.Y1 = a * points[0].X + b;
			linearl.X2 = points[size - 1].X;
			linearl.Y2 = a * points[size-1].X + b;
			return linearl;
		}

		// returns the deviation between point p and the line equation of the points
		public static float dev(Point p, Point[] points, int size)
		{
			Line l = linear_reg(points, size);
			return dev(p, l);
		}

		// returns the deviation between point p and the line
		public static float dev(Point p, Line l)
		{
			float a = (float)((l.Y1 - l.Y2) / (l.X1 - l.X2));
			float b = (float)(a * l.X1 - l.Y1);
			float x = (float)(p.Y - a * (p.X) + b);
			if (x < 0)
				x *= -1;
			return x;
		}
	}
}
