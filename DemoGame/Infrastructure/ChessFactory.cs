// Copyright @JJSoft - All Rights Reserved
// Filename: ChessFactory.cs
// Created By  :  Frankie
// Created Date:  25/02/2020  20:18
// Last Edit:
//    Author:   Frankie
//    Date:     25/02/2020  20:19

namespace DemoGame.Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using DemoGame.Model;

    /// <summary>
    /// The chess factory.
    /// </summary>
    public class ChessFactory
    {
        private List<ChessPoint> ChessPoints = new List<ChessPoint>();

        private int rowNumber = 1;

        private int columnNumber = 1;

        public bool ShouldQuitGame => this.ChessPoints.All(x => x.TurnOnStatus);

        public List<ChessPoint> BeginGame(int rowNumber, int columnNumber)
        {
            if (rowNumber <= 0)
            {
                throw new ArgumentException("row number must great than 0");
            }

            if (columnNumber <= 0)
            {
                throw new ArgumentException("column number must great than 0");
            }

            this.rowNumber = rowNumber;
            this.columnNumber = columnNumber;

            var lightOnList = this.RandomLightOnPoint(rowNumber, columnNumber);
            for (var rowIndex = 0; rowIndex < rowNumber; rowIndex++)
            {
                for (var columnIndex = 0; columnIndex < columnNumber; columnIndex++)
                {
                    var chessPoint = new ChessPoint
                                         {
                                             Column = columnIndex,
                                             Row = rowIndex
                                         };
                    chessPoint.TurnOnStatus = lightOnList.Any(x => x == chessPoint.Key);
                    this.ChessPoints.Add(chessPoint);
                }
            }

            return this.ChessPoints.Where(x => x.TurnOnStatus).ToList();
        }

        public void ShowLightOnChessPoints()
        {
            foreach (var chessPoint in this.ChessPoints.Where(x => x.TurnOnStatus))
            {
                Console.WriteLine($"The chess point[{chessPoint.Row}][{chessPoint.Column}] status is light on");
            }
        }

        public void ShowLightOffChessPoints()
        {
            foreach (var chessPoint in this.ChessPoints.Where(x => !x.TurnOnStatus))
            {
                Console.WriteLine($"The chess point[{chessPoint.Row}][{chessPoint.Column}] status is light off");
            }
        }

        public void SelectChessPoint(int rowIndex, int columnIndex)
        {
            if (rowIndex <= 0)
            {
                throw new ArgumentException("row number must be greater than 0");
            }

            if (columnIndex <= 0)
            {
                throw new ArgumentException("column number must be greater than 0");
            }

            if (rowIndex > this.rowNumber - 1)
            {
                throw new ArgumentException($"Row number must be less than {this.rowNumber - 1}");
            }

            if (columnIndex > this.columnNumber - 1)
            {
                throw new ArgumentException($"Column number must be less than {this.columnNumber - 1}");
            }

            this.ChangeChessPointStatus(rowIndex - 1, columnIndex);
            this.ChangeChessPointStatus(rowIndex, columnIndex);
            this.ChangeChessPointStatus(rowIndex + 1, columnIndex);
            this.ChangeChessPointStatus(rowIndex, columnIndex - 1);
            this.ChangeChessPointStatus(rowIndex, columnIndex + 1);
        }

        private void ChangeChessPointStatus(int rowIndex, int columnIndex)
        {
            if (rowIndex < 0 || columnIndex < 0 || rowIndex > this.rowNumber - 1 || columnIndex > this.columnNumber - 1)
            {
                return;
            }

            var tempChessPoint = this.ChessPoints.FirstOrDefault(x => x.Key == this.GetKey(rowIndex, columnIndex));
            tempChessPoint.TurnOnStatus = !tempChessPoint.TurnOnStatus;
        }

        private int GetDimension(int rowNumber, int columnNumber)
        {
            var random = new Random();
            var rowIndex = random.Next(0, rowNumber - 1).ToString();
            var columnIndex = random.Next(0, columnNumber - 1).ToString();
            return int.Parse(rowIndex + columnIndex);
        }

        private int GetKey(int rowIndex, int columnIndex)
        {
            var strRowIndex = rowIndex.ToString();
            var strColumnIndex = columnIndex.ToString();
            return int.Parse(strRowIndex + strColumnIndex);
        }

        private List<int> RandomLightOnPoint(int rowNumber, int columnNumber)
        {
            var lightOnList = new List<int>();

            var random = new Random();
            var totalNumber = random.Next(1, 5);

            for (var i = 0; i < totalNumber; i++)
            {
                while (true)
                {
                    var dimension = this.GetDimension(rowNumber, columnNumber);
                    if (!lightOnList.Any(x => x == dimension))
                    {
                        lightOnList.Add(dimension);
                        break;
                    }
                }
            }

            return lightOnList;
        }
    }
}