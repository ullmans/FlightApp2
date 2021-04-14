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
            this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
    }

    // for each of the properties in the interface if the value is new then the
    // NotifyPropertyChanged function is called
    public bool running
    {
        get { return mainModel.pause; }
        set
        {
            if (value != mainModel.pause)
            {
                mainModel.pause = value;
                this.NotifyPropertyChanged("running");
            }
        }
    }

    public int lines
    {
        get { return mainModel.lines; }
        set { if (mainModel.lines != value)
            {
                mainModel.lines = value;
                this.NotifyPropertyChanged("lines");
            } 
        }
    }
    public int position
    {
        get { return mainModel.position; }
        set
        {
            if (mainModel.position != value)
            {
                mainModel.position = value;
                this.NotifyPropertyChanged("position");
            }
        }
    }

    public double playSpeed
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
        this.position++;
    }
}
