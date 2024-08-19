namespace ReM.View;

partial class Users
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
        dataGridViewUsers = new DataGridView();
        ColumnUserId = new DataGridViewTextBoxColumn();
        ColumnUsername = new DataGridViewTextBoxColumn();
        ColumnName = new DataGridViewTextBoxColumn();
        ColumnSurname = new DataGridViewTextBoxColumn();
        ColumnEmail = new DataGridViewTextBoxColumn();
        ColumnPhone = new DataGridViewTextBoxColumn();
        ColumnCompany = new DataGridViewTextBoxColumn();
        ColumnIsEditor = new DataGridViewTextBoxColumn();
        buttonDelete = new Button();
        ((System.ComponentModel.ISupportInitialize)dataGridViewUsers).BeginInit();
        SuspendLayout();
        // 
        // buttonRefresh
        // 
        buttonRefresh.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
        buttonRefresh.Location = new Point(3, 489);
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
        buttonUpdate.Location = new Point(825, 489);
        buttonUpdate.Name = "buttonUpdate";
        buttonUpdate.Size = new Size(75, 23);
        buttonUpdate.TabIndex = 4;
        buttonUpdate.Text = "Update";
        buttonUpdate.UseVisualStyleBackColor = true;
        buttonUpdate.Click += ButtonUpdate_Click;
        // 
        // dataGridViewUsers
        // 
        dataGridViewUsers.AllowUserToDeleteRows = false;
        dataGridViewUsers.AllowUserToOrderColumns = true;
        dataGridViewUsers.AllowUserToResizeColumns = false;
        dataGridViewUsers.AllowUserToResizeRows = false;
        dataGridViewUsers.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        dataGridViewUsers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        dataGridViewUsers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dataGridViewUsers.Columns.AddRange(new DataGridViewColumn[] { ColumnUserId, ColumnUsername, ColumnName, ColumnSurname, ColumnEmail, ColumnPhone, ColumnCompany, ColumnIsEditor });
        dataGridViewUsers.Location = new Point(0, 0);
        dataGridViewUsers.MultiSelect = false;
        dataGridViewUsers.Name = "dataGridViewUsers";
        dataGridViewUsers.Size = new Size(903, 483);
        dataGridViewUsers.TabIndex = 3;
        dataGridViewUsers.CellValueChanged += DataGridViewUsers_CellValueChanged;
        // 
        // ColumnUserId
        // 
        ColumnUserId.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
        ColumnUserId.HeaderText = "UserId";
        ColumnUserId.Name = "ColumnUserId";
        ColumnUserId.ReadOnly = true;
        ColumnUserId.Width = 65;
        // 
        // ColumnUsername
        // 
        ColumnUsername.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        ColumnUsername.HeaderText = "Username";
        ColumnUsername.MinimumWidth = 100;
        ColumnUsername.Name = "ColumnUsername";
        // 
        // ColumnName
        // 
        ColumnName.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
        ColumnName.HeaderText = "Name";
        ColumnName.Name = "ColumnName";
        ColumnName.Width = 64;
        // 
        // ColumnSurname
        // 
        ColumnSurname.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
        ColumnSurname.HeaderText = "Surname";
        ColumnSurname.Name = "ColumnSurname";
        ColumnSurname.Width = 79;
        // 
        // ColumnEmail
        // 
        ColumnEmail.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
        ColumnEmail.HeaderText = "Email";
        ColumnEmail.Name = "ColumnEmail";
        ColumnEmail.Width = 61;
        // 
        // ColumnPhone
        // 
        ColumnPhone.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
        ColumnPhone.HeaderText = "Phone";
        ColumnPhone.Name = "ColumnPhone";
        ColumnPhone.Width = 66;
        // 
        // ColumnCompany
        // 
        ColumnCompany.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
        ColumnCompany.HeaderText = "Company";
        ColumnCompany.Name = "ColumnCompany";
        ColumnCompany.Width = 84;
        // 
        // ColumnIsEditor
        // 
        ColumnIsEditor.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
        ColumnIsEditor.HeaderText = "IsEditor";
        ColumnIsEditor.Name = "ColumnIsEditor";
        ColumnIsEditor.Width = 71;
        // 
        // buttonDelete
        // 
        buttonDelete.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
        buttonDelete.Location = new Point(744, 489);
        buttonDelete.Name = "buttonDelete";
        buttonDelete.Size = new Size(75, 23);
        buttonDelete.TabIndex = 6;
        buttonDelete.Text = "Delete";
        buttonDelete.UseVisualStyleBackColor = true;
        buttonDelete.Click += ButtonDelete_Click;
        // 
        // Users
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        Controls.Add(buttonDelete);
        Controls.Add(buttonRefresh);
        Controls.Add(buttonUpdate);
        Controls.Add(dataGridViewUsers);
        Name = "Users";
        Size = new Size(903, 515);
        Load += Users_Load;
        ((System.ComponentModel.ISupportInitialize)dataGridViewUsers).EndInit();
        ResumeLayout(false);
    }

    #endregion

    private Button buttonRefresh;
    private Button buttonUpdate;
    private DataGridView dataGridViewUsers;
    private DataGridViewTextBoxColumn ColumnUserId;
    private DataGridViewTextBoxColumn ColumnUsername;
    private DataGridViewTextBoxColumn ColumnName;
    private DataGridViewTextBoxColumn ColumnSurname;
    private DataGridViewTextBoxColumn ColumnEmail;
    private DataGridViewTextBoxColumn ColumnPhone;
    private DataGridViewTextBoxColumn ColumnCompany;
    private DataGridViewTextBoxColumn ColumnIsEditor;
    private Button buttonDelete;
}
