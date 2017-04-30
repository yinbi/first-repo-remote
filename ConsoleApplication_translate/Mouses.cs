using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication_translate
{
    public class Mouses
    {
        public Mouses(Cats cat)
        {
            cat.SoundsEvent += Runaway;
        }
        public class RunawayEventArgs : EventArgs
        {
            public Mouses mouse;
            public RunawayEventArgs(Mouses m)
            {
                mouse = m;
            }
        }
        public delegate void RunawayEventHandler(object send, EventArgs e);
        public event RunawayEventHandler RunawayEvent;

        private void OnRun(EventArgs e)
        {
            if (RunawayEvent != null)
            {
                RunawayEvent(this, e);
            }
        }
        private void Runaway(object sender,EventArgs e)
        {
            Console.WriteLine("老鼠开始逃跑了");
            
        }



    }
}
