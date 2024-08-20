namespace ReM.View;

public partial class RequestsControl
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
        dataGridViewRequests = new DataGridView();
        ColumnRequestId = new DataGridViewTextBoxColumn();
        ColumnTitle = new DataGridViewTextBoxColumn();
        ColumnDescription = new DataGridViewTextBoxColumn();
        ColumnBody = new DataGridViewTextBoxColumn();
        ColumnType = new DataGridViewTextBoxColumn();
        ColumnIsActive = new DataGridViewTextBoxColumn();
        ColumnUserIdCreation = new DataGridViewTextBoxColumn();
        ColumnTimeCreation = new DataGridViewTextBoxColumn();
        ColumnUserIdEditing = new DataGridViewTextBoxColumn();
        ColumnTimeEditing = new DataGridViewTextBoxColumn();
        ColumnUserIdApproval = new DataGridViewTextBoxColumn();
        ColumnTimeApproval = new DataGridViewTextBoxColumn();
        ((System.ComponentModel.ISupportInitialize)dataGridViewRequests).BeginInit();
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
        // dataGridViewRequests
        // 
        dataGridViewRequests.AllowUserToDeleteRows = false;
        dataGridViewRequests.AllowUserToOrderColumns = true;
        dataGridViewRequests.AllowUserToResizeColumns = false;
        dataGridViewRequests.AllowUserToResizeRows = false;
        dataGridViewRequests.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        dataGridViewRequests.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        dataGridViewRequests.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dataGridViewRequests.Columns.AddRange(new DataGridViewColumn[] { ColumnRequestId, ColumnTitle, ColumnDescription, ColumnBody, ColumnType, ColumnIsActive, ColumnUserIdCreation, ColumnTimeCreation, ColumnUserIdEditing, ColumnTimeEditing, ColumnUserIdApproval, ColumnTimeApproval });
        dataGridViewRequests.Location = new Point(0, 0);
        dataGridViewRequests.MultiSelect = false;
        dataGridViewRequests.Name = "dataGridViewRequests";
        dataGridViewRequests.Size = new Size(900, 468);
        dataGridViewRequests.TabIndex = 7;
        dataGridViewRequests.CellValueChanged += DataGridViewRequests_CellValueChanged;
        // 
        // ColumnRequestId
        // 
        ColumnRequestId.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
        ColumnRequestId.HeaderText = "RequestId";
        ColumnRequestId.Name = "ColumnRequestId";
        ColumnRequestId.ReadOnly = true;
        ColumnRequestId.Width = 84;
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
        ColumnUserIdEditing.HeaderText = "UserIdEditing";
        ColumnUserIdEditing.Name = "ColumnUserIdEditing";
        ColumnUserIdEditing.Width = 102;
        // 
        // ColumnTimeEditing
        // 
        ColumnTimeEditing.HeaderText = "TimeEditing";
        ColumnTimeEditing.Name = "ColumnTimeEditing";
        ColumnTimeEditing.ReadOnly = true;
        ColumnTimeEditing.Width = 95;
        // 
        // ColumnUserIdApproval
        // 
        ColumnUserIdApproval.HeaderText = "UserIdApproval";
        ColumnUserIdApproval.Name = "ColumnUserIdApproval";
        ColumnUserIdApproval.Width = 113;
        // 
        // ColumnTimeApproval
        // 
        ColumnTimeApproval.HeaderText = "TimeApproval";
        ColumnTimeApproval.Name = "ColumnTimeApproval";
        ColumnTimeApproval.Width = 106;
        // 
        // RequestsControl
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        Controls.Add(buttonDelete);
        Controls.Add(buttonRefresh);
        Controls.Add(buttonUpdate);
        Controls.Add(dataGridViewRequests);
        Name = "RequestsControl";
        Size = new Size(900, 500);
        Load += Requests_Load;
        ((System.ComponentModel.ISupportInitialize)dataGridViewRequests).EndInit();
        ResumeLayout(false);
    }

    #endregion

    private Button buttonDelete;
    private Button buttonRefresh;
    private Button buttonUpdate;
    private DataGridView dataGridViewRequests;
    private DataGridViewTextBoxColumn ColumnRequestId;
    private DataGridViewTextBoxColumn ColumnTitle;
    private DataGridViewTextBoxColumn ColumnDescription;
    private DataGridViewTextBoxColumn ColumnBody;
    private DataGridViewTextBoxColumn ColumnType;
    private DataGridViewTextBoxColumn ColumnIsActive;
    private DataGridViewTextBoxColumn ColumnUserIdCreation;
    private DataGridViewTextBoxColumn ColumnTimeCreation;
    private DataGridViewTextBoxColumn ColumnUserIdEditing;
    private DataGridViewTextBoxColumn ColumnTimeEditing;
    private DataGridViewTextBoxColumn ColumnUserIdApproval;
    private DataGridViewTextBoxColumn ColumnTimeApproval;
}
