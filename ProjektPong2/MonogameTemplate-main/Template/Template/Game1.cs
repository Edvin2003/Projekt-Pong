using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Template
{


    public class Game1 : Game

    {
        int x_speed = 4;
        int y_speed = 4;

        // Hastigheten för bollen

        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Texture2D pixel;

        Rectangle ball = new Rectangle(250, 100, 20, 20);
        Rectangle left_paddle = new Rectangle(10, 150, 20, 150);
        Rectangle right_paddle = new Rectangle(770, 150, 20, 150);

        Rectangle ball1 = new Rectangle(250, 200, 20, 70);
        Rectangle ball2 = new Rectangle(530, 200, 20, 70);
        
        Rectangle ball5 = new Rectangle(380, 430, 20, 50);
        Rectangle ball6 = new Rectangle(380, 0, 20, 50);

        // Plats och storlek för bollen- 1, 2, 3, 4, 5, 6 och padlarna både vänster och höger. 



        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }


        protected override void Initialize()
        {


            base.Initialize();
        }

        
        protected override void LoadContent()
        {

            spriteBatch = new SpriteBatch(GraphicsDevice);
            pixel = Content.Load<Texture2D>("pixel");



        }


        protected override void UnloadContent()
        {

        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            ball.X += x_speed;
            ball.Y += y_speed;



            if (ball.Y < 0 || ball.Y > Window.ClientBounds.Height - ball.Height)
                y_speed *= -1;
            if (ball.Intersects(left_paddle) || ball.Intersects(right_paddle))
                x_speed *= -1;
            if (ball.X < 0 || ball.X > Window.ClientBounds.Width - ball.Width)
                Exit();

            if (ball1.Intersects(ball) || ball1.Intersects(ball))
                x_speed *= -1;

            if (ball2.Intersects(ball) || ball2.Intersects(ball))
                x_speed *= -1;

            

            if (ball5.Intersects(ball) || ball5.Intersects(ball))
                x_speed *= -1;

            if (ball6.Intersects(ball) || ball6.Intersects(ball))
                x_speed *= -1;
                
            if (ball1.Intersects(ball) || ball1.Intersects(ball))
                y_speed *= -1;

            if (ball2.Intersects(ball) || ball2.Intersects(ball))
                y_speed *= -1;

            

            if (ball5.Intersects(ball) || ball5.Intersects(ball))
                y_speed *= -1;

            if (ball6.Intersects(ball) || ball6.Intersects(ball))
                y_speed *= -1;
            // Att bollen studsar när den träffar ett hinder. 

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            KeyboardState kstate = Keyboard.GetState();
            if (kstate.IsKeyDown(Keys.Up))
                right_paddle.Y -= 8;
            if (kstate.IsKeyDown(Keys.Down))
                right_paddle.Y += 8;
            if (kstate.IsKeyDown(Keys.W))
                left_paddle.Y -= 8;
            if (kstate.IsKeyDown(Keys.S))
                left_paddle.Y += 8;        // Hastigheten på padlarna, upp och ner. 
            if (left_paddle.Y < 0)
                left_paddle.Y = 0;
            if (right_paddle.Y < 0)
                right_paddle.Y = 0;
            if (left_paddle.Y > Window.ClientBounds.Height - left_paddle.Height)
                left_paddle.Y = Window.ClientBounds.Height - left_paddle.Height;
            if (right_paddle.Y > Window.ClientBounds.Height - right_paddle.Height)
                right_paddle.Y = Window.ClientBounds.Height - right_paddle.Height;

            if (kstate.IsKeyDown(Keys.E))
                ball1.Y -= 8;
            if (kstate.IsKeyDown(Keys.D))
                ball1.Y += 8;
            if (kstate.IsKeyDown(Keys.Left))
                ball2.Y -= 8;
            if (kstate.IsKeyDown(Keys.Right))
                ball2.Y += 8;
            if (ball1.Y > Window.ClientBounds.Height - ball1.Height)
                ball1.Y = Window.ClientBounds.Height - ball1.Height;
            if (ball2.Y > Window.ClientBounds.Height - ball2.Height)
                ball2.Y = Window.ClientBounds.Height - ball2.Height;



            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            spriteBatch.Begin();
            spriteBatch.Draw(pixel, ball, Color.Green);
            spriteBatch.Draw(pixel, left_paddle, Color.Green);
            spriteBatch.Draw(pixel, right_paddle, Color.Green);

            spriteBatch.Draw(pixel, ball1, Color.Yellow);
            spriteBatch.Draw(pixel, ball2, Color.Yellow);
            spriteBatch.Draw(pixel, ball5, Color.Yellow);
            spriteBatch.Draw(pixel, ball6, Color.Yellow);  // Färg på hinner och bollen även padlarna. 
            spriteBatch.End();




            base.Draw(gameTime);
        }
    }
}
