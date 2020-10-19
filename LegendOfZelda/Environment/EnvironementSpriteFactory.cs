using LegendOfZelda.Environment.Sprite;
using LegendOfZelda.Interface;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Environment
{
    //Sprite Factory based of model found in slides
    class EnvironmentSpriteFactory
    {
        private Texture2D squareSprite;
        private Texture2D statueSprite;
        private Texture2D stairSprite;
        private Texture2D doorSprite;
        private Texture2D ladderSprite;
        private Texture2D brickTileSprite;
        private Texture2D tileBlackSprite;
        private Texture2D tileWaterSprite;
        private Texture2D tileBlueGrassSprite;
        private Texture2D roomBorderSprite;
        private Texture2D fireSprite;

        public static EnvironmentSpriteFactory Instance { get; } = new EnvironmentSpriteFactory();

        public void LoadAllTextures(ContentManager content)
        {
            //Load Environment Sprites
            squareSprite = content.Load<Texture2D>("Environment/Block");
            statueSprite = content.Load<Texture2D>("Environment/Statue");
            stairSprite = content.Load<Texture2D>("Environment/Stairs");
            doorSprite = content.Load<Texture2D>("Environment/Doors");
            ladderSprite = content.Load<Texture2D>("Environment/Ladder");
            brickTileSprite = content.Load<Texture2D>("Environment/BrickTile");

            //Load Tile Sprites
            tileBlackSprite = content.Load<Texture2D>("Environment/BlackTile");
            tileBlueGrassSprite = content.Load<Texture2D>("Environment/BlueGrassTile");
            tileWaterSprite = content.Load<Texture2D>("Environment/WaterTile");
            roomBorderSprite = content.Load<Texture2D>("Environment/RoomBorder");
            fireSprite = content.Load<Texture2D>("Items/Fire");
        }

        public ISprite CreateBlockSprite()
        {
            return new SquareSprite(squareSprite);
        }
        public ISprite CreateStatueSprite()
        {
            return new StatueSprite(statueSprite);
        }
        public ISprite CreateStairSprite()
        {
            return new StairSprite(stairSprite);
        }
        public ITextureAtlasSprite CreateDoorSprite()
        {
            return new DoorSprite(doorSprite);
        }
        public ISprite CreateLadderSprite()
        {
            return new LadderSprite(ladderSprite);
        }
        public ISprite CreateBrickTileSprite()
        {
            return new BrickTileSprite(brickTileSprite);
        }
        public ISprite CreateTileBlackSprite()
        {
            return new TileBlackSprite(tileBlackSprite);
        }
        public ISprite CreateTileBlueGrassSprite()
        {
            return new TileBlueGrassSprite(tileBlueGrassSprite);
        }
        public ISprite CreateTileWaterSprite()
        {
            return new TileWaterSprite(tileWaterSprite);
        }
        public ISprite CreateRoomBorderSprite()
        {
            return new RoomBorderSprite(roomBorderSprite);
        }
        public ISprite CreateFireSprite()
        {
            return new FireSprite(fireSprite);
        }
    }
}
