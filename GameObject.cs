using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SharpDX.Direct3D9;

namespace GameProject
{
    /// <summary>
    /// Представляет игровой объект в мире
    /// </summary>
    public class GameObject
    {
        /// <summary>
        /// Получает или задает текстуру объекта
        /// </summary>
        public Texture2D Texture { get; set; }

        /// <summary>
        /// Получает или задает позицию объекта на экране
        /// </summary>
        public Vector2 Position { get; set; }

        /// <summary>
        /// Получает ограничивающий прямоугольник объекта для коллизий и отрисовки
        /// </summary>
        public Rectangle Bounds => new Rectangle((int)Position.X, (int)Position.Y, Texture.Width, Texture.Height);

        /// <summary>
        /// Получает или задает значение, указывающее, видим ли объект
        /// </summary>
        public bool IsVisible { get; set; }

        /// <summary>
        /// Получает или задает значение, указывающее, активен ли объект
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// Получает или задает значение, указывающее, может ли объект быть пройден или пересечен игроком
        /// </summary>
        public bool IsSolid { get; set; }

        /// <summary>
        /// Получает или задает значение, указывающее, является ли объект коллизионным
        /// </summary>
        public bool IsCollidable { get; set; }

        /// <summary>
        /// Инициализирует новый экземпляр класса GameObject
        /// </summary>
        /// <param name="texture">Текстура объекта</param>
        /// <param name="position">Позиция объекта на экране</param>
        /// <param name="isVisible">Значение, указывающее, видим ли объект. По умолчанию true</param>
        /// <param name="isActive">Значение, указывающее, активен ли объект. По умолчанию true</param>
        /// <param name="isSolid">Значение, указывающее, является ли объект преградой. По умолчанию false</param>
        /// <param name="isCollidable">Значение, указывающее, является ли объект коллизионным. По умолчанию false</param>
        public GameObject(Texture2D texture, Vector2 position, bool isVisible = true, bool isActive = true, bool isSolid = false, bool isCollidable = false)
        {
            Texture = texture;
            Position = position;
            IsVisible = isVisible;
            IsActive = isActive;
            IsSolid = isSolid;
            IsCollidable = isCollidable;
        }

        /// <summary>
        /// Отрисовывает объект на экране с использованием указанного SpriteBatch
        /// </summary>
        /// <param name="spriteBatch">SpriteBatch, используемый для отрисовки</param>
        public void Draw(SpriteBatch spriteBatch)
        {
            if (IsVisible)
            {
                spriteBatch.Draw(Texture, Position, Color.White);
            }
        }
    }
}




//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Microsoft.Xna.Framework;
//using Microsoft.Xna.Framework.Content;
//using Microsoft.Xna.Framework.Graphics;
//using Microsoft.Xna.Framework.Input;
//using SharpDX.Direct3D9;

//namespace GameProject
//{
//    public class GameObject
//    {
//        // Основные свойства объекта
//        public Texture2D Texture { get; set; } // текстура объекта
//        public Vector2 Position { get; set; } // позиция объекта на экране
//        public Rectangle Bounds => new Rectangle((int)Position.X, (int)Position.Y, Texture.Width, Texture.Height); // границы объекта для коллизий и отрисовки
//        public bool IsVisible { get; set; } // видим ли объект
//        public bool IsActive { get; set; } // активен ли объект
//        public bool IsSolid { get; set; } // может ли объект быть пройден или пересечен игроком
//        public bool IsCollidable { get; set; } // объект коллизионный или нет


//        // Конструктор
//        public GameObject(Texture2D texture, Vector2 position, bool isVisible = true, bool isActive = true, bool isSolid = false, bool isCollidable = false)
//        {
//            Texture = texture;
//            Position = position;
//            IsVisible = isVisible;
//            IsActive = isActive;
//            IsSolid = isSolid;
//            IsCollidable = isCollidable;
//        }

//        // Отрисовка объекта на экране
//        public void Draw(SpriteBatch spriteBatch)
//        {
//            if (IsVisible)
//            {
//                spriteBatch.Draw(Texture, Position, Color.White);
//            }
//        }        
//    }
//}


