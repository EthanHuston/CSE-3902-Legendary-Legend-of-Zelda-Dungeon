# Bugs

### Sprint 4
Our testing plan included personally testing features as they were implemented as to ensure their functionality and also allowing outside parties (mainly roommates of team members) to play test the game and find potential bugs which the team wouldn't be able to think of. Through this test plan we found some bugs but were able to eliminate all bugs that we discovered in our testing. Additionally all known bugs from previous sprints were also fixed during this sprint.

### From Sprint 3
- [[fixed]: ](../sprint3/Bugs.md)Hand enemies drag Link, but they are also able to go outside the wall and can carry Link out. When releasing Link outside of walls, Link's collision handling takes over and weird things happen
- [[fixed]: ](../sprint3/Bugs.md)Game screen is extremely small; need to finish implementing a scaling system to make screen bigger
- [[fixed]: ](../sprint3/Bugs.md)In Room 1, bats slowly glitch off the screen; issue lies with how we are handling wall collisions for bat
- [[fixed]: ](../sprint3/Bugs.md)Goriya movement logic is acting strange; they get stuck in the corners and room is too easy as they don't throw the boomerang at Link
- [[fixed]: ](../sprint3/Bugs.md)If you just tap Link's movement keys repeatedly, he will alternate between walking and animating
- [[fixed]: ](../sprint3/Bugs.md)It is difficult to walk Link between two blocks that have a gap of 1 tile (16 px * SpriteScaler)
- [[fixed]: ](../sprint3/Bugs.md)Link can spam as many boomerangs/arrow/sword beams as he wants to; fix by putting a can spawn boolean dictionary in LinkPlayer.cs
