# Moving Forward
### Agile and Team Planning

For Sprint 4 and onward, our team needs to do a better job capitalizing on the first week of the Sprint cycle. Even though it was mostly an issue this week due to a large workload outside the scope of this class (midterms and such, which can be seen on the [burndown chart](BurndownChart.PNG)), time management between team members still could have been handled better. However, in terms of planning task completion time, we believe that our team has improved exponentially when compared to Sprint 2. Issues with the Azure Boards this sprint came down to mostly overloading tasks rather than a lack of awareness to their completion times.

During this sprint, we also struggled with debugging, as we were working up until the due date to iron out bugs. However, this was due in part of our team being busy with schoolwork, so Sprint 4 should hopefully be better. 

### Refactoring
During this sprint, we did a lot of refactoring to prep the code for future features, like different games states (i.e. PauseState, EndGame, etc.). This should save a lot of hassle in the rest of the projects. 

Coming off of last sprint, we also created classes to manage items that are spawned onscreen. This gives us a single point of control for spawning and updating all items. Moving forward, we just want to refine this and streamline it more to ensure it stays both readable and maintainable.

There are also a few places where we could drastically simplify and reduce the amount of code we have. This includes in certain sprites, like Goriya up/down/left/right as well as some of Link's states, like when he uses items. A lot of this logic could be combined into a more generic class, or implemented into the classes that call methods from those classes. Making these simplifications will greatly reduce the amount of code and coupling.

Finally, Constants.cs is very long. We broke the room's constants off into its own file, so we will also do this for the rest of the types in the project, like Link and enemies.

While we do have some changes to make moving forward, we are happy with the readability and maintainability of our code as well as the amount of coupling and cohesion, especially at this point in the semester during a busy and stressful sprint.
