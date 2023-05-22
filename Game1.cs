using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SharpDX.Direct2D1;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace GameProject
{
    /// <summary>
    /// Состояния игры
    /// </summary>
    enum Status { SplashScreen, Game, Pause, Ending }

    /// <summary>
    /// Главный класс игры
    /// </summary>
    public class Game1 : Game
    {
        /// <summary>
        /// Графика
        /// </summary>
        GraphicsDeviceManager _graphics;
        /// <summary>
        /// Хранилище спрайтов
        /// </summary>
        Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch;
        /// <summary>
        /// Состояние игры
        /// </summary>
        Status _status = Status.SplashScreen;
        /// <summary>
        /// Игрок
        /// </summary>
        Player player;
        /// <summary>
        /// Блоки
        /// </summary>
        public List<Block> blocks;
        /// <summary>
        /// Предыдущая поциция игрока
        /// </summary>
        Vector2 PreviousPosition;
        /// <summary>
        /// Скорость падения
        /// </summary>
        float falling;

        /// <summary>
        /// Конструктор класса Game1
        /// </summary>
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        /// <summary>
        /// Метод инициализации игры
        /// </summary>
        protected override void Initialize()
        {
            _graphics.PreferredBackBufferWidth = 1920;
            _graphics.PreferredBackBufferHeight = 1080;
            _graphics.IsFullScreen = true;
            _graphics.ApplyChanges();
            _status = Status.SplashScreen;

            string test = Maps.levels[1];
            blocks = LoadLevel(test);
            player = new Player(Content.Load<Texture2D>("amogus"), new Vector2(51, 51));
            falling = 1f;

            base.Initialize();
        }

        /// <summary>
        /// Метод загрузки контента игры
        /// </summary>
        protected override void LoadContent()
        {
            spriteBatch = new Microsoft.Xna.Framework.Graphics.SpriteBatch(GraphicsDevice);
            SplashScreen.Bacground = Content.Load<Texture2D>("PLACEHOLDERBACKGROUND");
            SplashScreen.TextPic = Content.Load<Texture2D>("PressEnterPic");
        }
        /// <summary>
        /// Метод обновления состояния игры
        /// </summary>
        /// <param name="gameTime">Время игры</param>
        protected override void Update(GameTime gameTime)
        {
            switch (_status)
            {
                case Status.SplashScreen:
                    SplashScreen.Update();
                    if (Keyboard.GetState().IsKeyDown(Keys.Enter))
                    {
                        _status = Status.Game;
                        SplashScreen.Bacground.Dispose();
                        SplashScreen.TextPic.Dispose();
                    }
                    break;
                case Status.Game:
                    if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                        _status = Status.Pause;
                    break;
            }

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            PreviousPosition = player.Position;

            player.Update(gameTime, Keyboard.GetState(), blocks, falling);

            foreach (Block block in blocks)
            {
                if (player.Bounds.Intersects(block.Bounds))
                {
                    player.Position = PreviousPosition;
                    falling = 0;
                }
                else
                    falling = 1f;
            }

            //player.Update(gameTime, Keyboard.GetState(), blocks, falling);

            base.Update(gameTime);
        }

        /// <summary>
        /// Метод отрисовки игры
        /// </summary>
        /// <param name="gameTime">Время игры</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            // TODO: Add your drawing code here
            spriteBatch.Begin();
            SplashScreen.Draw(spriteBatch);
            foreach (var block in blocks)
            {
                if (block.IsVisible)
                {
                    block.Draw(spriteBatch);
                }
            }
            player.Draw(spriteBatch);

            SplashScreen.Draw(spriteBatch);
            spriteBatch.End();
            base.Draw(gameTime);
        }

        /// <summary>
        /// Метод загрузки уровня
        /// </summary>
        /// <param name="text">Текстовое представление уровня</param>
        /// <returns>Список блоков уровня</returns>
        public List<Block> LoadLevel(string text)
        {
            List<Block> Blocks = new List<Block>();
            string[] map = text.Split(',');
            string subtext;
            int width = map[0].Length;
            int height = map.Count();
            for (int i = 0; i < height; i++)
            {
                subtext = map[i];
                for (int j = 0; j < width; j++)
                {
                    char c = subtext[j];
                    if (c == 'B')
                    {
                        Block block = new Block(Content.Load<Texture2D>("newTESTblock"), new Vector2(j * Block.Width, i * Block.Height));
                        block.Position = new Vector2(j * Block.Width, i * Block.Height);
                        Blocks.Add(block);
                    }
                }
            }
            return Blocks;
        }




        //public void Cher()
        //{                    
        //    player.CanMoveLeft = true;

        //    if (IsDownBlock())
        //    {
        //        player.CanMoveLeft = true;
        //    }
        //    else
        //        player.CanMoveLeft = true;
        //}


        
        /// <summary>
        /// Проверяет, есть ли блок сверху от игрока
        /// </summary>
        /// <returns>True, если есть блок сверху; иначе False</returns>
        public bool IsUpBlock()
        {
            Vector2 chPos = new Vector2(player.Position.X, player.Position.Y - 1);
            return IsBlock(chPos);
        }

        /// <summary>
        /// Проверяет, есть ли блок снизу от игрока
        /// </summary>
        /// <returns>True, если есть блок снизу; иначе False</returns>
        public bool IsDownBlock()
        {
            Vector2 chPos = new Vector2(player.Position.X, player.Position.Y);
            return IsBlock(chPos);
        }

        /// <summary>
        /// Проверяет, есть ли блок слева от игрока
        /// </summary>
        /// <returns>True, если есть блок слева; иначе False</returns>
        public bool IsLeftBlock()
        {
            Vector2 chPos = new Vector2(player.Position.X - 1, player.Position.Y);
            return IsBlock(chPos);
        }

        /// <summary>
        /// Проверяет, есть ли блок справа от игрока.
        /// </summary>
        /// <returns>True, если есть блок справа; иначе False</returns>
        public bool IsRightBlock()
        {
            Vector2 chPos = new Vector2(player.Position.X + 1, player.Position.Y);
            return IsBlock(chPos);
        }

        /// <summary>
        /// Проверяет, есть ли блок по указанным координатам
        /// </summary>
        /// <param name="pos">Позиция для проверки</param>
        /// <returns>True, если есть блок на указанных координатах; иначе False</returns>
        public bool IsBlock(Vector2 pos)
        {
            int xx = (int)Math.Round(pos.X);
            int yy = (int)Math.Round(pos.Y);
            Rectangle temp = new Rectangle(xx, yy, xx + 1, yy + 1);
            foreach (Block block in blocks)
            {
                if (temp.Intersects(block.Bounds))
                {
                    return true;
                }
            }
            return false;
        }    
    }
}