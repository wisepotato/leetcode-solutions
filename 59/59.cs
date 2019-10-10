using System;
namespace Solutions._59
{
    /// <summary>
    /// Solution for exercise 59
    /// 
    /// It creates a spiral matrix such as
    /// 
    /// 1 2 3 
    /// 8 9 4  for n =3
    /// 7 6 5 
    /// 
    /// and
    /// 
    /// 1  2  3  4
    /// 12 13 14 5
    /// 11 16 15 6  for n =4
    /// 10 9  8  7
    /// </summary>
    public class Solution
    {

        /// <summary>
        /// used for detecting how deep in the spiral we are.
        /// </summary>
        private int _offset;
        /// <summary>
        /// This is used to keep track of the current number of the spiral.
        /// </summary>
        private int _currentInteger;
        /// <summary>
        /// Defines the final index, used for out-of-bounds detection.
        /// </summary>
        private int _lastIndex;
        /// <summary>
        /// The spiral matrix in question
        /// </summary>
        private int[][] _matrix;
        /// <summary>
        /// stopping condition on the x axis
        /// </summary>
        private int _xEnd;
        /// <summary>
        /// Stopping condition on the y axis
        /// </summary>
        private int _yEnd;
        /// <summary>
        /// Entrypoint
        /// </summary>
        /// <param name="n">With/Height of the resulting matrix</param>
        /// <returns>A matrix with a spiral in numbers 1 ...</returns>
        public int[][] GenerateMatrix(int n)
        {
            _matrix = MakeEmptyMatrix(n);
            if (n == 0)
            {
                return _matrix;
            }
            if (n == 1)
            {
                _matrix[0][0] = 1;
                return _matrix;
            }
            _currentInteger = 1;
            SetEndPoint(n);
            // Some setup to make sure that we have a 
            // 'clean' start
            int x = 0;
            int y = 0;
            _offset = 0;
            _lastIndex = n - 1;
            // we always start by going right
            GoHorizontal(x, y);
            return _matrix;
        }

        /// <summary>
        /// Goes left-to-right and right-to-left in reverse, while also setting the number in the matrix
        /// </summary>
        /// <param name="x">starting position for x</param>
        /// <param name="y">starting position for y</param>
        /// <param name="reverse">if set to true, reverses direction to right-to-left</param>
        private void GoHorizontal(int x, int y, bool reverse = false)
        {
            if (reverse)
            {
                while (x >= _offset)
                {
                    _matrix[y][x] = _currentInteger++;

                    if (CheckEndCondition(x, y))
                        return;
                    x--;
                }
                x++; // dont want to go out of bounds
                GoVertical(x, y - 1, true);
            }
            else
            {
                while (x <= _lastIndex - _offset)
                {
                    _matrix[y][x] = _currentInteger++;
                    if (CheckEndCondition(x, y))
                        return;
                    x++;
                }
                x--;
                GoVertical(x, y + 1);
            }
            if (CheckEndCondition(x, y))
                return;
        }

        /// <summary>
        /// Goes horiziontal, default is top-to-bottom
        /// </summary>
        /// <param name="x">x starting position</param>
        /// <param name="y">y starting position</param>
        /// <param name="reverse">whether or not to reverse the direction</param>
        private void GoVertical(int x, int y, bool reverse = false)
        {
            if (reverse)
            {
                // we increase the offset here and only here to show that we have completed 
                // a 'lap'
                // In this case we will be here (denoted with an x)
                // 1 2 3
                //     4
                // x 6 5 
                // in this case the offset **was** 0, now it will be 1.
                _offset++;
                while (y >= _offset)
                {
                    _matrix[y][x] = _currentInteger++;
                    if (CheckEndCondition(x, y))
                        return;
                    y--;

                }
                y++; // out of bounds check
                GoHorizontal(x + 1, y);
            }
            else
            {
                while (y <= _lastIndex - _offset)
                {
                    _matrix[y][x] = _currentInteger++;
                    if (CheckEndCondition(x, y))
                        return;
                    y++;
                }
                y--; // out of bounds check;
                GoHorizontal(x - 1, y, true);
            }
            if (CheckEndCondition(x, y))
                return;
        }

        /// <summary>
        /// Tells you whether the program has reached the center of the spiral.
        /// </summary>
        /// <param name="x">x parameter to check against xEnd</param>
        /// <param name="y">y parameter to check against yEnd</param>
        /// <returns></returns>
        private bool CheckEndCondition(int x, int y)
        {
            return x == _xEnd && y == _yEnd;
        }

        /// <summary>
        /// Creates an empty int array array of equal height/width;
        /// </summary>
        /// <param name="widthHeight">Your required height/width</param>
        /// <returns></returns>
        public int[][] MakeEmptyMatrix(int widthHeight)
        {
            int[][] matrix = new int[widthHeight][];
            for (int i = 0; i < widthHeight; i++)
            {
                var toInsert = new int[widthHeight];
                matrix[i] = toInsert;
            }
            return matrix;
        }

        /// <summary>
        /// Fetches the endpoint for this matrix
        /// </summary>
        /// <param name="n">the width/height of the matrix</param>
        /// <returns>A tuple containing the x and y (int) which signals the end.</returns>
        private void SetEndPoint(int n)
        {
            int x;
            int y;
            if (n == 0)
            {
                _xEnd = 0;
                _yEnd = 0;
                return;
            }
            if (n % 2 == 0)
            {
                x = Convert.ToInt32((n / 2) - 1);
                y = x + 1;
            }
            else
            {
                x = Convert.ToInt32((n - 1) / 2);
                y = x;
            }
            _xEnd = x;
            _yEnd = y;
        }
    }
}
