namespace ReM.View;

partial class OperationsControl
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
        dataGridViewOperations = new DataGridView();
        buttonViewHistory = new Button();
        buttonViewBranchProgess = new Button();
        textBoxData = new TextBox();
        ((System.ComponentModel.ISupportInitialize)dataGridViewOperations).BeginInit();
        SuspendLayout();
        // 
        // dataGridViewOperations
        // 
        dataGridViewOperations.AllowUserToDeleteRows = false;
        dataGridViewOperations.AllowUserToOrderColumns = true;
        dataGridViewOperations.AllowUserToResizeColumns = false;
        dataGridViewOperations.AllowUserToResizeRows = false;
        dataGridViewOperations.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        dataGridViewOperations.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        dataGridViewOperations.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dataGridViewOperations.Location = new Point(0, 61);
        dataGridViewOperations.MultiSelect = false;
        dataGridViewOperations.Name = "dataGridViewOperations";
        dataGridViewOperations.ReadOnly = true;
        dataGridViewOperations.RowHeadersVisible = false;
        dataGridViewOperations.Size = new Size(900, 439);
        dataGridViewOperations.TabIndex = 15;
        // 
        // buttonViewHistory
        // 
        buttonViewHistory.Location = new Point(3, 32);
        buttonViewHistory.Name = "buttonViewHistory";
        buttonViewHistory.Size = new Size(99, 23);
        buttonViewHistory.TabIndex = 16;
        buttonViewHistory.Text = "View History";
        buttonViewHistory.UseVisualStyleBackColor = true;
        buttonViewHistory.Click += ButtonViewHistory_Click;
        // 
        // buttonViewBranchProgess
        // 
        buttonViewBranchProgess.Location = new Point(108, 32);
        buttonViewBranchProgess.Name = "buttonViewBranchProgess";
        buttonViewBranchProgess.Size = new Size(144, 23);
        buttonViewBranchProgess.TabIndex = 17;
        buttonViewBranchProgess.Text = "View Branch Progess";
        buttonViewBranchProgess.UseVisualStyleBackColor = true;
        buttonViewBranchProgess.Click += ButtonViewBranchProgess_Click;
        // 
        // textBoxData
        // 
        textBoxData.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        textBoxData.Location = new Point(3, 3);
        textBoxData.Name = "textBoxData";
        textBoxData.Size = new Size(894, 23);
        textBoxData.TabIndex = 18;
        // 
        // OperationsControl
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        Controls.Add(textBoxData);
        Controls.Add(buttonViewBranchProgess);
        Controls.Add(buttonViewHistory);
        Controls.Add(dataGridViewOperations);
        Name = "OperationsControl";
        Size = new Size(900, 500);
        ((System.ComponentModel.ISupportInitialize)dataGridViewOperations).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private DataGridView dataGridViewOperations;
    private Button buttonViewHistory;
    private Button buttonViewBranchProgess;
    private TextBox textBoxData;
}
