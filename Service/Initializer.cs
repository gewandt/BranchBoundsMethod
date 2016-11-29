using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Service
{
    public class Initializer
    {
        public static Dictionary<string, List<int>> MainMatrixDic = new Dictionary<string, List<int>>();
        private const int ColumnWidth = 70;
        private const int RowHeadersWidth = 100;
        private static int CountRows { get; set; }
        private static int CountColumns { get; set; }
        
        public static void InitDataGridColumns(DataGridView dataGrid, int count)
        {
            if (count < 0) return;
            dataGrid.ColumnCount = count;
            CountColumns = count;
            for (int i = 0; i < count; i++)
            {
                dataGrid.Columns[i].Name = $"Деталь {i}";
                dataGrid.Columns[i].Width = ColumnWidth;
            }
        }

        public static void InitDataGridRows(DataGridView dataGrid, int count = 3)
        {
            if (count < 0) return;
            CountRows = count;
            dataGrid.RowCount = count;
            dataGrid.RowHeadersWidth = RowHeadersWidth;
            char j = 'a';
            for (int i = 0; i < count; i++)
            {
                dataGrid.Rows[i].HeaderCell.Value = $"Станок {j}";
                j++;
            }
        }

        public static void InitGridValues(DataGridView dataGrid)
        {
            if (CountRows.Equals(0) || CountColumns.Equals(0)) return;
            var rnd = new Random();
           
            for (int i = 0; i < CountColumns; i++)
            {
                var list = new List<int>();
                for (int j = 0; j < CountRows; j++)
                {
                    var number = rnd.Next(1, 5);
                    dataGrid[i, j].Value = number;
                    list.Add(number);
                }
                MainMatrixDic.Add(i.ToString(), list);
            }
        }

        public static void ClearDictionary()
        {
            MainMatrixDic.Clear();
        }
    }
}
