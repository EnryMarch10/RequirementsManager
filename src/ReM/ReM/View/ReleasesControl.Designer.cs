namespace ReM.View;

partial class ReleasesControl
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
        buttonUpdate = new Button();
        dataGridViewReleases = new DataGridView();
        buttonDelete = new Button();
        ColumnReleaseName = new DataGridViewTextBoxColumn();
        ColumnDescription = new DataGridViewTextBoxColumn();
        ColumnTimeCreation = new DataGridViewTextBoxColumn();
        ColumnNumRequests = new DataGridViewTextBoxColumn();
        ColumnNumRequirements = new DataGridViewTextBoxColumn();
        ColumnUserIdCreation = new DataGridViewTextBoxColumn();
        ((System.ComponentModel.ISupportInitialize)dataGridViewReleases).BeginInit();
        SuspendLayout();
        // 
        // buttonRefresh
        // 
        buttonRefresh.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
        buttonRefresh.Location = new Point(3, 474);
        buttonRefresh.Name = "buttonRefresh";
        buttonRefresh.Size = new Size(75, 23);
        buttonRefresh.TabIndex = 5;
        buttonRefresh.Text = "Refresh";
        buttonRefresh.UseVisualStyleBackColor = true;
        buttonRefresh.Click += ButtonRefresh_Click;
        // 
        // buttonUpdate
        // 
        buttonUpdate.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
        buttonUpdate.Location = new Point(822, 474);
        buttonUpdate.Name = "buttonUpdate";
        buttonUpdate.Size = new Size(75, 23);
        buttonUpdate.TabIndex = 4;
        buttonUpdate.Text = "Update";
        buttonUpdate.UseVisualStyleBackColor = true;
        buttonUpdate.Click += ButtonUpdate_Click;
        // 
        // dataGridViewReleases
        // 
        dataGridViewReleases.AllowUserToDeleteRows = false;
        dataGridViewReleases.AllowUserToOrderColumns = true;
        dataGridViewReleases.AllowUserToResizeColumns = false;
        dataGridViewReleases.AllowUserToResizeRows = false;
        dataGridViewReleases.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        dataGridViewReleases.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        dataGridViewReleases.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dataGridViewReleases.Columns.AddRange(new DataGridViewColumn[] { ColumnReleaseName, ColumnDescription, ColumnTimeCreation, ColumnNumRequests, ColumnNumRequirements, ColumnUserIdCreation });
        dataGridViewReleases.Location = new Point(0, 0);
        dataGridViewReleases.MultiSelect = false;
        dataGridViewReleases.Name = "dataGridViewReleases";
        dataGridViewReleases.Size = new Size(900, 468);
        dataGridViewReleases.TabIndex = 3;
        dataGridViewReleases.CellValueChanged += DataGridViewUsers_CellValueChanged;
        // 
        // buttonDelete
        // 
        buttonDelete.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
        buttonDelete.Location = new Point(741, 474);
        buttonDelete.Name = "buttonDelete";
        buttonDelete.Size = new Size(75, 23);
        buttonDelete.TabIndex = 6;
        buttonDelete.Text = "Delete";
        buttonDelete.UseVisualStyleBackColor = true;
        buttonDelete.Click += ButtonDelete_Click;
        // 
        // ColumnReleaseName
        // 
        ColumnReleaseName.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        ColumnReleaseName.HeaderText = "ReleaseName";
        ColumnReleaseName.Name = "ColumnReleaseName";
        // 
        // ColumnDescription
        // 
        ColumnDescription.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        ColumnDescription.HeaderText = "Description";
        ColumnDescription.MinimumWidth = 100;
        ColumnDescription.Name = "ColumnDescription";
        // 
        // ColumnTimeCreation
        // 
        ColumnTimeCreation.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
        ColumnTimeCreation.HeaderText = "TimeCreation";
        ColumnTimeCreation.Name = "ColumnTimeCreation";
        ColumnTimeCreation.ReadOnly = true;
        ColumnTimeCreation.Width = 103;
        // 
        // ColumnNumRequests
        // 
        ColumnNumRequests.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
        ColumnNumRequests.HeaderText = "NumRequests";
        ColumnNumRequests.Name = "ColumnNumRequests";
        ColumnNumRequests.ReadOnly = true;
        ColumnNumRequests.Width = 106;
        // 
        // ColumnNumRequirements
        // 
        ColumnNumRequirements.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
        ColumnNumRequirements.HeaderText = "NumRequirements";
        ColumnNumRequirements.Name = "ColumnNumRequirements";
        ColumnNumRequirements.ReadOnly = true;
        ColumnNumRequirements.Width = 132;
        // 
        // ColumnUserIdCreation
        // 
        ColumnUserIdCreation.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
        ColumnUserIdCreation.HeaderText = "UserIdCreation";
        ColumnUserIdCreation.Name = "ColumnUserIdCreation";
        ColumnUserIdCreation.Width = 110;
        // 
        // ReleasesControl
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        Controls.Add(buttonDelete);
        Controls.Add(buttonRefresh);
        Controls.Add(buttonUpdate);
        Controls.Add(dataGridViewReleases);
        Name = "ReleasesControl";
        Size = new Size(900, 500);
        Load += Releases_Load;
        ((System.ComponentModel.ISupportInitialize)dataGridViewReleases).EndInit();
        ResumeLayout(false);
    }

    #endregion

    private Button buttonRefresh;
    private Button buttonUpdate;
    private DataGridView dataGridViewReleases;
    private Button buttonDelete;
    private DataGridViewTextBoxColumn ColumnReleaseName;
    private DataGridViewTextBoxColumn ColumnDescription;
    private DataGridViewTextBoxColumn ColumnTimeCreation;
    private DataGridViewTextBoxColumn ColumnNumRequests;
    private DataGridViewTextBoxColumn ColumnNumRequirements;
    private DataGridViewTextBoxColumn ColumnUserIdCreation;
}
