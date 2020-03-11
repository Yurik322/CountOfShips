//-----------------------------------------------------------------------
// <copyright file="Functions.cs" company="My Company">
//    Created by yurik_322 on 20/03/10.
// </copyright>
//-----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;

namespace CountOfShips
{
    public class Functions
    {
        public readonly bool[][] BattleBoard;

        /// <summary>
        /// Initializes a new instance of the <see cref="Functions"/> class.
        /// </summary>
        /// <param name="battleBoard">matrix with 1 and 0</param>
        public Functions(bool[][] battleBoard)
        {
            BattleBoard = battleBoard;
        }

        /// <summary>
        /// Method for counting ships in collection.
        /// </summary>
        /// <returns>Return number of ships</returns>
        public IDictionary<int, int> CountOfShips()
        {
            var number = new Dictionary<int, int>();

            for (int i = 0; i < BattleBoard.Length; i++)
            {
                for (int j = 0; j < BattleBoard[i].Length; j++)
                { 
                    if (BattleBoard[i][j])
                    {
                        int counter = SizeOfShip(i, j);

                        if (!number.ContainsKey(counter))
                        {
                            number[counter] = 0;
                        }

                        number[counter]++;
                    }
                }
            }

            return number;
        }

        /// <summary>
        /// Method for counting size of ships.
        /// </summary>
        /// <param name="i">first position</param>
        /// <param name="j">second position</param>
        /// <returns>Return size of ships</returns>
        public int SizeOfShip(int i, int j)
        {
            int size = BattleBoard[i][j] ? 1 : 0;
            BattleBoard[i][j] = false;

            if (j < BattleBoard[i].Length - 1 && i < BattleBoard.Length - 1 && BattleBoard[i + 1][j + 1] && !BattleBoard[i][j + 1] && !BattleBoard[i + 1][j])
            { 
                throw new Exception("Invalid input, try better one " + (i + 1) + " " + (j + 1));
            }

            if (j > 0 && i < BattleBoard.Length - 1 && !BattleBoard[i][j - 1] && !BattleBoard[i + 1][j] && BattleBoard[i + 1][j - 1])
            {
                throw new Exception("Invalid input, try better one " + (i + 1) + " " + (j - 1));
            }

            if (j < BattleBoard[i].Length - 1 && BattleBoard[i][j + 1])
            {
                size += SizeOfShip(i, j + 1);
            }

            if (i < BattleBoard.Length - 1 && BattleBoard[i + 1][j])
            {
                size += SizeOfShip(i + 1, j);
            }

            if (j > 0 && BattleBoard[i][j - 1])
            {
                size += SizeOfShip(i, j - 1);
            }

            return size;
        }

        /// <summary>
        /// Method for counting whole sum of ships.
        /// </summary>
        public static void SumOfShips()
        {
            var board = InitializedBoard.Board;

            var matrixArray = board.Select(x => x.Select(y => y != '0').ToArray()).ToArray();
            var battleBoard = new Functions(matrixArray);
            
            var result = battleBoard.CountOfShips();

            int sum = 0;
            foreach (var key in result.Keys.OrderBy(x => x))
            {
                Console.WriteLine("Size of Ship: (" + key + ") " + "=> count: " + result[key]);

                sum = result.Keys.OrderBy(x => x).Sum();
            }

            Console.WriteLine("\nCalculate number of ships equal to " + sum);
        }
    }
}
