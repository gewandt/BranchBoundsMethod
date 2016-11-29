using System.Windows.Forms;

namespace Service
{
    public class Initializer
    {
        private const int ColumnWidth = 70;
        private const int RowHeadersWidth = 100;
        public static void InitDataGridColumns(DataGridView dataGrid, int count)
        {
            if (count < 0) return;
            dataGrid.ColumnCount = count;
            for (int i = 0; i < count; i++)
            {
                dataGrid.Columns[i].Name = $"Деталь {i}";
                dataGrid.Columns[i].Width = ColumnWidth;
            }
        }

        public static void InitDataGridRows(DataGridView dataGrid, int count = 3)
        {
            if (count < 0) return;
            dataGrid.RowCount = count;
            dataGrid.RowHeadersWidth = RowHeadersWidth;
            char j = 'a';
            for (int i = 0; i < count; i++)
            {
                dataGrid.Rows[i].HeaderCell.Value = $"Станок {j}";
                j++;
            }
        }
    }
}
