using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.VisualBasic.FileIO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using PixelPushers.MonoZelda.Sprites;
using PixelPushers.MonoZelda.Tiles;

namespace PixelPushers.MonoZelda.Scenes;

public class ExperimentalDungeonLoader
{
    private static readonly HttpClient httpClient = new HttpClient();

    private static string Dungeon1 = "https://docs.google.com/spreadsheets/d/1LJPdekWHcv_nLglTE_mb_izUfJeQiEXoGHPhfGcHD-M/gviz/tq?tqx=out:csv&sheet=Room1";

    public ExperimentalDungeonLoader(ContentManager contentManager)
    {
        // Load the exterior
        var dungonPoint = new Point(0, 192);
        var d = new SpriteDict(contentManager.Load<Texture2D>(TextureData.Blocks), SpriteCSVData.Blocks, 0, dungonPoint);
        d.SetSprite("room_exterior");

        // Load the dungeon from the URI
        using var dungeon1Stream = DownloadCsvStream(Dungeon1);

        if (dungeon1Stream != null)
        {
            using var streamReader = new StreamReader(dungeon1Stream);

            // Set up text parser
            using TextFieldParser textFieldParser = new TextFieldParser(streamReader);
            textFieldParser.TextFieldType = FieldType.Delimited;
            textFieldParser.SetDelimiters(",");

            // Loop through CSV file
            var i = 0;
            var tileWidth = 64;
            var tileHeight = 64;
            var margin = new Point(64,64);
            while (!textFieldParser.EndOfData)
            {
                string[] fields = textFieldParser.ReadFields();
                var j = 0;

                foreach (var field in fields)
                {
                    // Try and parse the field as a BlockType enum
                    if (Enum.TryParse(field, out BlockType blockType))
                    {
                        var position = new Point(j * tileWidth, i * tileHeight) + dungonPoint + margin;
                        var dict = new SpriteDict(contentManager.Load<Texture2D>(TextureData.Blocks), SpriteCSVData.Blocks, 1, position);
                        var tile = TileFactory.CreateTile<Block1>(dict, blockType, position);
                    }

                    j++;
                }

                i++;
            }
        }
    }

    public Stream DownloadCsvStream(string url)
    {
        try
        {
            // Send a synchronous GET request to the specified URL
            var response = httpClient.GetAsync(url).Result;
            
            // Ensure that the request was successful
            response.EnsureSuccessStatusCode();

            // Return the response content as a stream (CSV content)
            return response.Content.ReadAsStreamAsync().Result;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error downloading CSV: {ex.Message}");
            return null;
        }
    }
}