# LegendOfZelda
Holds classes and interfaces used by every part of the game. Individual parts of the game are in their respective folders.

## Drawing in Layers
All ISpawnable objects in the game pass a layer float to their Draw method. The game then draws that sprite on the respective layer. These layers can be found in [Constants.DrawLayer](Constants.cs).
