# Code Maintainability, Readability, and Analysis
We had a decent amount of runtime errors in the game this time after merging all our parts together. Most of these were logical errors that prevent game features from working.

### Warnings and Errors
After we began testing, we found a lot of logical errors in dealing with collision detection and error handling. One of the major sources of our problems was determining how to get a position rectangle for every sprite on screen. Initially, we were saving the destination rectangle after every call to Draw, but this was problematic - as we were unable to properly initialize the destination rectangle until the sprite's Draw method was called. We fixed this, by returning Sprite.Bounds and then manually adding the X and Y values to the rectangle. This ultimately fixed a lot of our problems with collision detection. 

Compile errors and warnings were fairly easy to fix, as Visual Studio makes it easy to jump right to the build error and fix it. Most of the warnings we had consisted of having fields in classes that were unused or not setting fields to be readonly. These were fixed easily running Visual Studio's code cleanup.

### Maintainability and Readability
Here in Sprint 3, we were able to implement a lot of features and frameworks that we can extend to add new features in the rest of the project. One such feature was adding an [IGameState](../../LegendOfZelda/GameLogic/IGameState.cs) interface and adding a State member to [Game1](../../LegendOfZelda/Game1.cs). While we only have a [RoomState](../../LegendOfZelda/Rooms/RoomGameState.cs) right now, we will easily be able to implement new states in Sprint 4, like a GameWonState, PauseState, and StartMenuState. Another feature that we included in this sprint was including a list of players. Currently, since the game is only single player, we only have one player in there. However, since we already have the list, we should be able to add multiplayer into the game relatively gracefullly.

In terms of readability, we greatly improved it by adding more helper methods. Most methods are only 10-20 lines long, and, if they are longer, have multiple helper methods with descriptive names to make it easy to understand what is going on.
