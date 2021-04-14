using System.ComponentModel;

namespace MileStone1 {
    public interface IJoystickViewModel : INotifyPropertyChanged {
        double VM_aileron { get; }
        double VM_elevator { get; }
        double VM_throttle { get; }
        double VM_rudder { get; }
    }
}
