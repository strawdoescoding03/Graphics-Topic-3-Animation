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

        Vector2 tribbleGreySpeed, tribbleCreamSpeed,
            tribbleBrownSpeed, tribbleOrangeSpeed;

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

            tribbleGreySpeed = new Vector2(2,4);

            tribbleBrownRect = new Rectangle(10, 10, 100, 100);

            tribbleBrownSpeed = new Vector2(2,2);

            tribbleCreamRect = new Rectangle(10, 10, 100, 100);

            tribbleCreamSpeed = new Vector2(0,0);   

            tribbleOrangeRect = new Rectangle(110, 110, 100, 100);

            tribbleOrangeSpeed = new Vector2(0,0);

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


            //Collision


            if (tribbleGreyRect.Intersects(tribbleBrownRect))

            {
                tribbleBrownSpeed.X *= -1;
                tribbleBrownSpeed.Y *= -1;

                tribbleGreySpeed.X *= -1;
                tribbleGreySpeed.Y *= -1;
            }





            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            

            _spriteBatch.Begin();

            _spriteBatch.Draw(tribbleGreyTexture, tribbleGreyRect, Color.White);

            _spriteBatch.Draw(tribbleBrownTexture, tribbleBrownRect, Color.White);

            _spriteBatch.Draw(tribbleCreamTexture, tribbleCreamRect, Color.White);

            _spriteBatch.Draw(tribbleOrangeTexture, tribbleOrangeRect, null, Color.White, orangeRotation, new Vector2(0, 0), );

            _spriteBatch.End();
            
            
            
            
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
