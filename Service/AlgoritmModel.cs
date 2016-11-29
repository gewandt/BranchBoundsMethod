using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class AlgoritmModel
    {
        public Dictionary<string, int> SequenceDaDbDc { get; set; }
        public Dictionary<string, int> OptimalResultElementsFromSequence { get; set; }
        public List<string> OptimalSequence { get; set; }
        public List<AlgoritmModel> InnerAlgoritmModel { get; set; }
        public Dictionary<string, List<int>> MatrixDic { get; set; }
        public string ExcludedColumn { get; set; }
        public List<List<string>> OptimalSequencesResult { get; set; }
    }
}
