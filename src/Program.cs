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
