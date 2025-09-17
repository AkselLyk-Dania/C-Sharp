using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProjektBackup
{
    internal class Program
    {
        static void Main(string[] args)
        {
            QuizTime(); //Kør et program
        }

        //Den eneste måde jeg kunne lave globale variabler på, så de kan bruges all steder
        public static class Globals
        {
            //Array for hukommelse for sprøgsmål der allerede er svaret (maks 10)
            public static int[] quizMemory = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            //Points
            public static int score = 0;
            //Hvor mange spørgsmål er gået igennem
            public static int sporgsNum = 0;
            //Hvis forkert svar
            public static int forkert = 0;
            //Reserveret for tilfældigt nummer
            public static int rNum = 0;
            //Maks lavet spørgsmål, skal incrementers hvis flere er lavet
            public const int geoNum = 10;
        }

        static void QuizTime()
        {
            int delay = 700; //Antal millisekunder fra hvert linjeskift
            int charDelay = 19; //Antal millisekunder fra hvert skrevet bogstav

            string velkommen = "Velkommen til vores quiztime.";
            string velkommen2 = "Du kan vælge mellem Matematik eller Geografi:";

            //Denne loop bruges til at skrive bogstav til bogstav, som giver animation
            //Er brugt mange gange (LAV OM TIL EN FUNKTION)
            foreach (char c in velkommen) //Tæller fra begyndelsen af en string til enden
            {
                Console.Write(c); //Skriv bogstavet
                Thread.Sleep(charDelay); //Delay fra hvert bogstav
            }

            Thread.Sleep(delay);
            Console.WriteLine("");
            foreach (char c in velkommen2)
            {
                Console.Write(c);
                Thread.Sleep(charDelay);
            }

            Console.WriteLine("");
            Console.WriteLine("1. Matematik");
            Console.WriteLine("2. Geografi");
            //Console.WriteLine("3. Historie");

            //Vent svar fra brugeren
            string gameSelection = Console.ReadLine();

            switch (gameSelection)
            {
                case "1": //Hvis 1 er skrevet gå til matematik osv.
                    QuizTimeMatematik();
                    break;
                case "2":
                    QuizTimeGeografi();
                    break;
                case "3":
                    //QuizTimeHistorie(); //Hvis vi kan nå det
                    break;
                default: //Alt andet vil ramme default og genstarte programmet
                    QuizTime();
                    break;
            }

            // Abudi´s program/Spil starter her: Hovedregning spil
            void QuizTimeMatematik()
            {
                Console.WriteLine("Hej! Velkommen til Hovedregning spillet.");
                Console.Write("Skriv dit navn: ");
                string navn = Console.ReadLine();
                Console.WriteLine($"Godt at møde dig, {navn}!");

                Console.WriteLine("Tryk Space for at fortsætte...");
                Console.ReadKey(true);

                int liv = 3;
                int point = 0;
                Random rnd = new Random();

                while (liv > 0)
                {
                    Console.WriteLine();
                    Console.WriteLine($"Liv: {liv} | Point: {point}");

                    int tal1 = rnd.Next(1, 100);
                    int tal2 = rnd.Next(1, 100);

                    int korrektSvar = tal1 + tal2;
                    Console.WriteLine($"Hvad er {tal1} + {tal2}?");

                    string input = Console.ReadLine();
                }
            }

//<<<<<<< HEAD
//=======

///////////////////////// //Programmeret af Aksel lykkegaard
////////Geografi///////// //Semi text-adventure uden grafiske visninger men med sværhedsgrader,
///////////////////////// //points or tilfældige spørgsmål

//Har tre sværhedsgrader: Nemt, middel og svært
//Viser tilfældige spørgsmål, som vises én gang med score når man svarer rigtigt
//Kan vindes hvis man svarer all rigtige, ét forket svar taber man

            void QuizTimeGeografi()
            {
                //Hard reset (alle variabler er sat til deres nul værdier)
                Globals.quizMemory = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
                Globals.score = 0;
                Globals.sporgsNum = 0;
                Globals.forkert = 0;
                Globals.rNum = 0;

                string velkommenGeo1 = "velkommen til geografiquizzen, du kan vælge mellem tre";
                string velkommenGeo2 = "sværhedsgrader:";
                Console.Clear(); //Brugt til at rense konsollen for plads

                foreach (char c in velkommenGeo1)
                {
                    Console.Write(c);
                    Thread.Sleep(charDelay);
                }

                foreach (char c in velkommenGeo2)
                {
                    Console.Write(c);
                    Thread.Sleep(charDelay);
                }
                Console.WriteLine("");

                Console.WriteLine("1. Nemt");
                Console.WriteLine("2. Middel");
                Console.WriteLine("3. Svært");
                Console.WriteLine("#. Vis regler");

                string gameSelectionGeo = Console.ReadLine();

                switch (gameSelectionGeo)
                {
                    case "1":
                        QuizTimeGeoNem();
                        break;
                    case "2":
                    //QuizTimeGeoMid();
                    case "3":
                    //QuizTimeGeoSvær();
                    case "#":
                        VisReglerGeo();
                        break;
                    default:
                        QuizTime();
                        break;
                }
            }

            void VisReglerGeo()
            {
                string regel1 = "1. Hvert spil giver dig 10 spørgsmål, hvor du skal svare med navn og stavelse";
                string regel2 = "2. Du vinder hvis du svarer alle spørgsmål, men taber hvis du svarer forkert én gang";
                string regel3 = "3. Spørgsmålene er opstillet med en tilfældig rækkefølge";
                string regel4 = "Tryk på en tast for at gå tilbage...";

                Console.Clear();

                foreach (char c in regel1)
                {
                    Console.Write(c);
                    Thread.Sleep(charDelay);
                }
                Console.WriteLine("");
                foreach (char c in regel2)
                {
                    Console.Write(c);
                    Thread.Sleep(charDelay);
                }
                Console.WriteLine("");
                foreach (char c in regel3)
                {
                    Console.Write(c);
                    Thread.Sleep(charDelay);
                }
                Console.WriteLine("");
                Console.WriteLine("");
                foreach (char c in regel4)
                {
                    Console.Write(c);
                    Thread.Sleep(charDelay);
                }
                Console.ReadKey(true);
                QuizTimeGeografi();
            }

            void QuizTimeGeoNem()
            {
                //Hvis svaret spørgsmål er det samme, som maks har du vundet
                if (Globals.sporgsNum == Globals.geoNum)
                {
                    string geoNemTillykke = "Tillykke! Du har vundet quizzen med top score, som er " + Globals.geoNum + "!";
                    foreach (char c in geoNemTillykke)
                    {
                        Console.Write(c);
                        Thread.Sleep(charDelay);
                    }
                    Thread.Sleep(delay * 5);
                    Console.Clear();
                    QuizTime(); //Programmet genstartes
                    //System.Environment.Exit(0); //return; Er det nødvendigt?!?!?!?
                }

                //Begge skal være identiske for at still de samme spørgsmål og tjekke kravet
                string[] sporgsGeoNem =
                {
                    "Hvad kaldes landet i sydpolen for?",
                    "Hvad hedder Danmarks hovedstad?",
                    "Hvad hedder det største hav i verden?",
                    "Hvad hedder Jyllands nordligste by?",
                    "I Hvilken by ligger Danmarks højeste hus?",
                    "Hvad hedder Danmarks største ø?",

                    "Hvad hedder det store havområde imellem Nord og Sydamerika?", //Amerikanske golf, Mexikanske golf, Atlanterhavet
                    "Hvor høj er himmelbjerget i meter?",//Nævn tre eksempler 147 162 173
                    "Hvilket land ligger Vancouver i?", //Canada, USA, Grønland
                    "Hvor mange indbyggere er der i USA i millioner?", //315 340 356
                    "Hvad hedder Danmarks længste flod/vandløb?", //Gudenåen, Limfjorden, /Storå
                };

                string[,] eksGeoNem =
                {
                    {"1. Den Amerikanske Golf","2. Den Mexikanske Golf","3. Atlanterhavet"},
                    {"1. 147","2. 162","3. 173"},
                    {"1. Canada","2. USA","3. Grønland"},
                    {"1. 315","2. 340","3. 372"},
                    {"1. Gudenåen","2. Limfjorden","3. Storå"}
                };

                string[] svarGeoNem =
                {
                    "antarktis",
                    "københavn",
                    "stillehavet",
                    "skagen",
                    "aarhus",
                    "grønland",

                    "den mexikanske golf", //6
                    "147",
                    "canada",
                    "340",
                    "gudenåen",
                };

                string korrekt = "Korrekt! Din score er: ";
                string forkert1 = "Forkert! Bedre held næste gang!";

                Globals.rNum = RandomNum(0, Globals.geoNum + 1); //se funktionen længere nede

                if (Globals.sporgsNum > 0) //Køres kun hvis man har svaret rigtigt én gang
                {
                    for (int i = 0; i < Globals.geoNum; i++)
                    {
                        //quizMemory array bruges til at genkende allerede svaret spørgsmål, som er lavet tilfældigt
                        //Hvis de er identiske... genstarter quizzen og prøver indtil der er et ledigt tal
                        if (Globals.rNum == Globals.quizMemory[i]) //...men er det lovligt!?
                        {
                            //Test funktioner
                            //Console.WriteLine(Globals.rNum.ToString());
                            //Console.WriteLine(Globals.quizMemory[i].ToString());
                            //Console.WriteLine(Globals.sporgsNum.ToString());
                            //Console.WriteLine(Globals.quizMemory[1].ToString() + Globals.quizMemory[2].ToString() + Globals.quizMemory[3].ToString() + Globals.quizMemory[4].ToString() + Globals.quizMemory[5].ToString() + Globals.quizMemory[6].ToString() + Globals.quizMemory[7].ToString() + Globals.quizMemory[8].ToString() + Globals.quizMemory[9].ToString() + Globals.quizMemory[10].ToString());

                            Thread.Sleep(1); //Ét milllisekund delay for hvert gang den skifter
                            QuizTimeGeoNem();
                        }
                    }
                }

                string sporgsGeoNemNum = string.Format("Spørgsmål " + (Globals.sporgsNum + 1) + ": " + sporgsGeoNem[Globals.rNum]);
                Console.Clear();

                foreach (char c in sporgsGeoNemNum)
                {
                    Console.Write(c);
                    Thread.Sleep(charDelay);
                }

                if(Globals.rNum == 6 || Globals.rNum == 7 || Globals.rNum == 8 || Globals.rNum == 9 || Globals.rNum == 10)
                {
                    Console.WriteLine("");
                    foreach ( char c in eksGeoNem[Globals.rNum-6,0] )
                    {
                        Console.Write(c);
                        Thread.Sleep(charDelay);
                    }
                    Console.WriteLine("");
                    foreach (char c in eksGeoNem[Globals.rNum-6, 1])
                    {
                        Console.Write(c);
                        Thread.Sleep(charDelay);
                    }
                    Console.WriteLine("");
                    foreach (char c in eksGeoNem[Globals.rNum-6, 2])
                    {
                        Console.Write(c);
                        Thread.Sleep(charDelay);
                    }
                }

                Console.WriteLine("");
                Console.Write("Svar: ");
                string geoSvaretNem = Console.ReadLine();

                geoSvaretNem = geoSvaretNem.ToLower();

                if (geoSvaretNem == svarGeoNem[Globals.rNum])
                {
                    Globals.score++;
                    Globals.sporgsNum++;
                    if(Globals.sporgsNum < 9) Globals.quizMemory[Globals.sporgsNum] = Globals.rNum;
                    string korrektSvar = string.Format(korrekt + Globals.score);

                    foreach (char c in korrektSvar)
                    {
                        Console.Write(c);
                        Thread.Sleep(charDelay);
                    }

                }
                else
                {

                    foreach (char c in forkert1)
                    {
                        Console.Write(c);
                        Thread.Sleep(charDelay);
                    }
                    Console.WriteLine("");
                    string gameoverGeoNem = string.Format("GAME OVER! Din score var: " + Globals.score);
                    foreach (char c in gameoverGeoNem)
                    {
                        Console.Write(c);
                        Thread.Sleep(charDelay);
                    }
                    Thread.Sleep(delay * 5);
                    Console.Clear();
                    QuizTime();

                }
                Thread.Sleep(delay * 2);
                Console.Clear();
                QuizTimeGeoNem();
            }
            

        }

        // Returns et tilfældigt nummmer imellem min og max
        static int RandomNum(int min, int max)
        {
            //Bruges til at lave et tilfældigt nummer
            Random rnd = new Random();
            //Next bruges til at komme med et tilfældigt nummber fra min til maks
            return rnd.Next(min,max);
        }
    }
}
