namespace Transport
{
    partial class TransportOptimize
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.InputGrid = new System.Windows.Forms.DataGridView();
            this.Outputgrid = new System.Windows.Forms.DataGridView();
            this.BTNdelCol = new System.Windows.Forms.Button();
            this.BTNaddCol = new System.Windows.Forms.Button();
            this.BTNoptimize = new System.Windows.Forms.Button();
            this.TBColl = new System.Windows.Forms.TextBox();
            this.StatusLabel = new System.Windows.Forms.Label();
            this.Info1 = new System.Windows.Forms.Label();
            this.LabelSolution = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.InputGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Outputgrid)).BeginInit();
            this.SuspendLayout();
            // 
            // InputGrid
            // 
            this.InputGrid.AllowUserToOrderColumns = true;
            this.InputGrid.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.InputGrid.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.InputGrid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            this.InputGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.InputGrid.Location = new System.Drawing.Point(21, 61);
            this.InputGrid.Margin = new System.Windows.Forms.Padding(5);
            this.InputGrid.Name = "InputGrid";
            this.InputGrid.RowTemplate.Height = 25;
            this.InputGrid.Size = new System.Drawing.Size(629, 532);
            this.InputGrid.TabIndex = 0;
            this.InputGrid.CellLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.InputGrid_CellLeave);
            this.InputGrid.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.InputGrid_CellValidating);
            // 
            // Outputgrid
            // 
            this.Outputgrid.AllowUserToAddRows = false;
            this.Outputgrid.AllowUserToDeleteRows = false;
            this.Outputgrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Outputgrid.Location = new System.Drawing.Point(681, 61);
            this.Outputgrid.Margin = new System.Windows.Forms.Padding(5);
            this.Outputgrid.Name = "Outputgrid";
            this.Outputgrid.ReadOnly = true;
            this.Outputgrid.RowTemplate.Height = 25;
            this.Outputgrid.Size = new System.Drawing.Size(655, 532);
            this.Outputgrid.TabIndex = 1;
            // 
            // BTNdelCol
            // 
            this.BTNdelCol.Location = new System.Drawing.Point(21, 633);
            this.BTNdelCol.Margin = new System.Windows.Forms.Padding(5);
            this.BTNdelCol.Name = "BTNdelCol";
            this.BTNdelCol.Size = new System.Drawing.Size(142, 38);
            this.BTNdelCol.TabIndex = 2;
            this.BTNdelCol.Text = "Spalte -";
            this.BTNdelCol.UseVisualStyleBackColor = true;
            this.BTNdelCol.Click += new System.EventHandler(this.BTNdelCol_Click);
            // 
            // BTNaddCol
            // 
            this.BTNaddCol.Location = new System.Drawing.Point(173, 633);
            this.BTNaddCol.Margin = new System.Windows.Forms.Padding(5);
            this.BTNaddCol.Name = "BTNaddCol";
            this.BTNaddCol.Size = new System.Drawing.Size(147, 38);
            this.BTNaddCol.TabIndex = 3;
            this.BTNaddCol.Text = "Spalte +";
            this.BTNaddCol.UseVisualStyleBackColor = true;
            this.BTNaddCol.Click += new System.EventHandler(this.BTNaddCol_Click);
            // 
            // BTNoptimize
            // 
            this.BTNoptimize.Location = new System.Drawing.Point(521, 677);
            this.BTNoptimize.Margin = new System.Windows.Forms.Padding(5);
            this.BTNoptimize.Name = "BTNoptimize";
            this.BTNoptimize.Size = new System.Drawing.Size(129, 38);
            this.BTNoptimize.TabIndex = 6;
            this.BTNoptimize.Text = "Optimieren";
            this.BTNoptimize.UseVisualStyleBackColor = true;
            this.BTNoptimize.Click += new System.EventHandler(this.BTNoptimize_Click);
            // 
            // TBColl
            // 
            this.TBColl.Location = new System.Drawing.Point(334, 637);
            this.TBColl.Margin = new System.Windows.Forms.Padding(5);
            this.TBColl.Name = "TBColl";
            this.TBColl.Size = new System.Drawing.Size(316, 30);
            this.TBColl.TabIndex = 7;
            // 
            // StatusLabel
            // 
            this.StatusLabel.AutoSize = true;
            this.StatusLabel.Location = new System.Drawing.Point(617, 20);
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Size = new System.Drawing.Size(98, 25);
            this.StatusLabel.TabIndex = 8;
            this.StatusLabel.Text = "Staus OK";
            // 
            // Info1
            // 
            this.Info1.AutoSize = true;
            this.Info1.Location = new System.Drawing.Point(334, 607);
            this.Info1.Name = "Info1";
            this.Info1.Size = new System.Drawing.Size(134, 25);
            this.Info1.TabIndex = 9;
            this.Info1.Text = "Spaltenname:";
            // 
            // LabelSolution
            // 
            this.LabelSolution.AutoSize = true;
            this.LabelSolution.Location = new System.Drawing.Point(681, 633);
            this.LabelSolution.Name = "LabelSolution";
            this.LabelSolution.Size = new System.Drawing.Size(0, 25);
            this.LabelSolution.TabIndex = 10;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1371, 750);
            this.Controls.Add(this.LabelSolution);
            this.Controls.Add(this.Info1);
            this.Controls.Add(this.StatusLabel);
            this.Controls.Add(this.TBColl);
            this.Controls.Add(this.BTNoptimize);
            this.Controls.Add(this.BTNaddCol);
            this.Controls.Add(this.BTNdelCol);
            this.Controls.Add(this.Outputgrid);
            this.Controls.Add(this.InputGrid);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.InputGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Outputgrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DataGridView InputGrid;
        private DataGridView Outputgrid;
        private Button BTNdelCol;
        private Button BTNaddCol;
        private Button BTNoptimize;
        private TextBox TBColl;
        private DataGridViewTextBoxColumn Fabriken;
        private DataGridViewTextBoxColumn Vorräte;
        private Label StatusLabel;
        private Label Info1;
        private Label LabelSolution;
    }
}