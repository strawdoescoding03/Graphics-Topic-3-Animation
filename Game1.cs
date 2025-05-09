using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reflection;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Graphics_Topic_3_Animation
{

    enum Screen 
    {
        Intro,
        TribbleYard,
        EndScreen
    }

    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        Texture2D tribbleBrownTexture, tribbleBrownDeadTexture, tribbleCreamTexture, tribbleCreamDeadTexture, 
            tribbleGreyTexture, tribbleGreyDeadTexture, tribbleOrangeTexture,
            cannonMinHeight, cannonMidHeight, cannonMaxHeight, tribbleIntroTexture, tribbleEndScreenTexture;

        Rectangle tribbleBrownRect, tribbleCreamRect, tribbleGreyRect, tribbleOrangeRect, window,
            cannonRect;

        Vector2 tribbleGreySpeed, tribbleCreamSpeed, tribbleBrownSpeed,
            tribbleOrangeSpeedMin, tribbleOrangeSpeedMid, tribbleOrangeSpeedMax; 
            
        SpriteFont creamTribbleCountFont;
        
        
        int randomBrownTribblePositonX, randomBrownTribblePositonY, randomColor, creamTribbleCount, cannonCount, tribbleBrownDeathCount,
            tribbleCreamDeathCount;

        static Random generator = new Random();

        float orangeRotation;

        List<Color> colors = new();

        List<Texture2D> cannonTexture = new();

        Screen screen;

        MouseState mouseState;

        bool brownTribbleDead = false, greyTribbleDead = false, creamTribbleDead = false;


        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            screen = Screen.Intro;

            _graphics.PreferredBackBufferWidth = 800;
            _graphics.PreferredBackBufferHeight = 700;
            _graphics.ApplyChanges();

            window = new Rectangle(0, 0, 800, 700);

            tribbleGreyRect = new Rectangle(700, 0, 100, 100);

            tribbleGreySpeed = new Vector2(-2,6);

            tribbleBrownRect = new Rectangle(10, 10, 100, 100);

            tribbleBrownSpeed = new Vector2(3,3);

            tribbleCreamRect = new Rectangle(700, 10, 100, 100);

            tribbleCreamSpeed = new Vector2(0,50);

            tribbleOrangeRect = new Rectangle(110, 500, 100, 100);

            tribbleOrangeSpeedMin = new Vector2(8, -1);
            tribbleOrangeSpeedMid = new Vector2(8, -8);
            tribbleOrangeSpeedMax = new Vector2(8, -16);



            cannonRect = new Rectangle(-130, 370, 400, 400);

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


            creamTribbleCount = 0;

            

            base.Initialize();

        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);



            tribbleBrownTexture = Content.Load<Texture2D>("tribbleBrown");
            tribbleBrownDeadTexture = Content.Load<Texture2D>("brownTribbleDead");
            tribbleCreamTexture = Content.Load<Texture2D>("tribbleCream");
            tribbleCreamDeadTexture = Content.Load<Texture2D>("creamTribbleDead");
            tribbleGreyTexture = Content.Load<Texture2D>("tribbleGrey");
            tribbleGreyDeadTexture = Content.Load<Texture2D>("greyTribbleDead");
            tribbleOrangeTexture = Content.Load<Texture2D>("tribbleOrange");
            creamTribbleCountFont = Content.Load<SpriteFont>("creamCounterFont");
            tribbleIntroTexture = Content.Load<Texture2D>("tribbleStartingScreen");
            tribbleEndScreenTexture = Content.Load<Texture2D>("gameEndScreen");
            
            
            cannonMinHeight = Content.Load<Texture2D>("cannonHeight1");

            cannonMidHeight = Content.Load<Texture2D>("cannonHeight2");

            cannonMaxHeight = Content.Load<Texture2D>("cannonHeight3");


            cannonTexture.Add(cannonMinHeight);
            cannonTexture.Add(cannonMidHeight);
            cannonTexture.Add(cannonMaxHeight);



            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {

            this.Window.Title = "x = " + tribbleOrangeRect.X + " y = " + tribbleOrangeRect.Y;

            mouseState = Mouse.GetState();
            
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here


            if (screen == Screen.Intro)
            {
                if (mouseState.LeftButton == ButtonState.Pressed)

                {
                    screen = Screen.TribbleYard;
                }
                           
            
            }

            if (screen == Screen.TribbleYard)
            {
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



                //Orange tribble

                //Min Cannon

                if (cannonCount == 0)
                {
                    tribbleOrangeRect.X += (int)tribbleOrangeSpeedMin.X;
                    tribbleOrangeRect.Y += (int)tribbleOrangeSpeedMin.Y;
                }

                else if (cannonCount == 1)

                {
                    tribbleOrangeRect.X += (int)tribbleOrangeSpeedMid.X;
                    tribbleOrangeRect.Y += (int)tribbleOrangeSpeedMid.Y;
                }

                else if (cannonCount == 2)
                {
                    tribbleOrangeRect.X += (int)tribbleOrangeSpeedMax.X;
                    tribbleOrangeRect.Y += (int)tribbleOrangeSpeedMax.Y;
                }


                if (tribbleOrangeRect.X == 806 && tribbleOrangeRect.Y == 413)
                {

                    tribbleOrangeRect.X = 100;
                    tribbleOrangeRect.Y = 500;
                    cannonCount++;

                }

                else if (tribbleOrangeRect.X <= window.X - tribbleOrangeRect.X)
                {
                    tribbleOrangeRect.X = 40;
                    tribbleOrangeRect.Y = 500;
                    cannonCount++;
                }

                if (cannonCount == 3)
                {
                    cannonCount = 0;
                }


                orangeRotation += 0.5f;

                if (tribbleOrangeRect.X >= window.Width + tribbleOrangeRect.Width)
                    tribbleOrangeRect.X = window.X - tribbleOrangeRect.X;

                //Orange Tribble Death Collisions

                if ((tribbleBrownRect.Intersects(tribbleOrangeRect)))
                {
                    tribbleBrownDeathCount++;

                    randomBrownTribblePositonX = generator.Next(window.X, window.Width - tribbleBrownRect.Width);
                    randomBrownTribblePositonY = generator.Next(window.Y, window.Height - tribbleBrownRect.Height);

                    tribbleBrownRect.X = randomBrownTribblePositonX;
                    tribbleBrownRect.Y = randomBrownTribblePositonY;

                    if (tribbleBrownDeathCount >= 3)
                    {
                        brownTribbleDead = true;
                        tribbleBrownSpeed.X = 0;
                        tribbleBrownSpeed.Y = 0;
                    }
                }

                else if (tribbleOrangeRect.Intersects(tribbleGreyRect))

                {

                    greyTribbleDead = true;
                    tribbleGreySpeed.X = 0;
                    tribbleGreySpeed.Y = 0;

                }

                else if (tribbleOrangeRect.Intersects(tribbleCreamRect) && 
                    tribbleCreamRect.Y != window.Top && tribbleCreamRect.Y != window.Bottom)
                {
                    tribbleCreamDeathCount++;

                    if (tribbleCreamDeathCount > 25)
                    {
                        creamTribbleDead = true;
                        tribbleCreamSpeed.X = 0;
                        tribbleCreamSpeed.Y = 0;
                    }
                   
                }



                //Cream Trib

                tribbleCreamRect.X += (int)tribbleCreamSpeed.X;
                tribbleCreamRect.Y += (int)tribbleCreamSpeed.Y;

                //Y barriers

                if (tribbleCreamRect.Y + tribbleCreamRect.Height > window.Height || tribbleCreamRect.Y <= window.Top)
                {
                    tribbleCreamSpeed.Y *= -1;
                    randomColor = generator.Next(colors.Count);
                    creamTribbleCount += 1;

                    if (creamTribbleCount > 696)
                    {
                        creamTribbleCount = 0;
                    }
                }


            }

            if (brownTribbleDead == true && creamTribbleDead == true && greyTribbleDead == true)

            {
                screen = Screen.EndScreen;
            
            }
            


            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {

            GraphicsDevice.Clear(colors[randomColor]);

            _spriteBatch.Begin();


            if (screen == Screen.Intro)

            {
                _spriteBatch.Draw(tribbleIntroTexture, window, Color.White);
            }

            else if (screen == Screen.TribbleYard)

            {
               
                // Brown Tribble Draw Condition

                if (brownTribbleDead == false)
                    _spriteBatch.Draw(tribbleBrownTexture, tribbleBrownRect, Color.White);

                else if (brownTribbleDead == true)
                    _spriteBatch.Draw(tribbleBrownDeadTexture, tribbleBrownRect, Color.Red);


                // Cream Tribble Draw Condition

                if (creamTribbleDead == false)
                    _spriteBatch.Draw(tribbleCreamTexture, tribbleCreamRect, Color.White);


                else if (creamTribbleDead == true)
                    _spriteBatch.Draw(tribbleCreamDeadTexture, tribbleCreamRect, Color.White);

                // Grey Tribble Draw Condition

                if (greyTribbleDead == false)
                
                    _spriteBatch.Draw(tribbleGreyTexture, tribbleGreyRect, Color.White);

                else if (greyTribbleDead == true)                
                    _spriteBatch.Draw(tribbleGreyDeadTexture, tribbleGreyRect, Color.White);

                if (cannonCount == 0)
                {
                    _spriteBatch.Draw(tribbleOrangeTexture,
                   new Rectangle(tribbleOrangeRect.X + tribbleOrangeRect.Width / 2, tribbleOrangeRect.Y + tribbleOrangeRect.Height / 2, tribbleOrangeRect.Width, tribbleOrangeRect.Height),
                   null,
                   Color.White,
                   orangeRotation,
                   new Vector2(tribbleOrangeTexture.Width / 2, tribbleOrangeTexture.Height / 2),
                   SpriteEffects.None,
                   0f);

                    _spriteBatch.Draw(texture: cannonTexture[0], cannonRect, Color.White);
                }


                else if (cannonCount == 1)
                {
                    _spriteBatch.Draw(tribbleOrangeTexture,
                   new Rectangle(tribbleOrangeRect.X + tribbleOrangeRect.Width / 2, tribbleOrangeRect.Y + tribbleOrangeRect.Height / 2, tribbleOrangeRect.Width, tribbleOrangeRect.Height),
                   null,
                   Color.White,
                   orangeRotation,
                   new Vector2(tribbleOrangeTexture.Width / 2, tribbleOrangeTexture.Height / 2),
                   SpriteEffects.None,
                   0f);

                    _spriteBatch.Draw(texture: cannonTexture[1], cannonRect, Color.White);
                }

                else if (cannonCount == 2)
                {
                    _spriteBatch.Draw(tribbleOrangeTexture,
                   new Rectangle(tribbleOrangeRect.X + tribbleOrangeRect.Width / 2, tribbleOrangeRect.Y + tribbleOrangeRect.Height / 2, tribbleOrangeRect.Width, tribbleOrangeRect.Height),
                   null,
                   Color.White,
                   orangeRotation,
                   new Vector2(tribbleOrangeTexture.Width / 2, tribbleOrangeTexture.Height / 2),
                   SpriteEffects.None,
                   0f);

                    _spriteBatch.Draw(texture: cannonTexture[2], cannonRect, Color.White);
                }

                _spriteBatch.DrawString(creamTribbleCountFont, Convert.ToString(creamTribbleCount), new Vector2(249, 120), Color.Black);













            }


            else if (screen == Screen.EndScreen)

            {
                _spriteBatch.Draw(tribbleEndScreenTexture, window, Color.White);
            }


            _spriteBatch.End();
            
            
            
            
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
