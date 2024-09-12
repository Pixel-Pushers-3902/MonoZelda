using Microsoft.VisualBasic.FileIO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Diagnostics;

namespace LevelBasedGame.Sprites {
    internal class SpriteSheetParser
    {
        private Texture2D sheet;

        public SpriteSheetParser(Texture2D sheet) {
            this.sheet = sheet;
        }

        public SpriteDict Parse() {
            SpriteDict spriteDict = new(sheet, new Point(100, 100));
            string fileName = "Content/Sprite Source Rects - Player.csv";
            using TextFieldParser textFieldParser = new(fileName);
            textFieldParser.TextFieldType = FieldType.Delimited;
            textFieldParser.SetDelimiters(",");
            while (!textFieldParser.EndOfData) {
                string[] rows = textFieldParser.ReadFields();
                Debug.WriteLine(rows[0]);
                spriteDict.Add(ParseSprite(rows), rows[0]);
            }
            return spriteDict;
        }

        private static Sprite ParseSprite(string[] rows) {
            int x = int.Parse(rows[1]);
            int y = int.Parse(rows[2]);
            int width = int.Parse(rows[3]);
            int height = int.Parse(rows[4]);
            int frameCount = int.Parse(rows[5]);
            //TODO: parse anchor rows[6]
            Rectangle sourceRect = new(x, y, width, height);
            return new Sprite(sourceRect, Sprite.AnchorType.center, frameCount);
        }
    }
}
