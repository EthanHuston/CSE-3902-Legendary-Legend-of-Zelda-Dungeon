using Microsoft.Xna.Framework;

namespace LegendOfZelda.HUDClasses
{
    public static class HUDConstants
    {
        public const int hudx = 0, hudy = 0;
        public const int hudWidth = (int)(256 * Constants.GameScaler);
        public const int hudHeight = (int)(56 * Constants.GameScaler);

        //Locations on HUD
        public const int RupeeNumberX = (int)(96 * Constants.GameScaler);
        public const int RupeeNumberY = (int)(16 * Constants.GameScaler);
        public const int KeyNumberX = (int)(96 * Constants.GameScaler);
        public const int KeyNumberY = (int)(32 * Constants.GameScaler);
        public const int BombNumberX = (int)(96 * Constants.GameScaler);
        public const int BombNumberY = (int)(40 * Constants.GameScaler);
        public const int HeartX = (int)(184 * Constants.GameScaler);
        public const int HeartY = (int)(32 * Constants.GameScaler);
        public const int NumberWidth = (int)(8 * Constants.GameScaler);

        //Locations on HUDItemSpriteSheet
        public const int EmptyHeartX = 108, EmptyHeartY = 9;
        public const int HalfHeartX = 116, HalfHeartY = 9;
        public const int FullHeartX = 124, FullHeartY = 9;

    }
}
