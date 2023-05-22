using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProject
{
    /// <summary>
    /// Представляет блок в игре
    /// </summary>
    public class Block : GameObject
    {
        /// <summary>
        /// Получает или задает текстуру блока
        /// </summary>
        public new Texture2D Texture { get; set; }

        /// <summary>
        /// Получает или задает позицию блока на экране
        /// </summary>
        public Vector2 Position { get; set; }

        /// <summary>
        /// Получает ширину блока
        /// </summary>
        public static int Width { get; set; } = 32;

        /// <summary>
        /// Получает высоту блока
        /// </summary>
        public static int Height { get; set; } = 32;

        /// <summary>
        /// Получает ограничивающий прямоугольник блока для коллизий и отрисовки
        /// </summary>
        public Rectangle Bounds => new Rectangle((int)Position.X, (int)Position.Y, (int)Position.X + Width, (int)Position.Y + Height);

        /// <summary>
        /// Инициализирует новый экземпляр класса Block
        /// </summary>
        /// <param name="texture">Текстура блока</param>
        /// <param name="position">Позиция блока на экране</param>
        /// <param name="isVisible">Значение, указывающее, видим ли блок. По умолчанию true</param>
        /// <param name="isActive">Значение, указывающее, активен ли блок. По умолчанию true</param>
        /// <param name="isSolid">Значение, указывающее, является ли блок преградой. По умолчанию true</param>
        /// <param name="isCollidable">Значение, указывающее, является ли блок коллизионным. По умолчанию true</param>
        public Block(Texture2D texture, Vector2 position, bool isVisible = true, bool isActive = true, bool isSolid = true, bool isCollidable = true)
            : base(texture, position, isVisible, isActive, isSolid, isCollidable)
        {
            Texture = texture;
            Position = position;
        }

        /// <summary>
        /// Отрисовывает блок с использованием указанного SpriteBatch
        /// </summary>
        /// <param name="spriteBatch">SpriteBatch, используемый для отрисовки</param>
        public void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }
    }
}



//using Microsoft.Xna.Framework;
//using Microsoft.Xna.Framework.Graphics;
//using Microsoft.Xna.Framework.Input;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace GameProject
//{   
//    public class Block : GameObject
//    {
//        public new Texture2D Texture { get; set; }     
//        public Vector2 Position { get; set; }  
//        public static int Width { get; set; } = 32;
//        public static int Height { get; set; } = 32;
//        public Rectangle Bounds => new Rectangle((int)Position.X, (int)Position.Y, (int)Position.X + Width, (int)Position.Y + Height);

//        public Block(
//            Texture2D texture,
//            Vector2 position,
//            bool isVisible = true,
//            bool isActive = true,
//            bool isSolid = true,
//            bool isCollidable = true)
//            : base(texture, position, isVisible, isActive, isSolid, isCollidable)
//        {
//            Texture = texture;
//            Position = position;            
//        }

//        public  void Draw(SpriteBatch spriteBatch)
//        {
//            base.Draw(spriteBatch);
//        }
//    }
//}
