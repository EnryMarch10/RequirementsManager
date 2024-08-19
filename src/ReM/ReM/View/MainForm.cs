namespace ReM.View;

public partial class MainForm : Form
{
    public MainForm()
    {
        InitializeComponent();
    }

    private void MainForm_Load(object sender, EventArgs e)
    {
        Users myUserControl = new()
        {
            Dock = DockStyle.Fill
        };
        tabPageUsers.Controls.Add(myUserControl);
    }
}
