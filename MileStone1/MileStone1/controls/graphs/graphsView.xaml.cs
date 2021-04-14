using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MileStone1.controls.graphs
{
    /// <summary>
    /// Interaction logic for graphsView.xaml
    /// </summary>
    public partial class graphsView : UserControl
    {
        private string[] buttonsNames = new string[] {"aileron", "elevator", "rudder", "flaps", "slats",
            "speedbrake", "throttle", "throttle", "engine-pump", "engine-pump", "electric-pump",
            "electric-pump", "external-power", "APU-generator", "latitude-deg", "longitude-deg",
            "altitude-ft", "roll-deg", "pitch-deg", "heading-deg", "side-slip-deg", "airspeed-kt",
            "glideslope", "vertical-speed-fps", "airspeed-indicator_indicated-speed-kt",
            "altimeter_indicated-altitude-ft", "altimeter_pressure-alt-ft",
            "attitude-indicator_indicated-pitch-deg", "attitude-indicator_indicated-roll-deg",
            "attitude-indicator_internal-pitch-deg", "attitude-indicator_internal-roll-deg",
            "encoder_indicated-altitude-ft", "encoder_pressure-alt-ft",
            "gps_indicated-altitude-ft", "gps_indicated-ground-speed-kt", "gps_indicated-vertical-speed",
            "indicated-heading-deg", "magnetic-compass_indicated-heading-deg",
            "slip-skid-ball_indicated-slip-skid", "turn-indicator_indicated-turn-rate",
            "vertical-speed-indicator_indicated-speed-fpm", "engine_rpm"};
        private graphViewModel dviewmodel;
        //the points in graphs
        private PointCollection chosenPoints = new PointCollection();
        private PointCollection pearsonPoints = new PointCollection();
        private PointCollection linearPoints = new PointCollection();
        //linear line
        private Line linearLine;

        public Line Linearline
        {
            get { return this.linearLine; }
            set
            {
                this.linearLine = value;

                GeometryGroup linear = new GeometryGroup();
                linear.Children.Add(new LineGeometry(
                    new Point(value.X1, value.Y1), new Point(value.X2, value.Y2)));
                Path linear_path = new Path();
                linear_path.StrokeThickness = 1;
                linear_path.Stroke = Brushes.Blue;
                linear_path.Data = linear;

                PointCollection pc = new PointCollection();
                pc.Add(new Point(value.X1, value.Y1));
                pc.Add(new Point(value.X2, value.Y2));

                this.lenearGraph.Children.Add(linear_path);
            }
        }

        public PointCollection PearsonPoints
        {
            get { return this.pearsonPoints; }
            set
            {
                this.pearsonPoints = value;

                printDots(pearsonGraph, PearsonPoints);
                printPoly(pearsonGraph, PearsonPoints);
            }
        }

        public PointCollection ChosenPoints
        {
            get { return this.chosenPoints; }
            set
            {
                this.chosenPoints = value;

                printDots(canGraph, ChosenPoints);
                printPoly(canGraph, ChosenPoints);

            }
        }

        public PointCollection LinearPoints
        {
            get { return this.linearPoints; }
            set
            {
                this.linearPoints = value;
                printDots(lenearGraph, LinearPoints);

            }
        }

        public void setVM(graphViewModel graphVM)
        {
            this.dviewmodel = graphVM;
        }

        //create buttons and the exises
        public graphsView()
        {
            InitializeComponent();
        }

        public void SetVM()
        {
            this.dviewmodel = new graphViewModel(this);

            double step = this.buttonsl.Height / 22;
            StackPanel sp = this.buttonsl;
            for (int j = 0; j < 2; j++)
            {
                for (int i = 0; i < 21; i++)
                {
                    Button b = new Button()
                    {
                        Content = buttonsNames[2 * i + j],
                        Name = "Button" + (2 * i + j),
                        HorizontalAlignment = HorizontalAlignment.Left,
                        VerticalAlignment = VerticalAlignment.Top,
                        Height = step,
                        Width = sp.Width,
                    };
                    b.Click += this.Button_Click;
                    sp.Children.Add(b);

                }
                step = this.buttonsr.Height / 22;
                sp = this.buttonsr;
            }
            this.create_exis(canGraph);
            this.create_exis(pearsonGraph);
            this.create_exis(lenearGraph);
        }

        //when button is clicked we need to change graph
        private void Button_Click(Object sender, RoutedEventArgs e)
        {
            string number = ((Button)sender).Name.Split("Button")[1];
            int choose = Int32.Parse(number);
            this.dviewmodel.updateDots(choose);
            //this.dviewmodel.updateDots(0);
            pearson.Content = buttonsNames[dviewmodel.Pearson];
        }


        //create the exis for input graph
        private void create_exis(Canvas Graph)
        {
            const double margin = 10;
            double xmin = margin;
            double xmax = Graph.Width - margin;
            double ymax = Graph.Height - margin;


            // Make the X axis.
            GeometryGroup xaxis_geom = new GeometryGroup();
            xaxis_geom.Children.Add(new LineGeometry(
                new Point(0, ymax / 2), new Point(Graph.Width, ymax / 2)));

            Path xaxis_path = new Path();
            xaxis_path.StrokeThickness = 1;
            xaxis_path.Stroke = Brushes.Black;
            xaxis_path.Data = xaxis_geom;

            Graph.Children.Add(xaxis_path);

            // Make the Y ayis.
            GeometryGroup yaxis_geom = new GeometryGroup();
            yaxis_geom.Children.Add(new LineGeometry(
                new Point(xmin, 0), new Point(xmin, Graph.Height)));

            Path yaxis_path = new Path();
            yaxis_path.StrokeThickness = 1;
            yaxis_path.Stroke = Brushes.Black;
            yaxis_path.Data = yaxis_geom;

            Graph.Children.Add(yaxis_path);
        }

        //print the points that given in the given graph
        private void printDots(Canvas Graph, PointCollection Points)
        {
            // Display ellipses at the points.
            const float width = 4;
            const float radius = width / 2;
            foreach (Point point in Points)
            {
                Ellipse ellipse = new Ellipse();
                ellipse.SetValue(Canvas.LeftProperty, point.X - radius);
                ellipse.SetValue(Canvas.TopProperty, point.Y - radius);
                ellipse.Fill = Brushes.Blue;
                ellipse.Stroke = Brushes.Blue;
                ellipse.StrokeThickness = 1;
                ellipse.Width = width;
                ellipse.Height = width;
                Graph.Children.Add(ellipse);
            }
        }

        //print the polyline of the points in the graph
        private void printPoly(Canvas Graph, PointCollection Points)
        {
            Polyline polyline = new Polyline();
            polyline.StrokeThickness = 1;
            polyline.Stroke = Brushes.Blue;
            polyline.Points = Points;

            Graph.Children.Add(polyline);
        }
    }
}
