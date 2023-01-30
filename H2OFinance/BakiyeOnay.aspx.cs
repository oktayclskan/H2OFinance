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
            lv_talepler.DataSource = dm.TalepListele(1);
            lv_talepler.DataBind();
        }

        protected void lv_talepler_ItemCommand(object sender, ListViewCommandEventArgs e)
        {

        }

       
    }
}