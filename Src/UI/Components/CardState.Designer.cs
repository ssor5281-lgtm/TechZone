using System.ComponentModel;

namespace TechZone.UI.Components;

partial class CardState
{
    /// <summary> 
    /// Required designer variable.
    /// </summary>
    private IContainer components = null;

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

    #region Component Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        nameState = new System.Windows.Forms.Label();
        stateValue = new System.Windows.Forms.Label();
        SuspendLayout();
        // 
        // nameState
        // 
        nameState.BackColor = System.Drawing.Color.Transparent;
        nameState.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        nameState.Font = new System.Drawing.Font("Bahnschrift", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
        nameState.Location = new System.Drawing.Point(0, 16);
        nameState.Name = "nameState";
        nameState.Size = new System.Drawing.Size(150, 23);
        nameState.TabIndex = 0;
        nameState.Text = "Title";
        nameState.TextAlign = System.Drawing.ContentAlignment.TopCenter;
        // 
        // stateValue
        // 
        stateValue.BackColor = System.Drawing.Color.Transparent;
        stateValue.Font = new System.Drawing.Font("Bahnschrift", 19.800001F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
        stateValue.Location = new System.Drawing.Point(0, 43);
        stateValue.Name = "stateValue";
        stateValue.Size = new System.Drawing.Size(150, 45);
        stateValue.TabIndex = 1;
        stateValue.Text = "value";
        stateValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // CardState
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        BackgroundImage = global::TechZone.Resources.cardState;
        BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
        Controls.Add(stateValue);
        Controls.Add(nameState);
        DoubleBuffered = true;
        Size = new System.Drawing.Size(150, 100);
        ResumeLayout(false);
    }

    private System.Windows.Forms.Label nameState;

    private System.Windows.Forms.Label stateValue;

    #endregion
}