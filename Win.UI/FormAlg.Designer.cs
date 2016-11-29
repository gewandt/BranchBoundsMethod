namespace Win.UI
{
    partial class FormAlg
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonStartSearch = new System.Windows.Forms.Button();
            this.labelCount = new System.Windows.Forms.Label();
            this.buttonGenerateData = new System.Windows.Forms.Button();
            this.numericUpDownCount = new System.Windows.Forms.NumericUpDown();
            this.dataGridViewData = new System.Windows.Forms.DataGridView();
            this.listBoxOptimal = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewData)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonStartSearch
            // 
            this.buttonStartSearch.Enabled = false;
            this.buttonStartSearch.Location = new System.Drawing.Point(12, 157);
            this.buttonStartSearch.Name = "buttonStartSearch";
            this.buttonStartSearch.Size = new System.Drawing.Size(114, 23);
            this.buttonStartSearch.TabIndex = 0;
            this.buttonStartSearch.Text = "Запустить поиск";
            this.buttonStartSearch.UseVisualStyleBackColor = true;
            this.buttonStartSearch.Click += new System.EventHandler(this.buttonStartSearch_Click);
            // 
            // labelCount
            // 
            this.labelCount.AutoSize = true;
            this.labelCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelCount.Location = new System.Drawing.Point(13, 13);
            this.labelCount.Name = "labelCount";
            this.labelCount.Size = new System.Drawing.Size(202, 24);
            this.labelCount.TabIndex = 1;
            this.labelCount.Text = "Количество деталей:";
            // 
            // buttonGenerateData
            // 
            this.buttonGenerateData.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonGenerateData.Location = new System.Drawing.Point(376, 12);
            this.buttonGenerateData.Name = "buttonGenerateData";
            this.buttonGenerateData.Size = new System.Drawing.Size(163, 27);
            this.buttonGenerateData.TabIndex = 3;
            this.buttonGenerateData.Text = "Построить";
            this.buttonGenerateData.UseVisualStyleBackColor = true;
            this.buttonGenerateData.Click += new System.EventHandler(this.buttonGenerateData_Click);
            // 
            // numericUpDownCount
            // 
            this.numericUpDownCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.numericUpDownCount.Location = new System.Drawing.Point(230, 12);
            this.numericUpDownCount.Name = "numericUpDownCount";
            this.numericUpDownCount.Size = new System.Drawing.Size(123, 26);
            this.numericUpDownCount.TabIndex = 4;
            // 
            // dataGridViewData
            // 
            this.dataGridViewData.AllowUserToAddRows = false;
            this.dataGridViewData.AllowUserToDeleteRows = false;
            this.dataGridViewData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewData.Location = new System.Drawing.Point(12, 44);
            this.dataGridViewData.Name = "dataGridViewData";
            this.dataGridViewData.ReadOnly = true;
            this.dataGridViewData.Size = new System.Drawing.Size(527, 107);
            this.dataGridViewData.TabIndex = 5;
            // 
            // listBoxOptimal
            // 
            this.listBoxOptimal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.listBoxOptimal.FormattingEnabled = true;
            this.listBoxOptimal.ItemHeight = 16;
            this.listBoxOptimal.Location = new System.Drawing.Point(13, 213);
            this.listBoxOptimal.Name = "listBoxOptimal";
            this.listBoxOptimal.Size = new System.Drawing.Size(526, 116);
            this.listBoxOptimal.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(13, 183);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(276, 20);
            this.label1.TabIndex = 7;
            this.label1.Text = "5 наиболее оптимальных решений:";
            // 
            // FormAlg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(551, 358);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listBoxOptimal);
            this.Controls.Add(this.dataGridViewData);
            this.Controls.Add(this.numericUpDownCount);
            this.Controls.Add(this.buttonGenerateData);
            this.Controls.Add(this.labelCount);
            this.Controls.Add(this.buttonStartSearch);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FormAlg";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Метод ветвей и границ";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonStartSearch;
        private System.Windows.Forms.Label labelCount;
        private System.Windows.Forms.Button buttonGenerateData;
        private System.Windows.Forms.NumericUpDown numericUpDownCount;
        private System.Windows.Forms.DataGridView dataGridViewData;
        private System.Windows.Forms.ListBox listBoxOptimal;
        private System.Windows.Forms.Label label1;
    }
}

