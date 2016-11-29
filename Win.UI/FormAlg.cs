using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Service;
using Win.UI.Properties;

namespace Win.UI
{
    public partial class FormAlg : Form
    {
        public FormAlg()
        {
            InitializeComponent();
        }

        private void buttonGenerateData_Click(object sender, EventArgs e)
        {
            try
            {
                var count = int.Parse(numericUpDownCount.Text);
                Initializer.InitDataGridColumns(dataGridViewData, count);
                Initializer.InitDataGridRows(dataGridViewData);
                Initializer.InitGridValues(dataGridViewData);
                ButtonEnableDisable(false, true);
                listBoxOptimal.Items.Clear();
            }
            catch (Exception)
            {
                MessageBox.Show(Resources.ErrorMessage);
            }
        }

        private void buttonStartSearch_Click(object sender, EventArgs e)
        {
            try
            {
                // _matrix = new int[,] { { 2, 3, 4 }, { 5, 2, 4 }, { 1, 1, 2 }, { 3, 4, 2 }, { 3, 5, 2 } };
                var _mainMatrixDic = new Dictionary<string, List<int>>();
                _mainMatrixDic = Initializer.MainMatrixDic;
                //_mainMatrixDic.Add("1", new List<int>() { 2, 3, 4 });
                //_mainMatrixDic.Add("2", new List<int>() { 5, 2, 4 });
                //_mainMatrixDic.Add("3", new List<int>() { 1, 1, 2 });
                //_mainMatrixDic.Add("4", new List<int>() { 3, 4, 2 });
                //_mainMatrixDic.Add("5", new List<int>() { 3, 5, 2 });
                var algoritm = new Algoritm(_mainMatrixDic);
                var answerModel = algoritm.GetOptimalResultSequences();
                FillListBoxOptimal(answerModel);
                Initializer.ClearDictionary();
                ButtonEnableDisable(true, false);
            }
            catch (Exception)
            {
                MessageBox.Show(Resources.ErrorMessage);
            }
        }

        private void FillListBoxOptimal(Tuple<AlgoritmModel, List<List<string>>> model)
        {
            int taked = 5;
            if (model.Item2.Count < 5) taked = model.Item2.Count;
            var sb = new StringBuilder();
            foreach (var list in model.Item2.Take(taked))
            {
                foreach (var c in list)
                {
                    sb.Append(" >>> ").Append(c); ;
                }
                listBoxOptimal.Items.Add(sb);
                sb.Clear();
            }
        }

        private void ButtonEnableDisable(bool generate, bool search)
        {
            buttonStartSearch.Enabled = search;
            buttonGenerateData.Enabled = generate;
        }
    }
}
