using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace LegendOfZelda.GameState
{
    static class GameStateConstants
    {
        private const double gameScaler = Constants.GameScaler;

        public static Rectangle MainMenuTextureMapSource => new Rectangle(0, 0, 260, 224);

        private const int inventoryItemSelectStateHeight = (int)(88 * gameScaler);
        public static Point InventoryItemSelectStatePosition => new Point((int)(gameScaler * 0), (int)(gameScaler * 0));
        public static Point MapItemSelectStatePosition => new Point((int)(gameScaler * 0), InventoryItemSelectStatePosition.Y + inventoryItemSelectStateHeight);
        public static Point MapGridSize => new Point(8, 8);

        // Button Positions
        public static Point PauseStateResumeButtonLocation => new Point((int)(gameScaler * 48), (int)(gameScaler * 64));
        public static Point PauseStateExitButtonLocation => new Point((int)(gameScaler * 96), (int)(gameScaler * 96));
        public static Point PauseStateMainMenuButtonLocation => new Point((int)(gameScaler * 144), (int)(gameScaler * 64));


        // Item Positions in HudItems.png Texture Atlas
        public static Vector2 StandardItemSpriteSize => new Vector2(8, 16);
        public static Rectangle BombTextureAtlasSource => new Rectangle(85, 29, 8, 16);
        public static Rectangle BoomerangWoodTextureAtlasSource => new Rectangle(65, 29, 8, 16);
        public static Rectangle BoomerangSilverTextureAtlasSource => new Rectangle(74, 29, 8, 16);
        public static Rectangle ArrowWoodTextureAtlasSource => new Rectangle(96, 29, 8, 16);
        public static Rectangle ArrowSilverTextureAtlasSource => new Rectangle(105, 29, 8, 16);
        public static Rectangle BowTextureAtlasSource => new Rectangle(114, 29, 8, 16);
        public static Rectangle CandleBlueTextureAtlasSource => new Rectangle(125, 29, 8, 16);
        public static Rectangle CandleOrangeTextureAtlasSource => new Rectangle(134, 29, 8, 16);
        public static Rectangle WhistleTextureAtlasSource => new Rectangle(145, 29, 8, 16);
        public static Rectangle BaitTextureAtlasSource => new Rectangle(156, 29, 8, 16);
        public static Rectangle LetterTextureAtlasSource => new Rectangle(167, 29, 8, 16);
        public static Rectangle WaterBlueTextureAtlasSource => new Rectangle(176, 29, 8, 16);
        public static Rectangle WaterRedTextureAtlasSource => new Rectangle(185, 29, 8, 16);
        public static Rectangle MagicWandTextureAtlasSource => new Rectangle(196, 29, 8, 16);
        public static Rectangle RaftTextureAtlasSource => new Rectangle(0, 48, 16, 16);
        public static Rectangle RingRedTextureAtlasSource => new Rectangle(30, 48, 8, 16);
        public static Rectangle LadderTextureAtlasSource => new Rectangle(41, 48, 16, 16);
        public static Rectangle KeyMagicTextureAtlasSource => new Rectangle(60, 48, 8, 16);
        public static Rectangle PowerBraceletTextureAtlasSource => new Rectangle(71, 48, 8, 16);
        public static Rectangle MapTextureAtlasSource => new Rectangle(82, 48, 8, 16);
        public static Rectangle CompassTextureAtlasSource => new Rectangle(93, 48, 16, 16);
        public static Rectangle SwordWoodTextureAtlasSource => new Rectangle(36, 29, 8, 16);

        // Item Draw Positions in Item Selection Screen (relative to background- not absolute positions)
        public static Point SecondaryItemHudLocation => new Point((int)(68 * Constants.GameScaler), (int)(48 * Constants.GameScaler));
        public static Point MapHudLocation => new Point((int)(48 * Constants.GameScaler), (int)(24 * Constants.GameScaler));
        public static Point CompassHudLocation => new Point((int)(44 * Constants.GameScaler), (int)(64 * Constants.GameScaler));
        public static Point RaftHudLocation => new Point((int)(128 * Constants.GameScaler), (int)(24 * Constants.GameScaler));
        public static Point MagicBookHudLocation => new Point((int)(152 * Constants.GameScaler), (int)(24 * Constants.GameScaler));
        public static Point RingHudLocation => new Point((int)(164 * Constants.GameScaler), (int)(24 * Constants.GameScaler));
        public static Point LadderHudLocation => new Point((int)(176 * Constants.GameScaler), (int)(24 * Constants.GameScaler));
        public static Point KeyMagicHudLocation => new Point((int)(196 * Constants.GameScaler), (int)(24 * Constants.GameScaler));
        public static Point PowerBraceletHudLocation => new Point((int)(208 * Constants.GameScaler), (int)24);
        public static Point BoomerangHudLocation => new Point((int)(132 * Constants.GameScaler), (int)(48 * Constants.GameScaler));
        public static Point BombHudLocation => new Point((int)(156 * Constants.GameScaler), (int)(48 * Constants.GameScaler));
        public static Point ArrowHudLocation => new Point((int)(176 * Constants.GameScaler), (int)(48 * Constants.GameScaler));
        public static Point BowHudLocation => new Point((int)(184 * Constants.GameScaler), (int)(48 * Constants.GameScaler));
        public static Point CandleHudLocation => new Point((int)(204 * Constants.GameScaler), (int)(48 * Constants.GameScaler));
        public static Point WhistleHudLocation => new Point((int)(132 * Constants.GameScaler), (int)(64 * Constants.GameScaler));
        public static Point Empty1HudLocation => new Point((int)(156 * Constants.GameScaler), (int)(64 * Constants.GameScaler));
        public static Point LetterHudLocation => new Point((int)(180 * Constants.GameScaler), (int)(64 * Constants.GameScaler));
        public static Point Empty2HudLocation => new Point((int)(204 * Constants.GameScaler), (int)(64 * Constants.GameScaler));

        //Item Draw Positions in HUD screen
        public static Point LevelNumberLocation = new Point((int)(64 * Constants.GameScaler), (int)(8 * Constants.GameScaler));
        public static Point MinimapLocation = new Point((int)(16 * Constants.GameScaler), (int)(15 * Constants.GameScaler));
        
        // Source Rectangles for Map Pieces in HUDItems.png
        // Codes are binary numbers with each bit representing an opening on a given side order in UpRightDownLeft
        // Example: 1001 means the sprite has an opening on the Up and Left walls
        public static Vector2 MapPieceTextureSize => new Vector2(8, 8);
        public static Rectangle[] MapPieceTextureAtlasSource = new Rectangle[] {
            new Rectangle(0, 0, 8, 8), // 0000
            new Rectangle(18, 0, 8, 8), // 0001
            new Rectangle(36, 0, 8, 8), // 0010
            new Rectangle(54, 0, 8, 8), // 0011

            new Rectangle(9, 0, 8, 8), // 0100
            new Rectangle(27, 0, 8, 8), // 0101
            new Rectangle(45, 0, 8, 8), // 0110
            new Rectangle(63, 0, 8, 8), // 0111
            
            new Rectangle(72, 0, 8, 8), // 1000
            new Rectangle(90, 0, 8, 8), // 1001
            new Rectangle(108, 0, 8, 8), // 1010
            new Rectangle(126, 0, 8, 8), // 1011

            new Rectangle(81, 0, 8, 8), // 1100
            new Rectangle(99, 0, 8, 8), // 1101
            new Rectangle(117, 0, 8, 8), // 1110
            new Rectangle(135, 0, 8, 8) // 1111
        };

        public static Point MapStartPosition => new Point((int)(128 * Constants.GameScaler), (int)(8 * Constants.GameScaler));
        public static Rectangle RoomMarkerTextureAtlasSource => new Rectangle(9, 18, 3, 3);

        public enum InputType
        {
            Keyboard,
            Mouse,
            Gamepad
        }

        public static OldInputState GetOldInputState(List<IController> controllerList)
        {
            OldInputState oldInputState = new OldInputState();

            foreach (IController controller in controllerList)
            {
                switch (controller.GetInputType())
                {
                    case InputType.Keyboard:
                        oldInputState.oldKeyboardState = controller.GetOldInputState().oldKeyboardState;
                        break;

                    case InputType.Mouse:
                        oldInputState.oldMouseState = controller.GetOldInputState().oldMouseState;
                        break;
                }
            }

            return oldInputState;
        }
    }
}
