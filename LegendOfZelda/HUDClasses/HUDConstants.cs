using Microsoft.Xna.Framework;
using System.Collections.Generic;

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
        public static Point RupeePos = new Point(RupeeNumberX, RupeeNumberY);
        public const int KeyNumberX = (int)(96 * Constants.GameScaler);
        public const int KeyNumberY = (int)(32 * Constants.GameScaler);
        public const int BombNumberX = (int)(96 * Constants.GameScaler);
        public const int BombNumberY = (int)(40 * Constants.GameScaler);
        public const int HeartX = (int)(184 * Constants.GameScaler);
        public const int HeartY = (int)(32 * Constants.GameScaler);
        public static Point HeartPos = new Point(HeartX, HeartY);
        public const int NumberWidth = (int)(8 * Constants.GameScaler);
        public static Point SecondaryItemLocation = new Point((int)(Constants.GameScaler * 128), (int)(Constants.GameScaler * 24));
        public static Point PrimaryItemLocation = new Point((int)(Constants.GameScaler * 152), (int)(Constants.GameScaler * 24));

        //Player 2 locations
        public const int hudHeightMultiplayer = (int)(100 * Constants.GameScaler);
        public const int RupeeNumberXPlayer2 = (int)(96 * Constants.GameScaler);
        public const int RupeeNumberYPlayer2 = (int)(62 * Constants.GameScaler);
        public static Point RupeePosPlayer2 = new Point(RupeeNumberXPlayer2, RupeeNumberYPlayer2);
        public const int KeyNumberXPlayer2 = (int)(96 * Constants.GameScaler);
        public const int KeyNumberYPlayer2 = (int)(78 * Constants.GameScaler);
        public const int BombNumberXPlayer2 = (int)(96 * Constants.GameScaler);
        public const int BombNumberYPlayer2 = (int)(86 * Constants.GameScaler);
        public const int HeartXPlayer2 = (int)(184 * Constants.GameScaler);
        public const int HeartYPlayer2 = (int)(78 * Constants.GameScaler);
        public static Point HeartPosPlayer2 = new Point(HeartXPlayer2, HeartYPlayer2);
        public static Point SecondaryItemLocationPlayer2 = new Point((int)(Constants.GameScaler * 128), (int)(Constants.GameScaler * 70));
        public static Point PrimaryItemLocationPlayer2 = new Point((int)(Constants.GameScaler * 152), (int)(Constants.GameScaler * 70));

        //Minimap Square Locations
        public static Dictionary<Point, Point> MinimapSquarePositions = new Dictionary<Point, Point>
        {
            { new Point(1, 0), new Point((int)(30 * Constants.GameScaler), (int)(43 * Constants.GameScaler)) },
            { new Point(2, 0), new Point((int)(38 * Constants.GameScaler), (int)(43 * Constants.GameScaler)) },
            { new Point(3, 0), new Point((int)(46 * Constants.GameScaler), (int)(43 * Constants.GameScaler)) },
            { new Point(2, 1), new Point((int)(38 * Constants.GameScaler), (int)(39 * Constants.GameScaler)) },
            { new Point(1, 2), new Point((int)(30 * Constants.GameScaler), (int)(35 * Constants.GameScaler)) },
            { new Point(2, 2), new Point((int)(38 * Constants.GameScaler), (int)(35 * Constants.GameScaler)) },
            { new Point(3, 2), new Point((int)(46 * Constants.GameScaler), (int)(35 * Constants.GameScaler)) },
            { new Point(0, 3), new Point((int)(22 * Constants.GameScaler), (int)(31 * Constants.GameScaler)) },
            { new Point(1, 3), new Point((int)(30 * Constants.GameScaler), (int)(31 * Constants.GameScaler)) },
            { new Point(2, 3), new Point((int)(38 * Constants.GameScaler), (int)(31 * Constants.GameScaler)) },
            { new Point(3, 3), new Point((int)(46 * Constants.GameScaler), (int)(31 * Constants.GameScaler)) },
            { new Point(4, 3), new Point((int)(54 * Constants.GameScaler), (int)(31 * Constants.GameScaler)) },
            { new Point(2, 4), new Point((int)(38 * Constants.GameScaler), (int)(27 * Constants.GameScaler)) },
            { new Point(4, 4), new Point((int)(54 * Constants.GameScaler), (int)(27 * Constants.GameScaler)) },
            { new Point(5, 4), new Point((int)(62 * Constants.GameScaler), (int)(27 * Constants.GameScaler)) },
            { new Point(1, 5), new Point((int)(30 * Constants.GameScaler), (int)(23 * Constants.GameScaler)) },
            { new Point(2, 5), new Point((int)(38 * Constants.GameScaler), (int)(23 * Constants.GameScaler)) },
        };

        //Locations on HUDItemSpriteSheet
        public const int EmptyHeartX = 108, EmptyHeartY = 9;
        public const int HalfHeartX = 116, HalfHeartY = 9;
        public const int FullHeartX = 124, FullHeartY = 9;

        //Item Draw Positions in HUD screen (relative to HUD position)
        public static Point LevelNumberLocation => new Point((int)(64 * Constants.GameScaler), (int)(8 * Constants.GameScaler));
        public static Point MinimapLocation => new Point((int)(16 * Constants.GameScaler), (int)(15 * Constants.GameScaler));
    }
}
