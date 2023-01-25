using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccessLayer;

namespace H2OFinance
{
    public partial class AdminPanelMasterPage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Yönetici"]!=null)
            {
                Yoneticiler y = (Yoneticiler)Session["yönetici"];
                lb_kisiAdi.Text = $"{y.Isim} {y.Soyisim}";
            }
            else
            {
                Response.Redirect("AdminGiris.aspx");
            }
        }

        protected void lbtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminGiris.aspx");
        }
    }
}