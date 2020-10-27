# Code Maintainability, Readability, and Analysis
Initially, we had a lot of errors in the game after merging everything to master. However, we were able to fix these fairly quickly.

### Warnings and Errors
We also had a lot of warnings, including things like unused fields or not initializing fields in constructors. After manually fixing some of these and running Visual Studio's code cleanup, we were able to eliminate most of the warnings. Some of the warnings were from class members that were not used/read in Sprint 2, but these members will be used in later Sprints, so we kept them in there.

### Maintainability and Readability
In addition, We tried to keep Sprint 2 logic from general game logic. This means everything that Sprint 2 needs to do can be done within the namespace LegendOfZelda.Sprint2; we did not want to be putting Sprint2 logic inside of Link's, enemies', or any other classes, as this would make it harder to transition to Sprint 3. Once we start with Sprint 3, we can just remove the Sprint2 namespace and use all of the existing code without much change.

In addition, we used interfaces as much as possible to hide details about implementations as well as improve readability and maintainability.