using Microsoft.VisualBasic.FileIO;
using Microsoft.Xna.Framework;

namespace PixelPushers.MonoZelda.Sprites;


internal static class SpriteSheetParser
{
    public static void Parse(SpriteDict toPopulate, string CSVname)
    {
        //set up text parser
        using TextFieldParser textFieldParser = new(CSVname);
        textFieldParser.TextFieldType = FieldType.Delimited;
        textFieldParser.SetDelimiters(",");

        //loop through csv file
        while (!textFieldParser.EndOfData)
        {
            string[] fields = textFieldParser.ReadFields();
            toPopulate.Add(ParseSprite(fields), fields[0]);
        }
    }

    private static Sprite ParseSprite(string[] rows)
    {
        //scale up source rect data by 4 since image is upscaled by 4
        int x = int.Parse(rows[1]) * 4;
        int y = int.Parse(rows[2]) * 4;
        int width = int.Parse(rows[3]) * 4;
        int height = int.Parse(rows[4]) * 4;
        int frameCount = int.Parse(rows[5]);
        Sprite.AnchorType anchor = Sprite.StringToAnchorType(rows[6]);
        Rectangle sourceRect = new(x, y, width, height);
        return new Sprite(sourceRect, anchor, frameCount);
    }
}

