using System;
using System.ComponentModel;


namespace MileStone1 {
	public class ControlBarViewModel : IControlBarViewModel {
		private readonly double SPEED_DELTA = 0.1;

		// event for when a property is changed
		public event PropertyChangedEventHandler PropertyChanged;

		// event for when the simulation finished
		public event IControlBarViewModel.EndRun SimulationFinished;

		// the control bar's model
		private ControlBarModel model;

		//constructor
		public ControlBarViewModel(ControlBarModel model) {
			this.model = model;
			this.model.PropertyChanged += delegate (Object sender, PropertyChangedEventArgs e)
			{
				NotifyPropertyChanged("VM_" + e.PropertyName);
			};
			this.model.SimulationFinished += delegate (Object sender) {
				if (SimulationFinished != null) {
					SimulationFinished(this);
				}
			};
		}

		// calls the property chandged event
		public void NotifyPropertyChanged(string propName) {
			if (this.PropertyChanged != null) {
				this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
			}
		}

		// the amount of lines in a flight file
		public int VM_Lines {
			get { return this.model.Lines; }
		}

		// line in flight file the flight display is showing
		public double VM_Position {
			get { 
				return this.model.Position; 
			}
			set {
				this.model.Position = value;
            }
		}

		// the speed at which the flight display is runniong
		public double VM_PlaySpeed {
			get { return this.model.PlaySpeed; }
		}

		// decreases the flight display's speed
		public void DecreaseSpeed() {
			this.model.PlaySpeed -= SPEED_DELTA;
		}

		// increases the flight display's speed
		public void IncreaseSpeed() {
			this.model.PlaySpeed += SPEED_DELTA;
		}

		// pauses the flight display
		public void Pause() {
			this.model.Pause();
		}

		// unpauses the flight display
		public void Play() {
			this.model.Play();
		}

		// updates the control bar when moving to next line in flight file
		public void Move() {
			this.model.Position++;
		}
	}
}

