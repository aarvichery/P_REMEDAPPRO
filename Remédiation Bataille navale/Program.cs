using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Remoting.Lifetime;
using System.Text;
using System.Threading.Tasks;

namespace Remédiation_Bataille_navale
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Attribution des variables
            // Titre
            int Max = 16;
            int Min = 10;
            bool IsValueOK = false;
            int SquareValue = 0;
            // Tableau 
            int TableOK = 1;
            int NbRowTable = 1;
            bool NbColTable = false;
            int MarginX = 3;
            int MarginY = 15;
            // Bateaux
            string Boat = "█";

            // Titre

            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(37, 2);
            Console.WriteLine("╔═══════════════════════════════════════╗");
            Console.SetCursorPosition(37, 3);
            Console.WriteLine("║                                       ║");
            Console.SetCursorPosition(37, 4);
            Console.WriteLine("║            BATAILLE NAVALE            ║");
            Console.SetCursorPosition(37, 5);
            Console.WriteLine("║                                       ║");
            Console.SetCursorPosition(37, 6);
            Console.WriteLine("╚═══════════════════════════════════════╝\n");
            Console.ResetColor();
            Console.WriteLine("Bonjour, bienvenue dans le jeu bataille navale !");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Merci d'agrandir votre fenêtre pour qu'aucun bug ne se produise");
            Console.ResetColor();
            Console.WriteLine("Le but du jeu est de couler tous les bateaux adverses.");
            Console.Write("Veuillez choisir la taille de votre grille, la grille doit être de maximum ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(Min);
            Console.ResetColor();
            Console.Write(" de côtés et de minimum ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(Max);
            Console.ResetColor();
            Console.WriteLine(" de côté.");
            Console.Write("Votre valeur : ");

            SquareValue = Convert.ToInt32(Console.ReadLine());
            do
            {





                if (SquareValue < 10)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("Le nombre que vous avez choisi est trop petit pour ce jeu, veuillez rééssayer avec une valeur entre ");
                    Console.ResetColor();
                    Console.Write(Min);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(" et ");
                    Console.ResetColor();
                    Console.WriteLine(Max);
                    Console.Write("Votre valeur : ");
                    IsValueOK = false;
                    SquareValue = Convert.ToInt32(Console.ReadLine());

                }
                else if (SquareValue > 10 && SquareValue < 16)
                {
                    IsValueOK = true;
                }

                if (SquareValue > 16)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("Le nombre que vous avez choisi est trop grand pour ce jeu, veuillez rééssayer avec une valeur entre ");
                    Console.ResetColor();
                    Console.Write(Min);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(" et ");
                    Console.ResetColor();
                    Console.WriteLine(Max);
                    Console.Write("Votre valeur : ");
                    IsValueOK = false;
                    string input = Console.ReadLine();
                    int.TryParse(input, out SquareValue);

                }
                else if (SquareValue > 10 && SquareValue < 16)
                {
                    IsValueOK = true;
                }
                if (SquareValue == 10 || SquareValue == 16)
                {
                    IsValueOK = true;
                }

            } while (IsValueOK == false);


            Console.ResetColor();
            Console.WriteLine("Vous jouerez sur une grille carré de " + SquareValue + " de côté, si aucun vainqueur, le jeu se terminera au bout de 12 minutes.\n");
            Console.Write("BONNE CHANCE !");
            Console.Clear();

            // Création du tableau

            int ColTable = 1;
            bool Col = false;
            int NbCol = 1;
            Console.SetCursorPosition(MarginY + SquareValue, MarginX - 3);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Plateau d'attaques");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.SetCursorPosition(MarginY, MarginX);
            Console.Write("╔");
            do
            {
                Console.Write("═══");
                Console.Write("╦");
                TableOK++;
            } while (TableOK < SquareValue);

            Console.WriteLine("═══╗");
            MarginX++;
            ColTable = 1;
            Col = false;
            NbCol = 1;
            do
            {

                do
                {
                    Console.SetCursorPosition(MarginY, MarginX);
                    TableOK = 1;

                    if (ColTable == 1)
                    {
                        Console.Write("║");
                        Col = false;
                    }
                    if (ColTable == 2)
                    {
                        Console.Write("╠");
                        Col = true;
                    }

                    do
                    {
                        if (ColTable == 1)
                        {
                            do
                            {
                                Console.CursorLeft += 3;
                                Console.Write("║");
                            } while (NbCol == SquareValue);
                        }
                        if (ColTable == 2)
                        {
                            Console.Write("═══");
                            Console.Write("╬");
                        }
                        TableOK++;
                    } while (TableOK < SquareValue);

                    if (ColTable == 1)
                    {
                        Console.Write("   ║");
                    }
                    if (ColTable == 2)
                    {
                        Console.WriteLine("═══╣");
                    }
                    NbRowTable++;
                    MarginX++;

                    if (ColTable == 2 && Col == true)
                    {
                        ColTable--;
                    }
                    if (ColTable == 1 && Col == false)
                    {
                        ColTable++;
                    }
                } while (NbRowTable < SquareValue * 2);

                Console.SetCursorPosition(MarginY, MarginX);
                Console.Write("╚");
                TableOK = 1;
                do
                {
                    Console.Write("═══");
                    Console.Write("╩");
                    TableOK++;
                } while (TableOK < SquareValue);
            } while (TableOK < SquareValue);

            Console.Write("═══╝");

            // Création des lettres en haut de la grille d'attaque

            MarginY = 15;
            MarginX = 3;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(MarginY + 2, MarginX - 1);
            Console.Write("A");
            Console.CursorLeft = MarginY += 6;
            Console.Write("B");
            Console.CursorLeft = MarginY += 4;
            Console.Write("C");
            Console.CursorLeft = MarginY += 4;
            Console.Write("D");
            Console.CursorLeft = MarginY += 4;
            Console.Write("E");
            Console.CursorLeft = MarginY += 4;
            Console.Write("F");
            Console.CursorLeft = MarginY += 4;
            Console.Write("G");
            Console.CursorLeft = MarginY += 4;
            Console.Write("H");
            Console.CursorLeft = MarginY += 4;
            Console.Write("I");
            Console.CursorLeft = MarginY += 4;
            Console.Write("J");
            switch (SquareValue)
            {
                case 11:

                    Console.CursorLeft = MarginY += 4;
                    Console.Write("K");
                    break;

                case 12:

                    Console.CursorLeft = MarginY += 4;
                    Console.Write("K");
                    Console.CursorLeft = MarginY += 4;
                    Console.Write("L");
                    break;

                case 13:

                    Console.CursorLeft = MarginY += 4;
                    Console.Write("K");
                    Console.CursorLeft = MarginY += 4;
                    Console.Write("L");
                    Console.CursorLeft = MarginY += 4;
                    Console.Write("M");
                    break;

                case 14:

                    Console.CursorLeft = MarginY += 4;
                    Console.Write("K");
                    Console.CursorLeft = MarginY += 4;
                    Console.Write("L");
                    Console.CursorLeft = MarginY += 4;
                    Console.Write("M");
                    Console.CursorLeft = MarginY += 4;
                    Console.Write("N");
                    break;

                case 15:

                    Console.CursorLeft = MarginY += 4;
                    Console.Write("K");
                    Console.CursorLeft = MarginY += 4;
                    Console.Write("L");
                    Console.CursorLeft = MarginY += 4;
                    Console.Write("M");
                    Console.CursorLeft = MarginY += 4;
                    Console.Write("N");
                    Console.CursorLeft = MarginY += 4;
                    Console.Write("O");
                    break;

                case 16:

                    Console.CursorLeft = MarginY += 4;
                    Console.Write("K");
                    Console.CursorLeft = MarginY += 4;
                    Console.Write("L");
                    Console.CursorLeft = MarginY += 4;
                    Console.Write("M");
                    Console.CursorLeft = MarginY += 4;
                    Console.Write("N");
                    Console.CursorLeft = MarginY += 4;
                    Console.Write("O");
                    Console.CursorLeft = MarginY += 4;
                    Console.Write("P");
                    break;
            }

            int RowNumber = 1;

            // Création des numéros à droite de la grille

            Console.SetCursorPosition(MarginY + 3, MarginX += 1);
            do
            {
                Console.Write(RowNumber);
                Console.CursorLeft = MarginY + 3;
                Console.CursorTop = MarginX += 2;
                RowNumber++;

            } while (RowNumber < SquareValue);

            Console.Write(RowNumber);

            // Création des bateaux 
            int PorteAvion = 5;
            int Croiseur = 4;
            int ContreTorpilleur = 3;
            int Torpilleur = 2;
            int[,] TableColRow = new int[SquareValue, SquareValue];
            MarginY = 3;
            switch (SquareValue)
            {
                case 10:

                    TableColRow[0, 1] = PorteAvion;
                    TableColRow[0, 2] = PorteAvion;
                    TableColRow[0, 3] = PorteAvion;
                    TableColRow[0, 4] = PorteAvion;
                    TableColRow[0, 5] = PorteAvion;

                    TableColRow[3, 9] = Croiseur;
                    TableColRow[4, 9] = Croiseur;
                    TableColRow[5, 9] = Croiseur;
                    TableColRow[6, 9] = Croiseur;

                    TableColRow[6, 7] = ContreTorpilleur;
                    TableColRow[7, 5] = ContreTorpilleur;
                    TableColRow[8, 6] = ContreTorpilleur;

                    TableColRow[3, 1] = Torpilleur;
                    TableColRow[3, 2] = Torpilleur;
                    break;

                case 11:

                    TableColRow[5, 1] = PorteAvion;
                    TableColRow[5, 2] = PorteAvion;
                    TableColRow[5, 3] = PorteAvion;
                    TableColRow[5, 4] = PorteAvion;
                    TableColRow[5, 5] = PorteAvion;

                    TableColRow[3, 9] = Croiseur;
                    TableColRow[4, 9] = Croiseur;
                    TableColRow[5, 9] = Croiseur;
                    TableColRow[6, 9] = Croiseur;

                    TableColRow[6, 10] = ContreTorpilleur;
                    TableColRow[7, 10] = ContreTorpilleur;
                    TableColRow[8, 10] = ContreTorpilleur;

                    TableColRow[3, 0] = Torpilleur;
                    TableColRow[3, 1] = Torpilleur;
                    break;

                case 12:

                    TableColRow[7, 8] = PorteAvion;
                    TableColRow[7, 7] = PorteAvion;
                    TableColRow[7, 6] = PorteAvion;
                    TableColRow[7, 5] = PorteAvion;
                    TableColRow[7, 4] = PorteAvion;

                    TableColRow[3, 9] = Croiseur;
                    TableColRow[4, 9] = Croiseur;
                    TableColRow[5, 9] = Croiseur;
                    TableColRow[6, 9] = Croiseur;

                    TableColRow[5, 11] = ContreTorpilleur;
                    TableColRow[6, 11] = ContreTorpilleur;
                    TableColRow[7, 11] = ContreTorpilleur;

                    TableColRow[6, 3] = Torpilleur;
                    TableColRow[6, 3] = Torpilleur;
                    break;

                case 13:

                    TableColRow[2, 0] = PorteAvion;
                    TableColRow[3, 0] = PorteAvion;
                    TableColRow[4, 0] = PorteAvion;
                    TableColRow[5, 0] = PorteAvion;
                    TableColRow[6, 0] = PorteAvion;

                    TableColRow[6, 8] = Croiseur;
                    TableColRow[6, 9] = Croiseur;
                    TableColRow[6, 10] = Croiseur;
                    TableColRow[6, 11] = Croiseur;

                    TableColRow[5, 6] = ContreTorpilleur;
                    TableColRow[5, 7] = ContreTorpilleur;
                    TableColRow[5, 6] = ContreTorpilleur;

                    TableColRow[1, 3] = Torpilleur;
                    TableColRow[1, 4] = Torpilleur;
                    break;

                case 14:

                    TableColRow[13, 1] = PorteAvion;
                    TableColRow[13, 2] = PorteAvion;
                    TableColRow[13, 3] = PorteAvion;
                    TableColRow[13, 4] = PorteAvion;
                    TableColRow[1, 5] = PorteAvion;

                    TableColRow[3, 8] = Croiseur;
                    TableColRow[3, 9] = Croiseur;
                    TableColRow[3, 10] = Croiseur;
                    TableColRow[3, 11] = Croiseur;

                    TableColRow[8, 6] = ContreTorpilleur;
                    TableColRow[8, 7] = ContreTorpilleur;
                    TableColRow[8, 6] = ContreTorpilleur;

                    TableColRow[3, 5] = Torpilleur;
                    TableColRow[3, 6] = Torpilleur;
                    break;

                case 15:

                    TableColRow[5, 4] = PorteAvion;
                    TableColRow[5, 5] = PorteAvion;
                    TableColRow[5, 6] = PorteAvion;
                    TableColRow[5, 7] = PorteAvion;
                    TableColRow[5, 8] = PorteAvion;

                    TableColRow[6, 8] = Croiseur;
                    TableColRow[6, 9] = Croiseur;
                    TableColRow[6, 10] = Croiseur;
                    TableColRow[6, 11] = Croiseur;

                    TableColRow[5, 6] = ContreTorpilleur;
                    TableColRow[4, 6] = ContreTorpilleur;
                    TableColRow[3, 6] = ContreTorpilleur;

                    TableColRow[10, 3] = Torpilleur;
                    TableColRow[10, 4] = Torpilleur;
                    break;

                case 16:

                    TableColRow[15, 5] = PorteAvion;
                    TableColRow[15, 6] = PorteAvion;
                    TableColRow[15, 7] = PorteAvion;
                    TableColRow[15, 8] = PorteAvion;
                    TableColRow[15, 9] = PorteAvion;

                    TableColRow[4, 2] = Croiseur;
                    TableColRow[4, 3] = Croiseur;
                    TableColRow[4, 4] = Croiseur;
                    TableColRow[4, 5] = Croiseur;

                    TableColRow[1, 0] = ContreTorpilleur;
                    TableColRow[2, 0] = ContreTorpilleur;
                    TableColRow[3, 0] = ContreTorpilleur;

                    TableColRow[2, 3] = Torpilleur;
                    TableColRow[2, 4] = Torpilleur;
                    break;
            }

            // Commandes de jeu

            Console.ResetColor();
            Console.SetCursorPosition(MarginX - 10 + SquareValue * 5, 3);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Pour choisir la colonne ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("[←], [→]");
            Console.SetCursorPosition(MarginX - 10 + SquareValue * 5, 4);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Pour choisir la ligne ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("[↑], [↓]");
            Console.SetCursorPosition(MarginX - 10 + SquareValue * 5, 5);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Pour tirer ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("[ENTER]");
            Console.ResetColor();

            // Création de la Variable qui va déterminer la colonne choisie par l'attaquant

            int PosCol = 1;
            int Letter = 1;
           

            Console.SetCursorPosition(MarginX - 10 + SquareValue * 5, 8);
            Console.WriteLine("Choisissez maintenant la case que vous souhaitez attaquer en sélectionnant dans un premier temps la colonne et ensuite la ligne");

            MarginX = 3;
            MarginY = 15;
            ConsoleKeyInfo key1;

            Console.SetCursorPosition(MarginY + 2, MarginX - 1);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("A");

            
            do
            {
                key1 = Console.ReadKey(true);

                switch (key1.Key)
                {
                    case ConsoleKey.RightArrow:

                        switch (Letter)
                        {
                            case 1:

                                Console.CursorLeft--;
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.Write("A");
                                Console.CursorLeft += 3;
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.Write("B");
                                Letter++;
                                PosCol++;
                                break;

                            case 2:

                                Console.CursorLeft--;
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.Write("B");
                                Console.CursorLeft += 3;
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.Write("C");
                                Letter++;
                                PosCol++;
                                break;

                            case 3:

                                Console.CursorLeft--;
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.Write("C");
                                Console.CursorLeft += 3;
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.Write("D");
                                Letter++;
                                PosCol++;
                                break;

                            case 4:

                                Console.CursorLeft--;
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.Write("D");
                                Console.CursorLeft += 3;
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.Write("E");
                                Letter++;
                                PosCol++;
                                break;

                            case 5:

                                Console.CursorLeft--;
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.Write("E");
                                Console.CursorLeft += 3;
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.Write("F");
                                Letter++;
                                PosCol++;
                                break;

                            case 6:

                                Console.CursorLeft--;
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.Write("F");
                                Console.CursorLeft += 3;
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.Write("G");
                                Letter++;
                                PosCol++;
                                break;

                            case 7:

                                Console.CursorLeft--;
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.Write("G");
                                Console.CursorLeft += 3;
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.Write("H");
                                Letter++;
                                PosCol++;
                                break;

                            case 8:

                                Console.CursorLeft--;
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.Write("H");
                                Console.CursorLeft += 3;
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.Write("I");
                                Letter++;
                                PosCol++;
                                break;

                            case 9:

                                Console.CursorLeft--;
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.Write("I");
                                Console.CursorLeft += 3;
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.Write("J");
                                Letter++;
                                PosCol++;
                                break;

                            case 10:

                                switch (SquareValue)
                                {
                                    case 10:

                                        if(PosCol == 10)
                                        {
                                            Console.CursorLeft--;
                                            Console.ForegroundColor = ConsoleColor.Red;
                                            Console.Write("J");
                                            Console.SetCursorPosition(MarginY + 2, MarginX - 1);
                                            Console.ForegroundColor = ConsoleColor.Green;
                                            Console.Write("A");
                                            Letter = 1;
                                            PosCol = 1;

                                        }

                                        break;
                                }
                                if (Letter == 10)
                                {
                                    Letter++;
                                }
                                break;
                        

                            case 11:

                                switch (SquareValue)
                                {
                                    case 11:
                                        
                                        if(PosCol == 10)
                                        {
                                            Console.CursorLeft--;
                                            Console.ForegroundColor = ConsoleColor.Red;
                                            Console.Write("J");
                                            Console.CursorLeft += 3;
                                            Console.ForegroundColor= ConsoleColor.Green;
                                            Console.Write("K");
                                            

                                        }
                                        PosCol++;
                                            
                                        if (PosCol == 12)
                                        {
                                            Console.CursorLeft--;
                                            Console.ForegroundColor = ConsoleColor.Red;
                                            Console.Write("");
                                            Console.SetCursorPosition(MarginY + 2, MarginX - 1);
                                            Console.ForegroundColor = ConsoleColor.Green;
                                            Console.Write("A");
                                            Letter = 1;
                                            PosCol = 1;
                                        }

                                        
                                        

                                        break;
                                }

                                break;
                        }







                        break;
                }

            } while (key1.Key != ConsoleKey.Enter);



























            Console.ReadLine();








        }
























    }
}
