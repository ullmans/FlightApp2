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
The databar is a dash Board that display some flight data of the plane.
The dash board contain:
1. Altimeter
2. Air speed
3. Flight direction ("heading")
4. Pitch
5. Roll
6. Yaw 

We built it as a UserControl and with the MVVM design pattern, so the view and the model does not know each other.

### Joystick

### graph
thr graph is present a chosen data from the csv code and show a graph of the values- (the values in csv is y_exis and the time is x_exis).
in addition, the graph show the most pearson data.
graphView.xaml and graphView.xaml.cs is the view- they create and show the buttons and the graph.
graphViewModel.cs is the view model that control everything.
graphModel.cs is the model that calculate the graph need to be shown


## Using the Application
anyone who want to use our application, must download FlightGear. You can download Flightgear here: https://www.flightgear.org/download/
after download FlightGear, open it. You need to enter some definitions to it.
open the cmd, and write there:
--generic=socket,in,10,127.0.0.1,5400,tcp,playback_small
--fdm=null
this will be enough for first using th eapplication. for more Features, look here:https://www.flightgear.org/
now, you can run the application in the cmd (you need to compile before trying to run it), or open your IDE (we recommend visual studio), build the app, and run it.

## UML diagram
you can find here a UML diagram of our project: https://github.com/ullmans/FlightApp2/blob/main/UML%20Diagram.pdf
