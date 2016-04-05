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
       public Vector2 position;                   // stores position of grid cell
        public SpriteBatch spriteBatch;     // spriteBatch needed to draw cells
        int size;                           // size of individual grid cell
        Color color;

        MouseState lastMouseState;
        MouseState mouseState;
        bool isDestination;
        bool isObstacle;
        Rectangle clickableArea;

        public Vector2 endPoint;
        public Vector2 startPoint;
        //color of grid cell

        //get and set the color of the grid cell
        public Color GetColor
        {
            get { return color; }
            set { color = value; }
        }

        public bool IsDestination
        {
            get { return isDestination; }
            set { isDestination = value; }
        }

        public bool IsObstacle
        {
            get { return isObstacle; }
            set { isObstacle = value; }
        }

        public int Size
        {
            get { return size; }
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
            isDestination = false;
            clickableArea = new Rectangle((int)position.X, (int)position.Y, size, size);
        }

        /// <summary>
        /// Update Method
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Update(GameTime gameTime)
        {
            lastMouseState = mouseState;
            mouseState = Mouse.GetState();
            Point mousePosition = new Point(mouseState.X, mouseState.Y);
            
            if(lastMouseState.LeftButton == ButtonState.Released && mouseState.LeftButton == ButtonState.Pressed)
            {
                if (clickableArea.Contains(mousePosition))
                {
                    GetColor = Color.Green;
                    isDestination = true;
                }
            }

            else if (lastMouseState.RightButton == ButtonState.Released && mouseState.RightButton == ButtonState.Pressed)
            {
                if (clickableArea.Contains(mousePosition))
                {
                    // = Color.Red;
                    GetColor = Color.Black;
                    isObstacle = true;
                    //isDestination = true;
                }
            }

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
            //spriteBatch.DrawLine(startPoint + new Vector2(16,16), endPoint + new Vector2(16, 16), Color.DarkRed);

            spriteBatch.End();
        }
    }
}
