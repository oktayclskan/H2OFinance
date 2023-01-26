using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccessLayer;
namespace H2OFinance
{
    public partial class KriptoEkle : System.Web.UI.Page
    {
        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void lbtn_Ekle_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(kriptoIsim.Text.Trim()))
            {
                if (dm.VeriKontrol("Coinler","Isim",kriptoIsim.Text.Trim()))
                {
                    Coinler c = new Coinler();
                    c.Isim = kriptoIsim.Text;
                    c.CoinNick = kriptoNick.Text;
                    c.MaxArz = Convert.ToInt32(tb_MaxArz.Text);
                    if (dm.CoinEkle(c))
                    {
                        pnl_basarili.Visible = true;
                        pnl_basarisiz.Visible = false;
                        kriptoIsim.Text = "";
                        kriptoNick.Text = "";
                        tb_MaxArz.Text = "";
                       
                    }
                    else
                    {
                        pnl_basarili.Visible = false;
                        pnl_basarisiz.Visible = true;
                        lbl_mesaj.Text = "Coin Eklenirken bir hata oluştu";
                    }
                }
                else
                {
                    pnl_basarili.Visible = false;
                    pnl_basarisiz.Visible = true;
                    lbl_mesaj.Text = "Coin Daha önce eklenmiş";
                }
                
            }
            else
            {
                pnl_basarili.Visible = false;
                pnl_basarisiz.Visible = true;
                lbl_mesaj.Text = "Coin adı boş bırakılamaz";
            }
        }
    }
}