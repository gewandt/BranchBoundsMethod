using System;
using System.Collections.Generic;
using System.Linq;

namespace Service
{
    public class Service
    {
        private int[,] _matrix;

        private Dictionary<string, List<int>> _mainMatrixDic;

        private List<List<int>> opimal;


        private List<List<string>> _optimalSequencesResult;

        public Service()
        {
            _optimalSequencesResult = new List<List<string>>();
            _matrix = new int[,] { { 2, 3, 4 }, { 5, 2, 4 }, { 1, 1, 2 }, { 3, 4, 2 }, { 3, 5, 2 } };
            _mainMatrixDic = new Dictionary<string, List<int>>();
            _mainMatrixDic.Add("1", new List<int>() { 2, 3, 4 });
            _mainMatrixDic.Add("2", new List<int>() { 5, 2, 4 });
            _mainMatrixDic.Add("3", new List<int>() { 1, 1, 2 });
            _mainMatrixDic.Add("4", new List<int>() { 3, 4, 2 });
            _mainMatrixDic.Add("5", new List<int>() { 3, 5, 2 });


            var list = new List<int>() { 0 };
            opimal = new List<List<int>>();
            MethodBranch(list);
        }

        private void MethodBranch(List<int> excludedColumns)
        {
            CalculateD1(null,new List<string>(), new Dictionary<string, List<int>>() /*_matrixDic*/);
        }

        private void CalculateD1(string excludedColumn,List<string> optimalSequence, Dictionary<string, List<int>> matrixDic)
        {
            if (excludedColumn != null)
            {
                optimalSequence.Add(excludedColumn);
                matrixDic.Remove(excludedColumn);
            }
            else
            {
                //Problem if not first
                foreach(var matrDic in _mainMatrixDic)
                {
                    matrixDic.Add(matrDic.Key, matrDic.Value);
                }
            }

            //optimalSequence on this step
            var tempOptimalSequenceStep = new List<string>();

            foreach(var seq in optimalSequence)
            {
                tempOptimalSequenceStep.Add(seq);
            }

            //tempMatrixDic on this step
            var tempMatrixDic = new Dictionary<string, List<int>>();

            foreach (var seq in matrixDic)
            {
                tempMatrixDic.Add(seq.Key,seq.Value);
            }

            Dictionary<string, int> resultSequenceS1 = new Dictionary<string, int>();

            foreach (var elem in matrixDic)
            {
                var da = CalculateDa1(matrixDic, elem.Key);
                var db = CalculateDb1(matrixDic, elem.Key);
                var dc = CalculateDc1(matrixDic, elem.Key);
                var max = Math.Max(da, db);
                resultSequenceS1.Add(elem.Key, Math.Max(max, dc));
            }

            int minOptimalElem = -1;

            if (resultSequenceS1.Count != 0)
            {
                minOptimalElem = resultSequenceS1.Values.Min();
            }

            //get all min optimal values
            Dictionary<string, int> optimalResultElementsFromSequence = new Dictionary<string, int>();

            foreach(var elem in resultSequenceS1)
            {
                if (elem.Value == minOptimalElem)
                {
                    optimalResultElementsFromSequence.Add(elem.Key, elem.Value);
                }
            }

            if (matrixDic.Count == 0)
            {
                _optimalSequencesResult.Add(optimalSequence);
            }

            foreach (var optimalElement in optimalResultElementsFromSequence)
            {
                CalculateD1(optimalElement.Key, optimalSequence, matrixDic);

                matrixDic = tempMatrixDic;
                optimalSequence = tempOptimalSequenceStep;
            }

        }

        private int CalculateDa1(Dictionary<string,List<int>> tempMatrixDic, string excludedColumnIteration)
        {
            int sum = 0;
            int min = int.MaxValue;

            foreach(var elem in tempMatrixDic)
            {
                if (elem.Key != excludedColumnIteration)
                {
                    sum += elem.Value.First();
                }
            }

            foreach (var elem in tempMatrixDic)
            {
                if (elem.Key != excludedColumnIteration)
                {
                    var b = elem.Value[1];
                    var c = elem.Value[2];
                    min = min < b + c ? min : b + c;
                }
            }
            return sum + min;
        }


        private int CalculateDb1(Dictionary<string, List<int>> tempMatrixDic, string excludedColumnIteration)
        {
            int sum = 0;
            int min = int.MaxValue;

            foreach (var elem in tempMatrixDic)
            {
                if (elem.Key != excludedColumnIteration)
                {
                    sum += elem.Value[1];
                }
            }

            foreach (var elem in tempMatrixDic)
            {
                if (elem.Key != excludedColumnIteration)
                {
                    var c = elem.Value[2];
                    min = min < c ? min : c;
                }
            }

            List<int> list;
            tempMatrixDic.TryGetValue(excludedColumnIteration, out list);

            var b0 = list.First() + list[1];

            return sum + min + b0;
        }

        private int CalculateDc1(Dictionary<string, List<int>> tempMatrixDic, string excludedColumnIteration)
        {
            int sum = 0;

            foreach (var elem in tempMatrixDic)
            {
                if (elem.Key != excludedColumnIteration)
                {
                    sum += elem.Value.Last();
                }
            }

            List<int> list;
            tempMatrixDic.TryGetValue(excludedColumnIteration,out list);
            int c0 = 0;
            foreach(var elem in list)
            {
                c0 += elem;
            }

            return sum + c0;
        }


        //private List<int> CalculateD(List<int> excludedColumns)
        //{
        //    var columnCount = _matrix.GetLength(0);
        //    int[] arr = new int[columnCount];
        //    for (int i = 0; i < columnCount; i++)
        //    {
        //        var da = CalculateDa(excludedColumns, i);
        //        var db = CalculateDb(excludedColumns, i);
        //        var dc = CalculateDc(excludedColumns, i);
        //        var max = Math.Max(da, db);
        //        arr[i] = Math.Max(max, dc);
        //    }
        //    var minElem = arr.Min();

        //    for (int i = 0; i < arr.Length; i++)
        //    {
        //        if (arr[i].Equals(minElem))
        //        {
        //            if (!excludedColumns.Count.Equals(columnCount))
        //            {
        //                excludedColumns.Add(arr[i]);
        //                CalculateD(excludedColumns);
        //                opimal.Add(excludedColumns);
        //            }
        //        }
        //    }
        //    return excludedColumns;
        //}

        //private int CalculateDa(List<int> excludeColumnMatrix, int excludedColumnIteration)
        //{
        //    int sum = 0;
        //    int min = Int32.MaxValue;

        //    var columnCount = _matrix.GetLength(0);
        //    for (int i = 0; i < columnCount; i++)
        //    {
        //        if (!excludeColumnMatrix.Contains(i) && i != excludedColumnIteration)
        //        {
        //            sum += _matrix[i, 0];
        //        }
        //    }

        //    for (int i = 0; i < columnCount; i++)
        //    {
        //        if (i != excludedColumnIteration)
        //        {
        //            var b = _matrix[i, 1];
        //            var c = _matrix[i, 2];
        //            min = min < b + c ? min : b + c;
        //        }
        //    }
        //    return sum + min;
        //}

        //private int CalculateDb(List<int> excludeColumnMatrix, int excludedColumnIteration)
        //{
        //    int sum = 0;
        //    int min = Int32.MaxValue;

        //    var columnCount = _matrix.GetLength(0);
        //    for (int i = 0; i < columnCount; i++)
        //    {
        //        if (!excludeColumnMatrix.Contains(i) && i != excludedColumnIteration)
        //        {
        //            sum += _matrix[i, 1];
        //        }
        //    }

        //    for (int i = 0; i < columnCount; i++)
        //    {
        //        if (i != excludedColumnIteration)
        //        {
        //            var c = _matrix[i, 2];
        //            min = min < c ? min : c;
        //        }
        //    }

        //    var b0 = _matrix[excludedColumnIteration, 0] + _matrix[excludedColumnIteration, 1];
        //    return sum + min + b0;
        //}

        //private int CalculateDc(List<int> excludeColumnMatrix, int excludedColumnIteration)
        //{
        //    int sum = 0;

        //    var columnCount = _matrix.GetLength(0);
        //    for (int i = 0; i < columnCount; i++)
        //    {
        //        if (!excludeColumnMatrix.Contains(i) && i != excludedColumnIteration)
        //        {
        //            sum += _matrix[i, 2];
        //        }
        //    }

        //    var c0 = _matrix[excludedColumnIteration, 0] + _matrix[excludedColumnIteration, 1] + _matrix[excludedColumnIteration, 2];
        //    return sum + c0;
        //}


    }
}
