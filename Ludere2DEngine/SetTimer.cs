using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using Timer = System.Timers.Timer;

namespace Ludere2DEngine.Ludere2DEngine
{
    public class SetTimer
    {
        // Static Set Timer Information method that returns timer with values
        public static Timer Information(int time, bool loop, bool enabled, string action)
        {
            Timer t;
            t = new Timer(time);
            switch (action)
            {
                case "jump":
                    t.Elapsed += jumpElapsed;
                    break;
                case "idle":
                    t.Elapsed += idleElapsed;
                    break;
                case "move":
                    t.Elapsed += moveElapsed;
                    break;
                default:
                    t.Elapsed += eventElapsed;
                    break;
            }

            t.AutoReset = loop;
            t.Enabled = enabled;
            return t;
        }

        ///////////////////////////////////////
        //////// Event Elapsed Handler ////////
        ///////////////////////////////////////
        private static void moveElapsed(object sender, ElapsedEventArgs e)
        {
            TestGame.player.Animation("Player/playerMove1", "Player/playerMove2");
        }

        public static void eventElapsed(object sender, ElapsedEventArgs e)
        {
            Log.Send("Default Timer Elapsed");
        }

        public static void idleElapsed(object sender, ElapsedEventArgs e)
        {
            TestGame.player.Animation("Player/playerIdle1", "Player/playerIdle2");
        }

        private static void jumpElapsed(object sender, ElapsedEventArgs e)
        {
            TestGame.jump = false;
            TestGame.timerJump.Stop();
        }
    }
}
