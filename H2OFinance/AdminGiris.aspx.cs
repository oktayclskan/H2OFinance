using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccessLayer;


namespace H2OFinance
{
    public partial class AdminGiris : System.Web.UI.Page
    {
        DataModel dm =new DataModel();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tb_mail.Text) && !string.IsNullOrEmpty(Tb_sifre.Text))
            {
                Yoneticiler y =dm.YoneticiGiris(tb_mail.Text,Tb_sifre.Text);
                if (y !=null)
                {
                    Session["yönetici"] = y;
                    Response.Redirect("HomePage.aspx");
                }

            }
            else
            {

            }
        }

        protected void lbtnGiris_Click(object sender, EventArgs e)
        {

        }
    }
}