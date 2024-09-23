using Microsoft.Xna.Framework;
using MonoZelda.Enemies.GelFolder;
using MonoZelda.Enemies.GoriyaFolder;
using MonoZelda.Enemies.KeeseFolder;
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

        private GameState gameState;

        public GameState GameState
        {
            get
            {
                return gameState;
            }
            set
            {
                gameState = value;
            }
        }

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
                new Trap(spriteDict, graphics, TrapStateMachine.Direction.Down)
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
            enemyArr[index].SetOgPos();
        }

        public bool Update(GameTime gameTime)
        {
            enemyArr[index].Update(gameTime);
            return true;
        }
    }
}
