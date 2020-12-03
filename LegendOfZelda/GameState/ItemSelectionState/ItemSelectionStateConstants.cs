using LegendOfZelda.GameState.Utilities;
using Microsoft.Xna.Framework;

namespace LegendOfZelda.GameState.ItemSelectionState
{
    internal static class ItemSelectionStateConstants
    {
        private const double gameScaler = Constants.GameScaler;

        // Misc Constants
        public static Vector2 CameraVelocity => new Vector2(0, 15);
        public const int CameraPanDistance = InventoryPaneHeight + MapPaneHeight;

        // Pane Positions
        public const int InventoryPaneHeight = (int)(88 * gameScaler);
        public const int MapPaneHeight = (int)(88 * gameScaler);
        public static Point InventoryPaneStartPosition => new Point((int)(gameScaler * 0), -1 * (InventoryPaneHeight + MapPaneHeight));
        public static Point MapPaneStartPosition => new Point((int)(gameScaler * 0), InventoryPaneStartPosition.Y + InventoryPaneHeight);
        public static Point HudPaneStartPosition => new Point(0, InventoryPaneHeight + MapPaneHeight);

        // Item Draw Positions in Item Selection Screen (relative to background- not absolute positions)
        public static Point SecondaryItemHudLocation => new Point((int)(68 * Constants.GameScaler), (int)(48 * Constants.GameScaler));
        public static Point MapHudLocation => new Point((int)(48 * Constants.GameScaler), (int)(24 * Constants.GameScaler));
        public static Point CompassHudLocation => new Point((int)(44 * Constants.GameScaler), (int)(64 * Constants.GameScaler));
        public static Point RaftHudLocation => new Point((int)(128 * Constants.GameScaler), (int)(24 * Constants.GameScaler));
        public static Point MagicBookHudLocation => new Point((int)(152 * Constants.GameScaler), (int)(24 * Constants.GameScaler));
        public static Point RingHudLocation => new Point((int)(164 * Constants.GameScaler), (int)(24 * Constants.GameScaler));
        public static Point LadderHudLocation => new Point((int)(176 * Constants.GameScaler), (int)(24 * Constants.GameScaler));
        public static Point KeyMagicHudLocation => new Point((int)(196 * Constants.GameScaler), (int)(24 * Constants.GameScaler));
        public static Point PowerBraceletHudLocation => new Point((int)(208 * Constants.GameScaler), 24);
        public static Point BoomerangHudLocation => new Point((int)(132 * Constants.GameScaler), (int)(48 * Constants.GameScaler));
        public static Point BombHudLocation => new Point((int)(156 * Constants.GameScaler), (int)(48 * Constants.GameScaler));
        public static Point ArrowHudLocation => new Point((int)(176 * Constants.GameScaler), (int)(48 * Constants.GameScaler));
        public static Point BowHudLocation => new Point((int)(184 * Constants.GameScaler), (int)(48 * Constants.GameScaler));
        public static Point CandleHudLocation => new Point((int)(204 * Constants.GameScaler), (int)(48 * Constants.GameScaler));
        public static Point WhistleHudLocation => new Point((int)(132 * Constants.GameScaler), (int)(64 * Constants.GameScaler));
        public static Point Empty1HudLocation => new Point((int)(156 * Constants.GameScaler), (int)(64 * Constants.GameScaler));
        public static Point LetterHudLocation => new Point((int)(180 * Constants.GameScaler), (int)(64 * Constants.GameScaler));
        public static Point Empty2HudLocation => new Point((int)(204 * Constants.GameScaler), (int)(64 * Constants.GameScaler));

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

        public static Point MapPosition => new Point((int)(128 * Constants.GameScaler), (int)(8 * Constants.GameScaler));
        public static Point RoomMarkerDrawOffset => new Point((int)(MapPieceTextureSize.X / 2 * gameScaler - GameStateConstants.RoomMarkerTextureAtlasSource.Width), (int)(MapPieceTextureSize.Y / 2 * gameScaler - GameStateConstants.RoomMarkerTextureAtlasSource.Height));
    }
}
