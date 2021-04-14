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
		get { return this.model.running; }
    }
	// the amount of lines in a flight file
	public int VM_lines
    {
		get { return this.model.lines; }
    }
	// line in flight file the flight display is showing
	public int VM_position
    {
		get { return this.model.position; }
    }
	// the speed at which the flight display is runniong
	public double VM_playSpeed
    {
		get { return this.model.playSpeed; }
    }

	// returns to the start of the flight
	public void GoToStart()
    {
		if (VM_position != 0)
        {
			this.model.position = 0;
        }
    }

	// jumps to the end of the flight
	public void GoToEnd()
	{
		if (VM_position != VM_lines)
		{
			this.model.position = VM_lines;
		}
	}

	// decreases the flight display's speed
	public void DecreaseSpeed()
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
	
	// increases the flight display's speed
	public void IncreaseSpeed()
    {
		this.model.playSpeed += 0.1;
    }

	// pauses the flight display
	public void Pause()
    {
		this.model.running = false;
    }

	// unpauses the flight display
	public void Play()
	{
		this.model.running = true;
	}

	// jumps to a specific line in the flight file
	public void SkipTo(int newPosition)
    {
		this.model.position = newPosition;
    }

	// updates the control bar when moving to next line in flight file
	public void Move()
    {
		this.model.position++;
    }
}
