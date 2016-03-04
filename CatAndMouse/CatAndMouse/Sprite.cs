using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;


namespace CatAndMouse
{
    public class Sprite : DrawableGameComponent
    {
        protected Vector2 velocity; //used for cat and mouse velocity
        protected Vector2 position; //used for cat and mouse position
        protected Vector2 origin; //used for setting origin to center on sprites
        protected float orientation; //used for rotation of sprites

        protected float coolDown; 
       protected Texture2D texture; //used for loading textures
       protected SpriteBatch spritebatch; //used for drawing textures and strings
        

        public Sprite(Game game, string textureName, SpriteBatch spriteBatch, Vector2 position, Vector2 velocity) : base(game)
        {
            //add Sprites to game components so Update automatically gets called
            game.Components.Add(this);
            
            //set the parameters of the constructor to our local variables
            this.texture = game.Content.Load<Texture2D>(textureName);
            this.spritebatch = spriteBatch;
            this.position = position;
            this.velocity = velocity;

            //set origin of sprites to be half of their width and height
            origin = new Vector2(texture.Width / 2, texture.Height);
        }

  
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            //detect if the sprites are outside of the game window, and if they are put them back in
            if (position.X < 0)
            {
                position.X = (0 + texture.Width) / 2;
            }
            if (position.Y < 0 + texture.Height / 2)
            {
                position.Y = (0 + texture.Height) ;
            }
            if (position.X > 1024 - texture.Width / 2)
            {
                position.X = 1024 - texture.Width;
            }
            if (position.Y > 768 + texture.Height / 2)
            {
                position.Y = 768; 
            }

        }

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);

            //draw the textures onto the screen with a certain position, origin, and rotation
            spritebatch.Begin();
            spritebatch.Draw(texture, position,null, Color.White, orientation, origin, 1, SpriteEffects.None, 0);
            spritebatch.End();
        }

        public Vector2 Position
        {
            get
            {
                return this.position;
            }
            set
            {
                this.position = value;
            }
        }

        public float CoolDown
        {
            get
            {
                return this.coolDown;
            }
            set
            {
                this.coolDown = value;
            }
        }
    }
       
}
