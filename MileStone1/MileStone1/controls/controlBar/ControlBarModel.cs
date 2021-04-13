using System;
using System.ComponentModel;
using System.Threading;

public class ControlBarModel : IControlBarModel
{
    public event PropertyChangedEventHandler PropertyChanged;

    public ControlBarModel(int lines)
    {
        this.running = false;
        this.lines = lines;
        this.position = 0;
        this.playSpeed = 1;
    }

    public void NotifyPropertyChanged(string propName)
    {
        if (this.PropertyChanged != null)
        {
            this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
    }

    private bool Running;
    public bool running
    {
        get { return this.Running; }
        set
        {
            if (value != this.Running)
            {
                this.Running = value;
                this.NotifyPropertyChanged("Running");
            }
        }
    }

    private int Lines, Position;
    public int lines
    {
        get { return this.Lines; }
        set { if (this.Lines != value)
            {
                this.Lines = value;
                this.NotifyPropertyChanged("Lines");
            } 
        }
    }
    public int position
    {
        get { return this.Position; }
        set
        {
            if (this.Position != value)
            {
                this.Position = value;
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
