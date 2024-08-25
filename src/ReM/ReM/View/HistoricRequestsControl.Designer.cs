namespace ReM.View;

partial class HistoricRequestsControl
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
        dataGridViewHistoricRequests = new DataGridView();
        buttonRefresh = new Button();
        ((System.ComponentModel.ISupportInitialize)dataGridViewHistoricRequests).BeginInit();
        SuspendLayout();
        // 
        // dataGridViewHistoricRequests
        // 
        dataGridViewHistoricRequests.AllowUserToDeleteRows = false;
        dataGridViewHistoricRequests.AllowUserToOrderColumns = true;
        dataGridViewHistoricRequests.AllowUserToResizeColumns = false;
        dataGridViewHistoricRequests.AllowUserToResizeRows = false;
        dataGridViewHistoricRequests.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        dataGridViewHistoricRequests.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        dataGridViewHistoricRequests.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dataGridViewHistoricRequests.Location = new Point(0, 0);
        dataGridViewHistoricRequests.MultiSelect = false;
        dataGridViewHistoricRequests.Name = "dataGridViewHistoricRequests";
        dataGridViewHistoricRequests.ReadOnly = true;
        dataGridViewHistoricRequests.RowHeadersVisible = false;
        dataGridViewHistoricRequests.Size = new Size(900, 470);
        dataGridViewHistoricRequests.TabIndex = 11;
        // 
        // buttonRefresh
        // 
        buttonRefresh.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
        buttonRefresh.Location = new Point(3, 476);
        buttonRefresh.Name = "buttonRefresh";
        buttonRefresh.Size = new Size(75, 23);
        buttonRefresh.TabIndex = 13;
        buttonRefresh.Text = "Refresh";
        buttonRefresh.UseVisualStyleBackColor = true;
        buttonRefresh.Click += ButtonRefresh_Click;
        // 
        // HistoricRequestsControl
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        Controls.Add(buttonRefresh);
        Controls.Add(dataGridViewHistoricRequests);
        Name = "HistoricRequestsControl";
        Size = new Size(900, 500);
        ((System.ComponentModel.ISupportInitialize)dataGridViewHistoricRequests).EndInit();
        ResumeLayout(false);
    }

    #endregion

    private DataGridView dataGridViewHistoricRequests;
    private Button buttonRefresh;
}
