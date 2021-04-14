using System;
using System.ComponentModel;
using System.Threading;

public class ControlBarModel : IControlBarModel
{
    public event PropertyChangedEventHandler PropertyChanged;
    private MileStone1.IDataModel mainModel;

    public ControlBarModel(MileStone1.IDataModel mainModel)
    {
        this.mainModel = mainModel;
    }

    public void NotifyPropertyChanged(string propName)
    {
        if (this.PropertyChanged != null)
        {
            this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
    }

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

    private int Position;
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

    private double PlaySpeed;
    public double playSpeed
    {
        get { return this.PlaySpeed; }
        set
        {
            if (this.PlaySpeed != value)
            {
                this.PlaySpeed = value;
                this.NotifyPropertyChanged("playSpeed");
            }
        }
    }
 
    public void move()
    {
        this.position++;
    }
}
