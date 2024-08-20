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
        tabCtrlMain = new TabControl();
        tabPageUsers = new TabPage();
        tabPageRequests = new TabPage();
        tabPageRequirements = new TabPage();
        tabPageReleases = new TabPage();
        tabCtrlMain.SuspendLayout();
        SuspendLayout();
        // 
        // tabCtrlMain
        // 
        tabCtrlMain.Controls.Add(tabPageUsers);
        tabCtrlMain.Controls.Add(tabPageRequests);
        tabCtrlMain.Controls.Add(tabPageRequirements);
        tabCtrlMain.Controls.Add(tabPageReleases);
        tabCtrlMain.Dock = DockStyle.Fill;
        tabCtrlMain.Location = new Point(0, 0);
        tabCtrlMain.Name = "tabCtrlMain";
        tabCtrlMain.SelectedIndex = 0;
        tabCtrlMain.Size = new Size(800, 450);
        tabCtrlMain.TabIndex = 0;
        // 
        // tabPageUsers
        // 
        tabPageUsers.Location = new Point(4, 24);
        tabPageUsers.Name = "tabPageUsers";
        tabPageUsers.Padding = new Padding(3);
        tabPageUsers.Size = new Size(792, 422);
        tabPageUsers.TabIndex = 0;
        tabPageUsers.Text = "Users";
        tabPageUsers.UseVisualStyleBackColor = true;
        // 
        // tabPageRequests
        // 
        tabPageRequests.Location = new Point(4, 24);
        tabPageRequests.Name = "tabPageRequests";
        tabPageRequests.Padding = new Padding(3);
        tabPageRequests.Size = new Size(792, 422);
        tabPageRequests.TabIndex = 1;
        tabPageRequests.Text = "Requests";
        tabPageRequests.UseVisualStyleBackColor = true;
        // 
        // tabPageRequirements
        // 
        tabPageRequirements.Location = new Point(4, 24);
        tabPageRequirements.Name = "tabPageRequirements";
        tabPageRequirements.Padding = new Padding(3);
        tabPageRequirements.Size = new Size(792, 422);
        tabPageRequirements.TabIndex = 2;
        tabPageRequirements.Text = "Requirements";
        tabPageRequirements.UseVisualStyleBackColor = true;
        // 
        // tabPageReleases
        // 
        tabPageReleases.Location = new Point(4, 24);
        tabPageReleases.Name = "tabPageReleases";
        tabPageReleases.Padding = new Padding(3);
        tabPageReleases.Size = new Size(792, 422);
        tabPageReleases.TabIndex = 3;
        tabPageReleases.Text = "Releases";
        tabPageReleases.UseVisualStyleBackColor = true;
        // 
        // MainForm
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(800, 450);
        Controls.Add(tabCtrlMain);
        Name = "MainForm";
        Text = "RequirementsManager";
        Load += MainForm_Load;
        tabCtrlMain.ResumeLayout(false);
        ResumeLayout(false);
    }

    #endregion

    private TabControl tabCtrlMain;
    private TabPage tabPageUsers;
    private TabPage tabPageRequests;
    private TabPage tabPageRequirements;
    private TabPage tabPageReleases;
}
