using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccessLayer;

namespace H2OFinance
{
    public partial class CoinDelist : System.Web.UI.Page
    {
        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            lv_coinDelist.DataSource = dm.CoinListele();
            lv_coinDelist.DataBind();
        }

        protected void lv_coinDelist_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
           

        }

        protected void lv_coinDelist_ItemCommand1(object sender, ListViewCommandEventArgs e)
        {
            int id = Convert.ToInt32(e.CommandArgument);
            dm.DeleteCoin(id);
            lv_coinDelist.DataSource = dm.CoinListele();
            lv_coinDelist.DataBind();
        }
    }
}