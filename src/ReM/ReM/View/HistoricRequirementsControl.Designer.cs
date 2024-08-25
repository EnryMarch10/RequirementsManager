namespace ReM.View;

partial class HistoricRequirementsControl
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

    #region Component Designer generated code

    /// <summary> 
    /// Required method for Designer support - do not modify 
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        buttonRefresh = new Button();
        dataGridViewHistoricRequirements = new DataGridView();
        ((System.ComponentModel.ISupportInitialize)dataGridViewHistoricRequirements).BeginInit();
        SuspendLayout();
        // 
        // buttonRefresh
        // 
        buttonRefresh.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
        buttonRefresh.Location = new Point(3, 474);
        buttonRefresh.Name = "buttonRefresh";
        buttonRefresh.Size = new Size(75, 23);
        buttonRefresh.TabIndex = 15;
        buttonRefresh.Text = "Refresh";
        buttonRefresh.UseVisualStyleBackColor = true;
        buttonRefresh.Click += ButtonRefresh_Click;
        // 
        // dataGridViewHistoricRequirements
        // 
        dataGridViewHistoricRequirements.AllowUserToDeleteRows = false;
        dataGridViewHistoricRequirements.AllowUserToOrderColumns = true;
        dataGridViewHistoricRequirements.AllowUserToResizeColumns = false;
        dataGridViewHistoricRequirements.AllowUserToResizeRows = false;
        dataGridViewHistoricRequirements.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        dataGridViewHistoricRequirements.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        dataGridViewHistoricRequirements.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dataGridViewHistoricRequirements.Location = new Point(0, 0);
        dataGridViewHistoricRequirements.MultiSelect = false;
        dataGridViewHistoricRequirements.Name = "dataGridViewHistoricRequirements";
        dataGridViewHistoricRequirements.ReadOnly = true;
        dataGridViewHistoricRequirements.RowHeadersVisible = false;
        dataGridViewHistoricRequirements.Size = new Size(900, 468);
        dataGridViewHistoricRequirements.TabIndex = 14;
        // 
        // HistoricRequirementsControl
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        Controls.Add(buttonRefresh);
        Controls.Add(dataGridViewHistoricRequirements);
        Name = "HistoricRequirementsControl";
        Size = new Size(900, 500);
        ((System.ComponentModel.ISupportInitialize)dataGridViewHistoricRequirements).EndInit();
        ResumeLayout(false);
    }

    #endregion

    private Button buttonRefresh;
    private DataGridView dataGridViewHistoricRequirements;
}
