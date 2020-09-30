using System;
using System.Drawing;
using Ludere2DEngine.Ludere2DEngine;
using System.Windows.Forms;
using Timer = System.Timers.Timer;

namespace Ludere2DEngine
{
    public class TestGame : Ludere2DEngine.Ludere2DEngine
    {
        public static Sprite2D player; // Player Sprite
        public static Sprite2D playerCollider; // Player's foot collider

        // Movement Variables
        bool right;
        bool left;
        float y;
        public static bool canJump = true, jump;
        public bool blockRight = false;
        public bool blockLeft = false;

        // Timers / Animations
        public static Timer idleAnim;
        public static Timer moveAnim;
        public static Timer timerJump = SetTimer.Information(350, false, false, "jump");

        //Other stuff
        public static Sprite2D coin; // Coin Sprite
        public Random rnd = new Random(); // Random class


        ////////////////////
        /////Level Map//////
        ////////////////////
        string[,] Level =
        {
            {".", ".", ".", ".", ".", ".", ".", ".", ".", "."},
            {"a", ".", ".", ".", ".", ".", ".", ".", ".", "w"},
            {"a", ".", ".", ".", ".", ".", ".", ".", ".", "w"},
            {"a", ".", ".", ".", ".", ".", ".", ".", ".", "w"},
            {"a", ".", ".", ".", ".", ".", ".", ".", ".", "w"},
            {"g", "g", "g", "g", "g", "g", "g", "g", "g", "g"},
            {"d", "d", "d", "d", "d", "d", "d", "d", "d", "d"},
        };

        public TestGame() : base(new Vector2(582, 512), "Ludere2D Demo") // Constructor that Sets a Game Resolution, Window Name
        {

        }


        public override void onLoad() // Executed once at the start of the game
        {
            BackGroundColor = Color.LightBlue; // BG Color

            // Set Camera Offset
            CameraPosition.X -= 12;
            CameraPosition.Y += 25;

            ////////////////////////////////////////////
            // Convert Level Map's Strings to Sprites //
            ////////////////////////////////////////////
            for (int i = 0; i < Level.GetLength(1); i++)
            {
                for (int a = 0; a < Level.GetLength(0); a++)
                {

                    if (Level[a, i] == "g")
                    {
                        Sprite2D grass = new Sprite2D(new Vector2(i * 64, a * 64), new Vector2(64, 64), "Grass", "Tiles/Grass"); // Grass
                    }

                    if (Level[a, i] == "a")
                    {
                        Sprite2D wallA = new Sprite2D(new Vector2(i * 64, a * 64), new Vector2(64, 64), "WallA", "empty"); // Left Wall
                    }

                    if (Level[a, i] == "w")
                    {
                        Sprite2D wallD = new Sprite2D(new Vector2(i * 64, a * 64), new Vector2(64, 64), "WallD", "empty"); // Right Wall
                    }

                    if (Level[a, i] == "d")
                    {
                        Sprite2D dirt = new Sprite2D(new Vector2(i * 64, a * 64), new Vector2(64, 64), "Dirt", "Tiles/Dirt"); // Dirt
                    }
                }
            }
            
            // Setting Sprites
            player = new Sprite2D(new Vector2(256, 220), new Vector2(53, 64), "Player", "Player/playerIdle1"); // Player
            playerCollider = new Sprite2D(new Vector2(256 + 18, 220 + 54), new Vector2(15, 10), "PlayerCollider", "empty"); // Player Foot Collider
            coin = new Sprite2D(new Vector2(150, 210), new Vector2(32, 32), "Coin", "Coin"); // Coin

            // Player Foot Collider o
            playerCollider.position.X = player.position.X + 18; 
            playerCollider.position.Y = player.position.Y + 54;

            // Setting Timers / Animations
            idleAnim = SetTimer.Information(750, false, false, "idle");
            moveAnim = SetTimer.Information(250, false, false, "move");

            
            
        }

        public override void onDraw() 
        {

        }

        public float score;

        public override void onUpdate() // Executed every frame
        {
            if(player.scale.X > 0)
            {
                player.collider.X = (int)player.position.X;
                player.collider.Y = (int)player.position.Y;
            }
            else
            {
                player.collider.X = (int)player.position.X + (int)player.scale.X;
                player.collider.Y = (int)player.position.Y;
            }


            ///////////////////
            //Player Movement//
            /////////////////// 
            if (right && !blockRight)
            {
                player.flipX(false);
                player.position.X += 1f;
                idleAnim.Stop();
                moveAnim.Start();
            }
            else if (left && !blockLeft)
            {
                player.flipX(true);
                player.position.X -= 1f;
                idleAnim.Stop();
                moveAnim.Start();
            }
            else if (y == 0)
            {
                idleAnim.Start();
                moveAnim.Stop();
            }
            player.position.Y += y;

            if (player.scale.X < 0)
            {
                playerCollider.position.X = player.position.X - 32;
            }
            else
            {
                playerCollider.position.X = player.position.X + 18;
            }
            playerCollider.position.Y = player.position.Y + 54;

            if (jump)
            {
                y = -3f;
                timerJump.Start();

            }

            //////////////
            //Collisions//
            //////////////

            if (player.collider.IntersectsWith(coin.collider))
            {
                score++;
                float position = rnd.Next(64, 400);
                coin.DestroySelf();
                coin = new Sprite2D(new Vector2(rnd.Next(64, 400), 210), new Vector2(32, 32), "Coin" + score, "Coin");
            }

            /*if (player.IsColliding(player, coin))
            {
                score++;
                float position = rnd.Next(64, 400);
                coin.DestroySelf();
                coin = new Sprite2D(new Vector2(rnd.Next(64, 400), 210), new Vector2(32, 32), "Coin" + score, "Coin");
            }*/

            if (playerCollider.IsCollidingTag("Grass") && !jump)
            {
                y = 0;
                canJump = true;
            }
            else if(!jump)
            {
                y = 1.5f;
                canJump = false;
            }

            if (player.IsCollidingTag("WallA"))
            {
                blockLeft = true;
            }
            else
            {
                blockLeft = false;
            }

            if(player.IsCollidingTag("WallD"))
            {
                blockRight = true;
            }
            else
            {
                blockRight = false;
            }
        }

        //////////////////////
        //Get Key Down Input//
        //////////////////////
        public override void getKeyDown(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.D) { right = true; }
            if (e.KeyCode == Keys.A) { left = true; }
            if (e.KeyCode == Keys.Space)
            {
                if (canJump)
                {
                    jump = true;
                    canJump = false;
                }
            }
        }

        ////////////////////
        //Get Key Up Input//
        ////////////////////
        public override void getKeyUp(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.D) { right = false; }
            if (e.KeyCode == Keys.A) { left = false; }
        }
    }
}
