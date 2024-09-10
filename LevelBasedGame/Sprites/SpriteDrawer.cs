using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Numerics;

namespace LevelBasedGame.Sprites {
    internal static class SpriteDrawer {

        private class DictsComparator : IComparer<(SpriteDict, int priority)> {
            public int Compare((SpriteDict, int priority) x, (SpriteDict, int priority) y) {
                if (x.priority < y.priority) {
                    return -1;
                }
                if (x.priority == y.priority) {
                    return 0;
                }
                return 1;
            }
        }

        private static List<(SpriteDict spriteDict, int priority)> dicts = new();

        public static void AddSpriteDict(SpriteDict spriteDict, int priority) {
            dicts.Add((spriteDict, priority));
            dicts.Sort(new DictsComparator());
            //optimization: only sort list after all initial SpriteDicts are added
        }

        public static void Draw(SpriteBatch spriteBatch, GameTime gameTime) {
            foreach(var x in dicts) {
                x.spriteDict.Draw(spriteBatch, gameTime);
            }
        }
    }
}
