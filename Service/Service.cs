using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Service
{
    public class Service
    {
        private int[,] _matrix;
        private List<List<int>> opimal;

        public Service()
        {
            _matrix = new int[,] { { 2, 3, 4 }, { 5, 2, 4 }, { 1, 1, 2 }, { 3, 4, 2 }, { 3, 5, 2 } };
            var list = new List<int>() { 0 };
            opimal = new List<List<int>>();
            MethodBranch(list);
        }

        private void MethodBranch(List<int> excludedColumns)
        {
            CalculateD(excludedColumns);
        }

        private List<int> CalculateD(List<int> excludedColumns)
        {
            var columnCount = _matrix.GetLength(0);
            int[] arr = new int[columnCount];
            for (int i = 0; i < columnCount; i++)
            {
                var da = CalculateDa(excludedColumns, i);
                var db = CalculateDb(excludedColumns, i);
                var dc = CalculateDc(excludedColumns, i);
                var max = Math.Max(da, db);
                arr[i] = Math.Max(max, dc);
            }
            var minElem = arr.Min();

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i].Equals(minElem))
                {
                    if (!excludedColumns.Count.Equals(columnCount))
                    {
                        excludedColumns.Add(arr[i]);
                        CalculateD(excludedColumns);
                        opimal.Add(excludedColumns);
                    }
                }
            }
            return excludedColumns;
        }

        private int CalculateDa(List<int> excludeColumnMatrix, int excludedColumnIteration)
        {
            int sum = 0;
            int min = Int32.MaxValue;

            var columnCount = _matrix.GetLength(0);
            for (int i = 0; i < columnCount; i++)
            {
                if (!excludeColumnMatrix.Contains(i) && i!= excludedColumnIteration)
                {
                    sum += _matrix[i, 0];
                }
            }

            for (int i = 0; i < columnCount; i++)
            {
                if (i != excludedColumnIteration)
                {
                    var b = _matrix[i, 1];
                    var c = _matrix[i, 2];
                    min = min < b + c ? min : b + c;
                }
            }
            return sum + min;
        }

        private int CalculateDb(List<int> excludeColumnMatrix, int excludedColumnIteration)
        {
            int sum = 0;
            int min = Int32.MaxValue;

            var columnCount = _matrix.GetLength(0);
            for (int i = 0; i < columnCount; i++)
            {
                if (!excludeColumnMatrix.Contains(i) && i != excludedColumnIteration)
                {
                    sum += _matrix[i, 1];
                }
            }

            for (int i = 0; i < columnCount; i++)
            {
                if (i != excludedColumnIteration)
                {
                    var c = _matrix[i, 2];
                    min = min < c ? min : c;
                }
            }

            var b0 = _matrix[excludedColumnIteration, 0] + _matrix[excludedColumnIteration, 1];
            return sum + min + b0;
        }

        private int CalculateDc(List<int> excludeColumnMatrix, int excludedColumnIteration)
        {
            int sum = 0;

            var columnCount = _matrix.GetLength(0);
            for (int i = 0; i < columnCount; i++)
            {
                if (!excludeColumnMatrix.Contains(i) && i != excludedColumnIteration)
                {
                    sum += _matrix[i, 2];
                }
            }

            var c0 = _matrix[excludedColumnIteration, 0] + _matrix[excludedColumnIteration, 1] + _matrix[excludedColumnIteration, 2];
            return sum + c0;
        }
    }
}
