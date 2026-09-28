using System.ComponentModel;

namespace TechZone.UI.Components;

partial class TzDropdownButton
{
    private IContainer components = null!;

    protected override void Dispose(bool disposing)
    {
        if (disposing && components != null)
            components.Dispose();

        base.Dispose(disposing);
    }

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        dropdownPanel = new System.Windows.Forms.Panel();
        icon = new System.Windows.Forms.Label();
        valueLabel = new System.Windows.Forms.Label();
        dropdownPanel.SuspendLayout();
        SuspendLayout();
        // 
        // dropdownPanel
        // 
        dropdownPanel.BackColor = System.Drawing.Color.White;
        dropdownPanel.BackgroundImage = TechZone.Resources.dropdown_frame;
        dropdownPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
        dropdownPanel.Controls.Add(icon);
        dropdownPanel.Controls.Add(valueLabel);
        dropdownPanel.Location = new System.Drawing.Point(0, 0);
        dropdownPanel.Name = "dropdownPanel";
        dropdownPanel.Size = new System.Drawing.Size(175, 44);
        dropdownPanel.TabIndex = 0;
        // 
        // icon
        // 
        icon.BackColor = System.Drawing.Color.Transparent;
        icon.Cursor = System.Windows.Forms.Cursors.Hand;
        icon.Dock = System.Windows.Forms.DockStyle.Right;
        icon.Image = global::TechZone.Resources.icon_arrow_down;
        icon.Location = new System.Drawing.Point(131, 0);
        icon.Name = "icon";
        icon.Size = new System.Drawing.Size(44, 44);
        icon.TabIndex = 1;
        // 
        // valueLabel
        // 
        valueLabel.BackColor = System.Drawing.Color.Transparent;
        valueLabel.Cursor = System.Windows.Forms.Cursors.Hand;
        valueLabel.Font = new System.Drawing.Font("Bahnschrift", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
        valueLabel.ForeColor = System.Drawing.Color.Black;
        valueLabel.Location = new System.Drawing.Point(5, 14);
        valueLabel.Name = "valueLabel";
        valueLabel.Size = new System.Drawing.Size(138, 19);
        valueLabel.TabIndex = 0;
        valueLabel.Text = "value..";
        valueLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // TzDropdownButton
        // 
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
        BackColor = System.Drawing.Color.Transparent;
        Controls.Add(dropdownPanel);
        Cursor = System.Windows.Forms.Cursors.Hand;
        DoubleBuffered = true;
        Size = new System.Drawing.Size(175, 44);
        dropdownPanel.ResumeLayout(false);
        ResumeLayout(false);
    }

    private System.Windows.Forms.Panel dropdownPanel;
    private Label icon;
    private System.Windows.Forms.Label valueLabel;
}