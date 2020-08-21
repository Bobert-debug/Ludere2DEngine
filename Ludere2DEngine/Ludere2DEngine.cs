using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Threading;

namespace Ludere2DEngine.Ludere2DEngine
{

    class Canvas : Form
    {
        public Canvas()
        {
            this.DoubleBuffered = true;
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // Canvas
            // 
            this.ClientSize = new System.Drawing.Size(407, 254);
            this.Name = "Canvas";
            this.ResumeLayout(false);

        }
    }

    public abstract class Ludere2DEngine
    {
        private Vector2 ScreenSize = new Vector2(512, 512);
        private string Title = "Demo Game";
        private Canvas Window = null;
        private Thread GameLoopThread = null;

        public static List<Shape2D> AllShapes = new List<Shape2D>();
        public static List<Sprite2D> AllSprites = new List<Sprite2D>();

        public Color BackGroundColor = Color.Beige;

        public Vector2 CameraPosition = Vector2.Zero();

        public Ludere2DEngine(Vector2 ScreenSize, string Title)
        {
            Log.Send("Game is starting...");

            this.ScreenSize = ScreenSize;
            this.Title = Title;

            Window = new Canvas();
            Window.Size = new Size(Convert.ToInt32(this.ScreenSize.X), Convert.ToInt32(this.ScreenSize.Y));
            Window.Text = this.Title;
            Window.Paint += Renderer;
            Window.KeyDown += Window_KeyDown;
            Window.KeyUp += Window_KeyUp;


            GameLoopThread = new Thread(GameLoop);
            GameLoopThread.Start();

            Application.Run(Window);
        }

        private void Window_KeyUp(object sender, KeyEventArgs e)
        {
            getKeyUp(e);
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            getKeyDown(e);
        }

        public static void RegisterShape(Shape2D shape)
        {
            AllShapes.Add(shape);
        }
        public static void RemoveShape(Shape2D shape)
        {
            AllShapes.Remove(shape);
        }

        public static void RegisterSprite(Sprite2D sprite)
        {
            AllSprites.Add(sprite);
        }
        public static void RemoveSprite(Sprite2D sprite)
        {
            AllSprites.Remove(sprite);
        }

        void GameLoop()
        {

            onLoad();

            while (GameLoopThread.IsAlive)
            {
                try
                {
                    onDraw();
                    Window.BeginInvoke((MethodInvoker)delegate { Window.Refresh(); });
                    onUpdate();
                    Thread.Sleep(1);
                }
                catch
                {
                    Log.Error("Waiting for game...");
                    
                }

            }
        }

        private void Renderer(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            g.Clear(BackGroundColor);

            g.TranslateTransform(CameraPosition.X, CameraPosition.Y);

            foreach (Shape2D shape in AllShapes.ToList())
            {
                g.FillRectangle(new SolidBrush(Color.Red), shape.position.X, shape.position.Y, shape.scale.X, shape.scale.Y);
            }

            foreach (Sprite2D sprite in AllSprites.ToList())
            {
                g.DrawImage(sprite.Sprite, sprite.position.X, sprite.position.Y, sprite.scale.X, sprite.scale.Y);
            }
        }

        public abstract void onLoad();
        public abstract void onUpdate();
        public abstract void onDraw();
        public abstract void getKeyDown(KeyEventArgs e);
        public abstract void getKeyUp(KeyEventArgs e);
    }
}
