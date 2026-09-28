using System.ComponentModel;

namespace TechZone.UI.Components;

partial class DataTable
{
    private IContainer components = null!;

    private Panel tablePanel;
    private DataGridView dataGridView;

    protected override void Dispose(bool disposing)
    {
        if (disposing && components != null)
            components.Dispose();

        base.Dispose(disposing);
    }

    #region Component Designer generated code

    private void InitializeComponent()
    {
        tablePanel = new Panel();
        dataGridView = new DataGridView();

        ((ISupportInitialize)dataGridView).BeginInit();
        SuspendLayout();

        // tablePanel
        tablePanel.BackColor = Color.WhiteSmoke;
        tablePanel.Dock = DockStyle.Fill;
        tablePanel.Margin = new Padding(0);
        tablePanel.Name = "tablePanel";
        tablePanel.Padding = new Padding(1);
        tablePanel.TabIndex = 0;

        // dataGridView
        dataGridView.AllowUserToAddRows = false;
        dataGridView.AllowUserToDeleteRows = false;
        dataGridView.AllowUserToResizeColumns = false;
        dataGridView.AllowUserToResizeRows = false;
        dataGridView.AutoGenerateColumns = false;
        dataGridView.AutoSizeColumnsMode =
            DataGridViewAutoSizeColumnsMode.None;

        dataGridView.BackgroundColor = Color.WhiteSmoke;
        dataGridView.BorderStyle = BorderStyle.None;
        dataGridView.CellBorderStyle =
            DataGridViewCellBorderStyle.SingleHorizontal;

        dataGridView.ColumnHeadersBorderStyle =
            DataGridViewHeaderBorderStyle.None;

        dataGridView.ColumnHeadersHeight = 44;
        dataGridView.ColumnHeadersHeightSizeMode =
            DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

        dataGridView.Dock = DockStyle.Fill;
        dataGridView.EnableHeadersVisualStyles = false;
        dataGridView.ForeColor =
            Color.FromArgb(51, 65, 85);

        dataGridView.GridColor = Color.Gainsboro;
        dataGridView.Margin = new Padding(0);
        dataGridView.MultiSelect = false;
        dataGridView.Name = "dataGridView";
        dataGridView.ReadOnly = true;
        dataGridView.RowHeadersVisible = false;
        dataGridView.RowTemplate.Height = 44;

        dataGridView.SelectionMode =
            DataGridViewSelectionMode.FullRowSelect;

        dataGridView.TabIndex = 0;

        // Column Headers
        dataGridView.ColumnHeadersDefaultCellStyle =
            new DataGridViewCellStyle
            {
                Alignment =
                    DataGridViewContentAlignment.MiddleLeft,

                BackColor = Color.White,

                ForeColor =
                    Color.FromArgb(30, 41, 59),

                Font =
                    new Font(
                        "Segoe UI Variable",
                        9.5F,
                        FontStyle.Regular),

                Padding = new Padding(12, 0, 12, 0),

                SelectionBackColor = Color.White,

                SelectionForeColor =
                    Color.FromArgb(30, 41, 59),

                WrapMode =
                    DataGridViewTriState.False
            };

        // Data Cells
        dataGridView.DefaultCellStyle =
            new DataGridViewCellStyle
            {
                Alignment =
                    DataGridViewContentAlignment.MiddleLeft,

                BackColor = Color.White,

                ForeColor =
                    Color.FromArgb(51, 65, 85),

                Font =
                    new Font(
                        "Segoe UI Variable Text",
                        9.5F),

                Padding = new Padding(12, 0, 12, 0),

                SelectionBackColor =
                    Color.FromArgb(235, 247, 255),

                SelectionForeColor =
                    Color.FromArgb(15, 23, 42),

                WrapMode =
                    DataGridViewTriState.False
            };

        dataGridView.AlternatingRowsDefaultCellStyle =
            new DataGridViewCellStyle
            {
                BackColor = Color.White
            };

        // Controls
        tablePanel.Controls.Add(dataGridView);
        Controls.Add(tablePanel);

        // DataTable
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.White;
        Margin = new Padding(0);
        Name = "DataTable";
        Size = new Size(800, 500);

        ((ISupportInitialize)dataGridView).EndInit();
        ResumeLayout(false);
    }

    #endregion
}