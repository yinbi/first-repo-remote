using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication2
{
    //public delegate void MyTransHandler<TParam1>(TParam1 param1);
    /// <summary>
    /// 发布事件类
    /// </summary>
    public class Person
    {
        /// <summary>
        /// (发布)事件参数类
        /// </summary>
        public class TransEventAgrs : EventArgs
        {
            public string word;
            public TransEventAgrs(string str)
            {
                word = str;
            }
        }
        //定义delegate
        public delegate void TranslateEventHandler(object send, TransEventAgrs e);

        //事件对象
        public event TranslateEventHandler TransEvent;

        //事件触发方法
        public virtual void OnTransEvent(TransEventAgrs e)
        {
            if (TransEvent != null)
            {
                TransEvent(this, e);
            }
        }
        //引发事件
        public void Speak(string str)
        {
            TransEventAgrs e = new TransEventAgrs(str);
            OnTransEvent(e);
        }


    }
    //(订阅)监听事件类 (重复器)
    public class TransEventListener
    {
        //定义本地处理事件的方法 他与声明的事件delegate有相同的参数和返回值类型
        public void ProduceSound(object sender, Person.TransEventAgrs e)
        {
            Console.WriteLine(string.Format("事件触发者:{0},说:{1}", sender, e.word));
        }
        //订阅事件
        public void Subscribe(Person person)
        {
            person.TransEvent += new Person.TranslateEventHandler(ProduceSound);
        }
        //取消订阅事件
        public void UnSubscribe(Person person)
        {
            person.TransEvent -= new Person.TranslateEventHandler(ProduceSound);
        }

    }
    class Program
    {
        #region
        //static void Main(string[] args)
        //{
        //    MyTransHandler<string> mydele = new MyTransHandler<string>(TransToCN);
        //    //MyTransHandler<string> mydele = TransToCN;
        //    mydele("speak");
        //    Console.ReadKey();
        //}
        //static void Translate(string str, MyTransHandler<string> transDele)
        //{
        //    transDele(str);
        //}
        //static void TransToCN(string str)
        //{
        //    Console.Write(string.Format("translage zh-cn:{0}", str));
        //}
        //static void TransToEC(string str)
        //{
        //    Console.Write(string.Format("translage en-us:{0}", str));
        //}
        #endregion
        static void Main(string[] args)
        {
            //创建事件源对象
            Person person = new Person();
            //创建监听对象
            TransEventListener changer = new TransEventListener();

            //订阅事件
            Console.WriteLine("订阅事件");
            changer.Subscribe(person);

            //引发事件
            Console.WriteLine("引发事件");
            person.Speak("我说了一句话，你们去翻译吧");
            person.Speak("我又说了一句话，你们去翻译吧");

            //取消订阅事件
            Console.WriteLine("取消订阅事件");
            changer.UnSubscribe(person);

            //引发事件
            Console.WriteLine("引发事件");
            person.Speak("我再次说了一句话，你们去翻译吧");
            Console.ReadKey();
        }
    }
}
