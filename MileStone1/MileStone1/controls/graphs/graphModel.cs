using System;
using System.Windows.Media;
using System.Windows;
using System.Windows.Controls;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Shapes;
using System.Collections.Generic;



/**
 * the model of the graph.
 * save a canvas and calculate dots
 * 
 */

public class graphModel : INotifyPropertyChanged
{

	public event PropertyChangedEventHandler PropertyChanged;
	//canvases that save the information about the view-graphs
	private Canvas linearCanvas;
	private Canvas chooseCanvas;
	private Canvas pearsonCanvas;
	//the data that have read
	private List<double[]> csv;
	private graphViewModel gvm;

	public graphModel(graphViewModel gVM, List<double[]> Csv)
	{
		this.linearCanvas = new Canvas()
		{
			Width = 400,
			Height = 287
		};
		this.chooseCanvas = new Canvas()
		{
			Width = 150,
			Height = 120
		};
		this.pearsonCanvas = new Canvas()
		{
			Width = 150,
			Height = 120
		};
		CSV = Csv;
		gvm = gVM;

	}

	public List<double[]> CSV
    {
		get
        {
			return this.csv;
        }
		set
        {
			this.csv = value;
        }
    }

	//create the dots for the chosen given-graph.
	public PointCollection chosenDots(int given)
    {
		const double margin = 10;
		double xmin = margin;
		double xmax = this.chooseCanvas.Width - margin;
		double ymax = this.chooseCanvas.Height - margin;
		double step = this.chooseCanvas.Width / this.csv[given].Length;

		// check what the max value to show good in the view
		double MAX = 0;
		for (int m = 0; m < this.csv[given].Length; m++)
        {
			if (Math.Abs(this.csv[given][m]) > MAX)
            {
				MAX = Math.Abs(this.csv[given][m]);
            }
        }

		PointCollection pc = new PointCollection();
		int i = 0;
		for (double x = xmin; x <= xmax; x += step)
		{
			pc.Add(new Point(x, (ymax / 2) * (1 - this.csv[given][i] / (MAX + 1))));

			i++;
		}

		return pc;
    }
	
	//create the dots and linear line for the chosen given-graph
	public PointCollection linearDots(int given)
	{
		const double margin = 10;
		double xmin = margin;
		double xmax = this.linearCanvas.Width - margin;
		double ymax = this.linearCanvas.Height - margin;
		double step = this.linearCanvas.Width / this.csv[given].Length;

		// check what the max value to show good in the view
		double MAX = 0;
		for (int m = 0; m < this.csv[given].Length; m++)
		{
			if (Math.Abs(this.csv[given][m]) > MAX)
			{
				MAX = Math.Abs(this.csv[given][m]);
			}
		}
		PointCollection pc = new PointCollection();
		int i = 0;
		for (double x = xmin; x <= xmax; x += step)
		{
			pc.Add(new Point(x, (ymax / 2)*(1 - this.csv[given][i]/(MAX + 1))));
			i++;
		}
		//here nee dto add the linear and send to vm
		
		Point[] linearPoints = new Point[pc.Count];
		i = 0;
		foreach (Point point in pc)
        {
			linearPoints[i] = point;
        }
		Line l = MileStone1.anomaly_detection_util.linear_reg(linearPoints, pc.Count);
		l.Y1 = (ymax / 2) * (1 - l.Y1 / (MAX + 1));
		l.Y2 = (ymax / 2) * (1 - l.Y2 / (MAX + 1));

		this.gvm.VM_linearline = l;
		

		return pc;
	}

	//create the dots of the most correlative given
	public PointCollection pearsonDots(int given)
	{
		//here need to choose which graph it should be
		const double margin = 10;
		double xmin = margin;
		double xmax = this.pearsonCanvas.Width - margin;
		double ymax = this.pearsonCanvas.Height - margin;
		double step = this.pearsonCanvas.Width / this.csv[given].Length;
		
		// check what the max value to show good in the view
		double MAX = 0;
		for (int m = 0; m < this.csv[given].Length; m++)
		{
			if (Math.Abs(this.csv[given][m]) > MAX)
			{
				MAX = Math.Abs(this.csv[given][m]);
			}
		}

		int maxIndex = 0;

		
		float[] xs = new float[this.csv[given].Length];
		float[] ys = new float[this.csv[given].Length];
		int j = 0;
		float maxP = 0;
		for (int p = 0; p < this.CSV.Count; p++) {
			int yVal = 0;
			for (double x = xmin; x <= xmax; x += step)
			{
				xs[j] = (float)x;
				ys[j] = (float)(ymax / 2 - this.csv[j][yVal]);
				yVal++;
			}
			float pe;
			pe = MileStone1.anomaly_detection_util.pearson(xs, ys, this.csv[given].Length);
			if (pe > maxP)
            {
				maxP = pe;
				maxIndex = p;
            }

		}
		

		PointCollection pc = new PointCollection();
		int i = 0;
		for (double x = xmin; x <= xmax; x += step)
		{
			pc.Add(new Point(x, (ymax / 2) * (1 - this.csv[given][i] / (MAX + 1))));

			i++;
		}
		this.gvm.Pearson = maxIndex;

		return pc;
	}
}
