/*
############################################################################
#                                                                          #
#                                 Wykonał:                                 #
#                              Marek Żubrycki                              #
#       Student Wyższej Szkoły Informatyki i Zarządzania "Copernicus"      #
#                               we Wrocławiu                               #
#                                                                          #
############################################################################
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker
{
    class Talia
    {
        static protected int[] wykorzystane_karty = new int[52];
        static protected int ilosc_wykorzystanych = 0;
        static protected Opis_karty[] karty = new Opis_karty[52];
        static protected int zakres_kart;

        public struct Opis_karty
        {
            public int Rodzaj_karty;
            public string Kolor_karty;
        }
        public virtual void Tworzenie() //przypisuje kolor oraz numer każdej karcie w strukturze "karty"
        {
            int numer_karty = 2;
            for (int i = 0; i < 52; i++)
            {
                karty[i].Rodzaj_karty = numer_karty;
                karty[i].Kolor_karty = "Kier";
                karty[i + 1].Rodzaj_karty = numer_karty;
                karty[i + 1].Kolor_karty = "Karo";
                karty[i + 2].Rodzaj_karty = numer_karty;
                karty[i + 2].Kolor_karty = "Pik";
                karty[i + 3].Rodzaj_karty = numer_karty;
                karty[i + 3].Kolor_karty = "Trefl";
                numer_karty++;
                i += 3;
            }

        }
        protected int Losowanie() //losuje kartę z dostępnej puli oraz dodaje ją do tablicy z wykorzystanymi kartami
        {
            bool wystepuje;
            int wylosowana_karta;
            do
            {
                Random rand = new Random();
                wylosowana_karta = rand.Next(zakres_kart, 52);
                wystepuje = false;
                for (int j = 0; j < ilosc_wykorzystanych; j++)
                {
                    if (wylosowana_karta == wykorzystane_karty[j])
                    {
                        wystepuje = true;
                        break;
                    }
                }
            } while (wystepuje == true);
            wykorzystane_karty[ilosc_wykorzystanych] = wylosowana_karta;
            ilosc_wykorzystanych++;
            return wylosowana_karta;
        }
        protected string Uklad_kart(int wartosc) //wyświetla wartość kart w ręce
        {
            string nazwa = "";
            switch (wartosc)
            {
                case 1:
                    nazwa = "Poker królewski";
                    break;
                case 2:
                    nazwa = "Poker";
                    break;
                case 3:
                    nazwa = "Kareta";
                    break;
                case 4:
                    nazwa = "Full";
                    break;
                case 5:
                    nazwa = "Kolor";
                    break;
                case 6:
                    nazwa = "Strit";
                    break;
                case 7:
                    nazwa = "Trójka";
                    break;
                case 8:
                    nazwa = "Dwie pary";
                    break;
                case 9:
                    nazwa = "Para";
                    break;
                case 10:
                    nazwa = "Wysoka karta";
                    break;
            }
            return nazwa;

        }
    }
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
    class Stol : Talia
    {
        int Ilosc_graczy;
        public Stol(int Ilosc_graczy) //zakres tali wybrany przez gracza
        {
            Console.Write("Podaj od jakiej karty ma się zaczynać talia: ");
            bool flaga;
            int zakres;
            do
            {
                flaga = false;
                zakres = int.Parse(Console.ReadLine());
                if (zakres < 2 || zakres > 8)
                {
                    flaga = true;
                    Console.Write("Podałeś zły zakres (1<zakres<9) Podaj ponownie zakres: ");
                }
                else if (52 - (4 * (zakres - 2)) < (5 * Ilosc_graczy) * 2)
                {
                    flaga = true;
                    Console.Write("Niewystarczająca ilość kart dla podanej liczby graczy! (weź pod uwagę, że każdy gracz dostaje po 5 kart i może wymienić 5 kart)\nPodaj ponownie zakres: ");
                }

            } while (flaga == true);
            zakres_kart = 4 * (zakres - 2) + 1;
        }
        public override void Tworzenie() //cały proces gry
        {
            base.Tworzenie();
            Reka_zawodnika[] zawodnicy = new Reka_zawodnika[Ilosc_graczy];
            for (int i = 0; i < Ilosc_graczy; i++)
            {
                zawodnicy[i] = new Reka_zawodnika(i + 1);
                for (int k = 0; k < 5; k++)
                {
                    zawodnicy[i].Wylosowane_karty(Losowanie());
                }
            }
            Console.Clear();
            for (int i = 0; i < Ilosc_graczy; i++)
            {
                Console.WriteLine("Karty {0} gracza", (i + 1));
                zawodnicy[i].Wyswietl();
                zawodnicy[i].Wymiana_kart();
                zawodnicy[i].Sprawdzanie_Kart();
                System.Threading.Thread.Sleep(7000);
                Console.SetWindowSize(103, 45);
                Console.Clear();
            }
            Wyniki(zawodnicy);
            Console.Read();
        }
        protected void Wyniki(Reka_zawodnika[] zawodnicy) //sortuje graczy według wartości ich kart oraz wyświetla tabele wyników
        {
            Reka_zawodnika[] wyniki = zawodnicy;
            Reka_zawodnika pomocnicza;
            for (int i = 0; i < Ilosc_graczy; i++) //sortowanie bo wartości kart
            {
                for (int j = 1; j < Ilosc_graczy - i; j++)
                {
                    if (wyniki[j].wartosc_reki < wyniki[j - 1].wartosc_reki)
                    {
                        pomocnicza = wyniki[j];
                        wyniki[j] = wyniki[j - 1];
                        wyniki[j - 1] = pomocnicza;
                    }
                }
            }

            for (int n = 0; n < Ilosc_graczy - 1; n++)
            {
                for (int i = 0; i < Ilosc_graczy - n - 1; i++) //sprawdza czy paru graczy nie ma takiej samej wartości kart oraz ustala który z nich ma "mocniejszą" rękę w zależności od układu
                {
                    bool ZmienKolejnosc = false;
                    if (wyniki[i].wartosc_reki == wyniki[i + 1].wartosc_reki)
                    {
                        switch (wyniki[i].wartosc_reki)
                        {
                            case 2: //poker
                                if ((wyniki[i].reka[4] - 1) / 4 < (wyniki[i + 1].reka[4] - 1) / 4) ZmienKolejnosc = true;
                                break;
                            case 3: //kareta
                                if ((wyniki[i].reka[3] - 1) / 4 < (wyniki[i + 1].reka[3] - 1) / 4) ZmienKolejnosc = true;
                                break;
                            case 4: //full
                                if ((wyniki[i].reka[2] - 1) / 4 < (wyniki[i + 1].reka[2] - 1) / 4) ZmienKolejnosc = true;
                                else if ((wyniki[i].reka[2] - 1) / 4 == (wyniki[i + 1].reka[2] - 1) / 4)
                                {
                                    int karta_danego_gracza;
                                    if ((wyniki[i].reka[2] - 1) / 4 != (wyniki[i].reka[0] - 1) / 4) karta_danego_gracza = (wyniki[i].reka[0] - 1) / 4;
                                    else karta_danego_gracza = (wyniki[i].reka[4] - 1) / 4;
                                    if ((wyniki[i + 1].reka[2] - 1) / 4 != (wyniki[i + 1].reka[0] - 1) / 4)
                                    {
                                        if ((wyniki[i + 1].reka[0] - 1) / 4 > karta_danego_gracza) ZmienKolejnosc = true;
                                    }
                                    else
                                    {
                                        if ((wyniki[i + 1].reka[4] - 1) / 4 > karta_danego_gracza) ZmienKolejnosc = true;
                                    }

                                }
                                break;
                            case 5: //kolor
                                for (int j = 4; j > 0 - 1; j--)
                                {
                                    if ((wyniki[i].reka[j] - 1) / 4 == (wyniki[i + 1].reka[j] - 1) / 4) continue;
                                    if ((wyniki[i].reka[j] - 1) / 4 < (wyniki[i + 1].reka[j] - 1) / 4) ZmienKolejnosc = true;
                                    break;
                                }
                                break;
                            case 6: //strit
                                if ((wyniki[i].reka[4] - 1) / 4 < (wyniki[i + 1].reka[4] - 1) / 4) ZmienKolejnosc = true;
                                break;
                            case 7: //trójka
                                if ((wyniki[i].reka[2] - 1) / 4 < (wyniki[i + 1].reka[2] - 1) / 4) ZmienKolejnosc = true;
                                break;
                            case 8: //dwie pary
                                int max1 = 0;
                                int max2 = 0;
                                int indexpary1 = 0;
                                int indexpary2 = 0;
                                if ((wyniki[i].reka[1] - 1) / 4 < (wyniki[i].reka[4] - 1) / 4)
                                {
                                    max1 = (wyniki[i].reka[4] - 1) / 4;
                                    indexpary1 = 0;
                                }
                                else
                                {
                                    max1 = (wyniki[i].reka[1] - 1) / 4;
                                    indexpary1 = 4;
                                }
                                if ((wyniki[i + 1].reka[1] - 1) / 4 < (wyniki[i + 1].reka[4] - 1) / 4)
                                {
                                    max2 = (wyniki[i + 1].reka[4] - 1) / 4;
                                    indexpary2 = 0;
                                }
                                else
                                {
                                    max2 = (wyniki[i + 1].reka[1] - 1) / 4;
                                    indexpary2 = 4;
                                }
                                if (max2 > max1) ZmienKolejnosc = true;
                                else if (max2 == max1)
                                {
                                    if ((wyniki[i].reka[indexpary1] - 1) / 4 < (wyniki[i + 1].reka[indexpary2] - 1) / 4) ZmienKolejnosc = true;
                                }
                                break;
                            case 9: //para
                                bool czy_znaleziono = false;
                                for (int j = 0; j < 4; j++)
                                {
                                    if ((wyniki[i].reka[j] - 1) / 4 == (wyniki[i].reka[j + 1] - 1) / 4)
                                    {
                                        for (int k = 0; k < 4; k++)
                                        {
                                            if ((wyniki[i + 1].reka[k] - 1) / 4 == (wyniki[i + 1].reka[k + 1] - 1) / 4)
                                            {
                                                if ((wyniki[i].reka[j] - 1) / 4 < (wyniki[i + 1].reka[k] - 1) / 4) ZmienKolejnosc = true;
                                                czy_znaleziono = true;
                                                break;
                                            }
                                        }  
                                        if (czy_znaleziono == true) break;
                                    }
                                }
                                break;
                            case 10: //wysoka karta
                                for (int j = 4; j > 0 - 1; j--)
                                {
                                    if ((wyniki[i].reka[j] - 1) / 4 == (wyniki[i + 1].reka[j] - 1) / 4) continue;
                                    if ((wyniki[i].reka[j] - 1) / 4 < (wyniki[i + 1].reka[j] - 1) / 4) ZmienKolejnosc = true;
                                    break;
                                }
                                break;
                        }
                        if (ZmienKolejnosc == true)
                        {
                            pomocnicza = wyniki[i + 1];
                            wyniki[i + 1] = wyniki[i];
                            wyniki[i] = pomocnicza;
                        }

                    }
                }
            }
            if (Ilosc_graczy > 3) Console.SetWindowSize(103, 50); //powiększa okno cmd
            for (int i = 0; i < Ilosc_graczy; i++)
            {
                Console.WriteLine("Karty {0} gracza", wyniki[i].numer_zawodnika);
                wyniki[i].Wyswietl();
                Console.WriteLine("Jest to: " + Uklad_kart(wyniki[i].wartosc_reki));
                Console.WriteLine();
            }
            Console.Write("      ");
            Console.BackgroundColor = ConsoleColor.Green;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("--------------------------------------------");
            Console.ResetColor();
            Console.Write("      ");
            Console.BackgroundColor = ConsoleColor.Green;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("|              Tabela wyników              |");
            Console.ResetColor();
            for (int i = 0; i < Ilosc_graczy; i++)
            {
                Console.Write("      ");
                Console.BackgroundColor = ConsoleColor.Green;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine("| " + (i + 1) + " miejsce zajmuje zawodnik o numerze: " + wyniki[i].numer_zawodnika + "  |");
                Console.ResetColor();
            }
            Console.Write("      ");
            Console.BackgroundColor = ConsoleColor.Green;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("--------------------------------------------");
            Console.ResetColor(); ;
        }
        public int Liczba_graczy
        {
            get
            {
                return Ilosc_graczy;
            }
            set
            {
                Ilosc_graczy = value;
            }
        }
    }


    class Program
    {
        static int IloscGraczy()
        {
            Console.Write("Podaj ilość graczy: ");
            int Ilosc_graczy;
            bool flaga;
            do
            {
                flaga = false;
                Ilosc_graczy = int.Parse(Console.ReadLine());
                if (Ilosc_graczy < 1)
                {
                    Console.Write("Nieprawidłowa Ilość graczy! Podaj ponownie ilość graczy: ");
                    flaga = true;
                }
                else if (Ilosc_graczy == 1)
                {
                    Console.Write("Sam nie możesz grać w pokera! Podaj ponownie ilość graczy: ");
                    flaga = true;
                }
                else if (Ilosc_graczy > 5)
                {
                    Console.Write("Maksymalna ilość graczy to 5 osób! Podaj ponownie ilość graczy: ");
                    flaga = true;
                }
            } while (flaga == true);
            return Ilosc_graczy;
        }

        static void Main(string[] args)
        {
            Console.SetWindowSize(103, 40); //ustawia wielkość okna
            Console.WriteLine();

            //napis "POKER"
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("                                                                                                       \n PPPPPPPPPPPPPPPPP        OOOOOOOOO     KKKKKKKKK    KKKKKKKEEEEEEEEEEEEEEEEEEEEEERRRRRRRRRRRRRRRRR    \n P::::::::::::::::P     OO:::::::::OO   K:::::::K    K:::::KE::::::::::::::::::::ER::::::::::::::::R   \n P::::::PPPPPP:::::P  OO:::::::::::::OO K:::::::K    K:::::KE::::::::::::::::::::ER::::::RRRRRR:::::R  \n PP:::::P     P:::::PO:::::::OOO:::::::OK:::::::K   K::::::KEE::::::EEEEEEEEE::::ERR:::::R     R:::::R \n   P::::P     P:::::PO::::::O   O::::::OKK::::::K  K:::::KKK  E:::::E       EEEEEE  R::::R     R:::::R \n   P::::P     P:::::PO:::::O     O:::::O  K:::::K K:::::K     E:::::E               R::::R     R:::::R \n   P::::PPPPPP:::::P O:::::O     O:::::O  K::::::K:::::K      E::::::EEEEEEEEEE     R::::RRRRRR:::::R  \n   P:::::::::::::PP  O:::::O     O:::::O  K:::::::::::K       E:::::::::::::::E     R:::::::::::::RR   \n   P::::PPPPPPPPP    O:::::O     O:::::O  K:::::::::::K       E:::::::::::::::E     R::::RRRRRR:::::R  \n   P::::P            O:::::O     O:::::O  K::::::K:::::K      E::::::EEEEEEEEEE     R::::R     R:::::R \n   P::::P            O:::::O     O:::::O  K:::::K K:::::K     E:::::E               R::::R     R:::::R \n   P::::P            O::::::O   O::::::OKK::::::K  K:::::KKK  E:::::E       EEEEEE  R::::R     R:::::R \n PP::::::PP          O:::::::OOO:::::::OK:::::::K   K::::::KEE::::::EEEEEEEE:::::ERR:::::R     R:::::R \n P::::::::P           OO:::::::::::::OO K:::::::K    K:::::KE::::::::::::::::::::ER::::::R     R:::::R \n P::::::::P             OO:::::::::OO   K:::::::K    K:::::KE::::::::::::::::::::ER::::::R     R:::::R \n PPPPPPPPPP               OOOOOOOOO     KKKKKKKKK    KKKKKKKEEEEEEEEEEEEEEEEEEEEEERRRRRRRR     RRRRRRR \n                                                                                                       \n\n");
            Console.ResetColor();

            //POKER
            int Ilosc_graczy = IloscGraczy();
            Stol Typek = new Stol(Ilosc_graczy);
            Typek.Liczba_graczy = Ilosc_graczy;
            Typek.Tworzenie();
        }
    }
}
