using System;
using System.ComponentModel;

// control bar view model
public class ControlBarViewModel : INotifyPropertyChanged
{
	// event for when a property is changed
	public event PropertyChangedEventHandler PropertyChanged;
	// the control bar's model
	private ControlBarModel model;

	//constructor
	public ControlBarViewModel(ControlBarModel model)
	{
		this.model = model;
		this.model.PropertyChanged += delegate (Object sender, PropertyChangedEventArgs e)
		{
			NotifyPropertyChanged("VM_" + e.PropertyName);
		};
	}

	// calls the property chandged event
	public void NotifyPropertyChanged(string propName)
	{
		if (this.PropertyChanged != null)
		{
			this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
		}
	}

	// for each property their is only a getter that returns the control bar's
	// model's property and no setter

	// whether or not the flight display is running
	public bool VM_running
    {
		get { return this.model.Running; }
    }
	// the amount of lines in a flight file
	public int VM_lines
    {
		get { return this.model.Lines; }
    }
	// line in flight file the flight display is showing
	public int VM_position
    {
		get { return this.model.Position; }
    }
	// the speed at which the flight display is runniong
	public double VM_playSpeed
    {
		get { return this.model.PlaySpeed; }
    }

	// returns to the start of the flight
	public void GoToStart()
    {
		if (VM_position != 0)
        {
			this.model.Position = 0;
        }
    }

	// jumps to the end of the flight
	public void GoToEnd()
	{
		if (VM_position != VM_lines)
		{
			this.model.Position = VM_lines;
		}
	}

	// decreases the flight display's speed
	public void DecreaseSpeed()
	{
		if (VM_playSpeed > 0)
		{
			this.model.PlaySpeed -= 0.1;
		}
		if (VM_playSpeed < 0.01)
        {
			this.model.PlaySpeed = 0;
        }
	}
	
	// increases the flight display's speed
	public void IncreaseSpeed()
    {
		this.model.PlaySpeed += 0.1;
    }

	// pauses the flight display
	public void Pause()
    {
		this.model.Running = false;
    }

	// unpauses the flight display
	public void Play()
	{
		this.model.Running = true;
	}

	// jumps to a specific line in the flight file
	public void SkipTo(int newPosition)
    {
		this.model.Position = newPosition;
    }

	// updates the control bar when moving to next line in flight file
	public void Move()
    {
		this.model.Position++;
    }
}
