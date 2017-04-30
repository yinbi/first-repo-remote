using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication_translate
{
    public class Cats
    {
        public Cats(Persons p)
        {
            p.GetUpEvent += Mew;
        }
        public string Name { get; set; }
        public class SoundsEventArgs : EventArgs
        {
            public Cats cat;
            public SoundsEventArgs(Cats c)
            {
                cat = c;
            }
        }
        public delegate void SoundsEventHandler(object send, EventArgs e);
        public event SoundsEventHandler SoundsEvent;
        private void OnSounds(EventArgs e)
        {
            if(SoundsEvent!=null)
            {
                SoundsEvent(this, e);
            }
        }
        public void Mew(object sender,EventArgs e)
        {
            Console.WriteLine("猫叫了");
            //SoundsEventArgs ee = new SoundsEventArgs(this);
            OnSounds(e);
        }

    }
}
