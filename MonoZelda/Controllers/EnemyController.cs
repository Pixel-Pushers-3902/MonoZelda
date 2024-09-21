using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoZelda.Enemies;
using PixelPushers.MonoZelda;
using PixelPushers.MonoZelda.Commands;
using PixelPushers.MonoZelda.Controllers;
using PixelPushers.MonoZelda.Sprites;

namespace MonoZelda.Controllers
{
    public class EnemyController
    {
        public IEnemy Enemy;
        private IEnemy[] enemyArr;
        private int index;
        private int length;
        private readonly CommandManager commandManager;
        private SpriteDict spriteDict;

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

        public EnemyController(CommandManager commandManager)
        {
            this.commandManager = commandManager;
        }

        public void SetSpriteDicts(SpriteDict spriteDict)
        {
            this.spriteDict = spriteDict;

            enemyArr = new IEnemy[]
            {
                new Keese(spriteDict),
                new Goriya(spriteDict)
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

        public bool Update()
        {
            enemyArr[index].Update();
            return true;
        }
    }
}
