# LegendOfZelda.Enemies
Holds all enemies for the game. Each enemy implements IEnemy and has a sprite in LegendOfZelda.Sprites.

---
### TODO: 
- Simplify Goriya Sprites so we only need one of them and just pass in a direction
- Change GetRectangle method so it works always, even if Draw has not been called yet (right now ISprite.GetPositionRectangle() returns ISprite.destinationRectangle, which is initalized to Rectangle.Empty)