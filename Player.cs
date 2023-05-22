using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SharpDX.Direct3D9;

namespace GameProject
{
    /// <summary>
    /// Представляет игрока в игре
    /// </summary>
    public class Player : GameObject
    {
        /// <summary>
        /// Получает или задает текстуру игрока
        /// </summary>
        public new Texture2D Texture { get; set; }

        /// <summary>
        /// Получает или задает позицию игрока
        /// </summary>
        public Vector2 Position { get; set; }

        /// <summary>
        /// Получает границы игрока
        /// </summary>
        public Rectangle Bounds => new Rectangle((int)Position.X, (int)Position.Y, Texture.Width, Texture.Height);

        /// <summary>
        /// Получает или задает скорость игрока
        /// </summary>
        public float Speed { get; set; }

        /// <summary>
        /// Получает или задает значение, указывающее, прыгает ли игрок
        /// </summary>
        public bool IsJumping { get; set; }

        /// <summary>
        /// Получает или задает скорость прыжка игрока
        /// </summary>
        public float JumpVelocity { get; set; }

        /// <summary>
        /// Получает или задает значение гравитации для прыжков и падений игрока
        /// </summary>
        public float Gravity { get; set; }

        /// <summary>
        /// Получает или задает счетчик смертей игрока
        /// </summary>
        public int DeathCount { get; set; }

        public Vector2 Velocity { get; set; }
        public int JumpCounter { get; set; }
        public bool CanMoveLeft { get; set; }




        /// <summary>
        /// Инициализирует новый экземпляр класса Player с заданной текстурой и позицией
        /// </summary>
        /// <param name="texture">Текстура игрока</param>
        /// <param name="position">Позиция игрока</param>
        public Player(Texture2D texture, Vector2 position) : base(texture, position)
        {
            Texture = texture;
            Position = position;
            Velocity = new Vector2(0,0);
            Speed = 2f;
            IsJumping = false;
            JumpVelocity = -1f;
            Gravity = 0.5f;
            DeathCount = 0;
            JumpCounter = 0;
        }

        /// <summary>
        /// Обновляет состояние игрока на основе текущего состояния клавиатуры и уровня
        /// </summary>
        /// <param name="gameTime">Игровое время</param>
        /// <param name="keyboardState">Состояние клавиатуры</param>
        /// <param name="level">Уровень игры</param>
        /// <param name="fo">Сила гравитации</param>
        public void Update(GameTime gameTime, KeyboardState keyboardState, List<Block> level, float fo)
        {
            keyboardState = Keyboard.GetState();
            if (keyboardState.IsKeyDown(Keys.Space) && !IsJumping )
            {
                Jump();
            }

            if (IsJumping)
            {
                if (JumpCounter < 120)
                {
                    this.Position = new Vector2(Position.X, Position.Y + JumpVelocity);
                    JumpCounter++;
                }
                else
                {                
                    JumpCounter = 0;
                    IsJumping = false;
                }                
            }
            else
            {
                this.Position = new Vector2(Position.X, Position.Y + fo);
            }

            if (keyboardState.IsKeyDown(Keys.Left) && !IsJumping)
            {
                if(IsJumping || false)//!!!!!!
                {
                    this.Position = new Vector2(Position.X - Speed, Position.Y);
                }
                
                this.Position = new Vector2(Position.X - Speed, Position.Y-1);
            }
            

            if (keyboardState.IsKeyDown(Keys.Right) && !IsJumping)
            {
                this.Position = new Vector2(Position.X + Speed, Position.Y-1);
            }
            
        }

        /// <summary>
        /// Отрисовывает игрока на экране
        /// </summary>
        /// <param name="spriteBatch">SpriteBatch, используемый для отрисовки</param>
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Position, Color.White);
        }
        /// <summary>
        /// Выполняет прыжок игрока
        /// </summary>
        public void Jump()
        {
            //IsJumping = true;
            //JumpVelocity = -1f;

            //Bounds.Right;

            if (!IsJumping) // Добавьте проверку, чтобы игрок мог прыгнуть только один раз до достижения земли
            {
                IsJumping = true;
                //Velocity.Y = JumpVelocity; // Измените прыжковую скорость напрямую в Velocity.Y, а не меняйте позицию Y
                //Velocity = new Vector2(Position.X, Position.Y - 10f);
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
//using SharpDX.Direct3D9;

//namespace GameProject
//{
//    public class Player: GameObject
//    {

//        // Основные свойства игрока
//        public new Texture2D Texture { get; set; } // текстура игрока      
//        public Vector2 Position { get; set; } // позиция игрока
//        public Rectangle Bounds => new Rectangle((int)Position.X, (int)Position.Y, Texture.Width, Texture.Height); // границы игрока
//        public float Speed { get; set; } // скорость
//        public bool IsJumping { get; set; } // прыгает ли игрок
//        public float JumpVelocity { get; set; } // скорость прыжка игрока
//        public float Gravity { get; set; } // гравитация для прыжков и падений
//        public int DeathCount { get; set; } // счетчик смертей

//        public Player(Texture2D texture, Vector2 position) : base (texture, position)
//        {
//            Texture = texture;
//            Position = position;
//            Speed = 2f;
//            IsJumping = false;
//            JumpVelocity = -1f;
//            Gravity = 0.5f;
//            DeathCount = 0;
//        }

//        public void Update(GameTime gameTime, KeyboardState keyboardState, List<Block> level,float fo)
//        {
//            keyboardState = Keyboard.GetState();
//            if (keyboardState.IsKeyDown(Keys.Space) && !IsJumping)
//            {
//                Jump();
//            }

//            if (IsJumping)
//            {
//                this.Position = new Vector2(Position.X, Position.Y + JumpVelocity);
//            }
//            else
//            {
//                this.Position = new Vector2(Position.X, Position.Y + fo);                 
//            }
//            if (keyboardState.IsKeyDown(Keys.Left))
//            {
//                this.Position = new Vector2(Position.X - Speed, Position.Y);
//            }
//            if (keyboardState.IsKeyDown(Keys.Right))
//            {
//                this.Position = new Vector2(Position.X + Speed, Position.Y);
//            }
//        }
//        //Отрисовка игрока на экране
//        public void Draw(SpriteBatch spriteBatch)
//        {
//            spriteBatch.Draw(Texture, Position, Color.White);           
//        }
//        // Метод для прыжка
//        public void Jump()
//        {
//            IsJumping = true;
//            JumpVelocity = -12f;
//        }
//    }
//}
