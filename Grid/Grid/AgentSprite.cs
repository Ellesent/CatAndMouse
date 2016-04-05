//using Microsoft.Xna.Framework;
//using Microsoft.Xna.Framework.Graphics;
//using Microsoft.Xna.Framework.Input;
//using System;

//namespace CatAndMouse
//{
//    public class AgentSprite : Sprite
//    {
//        Vector2 targetPos; //store the mouses position as the target position
//        float maxSpeed; //the max speed the cat can go
//        float currentSpeed; //the current speed the cat is going
//        float distance;  //store vector between cat and mouse
//        Vector2 direction; //get the length of the vector between the cat and mouse
//        float targetDistance; //the cat's target distance from the mouse - means cat caught mouse
//        float slowDistance; //the distance that tells the cat to start slowing down
//        Vector2 vel2;

//        UserSprite mouse; //store the mouse object
//        SpriteFont font; //store the font used for drawing text
//      static Random rand; //used to put cat at a random position in world

//        float time; //timer until player wins
//        bool win; //did the player win?
//        bool lose;  //did the player lose?

//        float angle;


//        TypeOfEnemy.Enemy enemy;
//        public AgentSprite(Game game, string textureName, SpriteBatch spriteBatch, Vector2 position, Vector2 velocity, UserSprite target, TypeOfEnemy.Enemy enemy) : base(game, textureName, spriteBatch, position, velocity)
//        {   
//            //set the mouse as the target, and get the position of the cat
//            mouse = target;
//            this.enemy = enemy;
//            this.position = position;

//            if (enemy == TypeOfEnemy.Enemy.normal)
//            {
//                maxSpeed = 0.7f;
//            }
//            else if (enemy == TypeOfEnemy.Enemy.small)
//            {
//                maxSpeed = 0.9f;
//            }
//            else
//            {
//                maxSpeed = 0.5f;
//            }
//            //set the target distance, the slow down distance, and the time until win
//            targetDistance = 20;
//            slowDistance = 80;
//            time = 30;

//            //load the font used for text
//            font = game.Content.Load<SpriteFont>("Arial");

//            //set win and lose to false 
//            win = false;
//            lose = false;

//            //intitialize a new random object that will take care of a random position
//            rand = new Random();

           
//        }

//        public override void Update(GameTime gameTime)
//        {
//            //get the state of the keyboard
//            KeyboardState state = Keyboard.GetState();

//            //have the timer go down until 0
//            time -= (float)gameTime.ElapsedGameTime.TotalSeconds;

//            //set the target position to the mouse position and get the velocity between the two based on position, then turn that velocity into a unit vector
//            targetPos = mouse.Position;
//            velocity = targetPos - position;
//            velocity.Normalize();

//            //get the distance between the mouse and cat
//            direction = targetPos - position;
//            distance = direction.Length();

           
//            //if the timer goes out, the player has won
//            if (time <= 0)
//            {
//                win = true;
//                time = 0;
//            }

//            //if the game is over, the sprites stop moving
//            if (win == true || lose == true)
//            {
//                velocity = Vector2.Zero;
//                currentSpeed = 0;
//                mouse.Velocity = Vector2.Zero;

//                //after the game is over, if the player presses space the game should restart
//                if (state.IsKeyDown(Keys.Space))
//                {
//                    position = new Vector2(rand.Next(0, 1024), rand.Next(0, 768));
//                    time = 30;
//                    mouse.Velocity = new Vector2(0.5f, 0.5f);
//                    win = false;
//                    lose = false;
//                }
//            }

//            //if the distance between the cat and mouse is less than the target distance, than the player has lost 
//            if (distance < targetDistance)
//            {
                
//                lose = true;
//                //position = targetPos;
//                time = 30;

//            }

//            //if the cat reaches the slow distance, the cat should slow down based on how far away it is from the mouse
//            else if (distance < slowDistance)
//            {
//                currentSpeed = maxSpeed * distance / slowDistance;
//            }

//            //else the cat should move at its max speed because it is not near the mouse
//            else
//            {
//                currentSpeed = maxSpeed;
//            }

//            //set velocity to be velocity times the current speed, and change the cat's position based on this velocity
           
//            velocity = velocity * currentSpeed;

//            //have the cat face the direction it is currently moving
//            orientation = (float)Math.Atan2(-velocity.X, velocity.Y);

//            //if (!float.IsNaN(angle))
//           // {
//                position += velocity * gameTime.ElapsedGameTime.Milliseconds;
//          //  }

//            //Vector2 help = velocity;
//            //help.Normalize();

//            //velocity.Normalize();

//            float dot = Vector2.Dot(vel2, velocity);
//                 angle = (float)Math.Acos(dot);
//            //angle = Math.Cos((double)amount);
//            //Console.WriteLine(dot);
//            //Console.WriteLine(vel2);
//            //Console.WriteLine(velocity);
//            //Console.WriteLine(vel2);
//            Console.WriteLine(MathHelper.ToDegrees(angle));

//            //if (angle < 1f && angle > 0.1f)

//            //{

//            //    velocity.X = MathHelper.Clamp(velocity.X, -0.1f, 0.1f);
//            //    velocity.Y = MathHelper.Clamp(velocity.Y, -0.1f, 0.1f);

//            //}


          



//            vel2 = velocity;
//        }

//        public override void Draw(GameTime gameTime)
//        {
//            base.Draw(gameTime);

//            spritebatch.Begin();
//            if (enemy == TypeOfEnemy.Enemy.normal)
//            {
//                //draw how much time is left to 2 decimal places
//                spritebatch.DrawString(font, "Time left: " + time.ToString("N2"), new Vector2(0, 0), Color.Black);
//            }

//            //say whether the cat or mouse has one and tell the player how to reset the game
//            if (win == true)
//            {
//                spritebatch.DrawString(font, "The Mouse Wins! Press Space to play again", new Vector2(300, 350), Color.Red);
//                mouse.CoolDown = 5;
//            }
//            if (lose == true)
//            {
//                spritebatch.DrawString(font, "The Cat Wins! Press Space to play again", new Vector2(300, 350), Color.Red);
//                mouse.CoolDown = 5;
//            }
//            spritebatch.End();
//        }
//    }
//}











































































































































                