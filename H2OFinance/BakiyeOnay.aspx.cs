using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccessLayer;

namespace H2OFinance
{
    public partial class BakiyeOnay : System.Web.UI.Page
    {

        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void lv_talepler_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            Talepler t = new Talepler();
            Yoneticiler y = (Yoneticiler)Session["yönetici"];
            if (e.CommandName == "onay")
            {
                int id = Convert.ToInt32(e.CommandArgument);
                t = dm.TalepGetir(id);
                t.YoneticiID = y.ID;
                t.OnayTarih = DateTime.Now;
                dm.talepUpdate(t);
                if (dm.BakiyeOnay(t))
                {
                    lv_bekleyen.DataSource = dm.TalepListele(1);
                    lv_bekleyen.DataBind();
                }
            }
            if (e.CommandName == "red")
            {
                int id = Convert.ToInt32(e.CommandArgument);
                dm.TalepGetir(id);
                t.YoneticiID = y.ID;
                t.OnayTarih = DateTime.Now;
                if (dm.bakiyeReddet(id))
                {
                    lv_reddedilenler.DataSource = dm.TalepListele(3);
                    lv_reddedilenler.DataBind();
                }
            }



        }

        protected void lbtn_onay_Click(object sender, EventArgs e)
        {

            lv_onaylanan.DataSource = dm.TalepListele(2);
            lv_onaylanan.DataBind();
            lv_onaylanan.Visible = true;
            lv_bekleyen.Visible = false;
            lv_reddedilenler.Visible = false;

        }

        protected void lbtn_onayBekleyen_Click(object sender, EventArgs e)
        {

            lv_bekleyen.DataSource = dm.TalepListele(1);
            lv_bekleyen.DataBind();
            lv_bekleyen.Visible = true;
            lv_onaylanan.Visible = false;
            lv_reddedilenler.Visible = false;



        }

        protected void lbtn_reddet_Click(object sender, EventArgs e)
        {

            lv_reddedilenler.DataSource = dm.TalepListele(3);
            lv_reddedilenler.DataBind();
            lv_bekleyen.Visible = false;
            lv_onaylanan.Visible = false;
            lv_reddedilenler.Visible = true;

        }
    }
}