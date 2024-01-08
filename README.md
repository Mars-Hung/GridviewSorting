# GridviewSorting
Enhance the ease of sorting in the C# webform GridView.
1. add nuget package System.Linq.Dynamic
2. in index.aspx
using GridviewSorting.Extensions;
List<Employee> Employees = getdate();
gvMain.DataSource = Employees;
gvMain.DataBind<Employee>();
