using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace CatAndMouse
{
    class Bar : Sprite
    {
        //float coolDown;
        Sprite owner;
        float offset;
        TypeOfBar.Bars typeOfBar;


        public Bar(Game game, string textureName, SpriteBatch spriteBatch, Vector2 position, Vector2 velocity, Sprite owner, TypeOfBar.Bars typeOfBar) : base(game, textureName, spriteBatch, position, velocity)
        {
            this.owner = owner;
            offset = 30;
          //  coolDown = 0;
            this.typeOfBar = typeOfBar;
            
        }

        public override void Update(GameTime gameTime)
        {
           
            position = new Vector2(owner.Position.X, owner.Position.Y - offset);
           
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            //base.Draw(gameTime);
            spritebatch.Begin();
            if (typeOfBar == TypeOfBar.Bars.cooldown)
            {
                spritebatch.Draw(texture, new Rectangle((int)position.X - texture.Width / 2 - 4, (int)position.Y - texture.Height, (int)(texture.Width * (double)(0.20 * owner.CoolDown)), 8), null, Color.Red);
            }
            else if (typeOfBar == TypeOfBar.Bars.health)
            {

            }
            else if (typeOfBar == TypeOfBar.Bars.mana)
            {

            }

            spritebatch.End();
        }
    }
}
