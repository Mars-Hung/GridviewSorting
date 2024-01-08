# GridviewSorting
Enhance the ease of sorting in the C# webform GridView.
> ===========project=========
> 1. add nuget package System.Linq.Dynamic

> ===========index.aspx======
> 1. using GridviewSorting.Extensions;
> 2. gvMain.DataBind&lt;Employee&gt;();
> 3. gvMain.CustomSorting(e);
