using System;
using System.ComponentModel;
using System.Threading;

class ControlBarModel : IControlBarModel
{
    public event PropertyChangedEventHandler PropertyChanged;

    public ControlBarModel(int steps)
    {
        this.running = false;
        this.steps = steps;
        this.position = 0;
        this.playSpeed = 10;
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

    private int Steps, Position, PlaySpeed;
    public int steps
    {
        get { return this.Steps; }
        set { if (this.Steps != value)
            {
                this.Steps = value;
                this.NotifyPropertyChanged("Steps");
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
    public int playSpeed
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
