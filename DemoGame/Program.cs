// Copyright @JJSoft - All Rights Reserved
// Filename: Program.cs
// Created By  :  Frankie
// Created Date:  25/02/2020  17:27
// Last Edit:
//    Author:   Frankie
//    Date:     25/02/2020  20:59

namespace DemoGame
{
    using System;

    using DemoGame.Infrastructure;

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Start the game");
            Console.WriteLine("Please input numbers of rows");
            var rowNumber = Console.ReadLine();

            Console.WriteLine("Please input numbers of columns");
            var columnNumber = Console.ReadLine();

            var chessFactory = new ChessFactory();
            chessFactory.BeginGame(int.Parse(rowNumber), int.Parse(columnNumber));

            Console.WriteLine("Initialize the game");
            chessFactory.ShowLightOnChessPoints();

            Console.WriteLine("If you want to quit the game, please input q");
            while (true)
            {
                try
                {
                    Console.WriteLine("pleas select row index");
                    var selectedRowIndex = Console.ReadLine();

                    Console.WriteLine("pleas select column index");
                    var selectedColumnIndex = Console.ReadLine();
                    chessFactory.SelectChessPoint(int.Parse(selectedRowIndex), int.Parse(selectedColumnIndex));

                    Console.WriteLine("Show current situation:");
                    chessFactory.ShowLightOnChessPoints();
                    chessFactory.ShowLightOffChessPoints();

                    if (chessFactory.ShouldQuitGame)
                    {
                        Console.WriteLine("Congratulations! You finish it successfully! Please click q to quit the game");
                        if (Console.ReadKey().KeyChar == 'q')
                        {
                            Environment.Exit(0);
                        }
                    }

                    if (Console.ReadKey().KeyChar == 'q')
                    {
                        Environment.Exit(0);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}