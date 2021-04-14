# Advanced Programming 2
## milestone 1

group members: Shilo Ulman, Tal Ben-Zvi, Shaked Winder, Roy Tamir

## Design:
When the app is first oppened the user sees a window where he can upload a flight .csv file.
this page has a "start" button that takes the user to the applications main window.

We used the MVVM design pattern to create the application's main window.
The main window shows the flight using the Flight Gear application and also has a few user controls.
The main window's user control are the control bar, the data bar and the joystick.
Each of these user controls have there own view model.

The backbone of the main window is the model which provides the application's main functionalies.
The model communicate with the main window through the user controls' view models.

## Implementation:

### Starting Window:

### Model

### Control Bar:
The Control Bar is a user control in the controls folder that displays information about the flight
display such as speed and place. The Control Bar not only displays this information but also allows
the user to change and control them.
ControlBar.xaml is the Control Bar's view and ControlBar.xaml.cs is it's code behind.
ControlBarViewModel.cs is the Control Bar's view model which is observed by the view.
ControlBarModel.cs is the Control Bar's model which is obseved by the view model.

### Data Bar

### Joystick
