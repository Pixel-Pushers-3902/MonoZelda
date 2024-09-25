using Microsoft.Xna.Framework;
using MonoZelda.Enemies.AquamentusFolder;
using MonoZelda.Enemies.GelFolder;
using MonoZelda.Enemies.GoriyaFolder;
using MonoZelda.Enemies.KeeseFolder;
using MonoZelda.Enemies.OldmanFolder;
using MonoZelda.Enemies.StalfosFolder;
using MonoZelda.Enemies.TrapFolder;
using MonoZelda.Enemies.WallmasterFolder;
using MonoZelda.Enemies.ZolFolder;
using PixelPushers.MonoZelda;
using PixelPushers.MonoZelda.Commands;
using PixelPushers.MonoZelda.Sprites;

namespace MonoZelda.Enemies
{
    public class EnemyCycler
    {
        public IEnemy Enemy;
        private IEnemy[] enemyArr;
        private int index;
        private int length;
        private readonly CommandManager commandManager;
        private SpriteDict spriteDict;
        private GraphicsDeviceManager graphics;
        private double startTime;
        private bool changingSprite = false;

        public EnemyCycler(CommandManager commandManager, GraphicsDeviceManager graphics)
        {
            this.commandManager = commandManager;
            this.graphics = graphics;
        }

        public void SetSpriteDicts(SpriteDict spriteDict)
        {
            this.spriteDict = spriteDict;

            enemyArr = new IEnemy[]
            {
                new Keese(spriteDict, graphics),
                new Goriya(spriteDict, graphics),
                new Stalfos(spriteDict, graphics),
                new Gel(spriteDict, graphics),
                new Zol(spriteDict, graphics),
                new Wallmaster(spriteDict, graphics),
                new Trap(spriteDict, graphics, TrapStateMachine.Direction.Left),
                new Trap(spriteDict, graphics, TrapStateMachine.Direction.Right),
                new Trap(spriteDict, graphics, TrapStateMachine.Direction.Up),
                new Trap(spriteDict, graphics, TrapStateMachine.Direction.Down),
                new Aquamentus(spriteDict, graphics),
                new Oldman(spriteDict, graphics)
            };

            index = 0;
            length = enemyArr.Length;
        }

        public void SetCycle(int cycle)
        {
            index += cycle;
            if (index >= length)
            {
                index = 0;
            }
            else if (index < 0)
            {
                index = length - 1;
            }
            changingSprite = true;
            spriteDict.SetSprite("death");
        }

        public bool Update(GameTime gameTime)
        {
            if (changingSprite)
            {
                startTime = gameTime.TotalGameTime.TotalSeconds;
                changingSprite = false;
            }
            if(gameTime.TotalGameTime.TotalSeconds >= startTime + 0.5)
            {
                if (gameTime.TotalGameTime.TotalSeconds >= startTime + 0.6)
                {
                    enemyArr[index].Update(gameTime);
                }
                else
                {
                    enemyArr[index].SetOgPos();
                }
            }
            return true;
        }
    }
}
