using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccessLayer;
using System.IO;

namespace H2OFinance
{
    public partial class KriptoDuzenle : System.Web.UI.Page
    {
        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString.Count != 0)
            {
                if (!IsPostBack)
                {
                    int id = Convert.ToInt32(Request.QueryString["cid"]);
                    Coinler c = dm.CoinGetir(id);
                    kriptoIsim.Text = c.Isim;
                    kriptoNick.Text = c.CoinNick;
                    tb_MaxArz.Text = c.Max_Arz.ToString();
                }
            }
            else
            {
                Response.Redirect("CoinDelist.aspx");
            }
        }

        protected void lbtn_Guncelle_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(Request.QueryString["cid"]);
            Coinler c = dm.CoinGetir(id);
            c.Isim = kriptoIsim.Text;
            c.CoinNick = kriptoNick.Text;
            c.Max_Arz = Convert.ToInt32(tb_MaxArz.Text);

            if (fu_resim.HasFile)
            {
                FileInfo fi = new FileInfo(fu_resim.FileName);
                if (fi.Extension == ".jpg" || fi.Extension == ".png")
                {
                    string uzanti = fi.Extension;
                    string isim = Guid.NewGuid().ToString();
                    c.Resim = isim + uzanti;
                    fu_resim.SaveAs(Server.MapPath("~/AdminPanel/images/NFTCoinImg/" + isim + uzanti));
                }

                else
                {
                    pnl_basarisiz.Visible = true;
                    pnl_basarili.Visible = false;
                    lbl_mesaj.Text = "Resim uzantısı sadece .jpg veya .png olmalıdır";
                }
            }
            if (dm.CoinGuncelle(c))
            {
                pnl_basarisiz.Visible = false;
                pnl_basarili.Visible = true;
                lbl_mesaj.Text = "Coin Güncelleme işlemi başarılı";

            }
            else
            {
                pnl_basarisiz.Visible = true;
                pnl_basarili.Visible = false;
                lbl_mesaj.Text = "Coin Güncelleme işlemi başarısız";
            }

        }
    }
}