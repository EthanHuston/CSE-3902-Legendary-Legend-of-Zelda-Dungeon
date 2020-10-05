# Moving Forward
### Agile and Team Planning
For Sprint 3, we need to do a better job at planning out stories an estimating how long they will take. With Sprint 2 behind us, we think we have a better idea of how long each story will take to implement, which will allow us to better estimate how many story points to give it. In addition, now that we are more familiar with Azure Boards, we will be able to create Sprint 3 and the stories more towards the beginning of the sprint, allowing us to follow the ideal trendline on the [burndown chart](BurndownChart.jpg).

Finally, we can close stories after we implement them and make a general debugging story later that will be saved for the end of the sprint. We will close the stories as we finish them and start teh debugging story towards the end of the sprint once we merge everything to master and start debugging the game. This will allow the [burndown chart](BurndownChart.jpg) of more closely follow the trendline.

### Refactoring
Currently, Link uses its own items container to keep track of items that it spawns, like arrows, boomerangs, and bombs. Moving forward, it would be easier to make a container in Game1 (or someplace similar) that holds and keeps track of all items. This would improve code readability, as we will only need to update items in one place. In addition, it would improve maintainability, as it will help later when we are implementing collision detection.

Additionally, we need to use more helper/utility methods to clean up code and improve readability and reusability. This will also allow us to shorten the amount of code we have, as we can move frequently reused code unto the Utility class.