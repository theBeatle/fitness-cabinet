using System;
using Dal;

namespace ConsoleApp1
{
    class Temp
    {
        readonly IDal library = new Edal();

        public void func()
        {
            bool t = library.DBUserSaveCredentials("login", "password", "firstName", "lastName", "email", "sex", "phone", "false", "false");
            Console.WriteLine(t);
        }
    }



    class Program
    {
        //readonly IDal library;// = new Edal();

        


       

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var temp = new Temp();

            temp.func();


        }
    }
}
