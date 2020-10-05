# Bugs
For the most part everything works pretty good. However, we did have some issues with animations as well as functionality:
- Fireball sprite animates incorrectly when shot from Aquamentus
- Link flashes slightly when walking
- Keyboard Controller switches too fast - fix by implemented old state and checking which keys are newly pressed
- Sprites are all different size (ex: Link is small while enemies are huge) - implement sprite scaling functionality and constants to easily change this
- Some of the enemies will go offscreen after some time; unsure of the cause of this but it needs fixed