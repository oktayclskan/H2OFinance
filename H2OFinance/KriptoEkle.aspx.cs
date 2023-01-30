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
                if (!string.IsNullOrEmpty(tb_MaxArz.Text.Trim()))
                {
                    if (!string.IsNullOrEmpty(tb_fiyat.Text.Trim()))
                    {
                        if (dm.CoinKontrol(kriptoIsim.Text.Trim()))
                        {
                            Coinler c = new Coinler();
                            c.Isim = kriptoIsim.Text;
                            c.CoinNick = kriptoIsim.Text;
                            c.MaxArz = Convert.ToInt32(tb_MaxArz.Text);
                            c.Fiyat = Convert.ToDecimal(tb_fiyat.Text);
                            if (fu_resim.HasFile)
                            {
                                FileInfo fi = new FileInfo(fu_resim.FileName);
                                if (fi.Extension == ".jpg" || fi.Extension == ".png")
                                {
                                    string uzanti = fi.Extension;
                                    string isim = Guid.NewGuid().ToString();
                                    c.Resim = isim + uzanti;
                                    fu_resim.SaveAs(Server.MapPath("~/AdminPanel/images/NFTCoinImg/" + isim + uzanti));
                                    if (dm.CoinEkle(c))
                                    {
                                        pnl_basarili.Visible = true;
                                        pnl_basarisiz.Visible = false;

                                    }
                                    else
                                    {
                                        pnl_basarili.Visible = false;
                                        pnl_basarisiz.Visible = true;
                                        lbl_mesaj.Text = "Kripto Eklenirken Hata Oluştu";
                                    }

                                }
                                else
                                {
                                    pnl_basarili.Visible = false;
                                    pnl_basarisiz.Visible = true;
                                    lbl_mesaj.Text = "Resim uzantısı sadece .jpg veya .png olmalıdır";
                                }
                            }
                            else
                            {
                                pnl_basarili.Visible = false;
                                pnl_basarisiz.Visible = true;
                                lbl_mesaj.Text = "Resim Eklemeniz Gerekmektedir";
                            }

                        }
                        else
                        {
                            pnl_basarili.Visible = false;
                            pnl_basarisiz.Visible = true;
                            lbl_mesaj.Text = "Kripto Daha Önce Eklenmiş";
                        }
                    }
                    else
                    {
                        pnl_basarili.Visible = false;
                        pnl_basarisiz.Visible = true;
                        lbl_mesaj.Text = "Fiyat Boş Bırakılamaz";
                    }
                   


                }
                else
                {
                    pnl_basarili.Visible = false;
                    pnl_basarisiz.Visible = true;
                    lbl_mesaj.Text = "Max arzı doldur lan";
                }

            }
                



            else
            {
                pnl_basarili.Visible = false;
                pnl_basarisiz.Visible = true;
                lbl_mesaj.Text = "Kripto Adı boş bırakılamaz";
            }
        }
    }
}