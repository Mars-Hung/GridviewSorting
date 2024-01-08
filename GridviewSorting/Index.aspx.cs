using GridviewSorting.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GridviewSorting.Extensions;
namespace GridviewSorting
{
    public partial class Index : System.Web.UI.Page
    {
        char[] alpha = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
        Random rnd = new Random();
        List<Employee> Employees
        {
            set
            {
                Session["Employees" ] = value;
            }
            get
            {
                if (Session["Employees" ] == null)
                {
                    return null;
                }
                return (dynamic)Session["Employees" ];
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Employees = Enumerable.Range(0, 50).Select(a => new Employee
                {
                    ID = a,
                    Name = alpha[rnd.Next(0, alpha.Length)] + a.ToString("D3"),
                    Location = alpha[rnd.Next(0, alpha.Length)] + alpha[rnd.Next(0, alpha.Length)] + a.ToString(),
                    OnboardDate = DateTime.Now.AddDays(rnd.Next(0,100)),
                    CellPhone = "+13 " + rnd.Next(0, 1000000).ToString("D10"),
                    Phone = "+13 " + rnd.Next(0, 1000000).ToString("D10"),
                }).ToList();
                BindData();
            }
        }
        void BindData()
        {
            gvMain.DataSource = Employees;
            gvMain.DataBind<Employee>();
        }

        protected void gvMain_Sorting(object sender, GridViewSortEventArgs e)
        {
            gvMain.CustomSorting(e);
            BindData();
        }
    }
}