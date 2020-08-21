using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Ludere2DEngine.Ludere2DEngine
{
    public class Vector2
    {
        //Gets and Sets Vector2 Values
        public float X { get; set; }
        public float Y { get; set; }


        // Vector2 Constructor if nothing is set
        public Vector2()
        {
            X = Zero().X;
            Y = Zero().Y;
        }

        // Vector2 Constructor if X and Y is set
        public Vector2(float X, float Y)
        {
            this.X = X;
            this.Y = Y;
            
        }

        //Sets a new Vector2(0,0)
        public static Vector2 Zero() 
        {
            return new Vector2(0,0);
        }
    }
}
