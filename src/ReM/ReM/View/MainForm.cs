namespace ReM.View;

public partial class MainForm : Form
{
    public MainForm()
    {
        InitializeComponent();
    }

    private void MainForm_Load(object sender, EventArgs e)
    {
        tabPageUsers.Controls.Add(new UsersControl()
            {
                Dock = DockStyle.Fill
            });
        tabPageRequests.Controls.Add(new RequestsControl()
            {
                Dock = DockStyle.Fill
            });
        tabPageRequirements.Controls.Add(new RequirementsControl()
        {
            Dock = DockStyle.Fill
        });
        tabPageReleases.Controls.Add(new ReleasesControl()
        {
            Dock = DockStyle.Fill
        });
    }
}
