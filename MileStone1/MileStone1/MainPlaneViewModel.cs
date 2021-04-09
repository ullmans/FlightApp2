using System.ComponentModel;
using Microsoft.Win32;

namespace MileStone1 {
    class MainPlaneViewModel : IPlaneViewModel {
        private IPlaneModel model;

        public event PropertyChangedEventHandler PropertyChanged;

        private string filePath;
        public string VM_FilePath {
            get { return filePath; }
            set 
            {
                filePath = value;
                NotifyPropertyChanged("VM_FilePath");
            }
        }

        public MainPlaneViewModel(IPlaneModel model) {
            filePath = "";
            this.model = model;
        }

        public void StartSimulation() {
            model.Connect("localhost", 8081);
            model.Start(filePath);  
        }

        public void NotifyPropertyChanged(string propName) {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
    }
}