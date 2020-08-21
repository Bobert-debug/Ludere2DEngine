using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ludere2DEngine.Ludere2DEngine
{
    public class Sprite2D
    {
        // Sprite variables
        public Vector2 position = null;
        public Vector2 scale = null;
        public string Tag = "";
        public string Directory = "";
        public Bitmap Sprite = null;

        //Frame of Player Animation
        public int frame = 1;

        // Public Sprite2D Constructor that generates a Sprite with parameters
        public Sprite2D(Vector2 position, Vector2 scale, string Tag, string Directory)
        {
            this.position = position;
            this.scale = scale;
            this.Tag = Tag;
            this.Directory = Directory;

            Image tmp = Image.FromFile($"Assets/Sprites/{Directory}.png");
            Bitmap sprite = new Bitmap(tmp);
            Sprite = sprite;


            Log.Send($"[SPRITE2D] {Tag} has been registered");
            Ludere2DEngine.RegisterSprite(this);
        }
        
        // Animation Method
        public void Animation(string firstImage, string secondImage)
        {
            switch (frame)
            {
                case 1:
                    if(firstImage != "")
                    {
                        Image tmp = Image.FromFile($"Assets/Sprites/{firstImage}.png");
                        Bitmap sprite = new Bitmap(tmp);
                        Sprite = sprite;
                    }
                    TestGame.idleAnim.Start();
                    frame++;
                    break;
                case 2:
                    if (secondImage != "")
                    {
                        Image tmp = Image.FromFile($"Assets/Sprites/{secondImage}.png");
                        Bitmap sprite = new Bitmap(tmp);
                        Sprite = sprite;
                    }
                    TestGame.idleAnim.Start();
                    frame--;
                    break;
                default:
                    if (firstImage != "")
                    {
                        Image tmp = Image.FromFile($"Assets/Sprites/{firstImage}.png");
                        Bitmap sprite = new Bitmap(tmp);
                        Sprite = sprite;
                    }
                    TestGame.idleAnim.Start();
                    break;
            }
        }


        //Check collision between 2 sprites
        public bool IsColliding(Sprite2D a, Sprite2D b)
        {
            if(a.position.X < b.position.X + b.scale.X && a.position.X + a.scale.X > b.position.X &&
                a.position.Y < b.position.Y + b.scale.Y && a.position.Y + a.scale.Y > b.position.Y)
            {
                return true;
            }
            return false;
        }
        
        // flip Sprite Function, false = right && true = left
        public void flipX(bool flipX)
        {
            if (flipX && this.scale.X > 0)
            {
                this.scale.X *= -1;
                this.position.X -= this.scale.X;
            }
            else if (!flipX && this.scale.X < 0)
            {
                this.scale.X *= -1;
                this.position.X -= this.scale.X;
            }
        }

        // Check collision with especific object 
        public bool IsCollidingTag(string tag)
        {
            
            
            foreach(Sprite2D b in Ludere2DEngine.AllSprites.ToList())
            {
                if(b.Tag == tag)
                {
                    if (position.X < b.position.X + b.scale.X && 
                    position.X + scale.X > b.position.X &&
                    position.Y < b.position.Y + b.scale.Y && 
                    position.Y + scale.Y > b.position.Y)
                    {
                        return true;
                    }
                }

            }
            return false;
        }

        // DestroySelf Sprite2D
        public void DestroySelf()
        {
            Log.Send($"[SPRITE2D] {Tag} has been removed");
            Ludere2DEngine.RemoveSprite(this);
        }
    }
}
