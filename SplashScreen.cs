using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.IO;

namespace GameProject
{
    /// <summary>
    /// Представляет экран заставки игры
    /// </summary>
    static class SplashScreen
    {
        /// <summary>
        /// Получает или задает фоновую текстуру экрана заставки
        /// </summary>
        public static Texture2D Bacground { get; set; }
        public static Texture2D TextPic { get; set; }

        private static int timeCounter = 0;
        private static Color color;
        private static bool flag = true;

        /// <summary>
        /// Отрисовывает экран заставки с использованием указанного SpriteBatch
        /// </summary>
        /// <param name="spriteBatch">SpriteBatch, используемый для отрисовки</param>
        static public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Bacground, Vector2.Zero, color);
            if (!flag)
            {
                spriteBatch.Draw(TextPic, Vector2.Zero, color);
            }
        }

        /// <summary>
        /// Обновляет экран заставки
        /// </summary>
        static public void Update()
        {          
            if (flag)
            {
                color = Color.FromNonPremultiplied(255, 255, 255, timeCounter % 256);
                timeCounter++;

                if (timeCounter > 255)
                {
                    flag = false;
                }
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
//using Microsoft.Xna.Framework.Graphics;
//using Microsoft.Xna.Framework.Input;
//using System.IO;

//namespace GameProject
//{
//    static class SplashScreen
//    {
//        public static Texture2D Bacground {  get; set; }
//        static int timeCounter = 0;
//        static Color color;    
//        static public void Draw(SpriteBatch spriteBatch)
//        {
//            spriteBatch.Draw(Bacground, Vector2.Zero, color);
//        }
//        static public void Update()
//        {
//            color = Color.FromNonPremultiplied(255, 255, 255, timeCounter % 256);
//            timeCounter++;
//        }
//    }
//}