using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Lifetime;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Remédiation_Bataille_navale
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            bool continuer = true;
            do
            {
                
                Console.SetWindowSize(240, 63);


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
                char Let = 'A';

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

                do
                {
                    Console.Write("Votre valeur : ");
                    try
                    {
                        SquareValue = Convert.ToInt32(Console.ReadLine());
                        if (SquareValue < Min || SquareValue > Max)
                        {
                            // dit au joueur qu'il a mit des lignes trop petites ou trop grandes
                            Console.ForegroundColor= ConsoleColor.Red;
                            Console.WriteLine("Veuillez choisir un nombre entre 10 et 16");
                            Console.ResetColor();
                        }
                    }
                    catch (Exception e) // donne le message d'une erreur
                    {
                        Console.ForegroundColor=ConsoleColor.Red;
                        Console.WriteLine(e.Message);
                        Console.ResetColor();
                    }
                } while (SquareValue < Min || SquareValue > Max);



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

                Console.ForegroundColor = ConsoleColor.Red;
                for (int t = 0; t < SquareValue; t++)
                {
                    Console.SetCursorPosition(t * 4 + 17, 2);
                    Console.Write((char)('A' + t));
                }


                // Création des numéros à droite de la grille


                Console.SetCursorPosition(MarginY + 4 * SquareValue, MarginX++);
                for (int t = 0; t < SquareValue; t++)
                {
                    Console.SetCursorPosition(17 + 4 * SquareValue, 4 + t * 2);
                    Console.Write(t + 1);

                }
                Console.ResetColor();

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
                        TableColRow[6, 5] = ContreTorpilleur;
                        TableColRow[6, 6] = ContreTorpilleur;

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
                        TableColRow[6, 4] = Torpilleur;
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
                        TableColRow[5, 8] = ContreTorpilleur;

                        TableColRow[1, 3] = Torpilleur;
                        TableColRow[1, 4] = Torpilleur;
                        break;

                    case 14:

                        TableColRow[13, 1] = PorteAvion;
                        TableColRow[13, 2] = PorteAvion;
                        TableColRow[13, 3] = PorteAvion;
                        TableColRow[13, 4] = PorteAvion;
                        TableColRow[13, 5] = PorteAvion;

                        TableColRow[3, 8] = Croiseur;
                        TableColRow[3, 9] = Croiseur;
                        TableColRow[3, 10] = Croiseur;
                        TableColRow[3, 11] = Croiseur;

                        TableColRow[8, 6] = ContreTorpilleur;
                        TableColRow[8, 7] = ContreTorpilleur;
                        TableColRow[8, 8] = ContreTorpilleur;

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

                        TableColRow[9, 7] = ContreTorpilleur;
                        TableColRow[9, 8] = ContreTorpilleur;
                        TableColRow[9, 9] = ContreTorpilleur;

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

                MarginX = 3;
                MarginY = 15;
                Console.CursorVisible = false;
                ConsoleKeyInfo key1;

                int twoboat = 0;
                int threeboat = 0;
                int fourboat = 0;
                int fiveboat = 0;
                int end = 0;
                int colonne = 1;
                int ligne = 1;
                int allboat = 0;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.SetCursorPosition(MarginX + SquareValue * 6, 8);
                Console.WriteLine("Choisissez maintenant la case que vous souhaitez attaquer en la sélectionnant");
                Console.SetCursorPosition(MarginX + SquareValue * 6, 9);
                Console.WriteLine("et en appuyant sur [ENTER]");
                Console.ResetColor();
                Console.SetCursorPosition(MarginX + SquareValue * 6, 12);
                Console.Write("Torpilleur 0/2");
                Console.SetCursorPosition(MarginX + SquareValue * 6, 13);
                Console.Write("Contre Torpilleur 0/3");
                Console.SetCursorPosition(MarginX + SquareValue * 6, 14);
                Console.Write("Croiseur 0/4");
                Console.SetCursorPosition(MarginX + SquareValue * 6, 15);
                Console.Write("Porte Avion 0/5");
                Console.SetCursorPosition(MarginX + SquareValue * 6, 16);
                Console.Write("Water " + end + " /30");
                do
                {
                    do
                    {
                        FillCell(colonne, ligne);
                        key1 = Console.ReadKey(true);

                        switch (key1.Key)
                        {
                            case ConsoleKey.RightArrow:


                                Console.CursorLeft--;
                                Console.Write(" ");
                                if (TableColRow[colonne - 1, ligne - 1] == 1)
                                {
                                    Console.CursorLeft--;
                                    Console.ForegroundColor = ConsoleColor.Blue;
                                    Console.Write("█");

                                }
                                if (TableColRow[colonne - 1, ligne - 1] == 6 || TableColRow[colonne - 1, ligne - 1] == 9 || TableColRow[colonne - 1, ligne - 1] == 12 || TableColRow[colonne - 1, ligne - 1] == 15)
                                {
                                    Console.CursorLeft--;
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.Write("█");
                                }
                                colonne++;
                                if (colonne > SquareValue)
                                {
                                    colonne = 1;
                                }

                                break;

                            case ConsoleKey.LeftArrow:
                                Console.CursorLeft--;
                                Console.Write(" ");
                                if (TableColRow[colonne - 1, ligne - 1] == 1)
                                {
                                    Console.CursorLeft--;
                                    Console.ForegroundColor = ConsoleColor.Blue;
                                    Console.Write("█");

                                }
                                if (TableColRow[colonne - 1, ligne - 1] == 6 || TableColRow[colonne - 1, ligne - 1] == 9 || TableColRow[colonne - 1, ligne - 1] == 12 || TableColRow[colonne - 1, ligne - 1] == 15)
                                {
                                    Console.CursorLeft--;
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.Write("█");
                                }
                                colonne--;
                                if (colonne < 1)
                                {
                                    colonne = SquareValue;
                                }

                                break;

                            case ConsoleKey.UpArrow:
                                Console.CursorLeft--;
                                Console.Write(" ");
                                if (TableColRow[colonne - 1, ligne - 1] == 1)
                                {
                                    Console.CursorLeft--;
                                    Console.ForegroundColor = ConsoleColor.Blue;
                                    Console.Write("█");

                                }
                                if (TableColRow[colonne - 1, ligne - 1] == 6 || TableColRow[colonne - 1, ligne - 1] == 9 || TableColRow[colonne - 1, ligne - 1] == 12 || TableColRow[colonne - 1, ligne - 1] == 15)
                                {
                                    Console.CursorLeft--;
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.Write("█");
                                }
                                ligne--;
                                if (ligne < 1)
                                {
                                    ligne = SquareValue;
                                }
                                break;

                            case ConsoleKey.DownArrow:
                                Console.CursorLeft--;
                                Console.Write(" ");
                                if (TableColRow[colonne - 1, ligne - 1] == 1)
                                {
                                    Console.CursorLeft--;
                                    Console.ForegroundColor = ConsoleColor.Blue;
                                    Console.Write("█");

                                }
                                if (TableColRow[colonne - 1, ligne - 1] == 6 || TableColRow[colonne - 1, ligne - 1] == 9 || TableColRow[colonne - 1, ligne - 1] == 12 || TableColRow[colonne - 1, ligne - 1] == 15)
                                {
                                    Console.CursorLeft--;
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.Write("█");
                                }
                                ligne++;
                                if (ligne > SquareValue)
                                {
                                    ligne = 1;
                                }


                                break;
                        }

                    } while (key1.Key != ConsoleKey.Enter);
                    {

                        if (TableColRow[colonne - 1, ligne - 1] == 0)
                        {
                            TableColRow[colonne - 1, ligne - 1] = 1;
                            end++;
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.SetCursorPosition(13 + 4 * colonne, 2 + 2 * ligne);
                            Console.Write("█");
                            colonne = 1;
                            ligne = 1;
                            Console.ResetColor();
                            Console.SetCursorPosition(MarginX + SquareValue * 6, 16);
                            Console.Write("Water " + end + " /30");
                            Console.ForegroundColor = ConsoleColor.Green;

                        }



                        if (TableColRow[colonne - 1, ligne - 1] == 2)
                        {
                            TableColRow[colonne - 1, ligne - 1] = 6;
                            twoboat++;
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.SetCursorPosition(13 + 4 * colonne, 2 + 2 * ligne);
                            Console.Write("█");
                            colonne = 1;
                            ligne = 1;
                            Console.ResetColor();
                            Console.SetCursorPosition(MarginX + SquareValue * 6, 12);
                            Console.Write("Torpilleur " + twoboat + " /2");
                            if (twoboat == 2)
                            {
                                allboat++;

                            }


                        }

                        if (TableColRow[colonne - 1, ligne - 1] == 3)
                        {
                            TableColRow[colonne - 1, ligne - 1] = 9;
                            threeboat++;
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.SetCursorPosition(13 + 4 * colonne, 2 + 2 * ligne);
                            Console.Write("█");
                            colonne = 1;
                            ligne = 1;
                            Console.ResetColor();
                            Console.SetCursorPosition(MarginX + SquareValue * 6, 13);
                            Console.Write("Contre Torpilleur " + threeboat + " /3");
                            if (threeboat == 3)
                            {
                                allboat++;

                            }


                        }

                        if (TableColRow[colonne - 1, ligne - 1] == 4)
                        {
                            TableColRow[colonne - 1, ligne - 1] = 12;
                            fourboat++;
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.SetCursorPosition(13 + 4 * colonne, 2 + 2 * ligne);
                            Console.Write("█");
                            colonne = 1;
                            ligne = 1;
                            Console.ResetColor();
                            Console.SetCursorPosition(MarginX + SquareValue * 6, 14);
                            Console.Write("Croiseur " + fourboat + " /4");
                            if (fourboat == 4)
                            {
                                allboat++;

                            }

                        }

                        if (TableColRow[colonne - 1, ligne - 1] == 5)
                        {
                            TableColRow[colonne - 1, ligne - 1] = 15;
                            fiveboat++;
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.SetCursorPosition(13 + 4 * colonne, 2 + 2 * ligne);
                            Console.Write("█");
                            colonne = 1;
                            ligne = 1;
                            Console.ResetColor();
                            Console.SetCursorPosition(MarginX + SquareValue * 6, 15);
                            Console.Write("Porte Avion " + fiveboat + " /5");
                            if (fiveboat == 5)
                            {
                                allboat++;

                            }


                        }
                    }
                } while (end != 30 && allboat != 4);
                {
                    if (end == 30)
                    {

                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.SetCursorPosition(50, 10);
                        Console.Write("Vous avez perdu");
                        Console.ResetColor();
                        Console.SetCursorPosition(50, 11);
                        Console.WriteLine("Pour quitter, veuillez cliquer 2 fois sur votre touche [ESCAPE]");
                        Console.SetCursorPosition(50, 12);
                        Console.Write("Cliquez sur [Enter] pour rejouer");


                        ConsoleKeyInfo key2;

                        key2 = Console.ReadKey(true);

                        switch (key2.Key)
                        {
                            case ConsoleKey.Escape:
                                Environment.Exit(0);

                                break;

                            case ConsoleKey.Enter:
                                continuer = false;

                                break;
                        }


                    }

                    if (allboat == 4)
                    {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.SetCursorPosition(50, 10);
                        Console.Write("Vous avez gagné");
                        Console.ResetColor();
                        Console.SetCursorPosition(50, 11);
                        Console.WriteLine("Pour quitter, veuillez cliquer 2 fois sur votre touche [ESCAPE]");
                        Console.SetCursorPosition(50, 12);
                        Console.Write("Cliquez sur [Enter] pour rejouer");

                        ConsoleKeyInfo key3;

                        key3 = Console.ReadKey(true);

                        switch (key3.Key)
                        {
                            case ConsoleKey.Escape:
                                Environment.Exit(0);

                                break;

                            case ConsoleKey.Enter:
                                continuer = false;

                                break;
                        }
                    }


                }

            }while (continuer == false);

            }

        // Remplir une des cases de la grille 

        static void FillCell(int x, int y)
        {

            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(13 + 4 * x, 2 + 2 * y);
            Console.Write('█');


        }

        static void Table(int x, int[,] y)
        {
            int PorteAvion = 5;
            int Croiseur = 4;
            int ContreTorpilleur = 3;
            int Torpilleur = 2;
            switch (x)
            {
                case 10:

                    y[0, 1] = PorteAvion;
                    y[0, 2] = PorteAvion;
                    y[0, 3] = PorteAvion;
                    y[0, 4] = PorteAvion;
                    y[0, 5] = PorteAvion;

                    y[3, 9] = Croiseur;
                    y[4, 9] = Croiseur;
                    y[5, 9] = Croiseur;
                    y[6, 9] = Croiseur;

                    y[6, 7] = ContreTorpilleur;
                    y[7, 7] = ContreTorpilleur;
                    y[8, 7] = ContreTorpilleur;

                    y[3, 1] = Torpilleur;
                    y[3, 2] = Torpilleur;
                    break;

                case 11:

                    y[5, 1] = PorteAvion;
                    y[5, 2] = PorteAvion;
                    y[5, 3] = PorteAvion;
                    y[5, 4] = PorteAvion;
                    y[5, 5] = PorteAvion;

                    y[3, 9] = Croiseur;
                    y[4, 9] = Croiseur;
                    y[5, 9] = Croiseur;
                    y[6, 9] = Croiseur;

                    y[6, 10] = ContreTorpilleur;
                    y[7, 10] = ContreTorpilleur;
                    y[8, 10] = ContreTorpilleur;

                    y[3, 0] = Torpilleur;
                    y[3, 1] = Torpilleur;
                    break;

                case 12:

                    y[7, 8] = PorteAvion;
                    y[7, 7] = PorteAvion;
                    y[7, 6] = PorteAvion;
                    y[7, 5] = PorteAvion;
                    y[7, 4] = PorteAvion;

                    y[3, 9] = Croiseur;
                    y[4, 9] = Croiseur;
                    y[5, 9] = Croiseur;
                    y[6, 9] = Croiseur;

                    y[5, 11] = ContreTorpilleur;
                    y[6, 11] = ContreTorpilleur;
                    y[7, 11] = ContreTorpilleur;

                    y[6, 3] = Torpilleur;
                    y[6, 3] = Torpilleur;
                    break;

                case 13:

                    y[2, 0] = PorteAvion;
                    y[3, 0] = PorteAvion;
                    y[4, 0] = PorteAvion;
                    y[5, 0] = PorteAvion;
                    y[6, 0] = PorteAvion;

                    y[6, 8] = Croiseur;
                    y[6, 9] = Croiseur;
                    y[6, 10] = Croiseur;
                    y[6, 11] = Croiseur;

                    y[5, 6] = ContreTorpilleur;
                    y[5, 7] = ContreTorpilleur;
                    y[5, 8] = ContreTorpilleur;

                    y[1, 3] = Torpilleur;
                    y[1, 4] = Torpilleur;
                    break;

                case 14:

                    y[13, 1] = PorteAvion;
                    y[13, 2] = PorteAvion;
                    y[13, 3] = PorteAvion;
                    y[13, 4] = PorteAvion;
                    y[13, 5] = PorteAvion;

                    y[3, 8] = Croiseur;
                    y[3, 9] = Croiseur;
                    y[3, 10] = Croiseur;
                    y[3, 11] = Croiseur;

                    y[8, 6] = ContreTorpilleur;
                    y[8, 7] = ContreTorpilleur;
                    y[8, 8] = ContreTorpilleur;

                    y[3, 5] = Torpilleur;
                    y[3, 6] = Torpilleur;
                    break;

                case 15:

                    y[5, 4] = PorteAvion;
                    y[5, 5] = PorteAvion;
                    y[5, 6] = PorteAvion;
                    y[5, 7] = PorteAvion;
                    y[5, 8] = PorteAvion;

                    y[6, 8] = Croiseur;
                    y[6, 9] = Croiseur;
                    y[6, 10] = Croiseur;
                    y[6, 11] = Croiseur;

                    y[5, 6] = ContreTorpilleur;
                    y[4, 6] = ContreTorpilleur;
                    y[3, 6] = ContreTorpilleur;

                    y[10, 3] = Torpilleur;
                    y[10, 4] = Torpilleur;
                    break;

                case 16:

                    y[15, 5] = PorteAvion;
                    y[15, 6] = PorteAvion;
                    y[15, 7] = PorteAvion;
                    y[15, 8] = PorteAvion;
                    y[15, 9] = PorteAvion;

                    y[4, 2] = Croiseur;
                    y[4, 3] = Croiseur;
                    y[4, 4] = Croiseur;
                    y[4, 5] = Croiseur;

                    y[1, 0] = ContreTorpilleur;
                    y[2, 0] = ContreTorpilleur;
                    y[3, 0] = ContreTorpilleur;

                    y[2, 3] = Torpilleur;
                    y[2, 4] = Torpilleur;
                    break;
            }
            int[,] TableColRow = new int[x, x];



        }
    }
}
