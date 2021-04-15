using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Windows.Media;
using System.Windows.Shapes;



/**
 * the view model of the graph
 * connect between view and model
 */

public class graphViewModel : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler PropertyChanged;
    //the view and the model
    private graphModel dmodel;
    private MileStone1.controls.graphs.graphsView dview;
    private int pearson;

    public int Pearson
    {
        get { return this.pearson; }
        set { this.pearson = value; }
    }

    public graphViewModel(double[][] data)
    {
        //double[][] x;
        //x = new double[1][] { new double[]{ 1.0, 3.0, 5.0, 7.0, 9.0 } };
        
        this.dmodel = new graphModel(this, data);
        this.dview = new MileStone1.controls.graphs.graphsView();
        this.dview.setVM(this);
    }

    public Line VM_linearline
    {
        get { return dview.Linearline; }
        set { dview.Linearline = value; }
    }

    //save the dots in the view
    public PointCollection VM_dots
    {
        get { return dview.ChosenPoints; }
        set { dview.ChosenPoints = value; }
    }

    public PointCollection VM_pearsonDots
    {
        get { return dview.PearsonPoints; }
        set { dview.PearsonPoints = value; }
    }
    
    public PointCollection VM_linearDots
    {
        get { return dview.LinearPoints; }
        set { dview.LinearPoints = value; }
    }

    //update the dots in the graphs
    public void updateDots(int chosen)
    {
        VM_dots = dmodel.chosenDots(chosen);
        VM_pearsonDots = dmodel.pearsonDots(chosen);
        VM_linearDots = dmodel.linearDots(chosen);
    }
    
}


