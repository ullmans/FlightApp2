using System;
using System.ComponentModel;

class ControlBarViewModel : INotifyPropertyChanged
{
	public event PropertyChangedEventHandler PropertyChanged;
	private ControlBarModel model;
	public ControlBarViewModel(ControlBarModel model)
	{
		this.model = model;
		this.model.PropertyChanged += delegate (Object sender, PropertyChangedEventArgs e)
		{
			NotifyPropertyChanged("VM_" + e.PropertyName);
		};
	}

	public void NotifyPropertyChanged(string propName)
	{
		if (this.PropertyChanged != null)
		{
			this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
		}
	}

	public bool VM_running
    {
		get { return this.model.running; }
    }
	public int VM_lines
    {
		get { return this.model.lines; }
    }
	public int VM_position
    {
		get { return this.model.position; }
    }
	public double VM_playSpeed
    {
		get { return this.model.playSpeed; }
    }

	public void goToStart()
    {
		if (VM_position != 0)
        {
			this.model.position = 0;
        }
    }

	public void goToEnd()
	{
		if (VM_position != VM_lines)
		{
			this.model.position = VM_lines;
		}
	}

	public void decreaseSpeed()
	{
		if (VM_playSpeed > 0)
		{
			this.model.playSpeed -= 0.1;
		}
		if (VM_playSpeed < 0.01)
        {
			this.model.playSpeed = 0;
        }
	}
	
	public void increaseSpeed()
    {
		this.model.playSpeed += 0.1;
    }

	public void Pause()
    {
		this.model.running = false;
    }

	public void Play()
	{
		this.model.running = true;
	}

	public void skipTo(int newPosition)
    {
		this.model.position = newPosition;
    }

	public void move()
    {
		this.model.position++;
    }
}
