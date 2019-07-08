using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker
{
  class Reka_zawodnika : Talia
    {
        public int numer_zawodnika;
        public int wartosc_reki;
        public int[] reka = new int[5];
        int liczba_kart = 0;
        public Reka_zawodnika(int numer_zawodnika)
        {
            this.numer_zawodnika = numer_zawodnika;
        }
        public void Wylosowane_karty(int karta) //wylosowaną kartę dodaje do naszej ręki
        {
            reka[liczba_kart] = karta;
            liczba_kart++;
        }
        public void Wyswietl() //sortuje karty znajdujące się w ręce oraz wywołuje metodę do ich wyświetlenia
        {
            Array.Sort(reka);
            Wyswietl(reka);
            Console.WriteLine();
        }

        public void Wyswietl(int[] reka) //wyświetla karty
        {
            for (int i = 0; i < 5; i++)
            {
                Console.BackgroundColor = ConsoleColor.White;
                if (karty[reka[i] - 1].Kolor_karty == "Kier" || karty[reka[i] - 1].Kolor_karty == "Karo") Console.ForegroundColor = ConsoleColor.Red;
                else Console.ForegroundColor = ConsoleColor.Black;
                Console.Write("----------");
                Console.ResetColor();
                Console.Write("      ");
            }
            Console.WriteLine();
            for (int i = 0; i < 5; i++)
            {
                Console.BackgroundColor = ConsoleColor.White;
                if (karty[reka[i] - 1].Kolor_karty == "Kier" || karty[reka[i] - 1].Kolor_karty == "Karo") Console.ForegroundColor = ConsoleColor.Red;
                else Console.ForegroundColor = ConsoleColor.Black;
                if (karty[reka[i] - 1].Rodzaj_karty < 10) Console.Write("|" + karty[reka[i] - 1].Rodzaj_karty + "       |");
                else if (karty[reka[i] - 1].Rodzaj_karty == 10) Console.Write("|" + karty[reka[i] - 1].Rodzaj_karty + "      |");
                else if (karty[reka[i] - 1].Rodzaj_karty == 14) Console.Write("|A       |");
                else if (karty[reka[i] - 1].Rodzaj_karty == 11) Console.Write("|J       |");
                else if (karty[reka[i] - 1].Rodzaj_karty == 12) Console.Write("|Q       |");
                else if (karty[reka[i] - 1].Rodzaj_karty == 13) Console.Write("|K       |");
                Console.ResetColor();
                Console.Write("      ");
            }
            Console.WriteLine();
            for (int i = 0; i < 5; i++)
            {
                Console.BackgroundColor = ConsoleColor.White;
                if (karty[reka[i] - 1].Kolor_karty == "Kier" || karty[reka[i] - 1].Kolor_karty == "Karo") Console.ForegroundColor = ConsoleColor.Red;
                else Console.ForegroundColor = ConsoleColor.Black;
                Console.Write("|        |");
                Console.ResetColor();
                Console.Write("      ");
            }
            Console.WriteLine();
            for (int i = 0; i < 5; i++)
            {
                Console.BackgroundColor = ConsoleColor.White;
                if (karty[reka[i] - 1].Kolor_karty == "Kier" || karty[reka[i] - 1].Kolor_karty == "Karo") Console.ForegroundColor = ConsoleColor.Red;
                else Console.ForegroundColor = ConsoleColor.Black;
                if (karty[reka[i] - 1].Kolor_karty == "Kier" || karty[reka[i] - 1].Kolor_karty == "Karo") Console.Write("|  " + karty[reka[i] - 1].Kolor_karty + "  |");
                else if (karty[reka[i] - 1].Kolor_karty == "Pik") Console.Write("|  " + karty[reka[i] - 1].Kolor_karty + "   |");
                else Console.Write("| " + karty[reka[i] - 1].Kolor_karty + "  |");
                Console.ResetColor();
                Console.Write("      ");
            }
            Console.WriteLine();
            for (int i = 0; i < 5; i++)
            {
                Console.BackgroundColor = ConsoleColor.White;
                if (karty[reka[i] - 1].Kolor_karty == "Kier" || karty[reka[i] - 1].Kolor_karty == "Karo") Console.ForegroundColor = ConsoleColor.Red;
                else Console.ForegroundColor = ConsoleColor.Black;
                Console.Write("|        |");
                Console.ResetColor();
                Console.Write("      ");
            }
            Console.WriteLine();
            for (int i = 0; i < 5; i++)
            {
                Console.BackgroundColor = ConsoleColor.White;
                if (karty[reka[i] - 1].Kolor_karty == "Kier" || karty[reka[i] - 1].Kolor_karty == "Karo") Console.ForegroundColor = ConsoleColor.Red;
                else Console.ForegroundColor = ConsoleColor.Black;
                if (karty[reka[i] - 1].Rodzaj_karty < 10) Console.Write("|       " + karty[reka[i] - 1].Rodzaj_karty + "|");
                else if (karty[reka[i] - 1].Rodzaj_karty == 10) Console.Write("|      " + karty[reka[i] - 1].Rodzaj_karty + "|");
                else if (karty[reka[i] - 1].Rodzaj_karty == 14) Console.Write("|       A|");
                else if (karty[reka[i] - 1].Rodzaj_karty == 11) Console.Write("|       J|");
                else if (karty[reka[i] - 1].Rodzaj_karty == 12) Console.Write("|       Q|");
                else if (karty[reka[i] - 1].Rodzaj_karty == 13) Console.Write("|       K|");
                Console.ResetColor();
                Console.Write("      ");
            }
            Console.WriteLine();
            for (int i = 0; i < 5; i++)
            {
                Console.BackgroundColor = ConsoleColor.White;
                if (karty[reka[i] - 1].Kolor_karty == "Kier" || karty[reka[i] - 1].Kolor_karty == "Karo") Console.ForegroundColor = ConsoleColor.Red;
                else Console.ForegroundColor = ConsoleColor.Black;
                Console.Write("----------");
                Console.ResetColor();
                Console.Write("      ");
            }
            Console.WriteLine();
        }
        public void Wyswietl(int karta_przed, int karta_po) //wyswietla wszystkie zmiany kart na jakie się zdecydowaliśmy
        {
            Console.WriteLine("Stara karta           Nowa karta");
            for (int i = 0; i < 2; i++)
            {
                Console.BackgroundColor = ConsoleColor.White;
                if ((i == 0 && (karty[karta_przed - 1].Kolor_karty == "Kier" || karty[karta_przed - 1].Kolor_karty == "Karo")) || (i == 1 && (karty[karta_po - 1].Kolor_karty == "Kier" || karty[karta_po - 1].Kolor_karty == "Karo"))) Console.ForegroundColor = ConsoleColor.Red;
                else Console.ForegroundColor = ConsoleColor.Black;
                Console.Write("----------");
                Console.ResetColor();
                Console.Write("            ");
            }
            Console.WriteLine();
            int zmienna_pomocniczna = karta_przed;
            for (int i = 0; i < 2; i++)
            {
                Console.BackgroundColor = ConsoleColor.White;
                if ((i == 0 && (karty[karta_przed - 1].Kolor_karty == "Kier" || karty[karta_przed - 1].Kolor_karty == "Karo")) || (i == 1 && (karty[karta_po - 1].Kolor_karty == "Kier" || karty[karta_po - 1].Kolor_karty == "Karo"))) Console.ForegroundColor = ConsoleColor.Red;
                else Console.ForegroundColor = ConsoleColor.Black;
                if (karty[zmienna_pomocniczna - 1].Rodzaj_karty < 10) Console.Write("|" + karty[zmienna_pomocniczna - 1].Rodzaj_karty + "       |");
                else if (karty[zmienna_pomocniczna - 1].Rodzaj_karty == 10) Console.Write("|" + karty[zmienna_pomocniczna - 1].Rodzaj_karty + "      |");
                else if (karty[zmienna_pomocniczna - 1].Rodzaj_karty == 14) Console.Write("|A       |");
                else if (karty[zmienna_pomocniczna - 1].Rodzaj_karty == 11) Console.Write("|J       |");
                else if (karty[zmienna_pomocniczna - 1].Rodzaj_karty == 12) Console.Write("|Q       |");
                else if (karty[zmienna_pomocniczna - 1].Rodzaj_karty == 13) Console.Write("|K       |");
                zmienna_pomocniczna = karta_po;
                Console.ResetColor();
                Console.Write("            ");
            }
            Console.WriteLine();
            for (int i = 0; i < 2; i++)
            {
                Console.BackgroundColor = ConsoleColor.White;
                if ((i == 0 && (karty[karta_przed - 1].Kolor_karty == "Kier" || karty[karta_przed - 1].Kolor_karty == "Karo")) || (i == 1 && (karty[karta_po - 1].Kolor_karty == "Kier" || karty[karta_po - 1].Kolor_karty == "Karo"))) Console.ForegroundColor = ConsoleColor.Red;
                else Console.ForegroundColor = ConsoleColor.Black;
                Console.Write("|        |");
                Console.ResetColor();
                Console.Write("            ");
            }
            Console.WriteLine();
            zmienna_pomocniczna = karta_przed;
            for (int i = 0; i < 2; i++)
            {
                Console.BackgroundColor = ConsoleColor.White;
                if ((i == 0 && (karty[karta_przed - 1].Kolor_karty == "Kier" || karty[karta_przed - 1].Kolor_karty == "Karo")) || (i == 1 && (karty[karta_po - 1].Kolor_karty == "Kier" || karty[karta_po - 1].Kolor_karty == "Karo"))) Console.ForegroundColor = ConsoleColor.Red;
                else Console.ForegroundColor = ConsoleColor.Black;
                if (karty[zmienna_pomocniczna - 1].Kolor_karty == "Kier" || karty[zmienna_pomocniczna - 1].Kolor_karty == "Karo") Console.Write("|  " + karty[zmienna_pomocniczna - 1].Kolor_karty + "  |");
                else if (karty[zmienna_pomocniczna - 1].Kolor_karty == "Pik") Console.Write("|  " + karty[zmienna_pomocniczna - 1].Kolor_karty + "   |");
                else Console.Write("| " + karty[zmienna_pomocniczna - 1].Kolor_karty + "  |");
                zmienna_pomocniczna = karta_po;
                Console.ResetColor();
                if (i == 0) Console.Write("     ->     ");
            }
            Console.WriteLine();
            for (int i = 0; i < 2; i++)
            {
                Console.BackgroundColor = ConsoleColor.White;
                if ((i == 0 && (karty[karta_przed - 1].Kolor_karty == "Kier" || karty[karta_przed - 1].Kolor_karty == "Karo")) || (i == 1 && (karty[karta_po - 1].Kolor_karty == "Kier" || karty[karta_po - 1].Kolor_karty == "Karo"))) Console.ForegroundColor = ConsoleColor.Red;
                else Console.ForegroundColor = ConsoleColor.Black;
                Console.Write("|        |");
                Console.ResetColor();
                Console.Write("            ");
            }
            Console.WriteLine();
            zmienna_pomocniczna = karta_przed;
            for (int i = 0; i < 2; i++)
            {
                Console.BackgroundColor = ConsoleColor.White;
                if ((i == 0 && (karty[karta_przed - 1].Kolor_karty == "Kier" || karty[karta_przed - 1].Kolor_karty == "Karo")) || (i == 1 && (karty[karta_po - 1].Kolor_karty == "Kier" || karty[karta_po - 1].Kolor_karty == "Karo"))) Console.ForegroundColor = ConsoleColor.Red;
                else Console.ForegroundColor = ConsoleColor.Black;
                if (karty[zmienna_pomocniczna - 1].Rodzaj_karty < 10) Console.Write("|       " + karty[zmienna_pomocniczna - 1].Rodzaj_karty + "|");
                else if (karty[zmienna_pomocniczna - 1].Rodzaj_karty == 10) Console.Write("|      " + karty[zmienna_pomocniczna - 1].Rodzaj_karty + "|");
                else if (karty[zmienna_pomocniczna - 1].Rodzaj_karty == 14) Console.Write("|       A|");
                else if (karty[zmienna_pomocniczna - 1].Rodzaj_karty == 11) Console.Write("|       J|");
                else if (karty[zmienna_pomocniczna - 1].Rodzaj_karty == 12) Console.Write("|       Q|");
                else if (karty[zmienna_pomocniczna - 1].Rodzaj_karty == 13) Console.Write("|       K|");
                zmienna_pomocniczna = karta_po;
                Console.ResetColor();
                Console.Write("            ");
            }
            Console.WriteLine();
            for (int i = 0; i < 2; i++)
            {
                Console.BackgroundColor = ConsoleColor.White;
                if ((i == 0 && (karty[karta_przed - 1].Kolor_karty == "Kier" || karty[karta_przed - 1].Kolor_karty == "Karo")) || (i == 1 && (karty[karta_po - 1].Kolor_karty == "Kier" || karty[karta_po - 1].Kolor_karty == "Karo"))) Console.ForegroundColor = ConsoleColor.Red;
                else Console.ForegroundColor = ConsoleColor.Black;
                Console.Write("----------");
                Console.ResetColor();
                Console.Write("            ");
            }
            Console.WriteLine();
        }
        public void Wymiana_kart() //proces wymieniania kart wybranych przez gracza
        {
            bool flaga;
            int wybor;
            do
            {
                flaga = false;
                Console.Write("Ile kart chcesz wymienić? Twoja odp: ");
                wybor = int.Parse(Console.ReadLine());
                if (wybor < 0 || wybor > 5)
                {
                    flaga = true;
                    Console.WriteLine("Twój wybór wykracza poza dozwolony zakres!");
                }
            } while (flaga == true);
            int[] wymiana_karty = new int[wybor];
            int[] stare_karty = new int[wybor];
            for (int i = 0; i < wybor; i++)
            {
                do
                {
                    flaga = false;
                    Console.Write("Podaj " + (i + 1) + " kartę, którą chcesz wymienić (numer karty licząc w kolejności od lewej): ");
                    wymiana_karty[i] = int.Parse(Console.ReadLine());
                    for (int j = 0; j < i; j++)
                    {
                        if (wymiana_karty[i] == wymiana_karty[j])
                        {
                            flaga = true;
                            Console.Write("Podaną kartę już wymieniłeś!\n");
                        }
                    }
                } while (flaga == true);
                stare_karty[i] = reka[wymiana_karty[i] - 1];
                reka[wymiana_karty[i] - 1] = Losowanie();
            }
            Console.Clear();
            if (wybor > 3) Console.SetWindowSize(103, 50); //powiększa okno cmd
            for (int i = 0; i < wybor; i++)
            {
                Wyswietl(stare_karty[i], reka[wymiana_karty[i] - 1]);
            }
            Console.WriteLine("Twoje aktualne karty!");
            Wyswietl(); //wyswietla posortowane karty w naszej ręce
        }
        public void Sprawdzanie_Kart() //sprawdza wartość kart w ręce gracza
        {
            bool kolor = true;
            bool para = false;
            bool para2 = false;
            bool trojka = false;
            bool kareta = false;
            bool kolejnosc = true;
            bool krolewski = true;
            for (int i = 0; i < 5; i++)
            {
                if (i != 4)
                {
                    if (karty[reka[i] - 1].Kolor_karty != karty[reka[i + 1] - 1].Kolor_karty) kolor = false;
                    if (karty[reka[i] - 1].Rodzaj_karty + 1 != karty[reka[i + 1] - 1].Rodzaj_karty)
                    {
                        kolejnosc = false;
                        krolewski = false;
                    }
                }
            }
            if (krolewski == true && (karty[reka[0] - 1].Rodzaj_karty != 10 && karty[reka[4] - 1].Rodzaj_karty != 14)) krolewski = false;
            for (int i = 0; i < 5; i++)
            {
                if (i != 4 && karty[reka[i] - 1].Rodzaj_karty == karty[reka[i + 1] - 1].Rodzaj_karty)
                {
                    if (para == true && para2 == false)
                    {
                        if (karty[reka[i - 1] - 1].Rodzaj_karty == karty[reka[i] - 1].Rodzaj_karty)
                        {
                            para = false;
                            trojka = true;
                        }
                        else
                        {
                            para2 = true;
                        }

                    }
                    else
                    {
                        if (para2 == true && karty[reka[i - 1] - 1].Rodzaj_karty == karty[reka[i] - 1].Rodzaj_karty)
                        {
                            para2 = false;
                            trojka = true;
                        }
                        else
                        {
                            if (trojka == true)
                            {
                                kareta = true;
                                trojka = false;
                            }
                            else
                            {
                                para = true;
                            }
                        }
                    }
                }

            }
            if (krolewski == true && kolejnosc == true && kolor == true) wartosc_reki = 1;
            else if (kolejnosc == true && kolor == true) wartosc_reki = 2;
            else if (kareta == true) wartosc_reki = 3;
            else if (trojka == true && para == true) wartosc_reki = 4;
            else if (kolor == true) wartosc_reki = 5;
            else if (kolejnosc == true) wartosc_reki = 6;
            else if (trojka == true) wartosc_reki = 7;
            else if (para == true && para2 == true) wartosc_reki = 8;
            else if (para == true) wartosc_reki = 9;
            else wartosc_reki = 10;
            Console.WriteLine(Uklad_kart(wartosc_reki));
        }


    }
}
