namespace ReM.View;

partial class RequirementsControl
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
        buttonDelete = new Button();
        buttonRefresh = new Button();
        buttonUpdate = new Button();
        dataGridViewRequirements = new DataGridView();
        ColumnRequirementId = new DataGridViewTextBoxColumn();
        ColumnTitle = new DataGridViewTextBoxColumn();
        ColumnDescription = new DataGridViewTextBoxColumn();
        ColumnBody = new DataGridViewTextBoxColumn();
        ColumnType = new DataGridViewTextBoxColumn();
        ColumnIsActive = new DataGridViewTextBoxColumn();
        ColumnUserIdCreation = new DataGridViewTextBoxColumn();
        ColumnTimeCreation = new DataGridViewTextBoxColumn();
        ColumnUserIdEditing = new DataGridViewTextBoxColumn();
        ColumnTimeEditing = new DataGridViewTextBoxColumn();
        ColumnProgressPercentage = new DataGridViewTextBoxColumn();
        ColumnEstimatedHours = new DataGridViewTextBoxColumn();
        ColumnTakenHours = new DataGridViewTextBoxColumn();
        ColumnRequestId = new DataGridViewTextBoxColumn();
        ColumnParentRequirementId = new DataGridViewTextBoxColumn();
        ((System.ComponentModel.ISupportInitialize)dataGridViewRequirements).BeginInit();
        SuspendLayout();
        // 
        // buttonDelete
        // 
        buttonDelete.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
        buttonDelete.Location = new Point(741, 474);
        buttonDelete.Name = "buttonDelete";
        buttonDelete.Size = new Size(75, 23);
        buttonDelete.TabIndex = 10;
        buttonDelete.Text = "Delete";
        buttonDelete.UseVisualStyleBackColor = true;
        buttonDelete.Click += ButtonDelete_Click;
        // 
        // buttonRefresh
        // 
        buttonRefresh.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
        buttonRefresh.Location = new Point(3, 474);
        buttonRefresh.Name = "buttonRefresh";
        buttonRefresh.Size = new Size(75, 23);
        buttonRefresh.TabIndex = 9;
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
        buttonUpdate.TabIndex = 8;
        buttonUpdate.Text = "Update";
        buttonUpdate.UseVisualStyleBackColor = true;
        buttonUpdate.Click += ButtonUpdate_Click;
        // 
        // dataGridViewRequirements
        // 
        dataGridViewRequirements.AllowUserToDeleteRows = false;
        dataGridViewRequirements.AllowUserToOrderColumns = true;
        dataGridViewRequirements.AllowUserToResizeColumns = false;
        dataGridViewRequirements.AllowUserToResizeRows = false;
        dataGridViewRequirements.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        dataGridViewRequirements.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        dataGridViewRequirements.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dataGridViewRequirements.Columns.AddRange(new DataGridViewColumn[] { ColumnRequirementId, ColumnTitle, ColumnDescription, ColumnBody, ColumnType, ColumnIsActive, ColumnUserIdCreation, ColumnTimeCreation, ColumnUserIdEditing, ColumnTimeEditing, ColumnProgressPercentage, ColumnEstimatedHours, ColumnTakenHours, ColumnRequestId, ColumnParentRequirementId });
        dataGridViewRequirements.Location = new Point(0, 0);
        dataGridViewRequirements.MultiSelect = false;
        dataGridViewRequirements.Name = "dataGridViewRequirements";
        dataGridViewRequirements.Size = new Size(900, 468);
        dataGridViewRequirements.TabIndex = 7;
        dataGridViewRequirements.CellValueChanged += DataGridViewRequests_CellValueChanged;
        // 
        // ColumnRequirementId
        // 
        ColumnRequirementId.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
        ColumnRequirementId.HeaderText = "RequirementId";
        ColumnRequirementId.Name = "ColumnRequirementId";
        ColumnRequirementId.ReadOnly = true;
        ColumnRequirementId.Width = 110;
        // 
        // ColumnTitle
        // 
        ColumnTitle.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        ColumnTitle.HeaderText = "Title";
        ColumnTitle.MinimumWidth = 100;
        ColumnTitle.Name = "ColumnTitle";
        // 
        // ColumnDescription
        // 
        ColumnDescription.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
        ColumnDescription.HeaderText = "Description";
        ColumnDescription.Name = "ColumnDescription";
        ColumnDescription.Width = 92;
        // 
        // ColumnBody
        // 
        ColumnBody.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
        ColumnBody.HeaderText = "Body";
        ColumnBody.Name = "ColumnBody";
        ColumnBody.ReadOnly = true;
        ColumnBody.Width = 59;
        // 
        // ColumnType
        // 
        ColumnType.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
        ColumnType.HeaderText = "Type";
        ColumnType.Name = "ColumnType";
        ColumnType.Width = 56;
        // 
        // ColumnIsActive
        // 
        ColumnIsActive.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
        ColumnIsActive.HeaderText = "IsActive";
        ColumnIsActive.Name = "ColumnIsActive";
        ColumnIsActive.Width = 73;
        // 
        // ColumnUserIdCreation
        // 
        ColumnUserIdCreation.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
        ColumnUserIdCreation.HeaderText = "UserIdCreation";
        ColumnUserIdCreation.Name = "ColumnUserIdCreation";
        ColumnUserIdCreation.Width = 110;
        // 
        // ColumnTimeCreation
        // 
        ColumnTimeCreation.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
        ColumnTimeCreation.HeaderText = "TimeCreation";
        ColumnTimeCreation.Name = "ColumnTimeCreation";
        ColumnTimeCreation.ReadOnly = true;
        ColumnTimeCreation.Width = 103;
        // 
        // ColumnUserIdEditing
        // 
        ColumnUserIdEditing.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
        ColumnUserIdEditing.HeaderText = "UserIdEditing";
        ColumnUserIdEditing.Name = "ColumnUserIdEditing";
        ColumnUserIdEditing.Width = 102;
        // 
        // ColumnTimeEditing
        // 
        ColumnTimeEditing.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
        ColumnTimeEditing.HeaderText = "TimeEditing";
        ColumnTimeEditing.Name = "ColumnTimeEditing";
        ColumnTimeEditing.ReadOnly = true;
        ColumnTimeEditing.Width = 95;
        // 
        // ColumnProgressPercentage
        // 
        ColumnProgressPercentage.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
        ColumnProgressPercentage.HeaderText = "ProgressPercentage";
        ColumnProgressPercentage.Name = "ColumnProgressPercentage";
        ColumnProgressPercentage.Width = 136;
        // 
        // ColumnEstimatedHours
        // 
        ColumnEstimatedHours.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
        ColumnEstimatedHours.HeaderText = "EstimatedHours";
        ColumnEstimatedHours.Name = "ColumnEstimatedHours";
        ColumnEstimatedHours.Width = 116;
        // 
        // ColumnTakenHours
        // 
        ColumnTakenHours.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
        ColumnTakenHours.HeaderText = "TakenHours";
        ColumnTakenHours.Name = "ColumnTakenHours";
        ColumnTakenHours.Width = 94;
        // 
        // ColumnRequestId
        // 
        ColumnRequestId.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
        ColumnRequestId.HeaderText = "RequestId";
        ColumnRequestId.Name = "ColumnRequestId";
        ColumnRequestId.Width = 84;
        // 
        // ColumnParentRequirementId
        // 
        ColumnParentRequirementId.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
        ColumnParentRequirementId.HeaderText = "ParentRequirementId";
        ColumnParentRequirementId.Name = "ColumnParentRequirementId";
        ColumnParentRequirementId.Width = 144;
        // 
        // RequirementsControl
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        Controls.Add(buttonDelete);
        Controls.Add(buttonRefresh);
        Controls.Add(buttonUpdate);
        Controls.Add(dataGridViewRequirements);
        Name = "RequirementsControl";
        Size = new Size(900, 500);
        Load += Requirements_Load;
        ((System.ComponentModel.ISupportInitialize)dataGridViewRequirements).EndInit();
        ResumeLayout(false);
    }

    #endregion

    private Button buttonDelete;
    private Button buttonRefresh;
    private Button buttonUpdate;
    private DataGridView dataGridViewRequirements;
    private DataGridViewTextBoxColumn ColumnRequirementId;
    private DataGridViewTextBoxColumn ColumnTitle;
    private DataGridViewTextBoxColumn ColumnDescription;
    private DataGridViewTextBoxColumn ColumnBody;
    private DataGridViewTextBoxColumn ColumnType;
    private DataGridViewTextBoxColumn ColumnIsActive;
    private DataGridViewTextBoxColumn ColumnUserIdCreation;
    private DataGridViewTextBoxColumn ColumnTimeCreation;
    private DataGridViewTextBoxColumn ColumnUserIdEditing;
    private DataGridViewTextBoxColumn ColumnTimeEditing;
    private DataGridViewTextBoxColumn ColumnProgressPercentage;
    private DataGridViewTextBoxColumn ColumnEstimatedHours;
    private DataGridViewTextBoxColumn ColumnTakenHours;
    private DataGridViewTextBoxColumn ColumnRequestId;
    private DataGridViewTextBoxColumn ColumnParentRequirementId;
}
