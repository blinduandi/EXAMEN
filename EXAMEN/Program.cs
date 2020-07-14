using System;
using System.Xml;
using System.Threading;
using System.Data;
using System.IO;
using System.Reflection;
using System.Net.Mail;
using System.Runtime;

namespace EXAMEN
{
    class Loading
    {


        public static void show()
        {
            for (int i = 0; i < 3; i++)
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
            Console.Clear();
            load();
        }


        public static void load()
        {

            string[] login = new string[100];
            string[] parola = new string[100];
         int memor;
  

        XmlDocument xmldoc = new XmlDocument();
            XmlNodeList xmlnode;
            int i = 0;
                        
            FileStream fs = new FileStream("exemplu2.xml", FileMode.Open, FileAccess.Read);
            xmldoc.Load(fs);
            xmlnode = xmldoc.GetElementsByTagName("parola");
            for (i = 0; i < xmlnode.Count; i++)
            {
                xmlnode[i].ChildNodes.Item(0).InnerText.Trim();
                parola[i] = xmlnode[i].ChildNodes.Item(0).InnerText.Trim();

            }

           memor = xmlnode.Count ;
            //Math.Max(xmlnode);

            xmlnode = xmldoc.GetElementsByTagName("login");
            for (i = 0; i < xmlnode.Count ; i++)
            {
                xmlnode[i].ChildNodes.Item(0).InnerText.Trim();
                login[i] = xmlnode[i].ChildNodes.Item(0).InnerText.Trim();

            }

            fs.Close();
            Login a = new Login( parola,  login,  memor) ;
            
            //Console.Clear();
            ////////////
            string save;
            XmlDocument xmldocc = new XmlDocument();
            XmlNodeList xmlnodee;
            
            FileStream fss = new FileStream("exemplu4.xml", FileMode.Open, FileAccess.Read);
            xmldocc.Load(fss);
            xmlnodee = xmldocc.GetElementsByTagName("login");

            save = xmlnodee[0].ChildNodes.Item(0).InnerText.Trim();
            
            if (save == "123456789098") 
            { 
                 fss.Close();
                Login.select();               
            }

            else 
            {
XmlDocument xmldoccc = new XmlDocument();
            XmlNodeList xmlnodeee;
           //////// 
           int util=0;
            FileStream fsss = new FileStream("exemplu2.xml", FileMode.Open, FileAccess.Read);
            xmldoccc.Load(fsss);
            xmlnodeee = xmldoccc.GetElementsByTagName("login");
                for (i = 0; i < xmlnodeee.Count; i++)
                {
                    xmlnodeee[i].ChildNodes.Item(0).InnerText.Trim();
                    if (save == xmlnodeee[i].ChildNodes.Item(0).InnerText.Trim())
                    {
                        util=i;
                    }

                }
                fss.Close();
                fsss.Close();
                Principal.pricipal(util);
            }

        }

    }

    class Login : Principal
    {
        public static bool rezultat = false;

        public static string[] login ;
        public static string[] parola ;
        public static int memor;
        public static int util;
        public Login(string[] _parola, string[] _login, int _memor)
        { 
         login = _login;
         parola = _parola;
         memor= _memor;
        }



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
                    login_();
                    break;
                case '2':
                    // code block
                    Console.Clear();
                    inregistrare();
                    break;
            }

        }
        public static void login_()
        {


        start:
            bool mem = false;

            Console.Clear();
            if (rezultat == true)
            {
                Console.WriteLine("Ati introdus date gresite");
            }

            //introducem parola si loginul
            Console.WriteLine("\n\n\t\t\t\t\t╔═══════════════════════════════════════╗");
            Console.WriteLine("\t\t\t\t\t║\t      Introdu Login \t\t║");
            Console.WriteLine("\t\t\t\t\t╚═══════════════════════════════════════╝");
            Console.Write("\t\t\t\t\t\t    "); string _login = Console.ReadLine();
            Console.Clear();

            Console.WriteLine("\n\n\t\t\t\t\t╔═══════════════════════════════════════╗");
            Console.WriteLine("\t\t\t\t\t║\t Introdu Parola \t\t║");
            Console.WriteLine("\t\t\t\t\t╚═══════════════════════════════════════╝");
            Console.Write("\t\t\t\t\t\t    "); string pass = Console.ReadLine();
            Console.Clear();

            //verificam daca datele sunt introduse corect
            for (int i = 0; i < memor; i++)
            {
               

                if ((_login == login[i]) && (pass == parola[i]))
                {    util = i;
                    mem = true;
                    Principal.pricipal(util); 
                   
                }
            }
          
            if (mem == false)
            {
                rezultat = true;

                goto start;
            }


        }

        public static void inregistrare()
        {
            string filename = "exemplu2.xml";
            XmlDocument doc = new XmlDocument(); //create new instance of XmlDocument
            doc.Load(filename);  //load from file
            XmlNode NodeID = doc.CreateNode(XmlNodeType.Element, "S" + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString(), null);

            //Console.Clear();
            Console.WriteLine("\n\n\t\t\t\t\t╔═══════════════════════════════════════╗");
            Console.WriteLine("\t\t\t\t\t║\t      Introdu Nume \t\t║");
            Console.WriteLine("\t\t\t\t\t╚═══════════════════════════════════════╝");
            Console.Write("\t\t\t\t\t\t    ");
            string Nume = Console.ReadLine();
            XmlNode nodeNume = doc.CreateElement("Nume");
            nodeNume.InnerText = Nume;
            Console.Clear();
            Console.WriteLine("\n\n\t\t\t\t\t╔═══════════════════════════════════════╗");
            Console.WriteLine("\t\t\t\t\t║\t      Introdu Prenume \t\t║");
            Console.WriteLine("\t\t\t\t\t╚═══════════════════════════════════════╝");
            Console.Write("\t\t\t\t\t\t     ");
            string Prenume = Console.ReadLine();
            XmlNode nodePrenume = doc.CreateElement("Prenume");
            nodePrenume.InnerText = Prenume;
            bool bit = true;
        start: 
            Console.Clear();
            if (bit == false)
            {
                Console.WriteLine("Acest nickname nu este disponibil!");
            }
           
            Console.WriteLine("\n\n\t\t\t\t\t╔═══════════════════════════════════════╗");
            Console.WriteLine("\t\t\t\t\t║\t      Introdu Nickname \t\t║");
            Console.WriteLine("\t\t\t\t\t╚═══════════════════════════════════════╝");
            Console.Write("\t\t\t\t\t\t     ");
            string _login = Console.ReadLine();

            for (int i = 0; i < memor; i++)
            {

                if (_login == login[i])
                {   
                    bit = false;
                    goto start;
                    
                }


             }   
                
            XmlNode nodelogin = doc.CreateElement("login");
            nodelogin.InnerText = _login;
            Console.Clear();
            Console.WriteLine("\n\n\t\t\t\t\t╔═══════════════════════════════════════╗");
            Console.WriteLine("\t\t\t\t\t║\t      Introdu parola \t\t║");
            Console.WriteLine("\t\t\t\t\t╚═══════════════════════════════════════╝");
            Console.Write("\t\t\t\t\t\t     ");
            string parola = Console.ReadLine();
            XmlNode nodeparola = doc.CreateElement("parola");
            nodeparola.InnerText = parola;
            Console.Clear();
            Console.WriteLine("\n\n\t\t\t\t\t╔═══════════════════════════════════════╗");
            Console.WriteLine("\t\t\t\t\t║\t      Introdu email \t\t║");
            Console.WriteLine("\t\t\t\t\t╚═══════════════════════════════════════╝");
            Console.Write("\t\t\t\t\t\t     ");
            string mail = Console.ReadLine();
            XmlNode nodemail = doc.CreateElement("mail");
            nodemail.InnerText = mail;
            Console.Clear();

            NodeID.AppendChild(nodeNume);
            NodeID.AppendChild(nodePrenume);
            NodeID.AppendChild(nodelogin);
            NodeID.AppendChild(nodeparola);
            NodeID.AppendChild(nodemail);

            //add to elements collection
            doc.DocumentElement.AppendChild(NodeID);
            //save back
            doc.Save(filename);

            Loading.show();
            //introducem parola, loginul, emailul, numele, prenumele, varsta 
            //verificam daca datele sunt introduse corect
        }

    }



    class Principal
    {

        public static void pricipal(int i)
        {
            string nume, prenume, username, email, prieten;
            int count = 0;

            XmlDocument xmldoc = new XmlDocument();
            XmlNodeList xmlnode;

            FileStream fs = new FileStream("exemplu2.xml", FileMode.Open, FileAccess.Read);
            xmldoc.Load(fs);
            xmlnode = xmldoc.GetElementsByTagName("Nume");
            nume = xmlnode[i].ChildNodes.Item(0).InnerText.Trim();
            xmlnode = xmldoc.GetElementsByTagName("Prenume");
            prenume = xmlnode[i].ChildNodes.Item(0).InnerText.Trim();
            xmlnode = xmldoc.GetElementsByTagName("login");
            username = xmlnode[i].ChildNodes.Item(0).InnerText.Trim();
            xmlnode = xmldoc.GetElementsByTagName("mail");
            email = xmlnode[i].ChildNodes.Item(0).InnerText.Trim();

            XmlNodeList xmlnodes;
            XmlDocument xmldocs = new XmlDocument();
            FileStream fs1 = new FileStream("exemplu3.xml", FileMode.Open, FileAccess.Read);
            xmldocs.Load(fs1);
            xmlnodes = xmldocs.GetElementsByTagName("curent");
            //xmlnod = xmldoc.GetElementsByTagName("prieten");

            for (int j = 0; j < xmlnodes.Count; j++)
            {
                prieten = xmlnodes[j].ChildNodes.Item(0).InnerText.Trim();
                if (username == prieten)
                {

                    count++;
                }
            }

            //////////////////

            static void WriteBlueAlb(string value)
            {
                Console.BackgroundColor = ConsoleColor.Blue;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(value.PadRight(Console.WindowWidth - 1));
                Console.ResetColor();
            }

            //////////////////
            WriteBlueAlb("╔═════════════════════════════════════════════════════════════════════════════════════════════════════════════════════╗");
            WriteBlueAlb("║  Nume: " + nume + " Prenume: " + prenume + " Username: " + username + " Email: " + email + " Prieteni:" + count);
            WriteBlueAlb("╚═════════════════════════════════════════════════════════════════════════════════════════════════════════════════════╝");
            fs.Close();
            fs1.Close();
            //afisam informatia despre utilizatorul logat
            Console.WriteLine("\n\n\t\t\t\t\t╔═══════════════════════════════════════╗");
            Console.WriteLine("\t\t\t\t\t║\t      1.Prieteni \t\t║");
            Console.WriteLine("\t\t\t\t\t║\t      2.Cauta utilizatori \t║");
            Console.WriteLine("\t\t\t\t\t║\t      3.Iesire \t\t\t║");
            Console.WriteLine("\t\t\t\t\t║\t      4.Random \t\t\t║");
            Console.WriteLine("\t\t\t\t\t║\t      5.Iesire \t\t\t║");
            Console.WriteLine("\t\t\t\t\t║\t      6.Log out\t\t\t║");
            Console.WriteLine("\t\t\t\t\t╚═══════════════════════════════════════╝");
            switch (Console.ReadKey(true).KeyChar)
            {
                case '1':
                    // daca logare
                    Console.Clear();
                    prieteni(username, i);
                    break;
                case '2':
                    // code block
                   Console.Clear();
                    search(i, username);
                    break;
                case '3':
                    // daca logare
                     Console.Clear();
                    Environment.Exit(0);
                    break;
                case '4':
                    // code block
                    random(i);
                    break;
                case '5':
                    // code block
                    save(username);
                    break;                
                case '6':
                    // code block
                    exit1();
                    break;
            }

        }
            public static void exit1()
        {
            XmlTextWriter writer = new XmlTextWriter("exemplu4.xml", System.Text.Encoding.UTF8);
            writer.WriteStartDocument(true);
            writer.Formatting = Formatting.Indented;

            writer.WriteStartElement("Exemplu"); //<Exemplu>
            writer.WriteStartElement("login"); //<Numar>
            writer.WriteString("123456789098");  //continut
            writer.WriteEndElement(); //</Numar>
            writer.WriteEndElement(); //</Exemplu>
            writer.WriteEndDocument();
            writer.Close();

            Console.Clear();
            System.Environment.Exit(0);
           
          
        }

        public static void save(string username)
        {
            XmlTextWriter writer = new XmlTextWriter("exemplu4.xml", System.Text.Encoding.UTF8);
            writer.WriteStartDocument(true);
            writer.Formatting = Formatting.Indented;

            writer.WriteStartElement("Exemplu"); //<Exemplu>
            writer.WriteStartElement("login"); //<Numar>
            writer.WriteString(username);  //continut
            writer.WriteEndElement(); //</Numar>
            writer.WriteEndElement(); //</Exemplu>
            writer.WriteEndDocument();
            writer.Close();

            Console.Clear();
            System.Environment.Exit(0);
           
          
        }

        public static void jocul(string BOTU, string TU)
        {
            int NumForGuess = 0;
            Random rnd = new Random();
            NumForGuess = rnd.Next(0, 26);
            Console.WriteLine(BOTU + " Ok m-am gandit la un numar, ghiceste-l...");
            Console.WriteLine(BOTU + " Indiciu, numarul e de la 0 la 25");
            for (int i = 15; i > 1; i--)
            {
                Console.Write(TU + " : ");
                int Num = Convert.ToInt32(Console.ReadLine().ToString());
                if (NumForGuess > Num)
                {
                    Console.WriteLine(BOTU + "Gresit, mai ai " + i + " sanse");
                    Console.WriteLine(BOTU + "Numarul meu e mai mare");
                }
                else
                if (NumForGuess < Num)
                {
                    Console.WriteLine(BOTU + "Gresit, mai ai " + i + " sanse");
                    Console.WriteLine(BOTU + "Numarul meu e mai mic");
                }
                else
                    if (NumForGuess == Num)
                {
                    Console.WriteLine(BOTU + "ehhh, cu tine nu e interesant, prea repede ghicesti:)");
                    Console.WriteLine(BOTU + "Mai joci?");
                    return;
                }
            }
        }

        public static void gluma(string BOTU, string TU)
        {
            String[] Joke = new String[] { " : Bulă, pe care raft din bibliotecă ai pus cărţile de C#? \n\t – La raftul de cărţi horror.",
                                           " : O barză zboară cu un moș în cioc. La un moment dat mosneagu zice : \n\t -Hai , recunoaște că ne-am rătăcit !",
                                           " : Chuck Norris era pe moarte. Dupa o zi de chinuri moartea la implorat sa se dea jos",
                                           " : Chuck Norris s-a uitat o dată la soare timp de zece ore. Şi soarele a clipit primul",
                                           " : Chuck Norris nu va face niciodată infarct. Inima nu e atât de tâmpită să-l atace",
                                           " : Știți cum zic moldovenii la „Războiul Stelelor”? \n\t Galshiava pi sher!",
                                           " : Chuck Norris era pe moarte. Peste o zi, moartea la implorat să se dea jos",
                                           " : Azi, Nick Bota ma aciveaza si intreaba: \n\t Cortana, cat costa un deputat, imi ajunge din salariu de la STEP? "
                                          };



            Random rnd = new Random();
            int JokeGetter = rnd.Next(0, Joke.Length + 1);



            Console.WriteLine(BOTU + Joke[JokeGetter]);

        }



        public static void mesaje(string BOTU,int asd )
        {

            #region  intrebari raspuns
            String TU = "TU : ";
            
            Console.WriteLine(BOTU + " : Salut eu sunt "+BOTU+"\n\tdar pe tine cum te chama?");
            Console.Write(TU + " : Eu sunt  ");
            String Name = Console.ReadLine();
            TU = Name;
            Console.WriteLine(BOTU + " : Ok, salut " + Name + " !");
            Console.WriteLine(BOTU + " : Cati ani ai " + Name + " ?");
            int ani = Convert.ToInt32(Console.ReadLine());
            if (ani < 18)
            { Console.WriteLine(BOTU + " : Aoleu, esti inca minor. La o bere nu ne putem duce!"); }
            else { Console.WriteLine(BOTU + " : Super, hai la o bere."); }
            Console.WriteLine(BOTU + " : Sa-mi scuzi nesimtirea, " + Name + " cum e la tine?");
            Console.Write(TU + " : ");
            String UH = Console.ReadLine();
            String UHL = UH.ToLower();
            if (UHL.Contains("bine") || UHL.Contains("ok") || UHL.Contains("super")
             || UHL.Contains("very good") || UHL.Contains("good"))
            {
                Console.WriteLine(BOTU + " : Minunat, la mine tot e bine");
                Console.WriteLine("Sa-ti zic o gluma :) ");
                Console.WriteLine("sau poate vrei sa jucam un joc?:)");
                Console.WriteLine("ce vrei?");
            }
            else
            {
                Console.WriteLine(BOTU + " : Aoleu...Cu ce te pot ajuta " + TU + " ?");
                Console.WriteLine("Sa-ti zic o gluma :) ");
                Console.WriteLine("sau poate vrei sa jucam un joc?:)");
                Console.WriteLine("ce vrei?");
            }
            #endregion

            String dupabanc2="";


            String Need = Console.ReadLine();
        ziigluma:
            String need_l = Need.ToLower();
            if (need_l.Contains("zii") || need_l.Contains("gluma") || need_l.Contains("zii gluma") || need_l.Contains("zii o gluma") || need_l.Contains("zii")
                || need_l.Contains("banc") || need_l.Contains("zii bancul") || need_l.Contains("zii un banc"))
            {

                gluma(BOTU, TU);
                Console.WriteLine("Mai vrei una?");
             dupabanc2 = Console.ReadLine().ToLower();
            }
            //String dupajoc2 = dupajoc.ToLower();
           else if (dupabanc2.Contains("da") || dupabanc2.Contains("bine") || dupabanc2.Contains("ok") || dupabanc2.Contains("dai") || dupabanc2.Contains("mai dai"))
            {
                need_l = "gluma";
                goto ziigluma;
            }
            else
            {
                need_l = "game";
                goto finisarebanc;
            }
        finisarebanc:
           // Console.WriteLine(BOTU + " : Poate sa-ti zic un banc?");
            Console.Write(TU + " : ");



            String Raso1 = Console.ReadLine();
            Need = Raso1.ToLower();
            if (Raso1.Contains("zii") || Raso1.Contains("zii gluma") || Raso1.Contains("zii o gluma") || Raso1.Contains("zii") || Raso1.Contains("banc") || Raso1.Contains("zii bancul") || Raso1.Contains("zii un banc"))
            {
                need_l = "game";
                goto jocnou;



            }
            else
            {
                Console.WriteLine(BOTU + "Sper ca ti-am ridicat dispozitia. Ma poti apela oricand.");
                goto final;
            }




        jocnou:
            if (need_l.Contains("game") || need_l.Contains("joc") || need_l.Contains("jocul") || need_l.Contains("da sa joc") || need_l.Contains("da sa jucam") || need_l.Contains("hai sa ne jucam") || need_l.Contains("hai sa jucam"))
            {
                jocul(BOTU, TU);
            }
            String dupajoc2 = Console.ReadLine().ToLower();
            //String dupajoc2 = dupajoc.ToLower();
            if (dupajoc2.Contains("da") || dupajoc2.Contains("bine") || dupajoc2.Contains("ok") || dupajoc2.Contains("dai") || dupajoc2.Contains("mai dai"))
            {
                need_l = "game";
                goto jocnou;
            }
            else
            {
                need_l = "gluma";
                goto finisarejoc;
            }
        finisarejoc:
            Console.WriteLine(BOTU + " : Poate sa-ti zic un banc?");
            Console.Write(TU + " : ");



            String Raso = Console.ReadLine();
            Need = Raso.ToLower();
            if (Raso.Contains("zii") || Raso.Contains("zii gluma") || Raso.Contains("zii o gluma") || Raso.Contains("zii") || Raso.Contains("banc") || Raso.Contains("zii bancul") || Raso.Contains("zii un banc"))
            {
                need_l = "gluma";
                goto ziigluma;



            }
            else
            {
                Console.WriteLine(BOTU + "Sper ca ti-am ridicat dispozitia. Ma poti apela oricand.");
            }
        final:
            Console.WriteLine("Pentru a iesi tastează 1");
            String finalul = Console.ReadLine();
            if (finalul == "1")
            {
                pricipal(asd);
            }
        }




    

    public static void search(int j,string curent)
        {sta:
            string login;

            Console.Clear();
            Console.WriteLine("\n\n\t\t\t\t\t╔═══════════════════════════════════════╗");
            Console.WriteLine("\t\t\t\t\t║\t      Introdu nickname \t\t║");
            Console.WriteLine("\t\t\t\t\t╚═══════════════════════════════════════╝");
            Console.Write("\t\t\t\t\t\t     ");
            string search = Console.ReadLine();
           
            
            XmlDocument xmldoc = new XmlDocument();
            XmlNodeList xmlnode;

            FileStream fs = new FileStream("exemplu2.xml", FileMode.Open, FileAccess.Read);
            xmldoc.Load(fs);
            xmlnode = xmldoc.GetElementsByTagName("login");
            for (int i = 0; i < xmlnode.Count; i++)
            {
                login = xmlnode[i].ChildNodes.Item(0).InnerText.Trim();
                if (search == login)
                {
                    Console.WriteLine("\t\tUtilizatorul cautat: "+login+"\n\t\t1. Adauga\n\t\t2. Cauta iar\n\t\t3. Pagina principala" );
                    switch (Console.ReadKey(true).KeyChar)
                    {
                        case '1':
                            // daca logare
                            Console.Clear();
                            string filename = "exemplu3.xml";
                            XmlDocument doc = new XmlDocument(); //create new instance of XmlDocument
                            doc.Load(filename);  //load from file
                            XmlNode NodeID = doc.CreateNode(XmlNodeType.Element, "S" + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString(), null);  
                            XmlNode nodecurent = doc.CreateElement("curent");
                            nodecurent.InnerText = curent;
                            XmlNode nodeprieten = doc.CreateElement("prieten");
                            nodeprieten.InnerText = login;
                            doc.DocumentElement.AppendChild(nodeprieten);
                            doc.DocumentElement.AppendChild(nodecurent);
                            doc.DocumentElement.AppendChild(NodeID);

                            doc.Save(filename);

                            pricipal(j);
                            break;
                        case '2':
                            // code block
                            Console.Clear();
                            goto sta;
         //
                        case '3':
                            // daca logare
                            Console.Clear();
                            pricipal(j);
                            break;
                    }
                }
            }
        



            fs.Close();
            
            
            
            
            
            
            
            //afisam informatia despre utilizatorul cautat
        
        
        }


        public static void prieteni(string _logat ,int a)
        {
            int count=0;
            string[] _login=new string[100];

            XmlDocument xmldoc = new XmlDocument();
            XmlNodeList xmlnode;
            XmlNodeList xmlnod;

            FileStream fs = new FileStream("exemplu3.xml", FileMode.Open, FileAccess.Read);
            xmldoc.Load(fs);
            xmlnode = xmldoc.GetElementsByTagName("curent");
            xmlnod = xmldoc.GetElementsByTagName("prieten");
            for (int g = 0; g < xmlnode.Count; g++)
            {
                _login[g] = xmlnode[g].ChildNodes.Item(0).InnerText.Trim();

                if (_logat == _login[g])
                {
                    Console.WriteLine("Prietenul["+(count+1)+"]: " + xmlnod[g].ChildNodes.Item(0).InnerText.Trim());
                    count++;
                }
            }
            Console.Write("Introduceti nr prietenului dumneavoastra pentru ai vizualiza profilul!     :");
            
            int profil=Convert.ToInt32(Console.ReadLine());
            ///////////////////////////////////////////
            XmlDocument xmldocss = new XmlDocument();
            XmlNodeList xmlnodee;
            int i = 0;
            

            FileStream fss = new FileStream("exemplu2.xml", FileMode.Open, FileAccess.Read);
            xmldocss.Load(fss);
            xmlnodee = xmldocss.GetElementsByTagName("login");
            for (i = 0; i < xmlnodee.Count; i++)
            {
                xmlnodee[i].ChildNodes.Item(0).InnerText.Trim();
                if (xmlnod[profil].ChildNodes.Item(0).InnerText.Trim() == xmlnodee[i].ChildNodes.Item(0).InnerText.Trim())
                {
                    Console.Clear();
                    profil = i;
                    goto Exit;
                    
                }
            }

            
            Exit:
            fss.Close();


            ///////////////////////////////////////////
            string nume, prenume, username, email, prieten;
            int count2 = 0;

            XmlDocument xmldo = new XmlDocument();


            FileStream fs2 = new FileStream("exemplu2.xml", FileMode.Open, FileAccess.Read);
            xmldo.Load(fs2);
            xmlnode = xmldo.GetElementsByTagName("Nume");
            nume = xmlnode[profil].ChildNodes.Item(0).InnerText.Trim();
            xmlnode = xmldo.GetElementsByTagName("Prenume");
            prenume = xmlnode[profil].ChildNodes.Item(0).InnerText.Trim();
            xmlnode = xmldo.GetElementsByTagName("login");
            username = xmlnode[profil].ChildNodes.Item(0).InnerText.Trim();
            xmlnode = xmldo.GetElementsByTagName("mail");
            email = xmlnode[profil].ChildNodes.Item(0).InnerText.Trim();

            XmlNodeList xmlnodes;
            XmlDocument xmldocs = new XmlDocument();
            FileStream fs1 = new FileStream("exemplu3.xml", FileMode.Open, FileAccess.Read);
            xmldocs.Load(fs1);
            xmlnodes = xmldocs.GetElementsByTagName("curent");
            //xmlnod = xmldoc.GetElementsByTagName("prieten");

            for (int j = 0; j < xmlnodes.Count; j++)
            {
                prieten = xmlnodes[j].ChildNodes.Item(0).InnerText.Trim();
                if (username == prieten)
                {

                    count2++;
                }
            }


            //////////////////

            static void WriteBlueAlb(string value)
            {
                Console.BackgroundColor = ConsoleColor.Blue;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(value.PadRight(Console.WindowWidth - 1));
                Console.ResetColor();
            }

            //////////////////



            WriteBlueAlb("╔═════════════════════════════════════════════════════════════════════════════════════════════════════════════════════╗");
            WriteBlueAlb("║  Nume: " + nume + " Prenume: " + prenume + " Username: " + username + " Email: " + email + " Prieteni:" + count2);
            WriteBlueAlb("╚═════════════════════════════════════════════════════════════════════════════════════════════════════════════════════╝");

            Console.WriteLine("\n\n\t\t\t\t\t╔═══════════════════════════════════════╗");
            Console.WriteLine("\t\t\t\t\t║\t    1.Pagina principala \t║");
            Console.WriteLine("\t\t\t\t\t║\t      2.Mesaje \t\t\t║");
            Console.WriteLine("\t\t\t\t\t╚═══════════════════════════════════════╝");
            Console.Write("\t\t\t\t\t\t     ");


            fs2.Close();
            fs1.Close();
            ///////////////////////////////////////////


            switch (Console.ReadKey(true).KeyChar)
            {
                case '1':
                    // daca logare
                    Console.Clear();
                    pricipal(a);

                    break;
                case '2':
                    // code block
                    Console.Clear();
                    mesaje(nume,a);
                    break;
            }


            fs.Close();


            //afisam prietenii utilizatoruli logat
        }

        public static void random(int pas)
        {
            Random rand = new Random();

            string[] numeB = new string[] { "Adelin","Alexandru","Andrei","Anton","Bogdan","Catalin","Cosmin","Costin","Daniel","David","Dragos","Eduard","Emilian","Florin",
                                "Gabriel","George","Iulian","Ivan","Laurentiu","Liviu","Lucian","Madalin","Marius","Octavian","Ovidiu","Paul","Pavel",
                                "Raul","Robert","Sabin","Sebastian","Stefan","Sorin","Teodor","Valentin","Victor","Vlad"
                              };

            string[] numeF = new string[] { "Adelina","Adina","Adriana","Adela","Agnes","Alina","Alexandra","Ana","Anastasia","Anisoara","Ana-Maria","Anca","Angelica","Andreea",
                                "Andra","Antonia","Aurora","Aura","Aurelia","Bogdana","Brandusa","Bianca","Camelia","Carina","Cezara","Cecilia","Crina","Cosmina","Codruta",
                                "Clara","Carmen","Catalina","Carla","Cristina","Claudia","Corina","Daciana","Doina","Dorina","Dalia","Dana","Daniela","Daria","Delia","Diana",
                                "Ecaterina","Elena","Elisabeta","Eliza","Emilia","Ema","Florentina","Felicia","Gabriela","Geanina","Georgiana","Gloria","Gratiela","Gina","Greta",
                                "Ilinca","Ioana","Irina","Iulia","Izabela","Iris","Lacramioara","Laura","Lavinia","Larisa","Letitia","Liliana","Lidia","Luiza","Lucia","Luminita",
                                "Madalina","Mara","Marcela","Maria","Mariana","Melania","Mihaela","Mirela","Mirabela","Monica","Mioara","Nadia","Narcisa","Nicoleta","Nina","Natasa",
                                "Oana","Ozana","Otilia","Olimpia","Olivia","Paula","Raluca","Ramona","Rodica","Romanita","Roxana","Ruxandra","Sabina","Silvia","Simona","Sofia",
                                "Sonia","Stela","Sorina","Sorana","Stefania","Selena","Selina","Simina","Tatiana","Tereza","Teodora","Tamara","Tania","Valentina","Violeta","Victoria",
                                "Viorela","Virginia","Viviana","Zoe","Constanta","Petronela","Jana","Joita","Ileana","Dochia","Draga","Chira","Eufrozina","Fevronia","Crenguta",
                                "Margareta","Niculina","Stana","Vasilica","Zamfira","Dafina","Smaranda","Sanda","Serafima","Matilda","Iustina","Agripina","Ivona","Hortensia",
                                "Elvira","Afina","Dumbravita","Cornelia"
                              };


            string[] numedeF = new string[] { "Popescu","Ionescu","Popa","Pop","Nita","Nitu","Constantinescu","Stan","Stanciu","Dumitrescu","Dima","Gheorghiu","Ionita","Marin","Tudor","Dobre",
                                  "Barbu","Nistor","Florea","Fratila","Dinu","Dinescu","Georgescu","Stoica","Diaconu","Diaconescu","Mocanu","Voinea","Albu","Petrescu","Manole",
                                  "Cristea","Toma","Stanescu","Puscasu","Tomescu","Sava","Ciobanu","Rusu","Ursu","Lupu","Munteanu","Moldoveanu","Muresan","Andreescu","Sava",
                                  "Mihailescu","Iancu","Teodorescu","Moisescu","Calinescu","Tabacu","Negoita","Ifrim"
                                };

            int a = rand.Next(0, 10);

            for (int i=0;i<a;i++)
            {
                string filename = "exemplu2.xml";
                XmlDocument doc = new XmlDocument(); //create new instance of XmlDocument
                doc.Load(filename);  //load from file
                XmlNodeList xmlnode;
                
                XmlNode NodeID = doc.CreateNode(XmlNodeType.Element, "S" + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString(), null);

                string Nume = numedeF[rand.Next(0,30)];
                XmlNode nodeNume = doc.CreateElement("Nume");
                nodeNume.InnerText = Nume;
                int n = rand.Next(0, 1);
                string Prenume;
                if (n % 2 != 0) Prenume = numeB[rand.Next(0, 36)];
                else Prenume = numeF[rand.Next(0, 100)];
                XmlNode nodePrenume = doc.CreateElement("Prenume");
                nodePrenume.InnerText = Prenume;
            start:

                Console.Clear();

                
                string _login = Nume+"."+Prenume+ DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString()+"@gmail.com";
                
                
                xmlnode = doc.GetElementsByTagName("login");

                XmlNode nodelogin = doc.CreateElement("login");
                nodelogin.InnerText = _login;
                string parola = "1";
                XmlNode nodeparola = doc.CreateElement("parola");
                nodeparola.InnerText = parola;
                string mail = Nume + "." + Prenume + "@gmail.com";
                XmlNode nodemail = doc.CreateElement("mail");
                nodemail.InnerText = mail;
                Console.Clear();
                NodeID.AppendChild(nodeNume);
                NodeID.AppendChild(nodePrenume);
                NodeID.AppendChild(nodelogin);
                NodeID.AppendChild(nodeparola);
                NodeID.AppendChild(nodemail);

                //add to elements collection
                doc.DocumentElement.AppendChild(NodeID);
                //save back
                doc.Save(filename);
                Console.Clear();
                pricipal(pas);


            }


        }


        static void Main(string[] args)
        {
            Loading.show();
       

        }
    }
}
