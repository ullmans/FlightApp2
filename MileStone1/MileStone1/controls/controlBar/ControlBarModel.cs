using System;
using System.ComponentModel;
using System.Threading;

namespace MileStone1 {
    public class ControlBarModel : IControlBarModel {
        // event for when a property changes
        public event PropertyChangedEventHandler PropertyChanged;

        // event for when the simulation finished
        public event IControlBarModel.EndRun SimulationFinished;

        // connection to main model
        private MileStone1.IDataModel mainModel;

        // constructor
        public ControlBarModel(MileStone1.IDataModel mainModel) {
            this.mainModel = mainModel;
            this.mainModel.PropertyChanged += delegate (Object sender, PropertyChangedEventArgs e) {
                if (e.PropertyName.Equals("Time")) {
                    NotifyPropertyChanged("Position");
                } else if (e.PropertyName.Equals("Speed")) {
                    NotifyPropertyChanged("PlaySpeed");
                }
            };
            this.mainModel.ScanFinished += delegate (Object sender) {
                if (SimulationFinished != null) {
                    SimulationFinished(this);
                }
            };
        }

        // calls the property changed event
        public void NotifyPropertyChanged(string propName) {
            if (this.PropertyChanged != null) {
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }

        public int Lines {
            get {
                return (int)mainModel.GetSimulationTime(); 
            }
        }

        public double Position {
            get {
                return mainModel.Time; 
            }
            set {
                if (mainModel.Time != value) {
                    mainModel.Time = value;
                }
            }
        }

        public double PlaySpeed {
            get { return mainModel.Speed; }
            set {
                if (mainModel.Speed != value) {
                    mainModel.Speed = value;
                    this.NotifyPropertyChanged("PlaySpeed");
                }
            }
        }

        public void Play() {
            mainModel.Start();
        }

        public void Pause() {
            mainModel.Pause();
        }
    }
}

