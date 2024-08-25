using System.Data;
using Microsoft.EntityFrameworkCore;
using ReM.Models;

namespace ReM.View;
public partial class HistoricRequirementsControl : UserControl
{
    public HistoricRequirementsControl()
    {
        InitializeComponent();
    }

    private void ShowResults<T>(T[] queryResult, uint nLastRowsToRemove = 0)
    {
        dataGridViewHistoricRequirements.DataSource = queryResult;
        for (int i = 0; i < nLastRowsToRemove; i++)
        {
            dataGridViewHistoricRequirements.Columns.RemoveAt(dataGridViewHistoricRequirements.Columns.Count - 1);
        }
    }

    private void ButtonRefresh_Click(object sender, EventArgs e)
    {
        HistoricRequirement[] requests;
        using (RemContext context = new())
        {
            var query = from p in context.HistoricRequirements
                        select p;
            query.Load();
            requests = [.. query];
        }
        ShowResults(requests, 6);
    }
}
