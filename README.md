# Mars Rover Challenge
My implementation of the **Mars Rover Challenge** as described here: https://code.google.com/archive/p/marsrovertechchallenge/

## To run the project

Download the source, and either:
 - open it in Visual Studio and press F5 to launch the console, or
 - open a command prompt in the `ControlPanel` folder, and type `dotnet run`
 
 ## Entering Commands
 Start by entering the grid size with two integers, separated by a [space], representing the `width` and `height` of the plateau, respectively.
 Follow the above with any number of command-pairs, where:
  - the first entry in the pair refers to the position and heading of the rover to receive the command string.
  - the second entry in the pair represents a string of commands to send to the rover.
  
 ## Valid Commands
  - **M** Move forward one grid position in the direction the rover is facing
  - **L** Spin the rover one compass ordinal direction to the left without changing grid position
  - **R** Spin the rover one compass ordinal direction to the right without changing grid position
 
 ## Rules Implemented
  - A move command that will cause a rover to move off the edge of the plateau will be ignored.
  - A move command that will cause a rover to collide with another rover will be ignored.
  - A command addressing a rover that is off the plateau will be ignored.
  
 
 
