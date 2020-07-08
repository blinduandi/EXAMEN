using System;
using System.Xml;
using System.Threading;

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
              Console.WriteLine("\t\t\t\t\t\tLOADING.");
                Thread.Sleep(200);
                Console.Clear();
              Console.WriteLine("\t\t\t\t\t\tLOADING..");
                Thread.Sleep(200);
                Console.Clear();
              Console.WriteLine("\t\t\t\t\t\tLOADING...");

            }
            
            load();
        }


        public static void load()
        {
            //informatia din XML
            XmlTextWriter writer = new XmlTextWriter("exemplu.xml", System.Text.Encoding.UTF8);
            writer.WriteStartDocument(true);
            writer.Formatting = Formatting.Indented;

            writer.WriteStartElement("Exemplu"); //<Exemplu>
            writer.WriteStartElement("Numar"); //<Numar>
            writer.WriteString("2");  //continut
            writer.WriteEndElement(); //</Numar>
            writer.WriteEndElement(); //</Exemplu>
            writer.WriteEndDocument();
            writer.Close();

            Console.Write("Fisier XML creat cu succes");

        }

    }

    class Login
    {
        bool rezultat; //o vom folosi pentru a memora daca utilizatorul are cont

        public static void select()
        {
            //selectam cu ajutorul unui switch daca avem cont
        }
        public static void login()
        {
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
            Loading.show();

        }
    }
}
