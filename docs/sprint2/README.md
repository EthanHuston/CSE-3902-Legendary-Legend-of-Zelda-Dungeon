# docs/sprint2
## General Notes
Overall, Sprint 2 went okay. We did not plan out the tasks and timing all that great, which is discussed in more depth below. A lot of the tasks/stories took longer than expected, as seen in the burndown chart.

---
## Team Reflection and Agile Analysis
Sprint 2 started on 9/5, but we did not get a good start on planning until 9/15. When we met on 9/15, we set up a repo on GitHub. On 9/17, we decided to use Azure Boards as our issue tracker/Agile tool. This is when we actually created the stories and tasks.

In addition, we underestimated how long the stories would take. Initially, we planned to have the code written and merged to master branch by Sunday, 9/27. That would give us all week, 9/28-10/4 to review and clean up code as well as debug. However, as stated previously, stories took longer than initially planned, so we were unable to merge them to master until 10/3. 

As seen in the burndown chart, we officially closed the stories on 10/5, as we were still working out bugs and kinks in the program until that day.

---
## Code Maintainability, Readability, and Analysis
Initially, we had a lot of errors in the game after merging everything to master. However, we were able to fix these fairly quickly.

### Warnings and Errors
We also had a lot of warnings, including things like unused fields or not initializing fields in constructors. After manually fixing some of these and running Visual Studio's code cleanup, we were able to eliminate most of the warnings. Some of the warnings were from class members that were not used/read in Sprint 2, but these members will be used in later Sprints, so we kept them in there.

### Maintainability and Readability
In addition, We tried to keep Sprint 2 logic from general game logic. This means everything that Sprint 2 needs to do can be done within the namespace LegendOfZelda.Sprint2; we did not want to be putting Sprint2 logic inside of Link's, enemies', or any other classes, as this would make it harder to transition to Sprint 3. Once we start with Sprint 3, we can just remove the Sprint2 namespace and use all of the existing code without much change.

In addition, we used interfaces as much as possible to hide details about implementations as well as improve readability and maintainability.

---
## Moving Forward
### Agile and Team Planning
For Sprint 3, we need to do a better job at planning out stories an estimating how long they will take. With Sprint 2 behind us, we think we have a better idea of how long each story will take to implement, which will allow us to better estimate how many story points to give it. In addition, now that we are more familiar with Azure Boards, we will be able to create Sprint 3 and the stories more towards the beginning of the sprint, allowing us to follow the ideal trendline on the burndown chart.

Finally, we can close stories after we implement them and make a general debugging story later that will be saved for the end of the sprint. We will close the stories as we finish them and start teh debugging story towards the end of the sprint once we merge everything to master and start debugging the game. This will allow the burndown chart of more closely follow the trendline.

### Refactoring
Currently, Link uses its own items container to keep track of items that it spawns, like arrows, boomerangs, and bombs. Moving forward, it would be easier to make a container in Game1 (or someplace similar) that holds and keeps track of all items. This would improve code readability, as we will only need to update items in one place. In addition, it would improve maintainability, as it will help later when we are implementing collision detection.