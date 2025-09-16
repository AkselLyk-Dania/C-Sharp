using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

//Test

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
            public const int geoNum = 3;
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



            /////////////////////////
            ////////Geografi/////////
            /////////////////////////

            //Har tre sværhedsgrader: Nemt, middel og svært
            //Viser tilfældige spørgsmål, som vises én gang med score
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

            }

            void QuizTimeGeoNem()
            {
                //Hvis svaret spørgsmål er det samme, som maks har du vundet
                if (Globals.sporgsNum == Globals.geoNum)
                {
                    string geoNemTillykke = "Tillykke! Du har vundet quizzen med top score!";
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
                    "Hvad hedder det største hav i verden?"
                };

                string[] svarGeoNem =
                {
                    "Antarktis",
                    "København",
                    "Stillehavet"
                };

                string korrekt = "Korrekt! Din score er: ";
                string forkert1 = "Forkert! Bedre held næste gang!";

                //Bruges til at lave et tilfældigt nummer
                Random rnd = new Random();
                //Next bruges til at komme med et tilfældigt nummber fra min til maks
                Globals.rNum = rnd.Next(0, Globals.geoNum);

                if (Globals.sporgsNum > 0) //Køres kun hvis man har svaret rigtigt én gang
                {
                    for (int i = 0; i < 10; i++)
                    {
                        //quizMemory array bruges til at genkende allerede svaret spørgsmål, som er lavet tilfældigt
                        //Hvis de er identiske... genstarter quizzen og prøver indtil der er et ledigt tal
                        if (Globals.rNum == Globals.quizMemory[i]) //...men er det lovligt!?
                        {
                            Thread.Sleep(1); //Ét milllisekund for delay for hvert gang den skifter
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

                Console.WriteLine("");
                string geoSvaretNem = Console.ReadLine();

                if (geoSvaretNem == svarGeoNem[Globals.rNum])
                {
                    Globals.score++;
                    Globals.sporgsNum++;
                    Globals.quizMemory[Globals.sporgsNum] = Globals.rNum;
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
    }
}
