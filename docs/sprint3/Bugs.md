# Bugs
For the most part everything works pretty good. However, we did have some issues with functionality of certain enemies in the game:

### Sprint 3
- Hand enemies drag Link, but they are also able to go outside the wall and can carry Link out. When releasing Link outside of walls, Link's collision handling takes over and weird things happen
- Game screen is extremely small; need to finish implementing a scaling system to make screen bigger
- In Room 1, bats slowly glitch off the screen; issue lies with how we are handling wall collisions for bat
- Goriya movement logic is acting strange; they get stuck in the corners and room is too easy as they don't throw the boomerang at Link
- If you just tap Link's movement keys repeatedly, he will alternate between walking and animating
- It is difficult to walk Link between two blocks that have a gap of 1 tile (16 px * SpriteScaler)
- Link can spam as many boomerangs/arrow/sword beams as he wants to; fix by putting a can spawn boolean in LinkPlayer.cs

### From Sprint 2
- [[fixed]: ](../sprint2/Bugs.md)Fireball sprite animates incorrectly when shot from Aquamentus
- [[fixed]: ](../sprint2/Bugs.md)Link flashes slightly when walking 
- [[fixed]: ](../sprint2/Bugs.md)Sprites are all different size (ex: Link is small while enemies are huge) - implement sprite scaling functionality and constants to easily change this 
- [[fixed]: ](../sprint2/Bugs.md)Some of the enemies will go offscreen after some time; unsure of the cause of this but it needs fixed 
- [[fixed]: ](../sprint2/Bugs.md)The SpikeTrap Enemy movement logic is not behaving as intended, needs to be revisited or reworked. 
- [[fixed]: ](../sprint2/Bugs.md)Link walks too far when you just tap the walk 
- [[fixed]: ](../sprint2/Bugs.md)Link "slides on ice" when you press two direction buttons at the same time
