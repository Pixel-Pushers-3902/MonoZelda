using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using MonoZelda.Enemies.EnemyStateMachines;
using PixelPushers.MonoZelda.Sprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoZelda.Enemies
{
    internal class Goriya : IEnemy
    {
        private readonly GoriyaStateMachine stateMachine;
        private int horDelay = 0;
        private int vertDelay = 0;
        private int attackDelay = 0; //delay before attacking
        private int attacking = 0; //delay while attacking
        private readonly Random rnd = new();
        private Point pos = new(250, 250); // will change later
        private readonly SpriteDict goriyaSpriteDict;
        //vertDirection and horDirection should only be None at the same time when attacking and should never have a value other than None at the same time.
        private GoriyaStateMachine.VertDirection vertDirection = GoriyaStateMachine.VertDirection.None;
        private GoriyaStateMachine.HorDirection horDirection = GoriyaStateMachine.HorDirection.Right;

        public Goriya(SpriteDict spriteDict)
        {
            this.goriyaSpriteDict = spriteDict;
            stateMachine = new GoriyaStateMachine();
            goriyaSpriteDict.SetSprite("walk_left"); //using link sprites for now
        }

        public void SetOgPos() //sets to spawn position (eventually could be used for re-entering rooms)
        {
            pos.X = 250;
            pos.Y = 250;
        }

        public void Attack()
        {
            
            if (attacking <= 100) //while enemy is attacking it cant move. Eventually change to GameTime
            {
                horDelay = 0;
                vertDelay = 0;
                attacking++;
            }
            else
            {
                attacking = 0;
                attackDelay = 0;
                horDirection = GoriyaStateMachine.HorDirection.Left;
            }
            
        }

        public void ChangeHorDirection()
        {
            stateMachine.ChangeHorDirection(horDirection);
        }

        public void ChangeVertDirection()
        {
            stateMachine.ChangeVertDirection(vertDirection);
        }

        public void Update() //might eventually split this into multiple methods, controlling random movement is more extensive than I thought.
        {
            if (attackDelay >= 200) //eventually change to GameTime
            {
                attackDelay = 0;
                stateMachine.Attack();
                Attack();
            }
            if (horDelay >= rnd.Next(50, 100))
            {
                if (vertDirection == GoriyaStateMachine.VertDirection.None)
                {
                    switch (rnd.Next(1, 4))
                    {
                        case 1:
                            //if horDirection becomes None then vertDirection cannot be None
                            horDirection = GoriyaStateMachine.HorDirection.None;
                            switch (rnd.Next(1, 3))
                            {
                                case 1:
                                    vertDirection = GoriyaStateMachine.VertDirection.Up;
                                    break;
                                case 2:
                                    vertDirection = GoriyaStateMachine.VertDirection.Down;
                                    break;
                            }
                            break;
                        case 2:
                            horDirection = GoriyaStateMachine.HorDirection.Right;
                            break;
                        case 3:
                            horDirection = GoriyaStateMachine.HorDirection.Left;
                            break;
                    }
                    ChangeHorDirection();
                    horDelay = 0;
                }

            }

            if (vertDelay >= rnd.Next(50, 100))
            {
                if (horDirection == GoriyaStateMachine.HorDirection.None)
                {
                    switch (rnd.Next(1, 4))
                    {
                        case 1:
                            //if vertDirection becomes None then horDirection cannot be None
                            vertDirection = GoriyaStateMachine.VertDirection.None;
                            switch (rnd.Next(1,3))
                            {
                                case 1:
                                    horDirection = GoriyaStateMachine.HorDirection.Left;
                                    break;
                                case 2:
                                    horDirection = GoriyaStateMachine.HorDirection.Right;
                                    break;
                            }
                            break;
                        case 2:
                            vertDirection = GoriyaStateMachine.VertDirection.Up;
                            break;
                        case 3:
                            vertDirection = GoriyaStateMachine.VertDirection.Down;
                            break;
                    }
                    ChangeVertDirection();
                    vertDelay = 0;
                }
            }

            horDelay += rnd.Next(3);
            vertDelay += rnd.Next(3);
            attackDelay++;

            stateMachine.UpdateSprite(goriyaSpriteDict);
            pos = stateMachine.Update(pos); // calls to stateMachine for position updates
            goriyaSpriteDict.Position = pos; // updates position
        }

        public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            goriyaSpriteDict.Draw(spriteBatch, gameTime);
        }
    }
}
