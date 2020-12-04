using LegendOfZelda.GameState.RoomsState;
using LegendOfZelda.Link.Interface;
using Microsoft.Xna.Framework.Audio;
using System.Collections.Generic;

namespace LegendOfZelda.Rooms.RoomImplementation
{
    class RoomOfTheDisco : Room
    {
        private SoundEffectInstance discoMusic;

        public RoomOfTheDisco(List<IPlayer> playerList, Game1 game) : base(playerList, game)
        {
            // TODO: PATEL ADD YOUR MUSIC HERE
            discoMusic = SoundFactory.Instance.CreateFridayNightSound();
        }

        public override void RunRoomEntryProcedure()
        {
            ((RoomGameState)Game.State).DungeonMusic.Pause();
            // TODO: PATEL PLAY YOUR MUSIC HERE
            discoMusic.Play();
            base.RunRoomEntryProcedure();
        }

        public override void RunRoomExitProcedure()
        {
            // TODO: PATEL STOP YOUR MUSIC HERE
            discoMusic.Stop();
            ((RoomGameState)Game.State).DungeonMusic.Resume();
            base.RunRoomExitProcedure();
        }
    }
}
