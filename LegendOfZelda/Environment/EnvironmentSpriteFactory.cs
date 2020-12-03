using LegendOfZelda.Environment.Sprite;
using LegendOfZelda.Interface;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Environment
{
    //Sprite Factory based of model found in slides
    internal class EnvironmentSpriteFactory
    {
        private Texture2D squareSprite;
        private Texture2D fishStatueSprite;
        private Texture2D dragonStatueSprite;
        private Texture2D stairSprite;
        private Texture2D doorSprite;
        private Texture2D ladderSprite;
        private Texture2D brickTileSprite;
        private Texture2D blackBackgroundSprite;
        private Texture2D oldBackgroundSprite;
        private Texture2D memeBackgroundSprite;
        private Texture2D tileBackgroundSprite;
        private Texture2D tileBlackSprite;
        private Texture2D tileWaterSprite;
        private Texture2D tileBlueGrassSprite;
        private Texture2D roomBorderSprite;
        private Texture2D fireSprite;
        private Texture2D wallSprite;

        public static EnvironmentSpriteFactory Instance { get; } = new EnvironmentSpriteFactory();

        public void LoadAllTextures(ContentManager content)
        {
            //Load Environme    nt Sprites
            squareSprite = content.Load<Texture2D>("Environment/Block");
            fishStatueSprite = content.Load<Texture2D>("Environment/Statue");
            dragonStatueSprite = content.Load<Texture2D>("Environment/DragonStatue");
            stairSprite = content.Load<Texture2D>("Environment/Stairs");
            doorSprite = content.Load<Texture2D>("Environment/Doors");
            ladderSprite = content.Load<Texture2D>("Environment/Ladder");
            brickTileSprite = content.Load<Texture2D>("Environment/BrickTile");
            wallSprite = content.Load<Texture2D>("Environment/Walls");

            //Load Tile Sprites
            blackBackgroundSprite = content.Load<Texture2D>("Environment/BlackBackground");
            oldBackgroundSprite = content.Load<Texture2D>("Environment/OldManBackground");
            memeBackgroundSprite = content.Load<Texture2D>("Environment/MemeBackground");
            tileBackgroundSprite = content.Load<Texture2D>("Environment/TileBackground");
            tileBlackSprite = content.Load<Texture2D>("Environment/BlackTile");
            tileBlueGrassSprite = content.Load<Texture2D>("Environment/BlueGrassTile");
            tileWaterSprite = content.Load<Texture2D>("Environment/WaterTile");
            roomBorderSprite = content.Load<Texture2D>("Environment/RoomBorder");
            fireSprite = content.Load<Texture2D>("Items/Fire");
        }

        public ITextureAtlasSprite CreateWallSprite()
        {
            return new WallSprite(wallSprite);
        }
        public ISprite CreateSquareSprite()
        {
            return new SquareSprite(squareSprite);
        }
        public ISprite CreateFishStatueSprite()
        {
            return new FishStatueSprite(fishStatueSprite);
        }
        public ISprite CreateDragonStatueSprite()
        {
            return new DragonStatueSprite(dragonStatueSprite);
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
        public ISprite CreateBlackBackgroundSprite()
        {
            return new BlackBackgroundSprite(blackBackgroundSprite);
        }
        public ISprite CreateOldBackgroundSprite()
        {
            return new OldBackgroundSprite(oldBackgroundSprite);
        }

        public ISprite CreateMemeBackgroundSprite()
        {
            return new MemeBackgroundSprite(memeBackgroundSprite);
        }
        public ISprite CreateTileBackgroundSprite()
        {
            return new TileBackgroundSprite(tileBackgroundSprite);
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
