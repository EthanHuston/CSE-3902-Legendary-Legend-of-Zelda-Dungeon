using LegendOfZelda.HUDClasses;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace LegendOfZelda.GameState.Utilities
{
    internal static class GameStateConstants
    {
        private const double gameScaler = Constants.GameScaler;

        public const int ClockModeLengthMs = 5000;

        public static Rectangle MainMenuTextureMapSource => new Rectangle(0, 0, 260, 232);

        // Button Positions
        public static Point PauseStateResumeButtonLocation => new Point((int)(gameScaler * 48), (int)(gameScaler * 64));
        public static Point PauseStateExitButtonLocation => new Point((int)(gameScaler * 96), (int)(gameScaler * 96));
        public static Point PauseStateMainMenuButtonLocation => new Point((int)(gameScaler * 144), (int)(gameScaler * 64));
        public static Point LoseStateRetryButtonLocation => new Point((int)(gameScaler * 96), (int)(gameScaler * 64));
        public static Point LoseStateExitButtonLocation => new Point((int)(gameScaler * 96), (int)(gameScaler * 96));
        public static Point LoseStateGameOverSpriteLocation => new Point((int)(gameScaler * 65), (int)(gameScaler * 96));

        // Black Overlay for Win State
        public static Point WinStateSpriteLocationLeft => new Point((int)(gameScaler * -1 * Constants.MaxXPos), HUDConstants.hudHeight);
        public static Point WinStateSpriteLocationRight => new Point((int)(gameScaler * Constants.MaxXPos), HUDConstants.hudHeight);


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
        public static Rectangle RoomMarkerTextureAtlasSource => new Rectangle(9, 18, 3, 3);
    }

    enum InputType
    {
        Keyboard,
        Mouse,
        Gamepad
    }

    struct InputStates
    {
        public MouseState MouseState;
        public KeyboardState KeyboardState;
        public GamePadState GamePadState;
    }

    enum MouseButton
    {
        LeftButton,
        MiddleButton,
        RightButton
    }
}
