# LegendOfZelda
Holds classes and interfaces used by every part of the game. Individual parts of the game are in their respective folders.

## Drawing in Layers
All ISpawnable objects in the game pass a layer float to their Draw method. The game then draws that sprite on the respective layer. Here are the layers used for the game:

|Item |Layer |
|:-|:-:|
|Floor tiles |0|
|Stairs |0|
|Walls |0|
|Closed doors |0|
|Statues |1|
|Movable Block |1|
|Enemies |2|
|Npc| |2|
|Enemy Spawn Sprites |2.1|
|Player |3|
|Projectiles |4|
|Items |5|
|Open doors |6|
|Menus |7|
|HUD |7|
|InventoryMenu |7|
|MapMenu |7|
|MenuButton |7.1|
|MenuIcons |7.1|
|MapIcons |7.2|
|Map |7.2|
|MapMarkers |7.3|
