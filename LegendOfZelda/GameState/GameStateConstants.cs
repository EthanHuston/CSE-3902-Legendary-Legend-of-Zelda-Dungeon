using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace LegendOfZelda.GameState
{
    static class GameStateConstants
    {
        private const double gameScaler = Constants.GameScaler;

        // Button Positions
        public static Point PauseStateResumeButtonLocation => new Point((int)(gameScaler * 48), (int)(gameScaler * 64));
        public static Point PauseStateExitButtonLocation => new Point((int)(gameScaler * 96), (int)(gameScaler * 96));
        public static Point PauseStateMainMenuButtonLocation => new Point((int)(gameScaler * 144), (int)(gameScaler * 64));



        // Item Positions in HudItems.png Texture Atlas
        public static Vector2 StandardItemSpriteSize => new Vector2(8, 16);
        public static Point BombTextureAtlasLocation => new Point(85, 29);
        public static Point BoomerangWoodTextureAtlasLocation => new Point(65, 29);
        public static Point BoomerangSilverTextureAtlasLocation => new Point(74, 29);
        public static Point ArrowWoodTextureAtlasLocation => new Point(96, 29);
        public static Point ArrowSilverTextureAtlasLocation => new Point(105, 29);
        public static Point BowTextureAtlasLocation => new Point(114, 29);
        public static Point CandleBlueTextureAtlasLocation => new Point(125, 29);
        public static Point CandleOrangeTextureAtlasLocation => new Point(134, 29);
        public static Point WhistleTextureAtlasLocation => new Point(145, 29);
        public static Point BaitTextureAtlasLocation => new Point(156, 29);
        public static Point LetterTextureAtlasLocation => new Point(167, 29);
        public static Point WaterBlueTextureAtlasLocation => new Point(176, 29);
        public static Point WaterRedTextureAtlasLocation => new Point(185, 29);
        public static Point MagicWandTextureAtlasLocation => new Point(196, 29);
        public static Point RaftTextureAtlasLocation => new Point(0, 48);
        public static Point RingRedTextureAtlasLocation => new Point(30, 48);
        public static Point LadderTextureAtlasLocation => new Point(41, 48);
        public static Point KeyMagicTextureAtlasLocation => new Point(60, 48);
        public static Point PowerBraceletTextureAtlasLocation => new Point(71, 48);
        public static Point MapTextureAtlasLocation => new Point(82, 48);
        public static Point CompassTextureAtlasLocation => new Point(93, 48);

        // Item Draw Positions in Item Selection Screen (relative to background- not absolute positions)
        public static Point SecondaryItemHudLocation => new Point(68, 48);
        public static Point MapHudLocation => new Point(48, 112);
        public static Point CompassHudLocation => new Point(44, 152);
        public static Point RaftHudLocation => new Point(128, 24);
        public static Point MagicBookHudLocation => new Point(152, 24);
        public static Point RingHudLocation => new Point(164, 24);
        public static Point LadderHudLocation => new Point(176, 24);
        public static Point KeyMagicHudLocation => new Point(196, 24);
        public static Point PowerBraceletHudLocation => new Point(208, 24);
        public static Point BoomerangHudLocation => new Point(132, 48);
        public static Point BombHudLocation => new Point(156, 48);
        public static Point ArrowHudLocation => new Point(176, 48);
        public static Point BowHudLocation => new Point(184, 48);
        public static Point CandleHudLocation => new Point(204, 48);
        public static Point WhistleHudLocation => new Point(132, 64);
        public static Point Empty1HudLocation => new Point(156, 64);
        public static Point LetterHudLocation => new Point(180, 64);
        public static Point Empty2HudLocation => new Point(204, 64);



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
