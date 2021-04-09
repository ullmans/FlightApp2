using System.ComponentModel;
namespace MileStone1 {
    interface IPlaneViewModel : INotifyPropertyChanged { 
        void StartSimulation();

        string VM_FilePath { set; get; }
    }
}