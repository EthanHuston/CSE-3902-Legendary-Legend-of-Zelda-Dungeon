using LegendOfZelda.GameState.RoomTransitionState;
using LegendOfZelda.Link.Interface;
using Microsoft.Xna.Framework.Audio;
using System.Collections.Generic;

namespace LegendOfZelda.Rooms.RoomImplementation
{
    class RoomOfTheDisco : Room
    {
        private readonly SoundEffectInstance discoMusic;

        public RoomOfTheDisco(List<IPlayer> playerList, Game1 game) : base(playerList, game)
        {
            discoMusic = SoundFactory.Instance.CreateFridayNightSound();
        }

        public override void RunRoomEntryProcedure()
        {
            ((RoomTransitionGameState)Game.State).RoomGameState.DungeonMusic.Pause();
            discoMusic.Play();
            base.RunRoomEntryProcedure();
        }

        public override void RunRoomExitProcedure()
        {
            discoMusic.Stop();
            ((RoomTransitionGameState)Game.State).RoomGameState.DungeonMusic.Resume();
            base.RunRoomExitProcedure();
        }
    }
}
