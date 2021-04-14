using System;
using System.ComponentModel;
using System.Threading;

public class ControlBarModel : IControlBarModel
{
    // event for when a property changes
    public event PropertyChangedEventHandler PropertyChanged;

    // connection to main model
    private MileStone1.IDataModel mainModel;

    // constructor
    public ControlBarModel(MileStone1.IDataModel mainModel)
    {
        this.mainModel = mainModel;
    }

    // calls the property changed event
    public void NotifyPropertyChanged(string propName)
    {
        if (this.PropertyChanged != null)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
    }

    // for each of the properties in the interface if the value is new then the
    // NotifyPropertyChanged function is called
    public bool Running
    {
        get { return mainModel.Paused; }
        set
        {
            if (value != mainModel.Paused)
            {
                mainModel.Paused = value;
                this.NotifyPropertyChanged("running");
            }
        }
    }

    public int Lines
    {
        get { return mainModel.Lines; }
        set { if (mainModel.Lines != value)
            {
                mainModel.Lines = value;
                this.NotifyPropertyChanged("lines");
            } 
        }
    }
    public int Position
    {
        get { return mainModel.Position; }
        set
        {
            if (mainModel.Position != value)
            {
                mainModel.Position = value;
                this.NotifyPropertyChanged("position");
            }
        }
    }

    public double PlaySpeed
    {
        get { return mainModel.Speed; }
        set
        {
            if (mainModel.Speed != value)
            {
                mainModel.Speed = value;
                this.NotifyPropertyChanged("playSpeed");
            }
        }
    }
 
    public void Move()
    {
        this.Position++;
    }
}
