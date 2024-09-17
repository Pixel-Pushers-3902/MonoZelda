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
using PixelPushers.MonoZelda.Sprites;

namespace MonoZelda.Controllers
{
    public class EnemyController
    {
        private IEnemy enemy;
        private readonly IEnemy[] enemyArr;
        private int index;
        private readonly int length;
        private readonly MonoZeldaGame myGame;

        public EnemyController(MonoZeldaGame game)
        {
            myGame = game;
            string playerCsvFileName = "Content/Sprite Source Rects - Player.csv";
            SpriteDict keeseSpriteDict = new(myGame.Content.Load<Texture2D>("Sprites/player"), playerCsvFileName, 1, new Point(100, 100));
            SpriteDict goriyaSpriteDict = new(myGame.Content.Load<Texture2D>("Sprites/player"), playerCsvFileName, 1, new Point(100, 100));
            enemyArr = new IEnemy[]
            {
                new Keese(keeseSpriteDict),
                new Goriya(goriyaSpriteDict)
            };
            index = 0;
            enemy = enemyArr[index];
            length = enemyArr.Length;
        }

        public void CycleEnemy(int cycle)
        {
            index += cycle;
            if (index >= length)
            {
                index = 0;
            }else if (index < 0)
            {
                index = length-1;
            }
        }

        public IEnemy SetEnemy()
        {
            enemyArr[index].SetOgPos();
            return enemyArr[index];
        }
    }
}
