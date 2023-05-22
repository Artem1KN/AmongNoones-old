//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Microsoft.Xna.Framework;
//using Microsoft.Xna.Framework.Graphics;
//using Microsoft.Xna.Framework.Input;
//using System.IO;
//using System.Reflection.Metadata;

//namespace GameProject
//{
//    public class Level
//    {
//        //public Texture2D backgroundTexture { get; set; }  // текстура фона уровня       
//        //public Texture2D blockTex { get; set; } // temp
//        //public List<Block> blocks { get; set; } // коллекция блоков
//        //public string text { get; set; } //строка-уровень для blocks

//        //// Конструктор
//        //public Level(string text2, Texture2D blockTex2)
//        //{
//        //    text = text2;
//        //    blocks = LoadLevel(text);
//        //    blockTex = blockTex2;
//        //}
//        //public Level(Texture2D backgroundTexture, string text)
//        //{
//        //    backgroundTexture = backgroundTexture;
//        //    text = text;
//        //    blocks = LoadLevel(text);
//        //}

//        //public List<Block> LoadLevel(string text)
//        //{
//        //    List<Block> Blocks = new List<Block>();
//        //    Texture2D png = blockTex;
//        //    string[] map = text.Split(',');
//        //    string subtext;
//        //    int width = map[0].Length;
//        //    int height = map.Count();
//        //    for (int i = 0; i < height; i++)
//        //    {
//        //        subtext = map[i];
//        //        for (int j = 0; j < width; j++)
//        //        {
//        //            char c = subtext[j];
//        //            if (c == 'B')
//        //            {
//        //                Block block = new Block(png, new Vector2(j * Block.Width, i * Block.Height));
//        //                block.Position = new Vector2(j * Block.Width, i * Block.Height);
//        //                Blocks.Add(block);
//        //            }
//        //        }
//        //    }
//        //    return Blocks;
//        //}

//        // Обновление уровня
//        //public void Update(GameTime gameTime, Player player, List<Block> blocks)
//        //{
//        //    foreach (var block in blocks)
//        //    {
//        //        if (block.IsActive)
//        //        {
//        //            // Обновляем блоки

//        //        }
//        //    }

//        //}

//        // Отрисовка уровня на экране
//        //public void Draw(SpriteBatch spriteBatch)
//        //{
//        //    // Отрисовка фона
//        //    //spriteBatch.Draw(backgroundTexture, new Rectangle(0, 0, backgroundTexture.Width, backgroundTexture.Height), Color.White);
//        //    // Отрисовка блоков
//        //    foreach (var block in blocks)
//        //    {
//        //        if (block.IsVisible)
//        //        {
//        //            block.Draw(spriteBatch);
//        //        }
//        //    }

//        //}


        


//    }
//}