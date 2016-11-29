using System;
using System.Collections.Generic;
using System.Linq;

namespace Service
{
    public class Algoritm
    {
        private Dictionary<string, List<int>> _mainMatrixDic;
        private AlgoritmModel _rootModel;
        private List<List<string>> _optimalSequencesResult;

        public Algoritm(Dictionary<string, List<int>> mainMatrixDic)
        {
            _optimalSequencesResult = new List<List<string>>();
            _mainMatrixDic = mainMatrixDic;
        }

        public Tuple<AlgoritmModel,List<List<string>>> GetOptimalResultSequences()
        {
            var optimalSequence = new List<string>();
            var matrixDic = GetTempMatrixDic(_mainMatrixDic);
            _rootModel = new AlgoritmModel() { OptimalSequence = optimalSequence, MatrixDic = matrixDic };
            OptimalResultSequencesCalculation(_rootModel);
            return Tuple.Create(_rootModel, _optimalSequencesResult); 
        }

        private void OptimalResultSequencesCalculation(AlgoritmModel algModel)
        {
            algModel.SequenceDaDbDc = CalculateDSequence(algModel.MatrixDic);
            algModel.OptimalResultElementsFromSequence = GetOptimalValuesFromDSequence(algModel.SequenceDaDbDc);

            foreach (var optimalElement in algModel.OptimalResultElementsFromSequence)
            {
                algModel.OptimalSequence.Add(optimalElement.Key);

                var newAlgModel = new AlgoritmModel() { OptimalSequence = new List<string>(), MatrixDic = new Dictionary<string, List<int>>(),OptimalSequencesResult = new List<List<string>>() };
                if(algModel.InnerAlgoritmModel == null)
                {
                    algModel.InnerAlgoritmModel = new List<AlgoritmModel>();
                }
                newAlgModel.OptimalSequencesResult.Add(algModel.OptimalSequence);
                newAlgModel.MatrixDic = GetTempMatrixDic(algModel.MatrixDic);
                newAlgModel.MatrixDic.Remove(optimalElement.Key);
                newAlgModel.OptimalSequence = GetTempOptimalSequence(algModel.OptimalSequence);

                if (newAlgModel.MatrixDic.Count == 0)
                {
                    _optimalSequencesResult.Add(newAlgModel.OptimalSequence);
                    return;
                }

                algModel.InnerAlgoritmModel.Add(newAlgModel);
                OptimalResultSequencesCalculation(algModel.InnerAlgoritmModel.Last());
                algModel.OptimalSequence.Remove(algModel.OptimalSequence.Last());
            }

        }



        private List<string> GetTempOptimalSequence(List<string> optimalSequence)
        {
            var tempOptimalSequence = new List<string>();
            foreach (var seq in optimalSequence)
            {
                tempOptimalSequence.Add(seq);
            }
            return tempOptimalSequence;
        }

        private Dictionary<string, List<int>> GetTempMatrixDic(Dictionary<string, List<int>> matrixDic)
        {
            var tempMatrixDic = new Dictionary<string, List<int>>();
            foreach (var seq in matrixDic)
            {
                tempMatrixDic.Add(seq.Key, seq.Value);
            }
            return tempMatrixDic;
        }



        private Dictionary<string, int> CalculateDSequence(Dictionary<string, List<int>> matrixDic)
        {
            var sequenceDaDbDc = new Dictionary<string, int>();
            foreach (var elem in matrixDic)
            {
                var da = CalculateDa(matrixDic, elem.Key);
                var db = CalculateDb(matrixDic, elem.Key);
                var dc = CalculateDc(matrixDic, elem.Key);
                sequenceDaDbDc.Add(elem.Key, Math.Max(Math.Max(da, db), dc));
            }
            return sequenceDaDbDc;
        }

        private int CalculateDa(Dictionary<string, List<int>> tempMatrixDic, string excludedColumnIteration)
        {
            int sum = 0;
            int min = int.MaxValue;

            foreach (var elem in tempMatrixDic)
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

        private int CalculateDb(Dictionary<string, List<int>> tempMatrixDic, string excludedColumnIteration)
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

        private int CalculateDc(Dictionary<string, List<int>> tempMatrixDic, string excludedColumnIteration)
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
            tempMatrixDic.TryGetValue(excludedColumnIteration, out list);
            int c0 = 0;
            foreach (var elem in list)
            {
                c0 += elem;
            }

            return sum + c0;
        }



        private Dictionary<string, int> GetOptimalValuesFromDSequence(Dictionary<string, int> sequenceDaDbDc)
        {
            int minOptimalElem = -1;

            if (sequenceDaDbDc.Count != 0)
            {
                minOptimalElem = sequenceDaDbDc.Values.Min();
            }

            //get all min optimal values
            var optimalResultElementsFromSequence = new Dictionary<string, int>();

            foreach (var elem in sequenceDaDbDc)
            {
                if (elem.Value == minOptimalElem)
                {
                    optimalResultElementsFromSequence.Add(elem.Key, elem.Value);
                }
            }

            return optimalResultElementsFromSequence;
        }

    }
}
