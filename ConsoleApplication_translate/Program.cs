using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication_translate
{
    public class Person
    {
        public string Name { get; set; }
        public Person(string name)
        {
            this.Name = name;
        }
        /// <summary>
        /// 事件参数类
        /// </summary>
        public class TransEventAgrs : EventArgs
        {
            public string word;
            public TransEventAgrs(string str)
            {
                word = str;
            }
        }
        public delegate void TrandsEventHandler(object send, TransEventAgrs e);
        public event TrandsEventHandler TrandsEvent;
        public virtual void OnTrands(TransEventAgrs e)
        {
            if (TrandsEvent != null)
            {
                TrandsEvent(this, e);
            }
        }
        public void Speak(string word)
        {
            TransEventAgrs e = new TransEventAgrs(word);
            OnTrands(e);
        }
    }

    public class TrandsEventListener
    {
        public void ProduceSound_vip(object sender, Person.TransEventAgrs e)
        {
            Console.WriteLine(string.Format("{0}:{1},正在vip翻译成各国语言", ((Person)sender).Name, e.word));
        }
        public void ProduceSound(object sender, Person.TransEventAgrs e)
        {
            Console.WriteLine(string.Format("{0}:{1},正在翻译成各国语言", ((Person)sender).Name, e.word));
            if (((Person)sender).Name == "aobama")
            {
                ((Person)sender).TrandsEvent += ProduceSound_vip;
                ((Person)sender).TrandsEvent -= ProduceSound;
            }
        }
        public void Subscribe(Person person)
        {
            //person.TrandsEvent += new Person.TrandsEventHandler(ProduceSound);
            person.TrandsEvent += ProduceSound;
        }
        public void UnSubscribe(Person person)
        {
            //person.TrandsEvent -= new Person.TrandsEventHandler(ProduceSound);
            person.TrandsEvent -= ProduceSound;
        }
    }



    class Program
    {
        static void Main(string[] args)
        {
            #region 
            Person aobama = new Person("aobama");
            Console.WriteLine("奥巴马开始演讲了");
            TrandsEventListener Translator = new TrandsEventListener();
            Translator.Subscribe(aobama);
            aobama.Speak("first:Long live China");
            aobama.Speak("second:Long live China");

            Person xidada = new Person("习大大");
            Translator.Subscribe(xidada);
            xidada.Speak("first;奥巴马说的对");
            //try
            //{
            //    xidada.Speak("first;奥巴马说的对");
            //}
            //catch (Exception)
            //{

            //    throw;
            //}
            //finally
            //{
            //    xidada.TrandsEvent -= Translator.ProduceSound;
            //}

            xidada.Speak("second:奥巴马说的对");
            Console.ReadKey();
            #endregion

        }
    }

    
}
