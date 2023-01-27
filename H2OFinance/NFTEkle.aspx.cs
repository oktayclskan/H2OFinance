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
    public partial class NftEkle : System.Web.UI.Page
    {
        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void lbtn_NftEkle_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tb_NFTIsim.Text.Trim()))
            {

                if (!string.IsNullOrEmpty(tb_fiyat.Text.Trim()))
                {
                    if (dm.NftKontrol(tb_NFTIsim.Text.Trim()))
                    {
                        Nftler nft = new Nftler();
                        nft.Isim = tb_NFTIsim.Text;
                        nft.Fiyat = Convert.ToDecimal(tb_fiyat.Text);
                        if (fu_resim.HasFile)
                        {
                            FileInfo fi = new FileInfo(fu_resim.FileName);
                            if (fi.Extension == ".jpg" ||fi.Extension == ".png")
                            {
                                string uzanti = fi.Extension;
                                string isim = Guid.NewGuid().ToString();
                                nft.Resim = isim + uzanti;
                                fu_resim.SaveAs(Server.MapPath("~/AdminPanel/images/NFTCoinImg/" +isim + uzanti));
                                if (dm.NftEkle(nft))
                                {
                                    pnl_basarili.Visible = true;
                                    pnl_basarisiz.Visible = false;
                                }
                                else
                                {
                                    pnl_basarili.Visible = false;
                                    pnl_basarisiz.Visible = true;
                                    lbl_mesaj.Text = "nft Eklenirken Hata Oluştu";
                                }
                            }
                            else
                            {

                                pnl_basarili.Visible = false;
                                pnl_basarisiz.Visible = true;
                                lbl_mesaj.Text = "Resim uzantısı sadece .jpg veya png olmalıdır";
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
                        lbl_mesaj.Text = "NFT Daha Önce Eklenmiş";
                    }
                }
                else
                {
                    pnl_basarili.Visible = false;
                    pnl_basarisiz.Visible = true;
                    lbl_mesaj.Text = "Fiyatını belirtiniz ";
                }
            }
            else
            {

                pnl_basarili.Visible = false;
                pnl_basarisiz.Visible = true;
                lbl_mesaj.Text = "İsim boş bırakılamaz ";
            }
        }
    }
}