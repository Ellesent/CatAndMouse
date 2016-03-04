using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using C3.XNA;

namespace Grid
{
    /// <summary>
    /// Grid cell class for drawing the grid cells
    /// </summary>
    class GridCell : DrawableGameComponent
    {
        Vector2 position;                   // stores position of grid cell
        public SpriteBatch spriteBatch;     // spriteBatch needed to draw cells
        int size;                           // size of individual grid cell
        Color color;                        //color of grid cell

        //get and set the color of the grid cell
        public Color GetColor
        {
            get { return color; }
            set { color = value; }
        }

        /// <summary>
        /// Constructor for Grid Cell
        /// </summary>
        /// <param name="game">The game</param>
        /// <param name="spriteBatch">the spriteBatch</param>
        /// <param name="position">the position of the grid cell in the world</param>
        /// <param name="size">the size of the grid cell</param>
        /// <param name="color">the color of the grid cell</param>
        public GridCell(Game game, SpriteBatch spriteBatch, Vector2 position, int size, Color color) : base (game)
        {
            //store parameters and add this to components
            game.Components.Add(this);
            this.spriteBatch = spriteBatch;
            this.position = position;
            this.size = size;
            this.color = color;
        }

        /// <summary>
        /// Update Method
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        /// <summary>
        /// Draws the grid cell
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
            spriteBatch.Begin();

            //draw a rectangle with a border for a grid cell
           spriteBatch.FillRectangle(new Rectangle((int)position.X, (int)position.Y, size, size), color);
            spriteBatch.DrawRectangle(new Rectangle((int)position.X, (int)position.Y, size, size), Color.Black);

            spriteBatch.End();
        }
    }
}
