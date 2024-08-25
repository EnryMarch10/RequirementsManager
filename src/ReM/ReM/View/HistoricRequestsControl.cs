using Microsoft.EntityFrameworkCore;
using ReM.Models;

namespace ReM.View;

public partial class HistoricRequestsControl : UserControl
{
    public HistoricRequestsControl()
    {
        InitializeComponent();
    }

    private void ShowResults<T>(T[] queryResult, uint nLastRowsToRemove = 0)
    {
        dataGridViewHistoricRequests.DataSource = queryResult;
        for (int i = 0; i < nLastRowsToRemove; i++)
        {
            dataGridViewHistoricRequests.Columns.RemoveAt(dataGridViewHistoricRequests.Columns.Count - 1);
        }
    }

    private void ButtonRefresh_Click(object sender, EventArgs e)
    {
        HistoricRequest[] requests;
        string message;
        using (RemContext context = new())
        {
            var query = from p in context.HistoricRequests
                           select p;
            query.Load();
            requests = [.. query];
            message = query.ToString() ?? string.Empty;
        }
        ShowResults(requests, 5);
    }
}
