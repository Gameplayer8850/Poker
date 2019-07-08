using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker
{  
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
}
