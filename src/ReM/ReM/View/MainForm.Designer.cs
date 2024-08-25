namespace ReM.View;

partial class MainForm
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
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

    #region Windows Form Designer generated code

    /// <summary>
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        tabPageReleases = new TabPage();
        tabPageRequirements = new TabPage();
        tabPageRequests = new TabPage();
        tabPageUsers = new TabPage();
        tabCtrlMain = new TabControl();
        tabPageHistoricRequests = new TabPage();
        tabPageHistoricRequirements = new TabPage();
        tabPageOperations = new TabPage();
        tabCtrlMain.SuspendLayout();
        SuspendLayout();
        // 
        // tabPageReleases
        // 
        tabPageReleases.Location = new Point(4, 24);
        tabPageReleases.Name = "tabPageReleases";
        tabPageReleases.Padding = new Padding(3);
        tabPageReleases.Size = new Size(876, 433);
        tabPageReleases.TabIndex = 3;
        tabPageReleases.Text = "Releases";
        tabPageReleases.UseVisualStyleBackColor = true;
        // 
        // tabPageRequirements
        // 
        tabPageRequirements.Location = new Point(4, 24);
        tabPageRequirements.Name = "tabPageRequirements";
        tabPageRequirements.Padding = new Padding(3);
        tabPageRequirements.Size = new Size(876, 433);
        tabPageRequirements.TabIndex = 2;
        tabPageRequirements.Text = "Requirements";
        tabPageRequirements.UseVisualStyleBackColor = true;
        // 
        // tabPageRequests
        // 
        tabPageRequests.Location = new Point(4, 24);
        tabPageRequests.Name = "tabPageRequests";
        tabPageRequests.Padding = new Padding(3);
        tabPageRequests.Size = new Size(876, 433);
        tabPageRequests.TabIndex = 1;
        tabPageRequests.Text = "Requests";
        tabPageRequests.UseVisualStyleBackColor = true;
        // 
        // tabPageUsers
        // 
        tabPageUsers.Location = new Point(4, 24);
        tabPageUsers.Name = "tabPageUsers";
        tabPageUsers.Padding = new Padding(3);
        tabPageUsers.Size = new Size(876, 433);
        tabPageUsers.TabIndex = 0;
        tabPageUsers.Text = "Users";
        tabPageUsers.UseVisualStyleBackColor = true;
        // 
        // tabCtrlMain
        // 
        tabCtrlMain.Controls.Add(tabPageUsers);
        tabCtrlMain.Controls.Add(tabPageRequests);
        tabCtrlMain.Controls.Add(tabPageRequirements);
        tabCtrlMain.Controls.Add(tabPageReleases);
        tabCtrlMain.Controls.Add(tabPageHistoricRequests);
        tabCtrlMain.Controls.Add(tabPageHistoricRequirements);
        tabCtrlMain.Controls.Add(tabPageOperations);
        tabCtrlMain.Dock = DockStyle.Fill;
        tabCtrlMain.Location = new Point(0, 0);
        tabCtrlMain.Name = "tabCtrlMain";
        tabCtrlMain.SelectedIndex = 0;
        tabCtrlMain.Size = new Size(884, 461);
        tabCtrlMain.TabIndex = 0;
        // 
        // tabPageHistoricRequests
        // 
        tabPageHistoricRequests.Location = new Point(4, 24);
        tabPageHistoricRequests.Name = "tabPageHistoricRequests";
        tabPageHistoricRequests.Padding = new Padding(3);
        tabPageHistoricRequests.Size = new Size(876, 433);
        tabPageHistoricRequests.TabIndex = 4;
        tabPageHistoricRequests.Text = "Historic Requests";
        tabPageHistoricRequests.UseVisualStyleBackColor = true;
        // 
        // tabPageHistoricRequirements
        // 
        tabPageHistoricRequirements.Location = new Point(4, 24);
        tabPageHistoricRequirements.Name = "tabPageHistoricRequirements";
        tabPageHistoricRequirements.Padding = new Padding(3);
        tabPageHistoricRequirements.Size = new Size(876, 433);
        tabPageHistoricRequirements.TabIndex = 5;
        tabPageHistoricRequirements.Text = "Historic Requirements";
        tabPageHistoricRequirements.UseVisualStyleBackColor = true;
        // 
        // tabPageOperations
        // 
        tabPageOperations.Location = new Point(4, 24);
        tabPageOperations.Name = "tabPageOperations";
        tabPageOperations.Padding = new Padding(3);
        tabPageOperations.Size = new Size(876, 433);
        tabPageOperations.TabIndex = 6;
        tabPageOperations.Text = "Operations";
        tabPageOperations.UseVisualStyleBackColor = true;
        // 
        // MainForm
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(884, 461);
        Controls.Add(tabCtrlMain);
        MinimumSize = new Size(450, 250);
        Name = "MainForm";
        Text = "RequirementsManager";
        Load += MainForm_Load;
        tabCtrlMain.ResumeLayout(false);
        ResumeLayout(false);
    }

    #endregion

    private TabPage tabPageReleases;
    private TabPage tabPageRequirements;
    private TabPage tabPageRequests;
    private TabPage tabPageUsers;
    private TabControl tabCtrlMain;
    private TabPage tabPageHistoricRequests;
    private TabPage tabPageHistoricRequirements;
    private TabPage tabPageOperations;
}
