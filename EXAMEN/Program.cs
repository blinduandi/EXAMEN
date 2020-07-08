using System;

namespace EXAMEN
{
    class Loading
    {

        public static void show()
        {
            Console.WriteLine("LOADING...");
        }
        public static void load()
        {
            //informatia din XML
        }
    }
    class Login
    {
        //  bool rezultat; //o vom folosi pentru a memora daca utilizatorul are cont
                 //string Log;
        public static void select()
        {

            Console.WriteLine("\n\n\t\t\t\t\t╔═══════════════════════════════════════╗");
            Console.WriteLine("\t\t\t\t\t║\t Autentificare in sistem \t║");
            Console.WriteLine("\t\t\t\t\t╠═══════════════════════════════════════╣");
            Console.WriteLine("\t\t\t\t\t║\t    Autentificare: 1\t\t║\n\t\t\t\t\t║\t    Inregistrare: 2\t\t║");
            Console.WriteLine("\t\t\t\t\t╚═══════════════════════════════════════╝");

            //selectam cu ajutorul unui switch daca avem cont
            switch (Console.ReadKey(true).KeyChar)
            {
                case '1':
                    // daca logare
                    Console.Clear();
                    login();
                    break;
                case  '2':
                    // code block
                    Console.Clear();
                    inregistrare();                
                    break;
            }

        }
        public static void login()
        {
            //Log = Console.Read();
            Console.WriteLine("\n\n\t\t\t\t\t╔═══════════════════════════════════════╗");
            Console.WriteLine("\t\t\t\t\t║\t      Introdu Login \t\t║");
            Console.WriteLine("\t\t\t\t\t╚═══════════════════════════════════════╝");
            Console.Write("\t\t\t\t\t\t    "); Console.Read();
            Console.Clear();

            Console.WriteLine("\n\n\t\t\t\t\t╔═══════════════════════════════════════╗");
            Console.WriteLine("\t\t\t\t\t║\t Introdu Parola \t\t║");
            Console.WriteLine("\t\t\t\t\t╚═══════════════════════════════════════╝");
            Console.Write("\t\t\t\t\t\t    "); Console.Read();
            Console.Clear();
            //introducem parola si loginul
            //verificam daca datele sunt introduse corect
        }

        public static void inregistrare()
        {
            //introducem parola, loginul, emailul, numele, prenumele, varsta 
            //verificam daca datele sunt introduse corect
        }

    }




    class Principal
    {

        public static void pricipal()
        {
            //afisam informatia despre utilizatorul logat
        }


        public static void search()
        {
            //afisam informatia despre utilizatorul cautat
        }


        public static void prieteni()
        {
            //afisam prietenii utilizatoruli logat
        }




        static void Main(string[] args)
        {
            Login.select();

        }
    }
}
