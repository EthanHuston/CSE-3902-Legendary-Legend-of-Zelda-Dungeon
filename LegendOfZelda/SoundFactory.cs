using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;

namespace LegendOfZelda
{
    internal class SoundFactory
    {
        private SoundEffect friday_night;
        private SoundEffect arrow_boomerang;
        private SoundEffect bomb_blow;
        private SoundEffect bomb_drop;
        private SoundEffect boss_hit;
        private SoundEffect boss_scream;
        private SoundEffect clock_pickup;
        private SoundEffect door_unlock;
        private SoundEffect dungeon_music;
        private SoundEffect enemy_die;
        private SoundEffect enemy_hit;
        private SoundEffect fanfare;
        private SoundEffect game_over;
        private SoundEffect get_heart;
        private SoundEffect get_item;
        private SoundEffect get_rupee;
        private SoundEffect key_appear;
        private SoundEffect link_die;
        private SoundEffect link_hurt;
        private SoundEffect low_health;
        private SoundEffect refill;
        private SoundEffect secret;
        private SoundEffect shield;
        private SoundEffect stairs;
        private SoundEffect sword_combined;
        private SoundEffect sword_shoot;
        private SoundEffect sword_slash;
        private SoundEffect text;
        private SoundEffect time_flows;
        private SoundEffect title;
        private SoundEffect win;

        private ContentManager contentManager;
        public static SoundFactory Instance { get; } = new SoundFactory();

        public void LoadAllSounds(ContentManager content)
        {
            contentManager = content;
            arrow_boomerang = content.Load<SoundEffect>("Sounds/LOZ_Arrow_Boomerang");
            bomb_blow = content.Load<SoundEffect>("Sounds/LOZ_Bomb_Blow");
            bomb_drop = content.Load<SoundEffect>("Sounds/LOZ_Bomb_Drop");
            boss_hit = content.Load<SoundEffect>("Sounds/LOZ_Boss_Hit");
            boss_scream = content.Load<SoundEffect>("Sounds/LOZ_Boss_Scream1");
            clock_pickup = content.Load<SoundEffect>("Sounds/LOZ_Get_Item");
            door_unlock = content.Load<SoundEffect>("Sounds/LOZ_Door_Unlock");
            dungeon_music = content.Load<SoundEffect>("Sounds/LOZ_Dungeon");
            enemy_die = content.Load<SoundEffect>("Sounds/LOZ_Enemy_Die");
            enemy_hit = content.Load<SoundEffect>("Sounds/LOZ_Enemy_Hit");
            fanfare = content.Load<SoundEffect>("Sounds/LOZ_Fanfare");
            friday_night = content.Load<SoundEffect>("Sounds/Friday_Night");
            game_over = content.Load<SoundEffect>("Sounds/LOZ_GameOver");
            get_heart = content.Load<SoundEffect>("Sounds/LOZ_Get_Heart");
            get_item = content.Load<SoundEffect>("Sounds/LOZ_Get_Item");
            get_rupee = content.Load<SoundEffect>("Sounds/LOZ_Get_Rupee");
            key_appear = content.Load<SoundEffect>("Sounds/LOZ_Key_Appear");
            link_die = content.Load<SoundEffect>("Sounds/LOZ_Link_Die");
            link_hurt = content.Load<SoundEffect>("Sounds/LOZ_Link_Hurt");
            low_health = content.Load<SoundEffect>("Sounds/LOZ_LowHealth");
            refill = content.Load<SoundEffect>("Sounds/LOZ_Refill_Loop");
            secret = content.Load<SoundEffect>("Sounds/LOZ_Secret");
            shield = content.Load<SoundEffect>("Sounds/LOZ_Shield");
            stairs = content.Load<SoundEffect>("Sounds/LOZ_Stairs");
            sword_combined = content.Load<SoundEffect>("Sounds/LOZ_Sword_Combined");
            sword_shoot = content.Load<SoundEffect>("Sounds/LOZ_Sword_Shoot");
            sword_slash = content.Load<SoundEffect>("Sounds/LOZ_Sword_Slash");
            text = content.Load<SoundEffect>("Sounds/LOZ_Text");
            win = content.Load<SoundEffect>("Sounds/LOZ_Win");
        }

        public void LoadTitleSound(ContentManager content)
        {
            title = content.Load<SoundEffect>("Sounds/LOZ_Title");
        }

        public void LoadJojoSounds()
        {
            clock_pickup = contentManager.Load<SoundEffect>("Sounds/LOZ_ClockPickUp");
            time_flows = contentManager.Load<SoundEffect>("Sounds/LOZ_TimeFlows");
        }

        public void LoadYakuzaSounds()
        {
            dungeon_music = contentManager.Load<SoundEffect>("Sounds/Baka_Mitai");
        }

        public SoundEffectInstance CreateFridayNightSound()
        {
            return friday_night.CreateInstance();
        }
        public SoundEffectInstance CreateArrowBoomerangSound()
        {
            return arrow_boomerang.CreateInstance();
        }

        public SoundEffectInstance CreateBombBlowSound()
        {
            return bomb_blow.CreateInstance();
        }

        public SoundEffectInstance CreateBombDropSound()
        {
            return bomb_drop.CreateInstance();
        }

        public SoundEffectInstance CreateBossHitSound()
        {
            return boss_hit.CreateInstance();
        }

        public SoundEffectInstance CreateBossScreamSound()
        {
            return boss_scream.CreateInstance();
        }

        public SoundEffectInstance CreateClockPickUpSound()
        {
            return clock_pickup.CreateInstance();
        }

        public SoundEffectInstance CreateDoorUnlockSound()
        {
            return door_unlock.CreateInstance();
        }

        public SoundEffectInstance CreateDungeonMusicSound()
        {
            return dungeon_music.CreateInstance();
        }

        public SoundEffectInstance CreateEnemyDieSound()
        {
            return enemy_die.CreateInstance();
        }

        public SoundEffectInstance CreateEnemyHitSound()
        {
            return enemy_hit.CreateInstance();
        }

        public SoundEffectInstance CreateFanfareSound()
        {
            return fanfare.CreateInstance();
        }

        public SoundEffectInstance CreateGameOverSound()
        {
            return game_over.CreateInstance();
        }

        public SoundEffectInstance CreateGetHeartSound()
        {
            return get_heart.CreateInstance();
        }

        public SoundEffectInstance CreateGetItemSound()
        {
            return get_item.CreateInstance();
        }

        public SoundEffectInstance CreateGetRupeeSound()
        {
            return get_rupee.CreateInstance();
        }

        public SoundEffectInstance CreateKeyAppearSound()
        {
            return key_appear.CreateInstance();
        }

        public SoundEffectInstance CreateLinkDieSound()
        {
            return link_die.CreateInstance();
        }

        public SoundEffectInstance CreateLinkHurtSound()
        {
            return link_hurt.CreateInstance();
        }

        public SoundEffectInstance CreateLowHealthSound()
        {
            return low_health.CreateInstance();
        }

        public SoundEffectInstance CreateRefillSound()
        {
            return refill.CreateInstance();
        }

        public SoundEffectInstance CreateSecretSound()
        {
            return secret.CreateInstance();
        }

        public SoundEffectInstance CreateShieldSound()
        {
            return shield.CreateInstance();
        }

        public SoundEffectInstance CreateStairsSound()
        {
            return stairs.CreateInstance();
        }

        public SoundEffectInstance CreateSwordCombinedSound()
        {
            return sword_combined.CreateInstance();
        }

        public SoundEffectInstance CreateSwordShootSound()
        {
            return sword_shoot.CreateInstance();
        }

        public SoundEffectInstance CreateSwordSlashSound()
        {
            return sword_slash.CreateInstance();
        }

        public SoundEffectInstance CreateTextSound()
        {
            return text.CreateInstance();
        }

        public SoundEffectInstance CreateTimeFlowsSound()
        {
            return time_flows == null ? null : time_flows.CreateInstance();
        }

        public SoundEffectInstance CreateTitleSound()
        {
            return title.CreateInstance();
        }

        public SoundEffectInstance CreateWinSound()
        {
            return win.CreateInstance();
        }
    }
}
