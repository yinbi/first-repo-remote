using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication_translate
{
    public class Persons
    {
        public int Age { get; set; }
        public int Sex { get; set; }
        public string Name { get; set; }
        public class GetUpEventArgs : EventArgs
        {
            public Persons person;
            public GetUpEventArgs(Persons p)
            {
                person = p;
            }
        }
        public delegate void GetUpEventHandler(object send, EventArgs e);
        public event GetUpEventHandler GetUpEvent;

        private void OnGetUp(EventArgs e)
        {
            if (GetUpEvent != null)
            {
                GetUpEvent(this, e);
            }
        }

        public void WakeUp()
        {
            Console.WriteLine("人醒了开始起床");
            GetUpEventArgs e = new GetUpEventArgs(this);
            OnGetUp(e);
        }


    }
}
