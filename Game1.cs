using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reflection;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Graphics_Topic_3_Animation
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        Texture2D tribbleBrownTexture, tribbleCreamTexture, tribbleGreyTexture, tribbleOrangeTexture;

        Rectangle tribbleBrownRect, tribbleCreamRect, tribbleGreyRect, tribbleOrangeRect, window;

        Vector2 tribbleGreySpeed, tribbleCreamSpeed, tribbleBrownSpeed, tribbleOrangeSpeed;

        int randomBrownTribblePositonX, randomBrownTribblePositonY, randomColor;

        static Random generator = new Random();

        float orangeRotation;

        List<Color> colors = new();


        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            _graphics.PreferredBackBufferWidth = 800;
            _graphics.PreferredBackBufferHeight = 600;
            _graphics.ApplyChanges();

            window = new Rectangle(0, 0, 800, 600);

            tribbleGreyRect = new Rectangle(200, 300, 100, 100);

            tribbleGreySpeed = new Vector2(-2,6);

            tribbleBrownRect = new Rectangle(10, 10, 100, 100);

            tribbleBrownSpeed = new Vector2(3,3);

            tribbleCreamRect = new Rectangle(10, 10, 100, 100);

            tribbleCreamSpeed = new Vector2(0,50);   

            tribbleOrangeRect = new Rectangle(110, 500, 100, 100);

            tribbleOrangeSpeed = new Vector2(15,-2);

            orangeRotation = 0f;

            colors.Add(Color.Red);
            colors.Add(Color.Orange);
            colors.Add(Color.Yellow);
            colors.Add(Color.Green);
            colors.Add(Color.Blue);
            colors.Add(Color.Purple);
            colors.Add(Color.Azure);
            colors.Add(Color.DarkGreen);
            colors.Add(Color.DarkBlue);
            colors.Add(Color.DarkGray);
            colors.Add(Color.White);
            colors.Add(Color.YellowGreen);
            colors.Add(Color.Bisque);
            colors.Add(Color.Plum);
            colors.Add(Color.Aquamarine);
            colors.Add(Color.Magenta);
            colors.Add(Color.BlanchedAlmond);
            colors.Add(Color.Crimson);
            colors.Add(Color.Maroon);
            colors.Add(Color.Khaki);
            colors.Add(Color.Coral);
            colors.Add(Color.Cyan);
            colors.Add(Color.AliceBlue);
            colors.Add(Color.Aqua);
            colors.Add(Color.Lime);
            colors.Add(Color.MediumTurquoise);








            base.Initialize();

        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);



            tribbleBrownTexture = Content.Load<Texture2D>("tribbleBrown");
            tribbleCreamTexture = Content.Load<Texture2D>("tribbleCream");
            tribbleGreyTexture = Content.Load<Texture2D>("tribbleGrey");
            tribbleOrangeTexture = Content.Load<Texture2D>("tribbleOrange");

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            //Grey Trib
            
            tribbleGreyRect.X += (int)tribbleGreySpeed.X;
            tribbleGreyRect.Y += (int)tribbleGreySpeed.Y;
                        
                //X barriers
            
            if (tribbleGreyRect.X + tribbleGreyRect.Width >= window.Width || tribbleGreyRect.X <= window.X)
            {
                tribbleGreySpeed.X *= -1;
            }
               //Y barriers

            if (tribbleGreyRect.Y + tribbleGreyRect.Height > window.Height || tribbleGreyRect.Y <= window.Top)
            {
                tribbleGreySpeed.Y *= -1;
            }


            //Brown trib

            tribbleBrownRect.X += (int)tribbleBrownSpeed.X;
            tribbleBrownRect.Y += (int)tribbleBrownSpeed.Y;

                //X barriers

            if (tribbleBrownRect.X + tribbleBrownRect.Width >= window.Width || tribbleBrownRect.X <= window.X)
            {
                tribbleBrownSpeed.X *= -1;
            }
                //Y barriers

            if (tribbleBrownRect.Y + tribbleBrownRect.Height > window.Height || tribbleBrownRect.Y <= window.Top)
            {
                tribbleBrownSpeed.Y *= -1;
            }



                //Collisions


                if (tribbleGreyRect.Intersects(tribbleBrownRect))


            {   
                randomBrownTribblePositonX = generator.Next(window.X, window.Width - tribbleBrownRect.Width);
                randomBrownTribblePositonY = generator.Next(window.Y, window.Height - tribbleBrownRect.Height);

                tribbleBrownRect.X = randomBrownTribblePositonX;
                tribbleBrownRect.Y = randomBrownTribblePositonY;
            }

            if ((tribbleBrownRect.Intersects(tribbleOrangeRect)))
            {
                randomBrownTribblePositonX = generator.Next(window.X, window.Width - tribbleBrownRect.Width);               
                randomBrownTribblePositonY = generator.Next(window.Y, window.Height - tribbleBrownRect.Height);

                tribbleBrownRect.X = randomBrownTribblePositonX;
                tribbleBrownRect.Y = randomBrownTribblePositonY;

            }
            


            //Orange tribble

            tribbleOrangeRect.X += (int)tribbleOrangeSpeed.X;
            tribbleOrangeRect.Y += (int)tribbleOrangeSpeed.Y;

                //X Barriers

            if (tribbleOrangeRect.X >= window.Width + tribbleOrangeRect.Width)
                tribbleOrangeRect.X = window.X - tribbleOrangeRect.X;

                //Y Barriers

            if (tribbleOrangeRect.Y <= window.Y - tribbleOrangeRect.Height)
            {
                tribbleOrangeRect.Y = window.Height - tribbleOrangeRect.Height;
            }


            orangeRotation += 0.5f;


            //Cream Trib

            tribbleCreamRect.X += (int)tribbleCreamSpeed.X;
            tribbleCreamRect.Y += (int)tribbleCreamSpeed.Y;

            //X barriers

            if (tribbleCreamRect.X + tribbleCreamRect.Width >= window.Width || tribbleCreamRect.X <= window.X)
            {
                tribbleCreamSpeed.X *= -1;
                randomColor = generator.Next(colors.Count);
            }
            //Y barriers

            if (tribbleCreamRect.Y + tribbleCreamRect.Height > window.Height || tribbleCreamRect.Y <= window.Top)
            {
                tribbleCreamSpeed.Y *= -1;
                randomColor = generator.Next(colors.Count);
            }



          
            
            
            


            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
                   
                       
            
            GraphicsDevice.Clear(colors[randomColor]);
            
            

            _spriteBatch.Begin();

            _spriteBatch.Draw(tribbleGreyTexture, tribbleGreyRect, Color.White);

            _spriteBatch.Draw(tribbleBrownTexture, tribbleBrownRect, Color.White);

            _spriteBatch.Draw(tribbleCreamTexture, tribbleCreamRect, Color.White);


            _spriteBatch.Draw(tribbleOrangeTexture,
                new Rectangle(tribbleOrangeRect.X + tribbleOrangeRect.Width / 2, tribbleOrangeRect.Y + tribbleOrangeRect.Height / 2, tribbleOrangeRect.Width, tribbleOrangeRect.Height),
                null,
                Color.White,
                orangeRotation,
                new Vector2(tribbleOrangeTexture.Width / 2, tribbleOrangeTexture.Height / 2),
                SpriteEffects.None,
                0f);


            _spriteBatch.Draw(tribbleCreamTexture, tribbleCreamRect, Color.White);


            _spriteBatch.End();
            
            
            
            
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
