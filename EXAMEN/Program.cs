﻿using System;
using System.Xml;
using System.Threading;
using System.Data;

namespace EXAMEN
{
    class Loading
    {

        public static void show()
        {
            for(int i=0;i<10;i++)
            {
                Thread.Sleep(200);
                Console.Clear();
              Console.WriteLine("\t\t\t\t\t\tLOADING ░");
                Thread.Sleep(200);
                Console.Clear();
              Console.WriteLine("\t\t\t\t\t\tLOADING ░▒");
                Thread.Sleep(200);
                Console.Clear();
              Console.WriteLine("\t\t\t\t\t\tLOADING ░▒▓ ");

            }
            
            load();
        }


        public static void load()
        {

           /* XmlReader xmlFile;
            xmlFile = XmlReader.Create("exemplu2.xml", new XmlReaderSettings());

            Console.WriteLine(xmlFile.Read());*/
        

/* //informatia din XML
        XmlTextWriter writer = new XmlTextWriter("exemplu2.xml", System.Text.Encoding.UTF8);
            writer.WriteStartDocument(true);
            writer.Formatting = Formatting.Indented;

            
            writer.WriteStartElement("Nume"); //<Exemplu>
            writer.WriteString("Andi");
            writer.WriteStartElement("Prenume"); //<Numar>
            writer.WriteString("Blindu");
            writer.WriteStartElement("Login"); //<Numar>
            writer.WriteString("123");
            writer.WriteStartElement("Parola"); //<Numar>
            writer.WriteString("123");
         
            writer.WriteEndElement();
            writer.WriteEndElement();
            writer.WriteEndElement();
            writer.WriteEndElement(); 
            writer.WriteEndDocument();
            writer.Close();


            Console.Write("Fisier XML creat cu succes");
            Console.Clear();*/

        }

    }

    class Login : Principal
    {
         public static bool rezultat = false;

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
                case '2':
                    // code block
                    Console.Clear();
                    inregistrare();
                    break;
            }

        }
        public static void login()
        {
            start:
            Console.Clear();
            if(rezultat == true)
            { 
                Console.WriteLine("Ati introdus date gresite"); 
            }
           
            //introducem parola si loginul
            Console.WriteLine("\n\n\t\t\t\t\t╔═══════════════════════════════════════╗");
            Console.WriteLine("\t\t\t\t\t║\t      Introdu Login \t\t║");
            Console.WriteLine("\t\t\t\t\t╚═══════════════════════════════════════╝");
            Console.Write("\t\t\t\t\t\t    "); string login = Console.ReadLine();
            Console.Clear();

            Console.WriteLine("\n\n\t\t\t\t\t╔═══════════════════════════════════════╗");
            Console.WriteLine("\t\t\t\t\t║\t Introdu Parola \t\t║");
            Console.WriteLine("\t\t\t\t\t╚═══════════════════════════════════════╝");
            Console.Write("\t\t\t\t\t\t    "); string pass = Console.ReadLine();
            Console.Clear();

            //verificam daca datele sunt introduse corect

            if((login=="1") && (pass=="1"))
            {
                Principal.pricipal();
            }
            else
            {
                rezultat = true;

                goto start;
            }

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
            Loading.show();
            Login.select();

        }
    }
}
