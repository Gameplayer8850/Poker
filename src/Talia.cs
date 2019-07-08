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
}
