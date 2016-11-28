using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Service;

namespace Win.UI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // _matrix = new int[,] { { 2, 3, 4 }, { 5, 2, 4 }, { 1, 1, 2 }, { 3, 4, 2 }, { 3, 5, 2 } };
            var _mainMatrixDic = new Dictionary<string, List<int>>();
            _mainMatrixDic.Add("1", new List<int>() { 2, 3, 4 });
            _mainMatrixDic.Add("2", new List<int>() { 5, 2, 4 });
            _mainMatrixDic.Add("3", new List<int>() { 1, 1, 2 });
            _mainMatrixDic.Add("4", new List<int>() { 3, 4, 2 });
            _mainMatrixDic.Add("5", new List<int>() { 3, 5, 2 });

            var algoritm = new Algoritm(_mainMatrixDic);
            var answerModel = algoritm.GetOptimalResultSequences();
        }
    }
}
