# Moving Forward
### Agile and Team Planning
For Sprint 3, we need to do a better job at planning out stories an estimating how long they will take. With Sprint 2 behind us, we think we have a better idea of how long each story will take to implement, which will allow us to better estimate how many story points to give it. In addition, now that we are more familiar with Azure Boards, we will be able to create Sprint 3 and the stories more towards the beginning of the sprint, allowing us to follow the ideal trendline on the [burndown chart](BurndownChart.PNG).

Finally, we can close stories after we implement them and make a general debugging story later that will be saved for the end of the sprint. We will close the stories as we finish them and start the debugging story towards the end of the sprint once we merge everything to master and start debugging the game. This will allow the [burndown chart](BurndownChart.PNG) to more closely follow the trendline.

### Refactoring
Currently, Link uses its own items container to keep track of items that it spawns, like arrows, boomerangs, and bombs. Moving forward, it would be easier to make a container in Game1 (or someplace similar) that holds and keeps track of all items. This would improve code readability, as we will only need to update items in one place. In addition, it would improve maintainability, as it will help later when we are implementing collision detection.

Additionally, we need to use more helper/utility methods to clean up code and improve readability and reusability. This will also allow us to shorten the amount of code we have, as we can move frequently reused code unto the Utility class.

There are several places where we could create abstract classes to help cut down and reuse more code. One of these places in for Link's states, which repeat a lot of code because the call to change a state does nothing in many instances. We could create an abstract class to solve this and then only override the methods we need to change.

Finally, some of our classes, like SpriteFactory, are pretty long, so we would like to break that down into multiple classes in the future based on Sprite (ex: Link, Enemy, Environment, etc.). Creating helper methods that are generic and placing them in Utility.cs would also help us cut down on the length of some of our classes.

Overall, though, we are happy with our code and the amount of cohesion and coupling that we have.
