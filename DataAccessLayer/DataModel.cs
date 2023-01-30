using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    public class DataModel
    {
        SqlConnection con; SqlCommand cmd;
        public DataModel()
        {
            con = new SqlConnection(ConnectionStrings.H2OCon);
            cmd = con.CreateCommand();
        }

        public Yoneticiler YoneticiGiris(string mail, string sifre)
        {
            try
            {
                cmd.CommandText = "SELECT COUNT(*) FROM Yoneticiler WHERE Mail=@mail AND Sifre=@sifre";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@mail", mail);
                cmd.Parameters.AddWithValue("@sifre", sifre);
                con.Open();
                int sayi = Convert.ToInt32(cmd.ExecuteScalar());
                if (sayi > 0)
                {
                    cmd.CommandText = "Select * From Yoneticiler WHERE Mail=@mail AND Sifre=@sifre ";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@mail", mail);
                    cmd.Parameters.AddWithValue("@sifre", sifre);
                    SqlDataReader reader = cmd.ExecuteReader();
                    Yoneticiler y = new Yoneticiler();
                    while (reader.Read())
                    {
                        y.ID = reader.GetInt32(0);
                        y.Isim = reader.GetString(1);
                        y.Soyisim = reader.GetString(2);
                        y.Mail = reader.GetString(3);
                        y.Sifre = reader.GetString(4);
                        y.Telefon = reader.GetString(5);
                    }
                    return y;
                }
                else
                {
                    return null;
                }
            }
            catch
            {
                return null;
            }
            finally { con.Close(); }
        }
        #region CoinKontrol


        public bool CoinKontrol(string isim)
        {
            try
            {
                cmd.CommandText = "SELECT COUNT(*) FROM Coinler WHERE  Isim=@isim   ";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@isim", isim);
                con.Open();
                int sayi = Convert.ToInt32(cmd.ExecuteScalar());
                if (sayi == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            finally
            {
                con.Close();
            }
        }
        public bool CoinEkle(Coinler c)
        {
            try
            {
                cmd.CommandText = "INSERT INTO Coinler (CoinNick,Isim,Max_Arz,Resim,Fiyat) Values (@isim,@coinNick,@maxArz,@resim,@fiyat)";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@coinNick", c.CoinNick);
                cmd.Parameters.AddWithValue("@isim", c.Isim);
                cmd.Parameters.AddWithValue("@maxArz", c.MaxArz);
                cmd.Parameters.AddWithValue("@resim", c.Resim);
                cmd.Parameters.AddWithValue("@fiyat",c.Fiyat);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                con.Close();
            }
        }

        #endregion
        #region Nft Kontrol
        public bool NftEkle(Nftler nft)
        {
            try
            {
                cmd.CommandText= "INSERT INTO NFT (Isim,Fiyat,Resim) Values (@isim,@Fiyat,@resim)";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@isim",nft.Isim);
                cmd.Parameters.AddWithValue("@fiyat", nft.Fiyat);
                cmd.Parameters.AddWithValue("@resim", nft.Resim);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                con.Close();
            }
        }
        public bool NftKontrol(string isim)
        {
            try
            {
                cmd.CommandText = "SELECT COUNT(*) FROM NFT WHERE  Isim=@isim   ";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@isim", isim);
                con.Open();
                int sayi = Convert.ToInt32(cmd.ExecuteScalar());
                if (sayi == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            finally
            {
                con.Close();
            }
        }
        #endregion
        #region Talep Kontrol
        public List<Talepler> TalepListele(int d)
        {
            try
            {
                List<Talepler> tlp = new List<Talepler>();
                cmd.CommandText = "Select T.ID, T.Uye_ID, U.Isim, T.Yonetici_ID, Y.Isim, T.Miktar, T.TalepTarih, T.OnayTarihi, T.Durum From Talepler AS T JOIN Uyeler AS U ON T.Uye_ID=U.ID JOIN Yoneticiler AS Y ON T.Yonetici_ID=Y.ID WHERE T.Durum=@durum";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@durum",d);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                   
                    Talepler t = new Talepler();
                    t.ID = reader.GetInt32(0);
                    t.UyeID = reader.GetInt32(1);
                    t.UyeAdi = reader.GetString(2);
                    t.YoneticiID = reader.GetInt32(3);
                    t.YoneticiAdi = reader.GetString(4);
                    t.Miktar = reader.GetDecimal(5);
                    t.TalepTarih = reader.GetDateTime(6);
                    t.OnayTarih = !reader.IsDBNull(7) ? reader.GetDateTime(7) :reader.GetDateTime(6) ;
                    t.Durum = reader.GetByte(8);
                    tlp.Add(t);
                }
                return tlp;
            }
            catch
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }
        #endregion
    }

}