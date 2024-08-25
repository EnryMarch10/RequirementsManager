using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Asn1.Ocsp;
using ReM.Models;
using System.Windows.Forms;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace ReM.View;

public partial class OperationsControl : UserControl
{
    public OperationsControl()
    {
        InitializeComponent();
    }

    private void ShowResults<T>(T[] queryResult, uint nLastRowsToRemove = 0)
    {
        dataGridViewOperations.DataSource = queryResult;
        for (int i = 0; i < nLastRowsToRemove; i++)
        {
            dataGridViewOperations.Columns.RemoveAt(dataGridViewOperations.Columns.Count - 1);
        }
    }

    private void ButtonViewHistory_Click(object sender, EventArgs e)
    {
        var id = textBoxData.Text;
        HistoricRequirement[] requirementsVersions;

        try
        {
            using (var context = new RemContext())
            {
                var sql = @"SELECT
                        h_requirements.*
                        FROM REQUIREMENTS requirements, HISTORIC_REQUIREMENTS h_requirements
                        WHERE requirements.RequirementId = h_requirements.RequirementId AND
                              requirements.RequirementId = @id;";

                var query = context.HistoricRequirements
                    .FromSqlRaw(sql, new MySqlParameter("id", id));

                query.Load();
                requirementsVersions = [.. query];
            }
            ShowResults(requirementsVersions, 6);
        }
        catch (Exception ex)
        {
            var cause = ex.InnerException is not null ? ex.InnerException.Message : ex.Message;
            MessageBox.Show($"Error occurred.\nMessage: `{cause}`",
                    $"Operations manager",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
        }
    }

    private class RequirementsBranchData
    {
        public uint TotalProgressPercentage { get; set; }
        public float TotalEstimatedTime { get; set; }
        public float TotalTakenTime { get; set; }
    }

    private void ButtonViewBranchProgess_Click(object sender, EventArgs e)
    {
        var id = textBoxData.Text;
        RequirementsBranchData[] data;

        try
        {
            using (var context = new RemContext())
            {
                string sql = @"WITH RECURSIVE RequirementTree AS (
                                    SELECT *
                                    FROM REQUIREMENTS
                                    WHERE RequirementId = @id

                                    UNION ALL

                                    SELECT r.*
                                    FROM REQUIREMENTS r
                                    INNER JOIN RequirementTree rt ON r.ParentRequirementId = rt.RequirementId
                                )

                                SELECT
	                                SUM(progressPercentage) AS TotalProgressPercentage,
	                                SUM(estimatedHours) AS TotalEstimatedTime,
	                                SUM(takenHours) AS TotalTakenTime
                                FROM RequirementTree;";

                var query = context.Database
                    .SqlQueryRaw<RequirementsBranchData>(sql, new MySqlParameter("id", id));

                query.Load();
                data = [.. query];
            }
            ShowResults(data);
        }
        catch (Exception ex)
        {
            var cause = ex.InnerException is not null ? ex.InnerException.Message : ex.Message;
            MessageBox.Show($"Error occurred.\nMessage: `{cause}`",
                    $"Operations manager",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
        }
    }
}
