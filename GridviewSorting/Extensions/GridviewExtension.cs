using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using System.Linq.Dynamic;// install "System.Linq.Dynamic 1.08" package from nuget.
namespace GridviewSorting.Extensions
{
    public static class GridviewExtension 
    {
        public static void DataBind<T>(this GridView gv)
        {
            string sortExpression = gv.Attributes["SortExpression"];
            string sortDirection = gv.Attributes["SortDirection"];
            if (!string.IsNullOrEmpty(sortExpression) && !string.IsNullOrEmpty(sortDirection))
            {
                if (gv.DataSource is IEnumerable<T> dataSource)
                {
                    var result = dataSource.AsQueryable().OrderBy(sortExpression + " " + sortDirection);//using System.Linq.Dynamic to enable OrderBy()
                    gv.DataSource = result.ToList();
                }
                else
                {
                    throw new InvalidOperationException($"The DataSource is not of type List<{typeof(T).Name}>.");
                }
            }
            gv.DataBind();

            #region// add icon to header
            if (gv.Rows.Count > 0 && !string.IsNullOrEmpty(sortExpression) && !string.IsNullOrEmpty(sortDirection))
            {
                //add sorting icon to Header Cell
                gv.HeaderRow.Cells.Cast<TableCell>()
                    .SelectMany(cell => cell.Controls.OfType<LinkButton>())
                    .Where(btn => btn.CommandArgument == sortExpression)
                    .ToList()
                    .ForEach(btn =>
                    {
                        btn.Text += $"<span class='sorticon {sortDirection}'>{(sortDirection == SortDirection.Ascending.ToString() ? "▲" : "▼")}</sapn>";
                    });
            }
            #endregion
        }
        public static void CustomSorting(this GridView gv, GridViewSortEventArgs e)
        {
            Enum.TryParse(gv.Attributes["SortDirection"], out SortDirection sortDirection);
            string sortExpression = gv.Attributes["SortExpression"];

            if (sortExpression == e.SortExpression)
            {
                sortDirection = sortDirection == SortDirection.Ascending ? SortDirection.Descending : SortDirection.Ascending;
            }
            else
            {
                sortDirection = SortDirection.Ascending;
            }
            // Store the current SortDirection and SortExpression in the Attributes, to be used later.
            gv.Attributes["SortDirection"] = sortDirection.ToString();
            gv.Attributes["SortExpression"] = e.SortExpression;
        }
    }
}
