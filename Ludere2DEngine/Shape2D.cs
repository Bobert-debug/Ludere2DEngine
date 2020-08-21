using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Ludere2DEngine.Ludere2DEngine
{
    public class Shape2D
    {
        //Shape's variables
        public Vector2 position = null;
        public Vector2 scale = null;
        public string Tag = "";

        // Shape2D Constructor, gets position, scale and tag to create a shape
        public Shape2D(Vector2 position, Vector2 scale, string Tag)
        {
            this.position = position;
            this.scale = scale;
            this.Tag = Tag;

            Log.Send($"[SHAPE2D] {Tag} has been registered");
            Ludere2DEngine.RegisterShape(this);
        }

        // Destroys the Shape
        public void DestroySelf()
        {
            Log.Send($"[SHAPE2D] {Tag} has been removed");
            Ludere2DEngine.RemoveShape(this);
        }
    }
}
