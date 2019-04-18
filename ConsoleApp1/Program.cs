using System;
using Dal;

namespace ConsoleApp1
{
    class Temp
    {
        readonly IDal library = new Edal();

        public void func()
        {
            bool t = library.PersonSaveCredentials("login", "password", "firstName", "lastName", "email@xx.ua", "male", "phone", "false", "false");
            Console.WriteLine(t);
        }

        public void func2()
        {
            var t = library.GetAllPeople();
            var temp = 0;           
        }

        public void func3()
        {
            var t = library.PersonLoadPhoto("login", "password", @"D:\\1.jpg");
            var temp = 0;
        }
    }



    class Program
    {
        //readonly IDal library;// = new Edal();

        


       

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var temp = new Temp();

            //temp.func();

            //temp.func2();

            temp.func3();
        }
    }
}
