# Code Maintainability, Readability, and Analysis
Throughout this sprint, we remained happy with our code's current state, including its current maintainability and readability. We found that adding the extra features we wanted was relatively easy as we had planned ahead when building our code in previous sprints.

### Warnings and Errors
Overall, we kept our warnings and errors to a minimum during this sprint. Initially, we had several errors and some tough bugs due to changing members of the sprite factory dynamically during runtime, like when switching to specific sprites or sounds. In some instances, we were trying to create sounds that never got initialized, so we kept getting null values. However, after adding in some null checks and changing the organization of SoundFactory, we were able to resolve the issues.

Another major problem we ran into when implementing multiplayer was figuring out how to deal with having two HUDs stacked (one for each player). Initially, we were trying to set up the project so we could change the constants files during runtime by holding off on instantiation until we finalized the user's settings. However, we had many issues with this and eventually scrapped the idea. Finally, we decided to create an animated banner where the player 2 HUD would be in a two player game. This animated HUD adds a cool touch to the game and solves one of the major issues we had.

### Maintainability and Readability
After finishing sprint 4, were pretty confident in our code's readability and maintainability. We had assumed that implementing some of the new features we wanted to implement for sprint 5 would be relatively straight-forward. This turned out to be the case. We had a few issues, as mentioned above, but implementing these new feature went overall pretty good because we focused on maintainability throughout the entire project.

In regards to readability, we were also pleased with that. As we went throughout this sprint, we worked to improve it more by doing things like creating constants for number or breaking code off into separate classes or helper methods. 

Were we to continue this project in the future, we think we would be in a great spot to continue adding new features or improving on existing ones.
