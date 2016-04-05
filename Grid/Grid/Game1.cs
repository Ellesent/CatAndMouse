
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace Grid
{   /// summary
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        KeyboardState oldState;
        KeyboardState newState;

        UserSprite mouse; 

        Graph<int> grid;


        DiagonalGraph<int> diag;

        const int gridSize = 32;  // grid cell size
        GridCell[,] cells;        // array of grid cells for drawing the grid

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            //Set preferred size of screen
            graphics.PreferredBackBufferWidth = 1024;
            graphics.PreferredBackBufferHeight = 768;

            //Initialize grid cell array
            cells = new GridCell[graphics.PreferredBackBufferWidth / gridSize, graphics.PreferredBackBufferHeight / gridSize];
            IsMouseVisible = true; 

        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            //create the grid cells
            for (int i = 0; i < cells.GetLength(0); i++)
            {
                for (int j = 0; j < cells.GetLength(1); j++)
                {
                    cells[i, j] = new GridCell(this, spriteBatch, new Vector2(i * gridSize, j * gridSize), gridSize, Color.CornflowerBlue);
                }
            }

            //create the graph based on the grid cells and perform the breath first search
            grid = new Graph<int>(this, cells);
            diag = new DiagonalGraph<int>(this, cells);

            mouse = new UserSprite(this, "mouse", spriteBatch, new Vector2(5, 5), new Vector2(0.5f, 0.5f), grid.follow);
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
           
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            oldState = newState;
            newState = Keyboard.GetState();

            if (newState.IsKeyDown(Keys.B) && oldState.IsKeyUp(Keys.B))
            {
                grid.BreadthFirstSearch();

            }
            else if (newState.IsKeyDown(Keys.D) && oldState.IsKeyUp(Keys.D))
            {
                diag.BreadthFirstSearch();
            }
            // TODO: Add your update logic here


            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}

