using System;
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

        int randomBrownTribblePositonX, randomBrownTribblePositonY;

        Random randomBrownTribblePosition = new Random();

        float orangeRotation;

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

            tribbleCreamSpeed = new Vector2(0,0);   

            tribbleOrangeRect = new Rectangle(110, 500, 100, 100);

            tribbleOrangeSpeed = new Vector2(15,-2);

            orangeRotation = 0f;


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


            if (tribbleGreyRect.Intersects(tribbleBrownRect) || (tribbleBrownRect.X + tribbleBrownRect.Width >= window.Width || tribbleBrownRect.X <= window.X))

            {
                tribbleBrownSpeed.X *= -1;
                tribbleBrownSpeed.Y *= -1;


                randomBrownTribblePositonX = randomBrownTribblePosition.Next(window.X, window.Width - tribbleBrownRect.Width);
                randomBrownTribblePositonY = randomBrownTribblePosition.Next(window.Y, window.Height - tribbleBrownRect.Height);

                tribbleBrownRect.X = randomBrownTribblePositonX;
                tribbleBrownRect.Y = randomBrownTribblePositonY;
            }

            if ((tribbleBrownRect.Intersects(tribbleOrangeRect)))
            {
                randomBrownTribblePositonX = randomBrownTribblePosition.Next(window.X, window.Width - tribbleBrownRect.Width);               
                randomBrownTribblePositonY = randomBrownTribblePosition.Next(window.Y, window.Height - tribbleBrownRect.Height);

                tribbleBrownRect.X = randomBrownTribblePositonX;
                tribbleBrownRect.Y = randomBrownTribblePositonY;

            }
            


            //Orange tribble

            tribbleOrangeRect.X += (int)tribbleOrangeSpeed.X;
            tribbleOrangeRect.Y += (int)tribbleOrangeSpeed.Y;

            if (tribbleOrangeRect.Y <= window.Y - tribbleOrangeRect.Height)
            {
                tribbleOrangeRect.Y = window.Height - tribbleOrangeRect.Height;
            }



            if (tribbleOrangeRect.X >= window.Width + tribbleOrangeRect.Width)
                tribbleOrangeRect.X = window.X - tribbleOrangeRect.X;



            orangeRotation += 0.5f;


            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Transparent);
            

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



            _spriteBatch.End();
            
            
            
            
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
