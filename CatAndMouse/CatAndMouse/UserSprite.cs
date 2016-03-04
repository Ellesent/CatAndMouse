using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace CatAndMouse
{
    public class UserSprite : Sprite
    {
        Random rand; //used for setting random position in world
        KeyboardState oldstate; // get the oldstate of the keyboard
        KeyboardState state;  //get the new state of the keyboard
        //float coolDown; 

        public UserSprite(Game game, string textureName, SpriteBatch spriteBatch, Vector2 position, Vector2 velocity) : base(game, textureName, spriteBatch, position, velocity)
        {
            //intialize the random object
            rand = new Random();
            coolDown = 0; 
           
        }

        public override void Update(GameTime gameTime)
        {
            coolDown += (float)gameTime.ElapsedGameTime.TotalSeconds;
            coolDown = MathHelper.Clamp(coolDown, 0, 5);
            base.Update(gameTime);

            //set the keyboard's oldstate to the current state, and the current state to the just recently pressed key
            oldstate = state;
            state = Keyboard.GetState();

            //move the mouse based on if W, A, S, or D was pressed
            if (state.IsKeyDown(Keys.A))
            {
                position.X -= (velocity.X * gameTime.ElapsedGameTime.Milliseconds);
            }
            if (state.IsKeyDown(Keys.D))
            {
                position.X += (velocity.X * gameTime.ElapsedGameTime.Milliseconds);
            }
            if (state.IsKeyDown(Keys.W))
            {
                position.Y -= (velocity.Y * gameTime.ElapsedGameTime.Milliseconds);
            }
            if (state.IsKeyDown(Keys.S))
            {
                position.Y += (velocity.Y * gameTime.ElapsedGameTime.Milliseconds);
            }

            //check if the current state of space is down, and the old one was up - this is used to detect a key press so the mouse can't constantly jump around the screen
            if (state.IsKeyDown(Keys.Space) && oldstate.IsKeyUp(Keys.Space) && coolDown == 5)
            {
                //if the space key was pressed, move the mouse to a random position 
                position = new Vector2(rand.Next(0, 1024), rand.Next(0, 768));
                coolDown = 0;
            }
        }

        //a getter and setter for the mouse's position -used by cat
      

        //a getter and setter for the mouse's velocity - used by cat
        public Vector2 Velocity
        {
            get
            {
                return this.velocity;
            }
            set
            {
                this.velocity = value;
            }
        }

       
    }
}
