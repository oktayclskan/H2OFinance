using System;
using System.Collections.Generic;
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
                cmd.CommandText = "INSERT INTO Coinler (CoinNick,Isim,Max_Arz,Resim,Fiyat,Durum) Values (@isim,@coinNick,@maxArz,@resim,@fiyat,1)";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@coinNick", c.CoinNick);
                cmd.Parameters.AddWithValue("@isim", c.Isim);
                cmd.Parameters.AddWithValue("@maxArz", c.Max_Arz);
                cmd.Parameters.AddWithValue("@resim", c.Resim);
                cmd.Parameters.AddWithValue("@fiyat", c.Fiyat);
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
        public List<Coinler> CoinListele()
        {
            try
            {
                List<Coinler> coin = new List<Coinler>();
                cmd.CommandText = "SELECT ID,CoinNick,Isim,Max_Arz,Resim,Fiyat From Coinler WHERE Durum = 1";
                cmd.Parameters.Clear();
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Coinler c = new Coinler();
                    c.ID = reader.GetInt32(0);
                    c.CoinNick = reader.GetString(1);
                    c.Isim = reader.GetString(2);
                    c.Max_Arz = reader.GetInt32(3);
                    c.Resim = !reader.IsDBNull(4) ? reader.GetString(4) : "none.png";
                    c.Fiyat = reader.GetDecimal(5);
                    //c.Durum = reader.GetBoolean(5);
                    //c.DurumStr = reader.GetBoolean(5) ? "<label style='color:green'>Aktif</label>" : "<label style='color:gray'>Pasif</label> ";
                    coin.Add(c);
                }
                return coin;
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
        public void CoinDurumDegiştir(int id)
        {
            try
            {
                cmd.CommandText = "UPDATE Coinler SET Durum=0 WHERE ID=@id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                cmd.ExecuteNonQuery();
            }

            finally { con.Close(); }
        }
        //public void DeleteCoin(int id)
        //{
        //    try
        //    {
        //        cmd.CommandText = "Delete From Coinler Where ID=@id";
        //        cmd.Parameters.Clear();
        //        cmd.Parameters.AddWithValue("@id",id);
        //        con.Open();
        //        cmd.ExecuteNonQuery();
        //    }
        //    finally { con.Close(); }
        //}
        public bool CoinGuncelle(Coinler c)
        {
            try
            {
                cmd.CommandText = "UPDATE Coinler SET Isim=@isim,CoinNick=@coinNick,Max_Arz=@maxArz,Resim=@resim WHERE ID=@id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", c.ID);
                cmd.Parameters.AddWithValue("@isim", c.Isim);
                cmd.Parameters.AddWithValue("@coinNick", c.CoinNick);
                cmd.Parameters.AddWithValue("@maxArz", c.Max_Arz);
                cmd.Parameters.AddWithValue("@resim", c.Resim);
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
        public Coinler CoinGetir(int id)
        {
            try
            {

                cmd.CommandText = "SELECT * FROM Coinler WHERE ID=@id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                Coinler c = new Coinler();
                while (reader.Read())
                {
                    c.ID = reader.GetInt32(0);
                    c.CoinNick = reader.GetString(1);
                    c.Isim = reader.GetString(2);
                    c.Max_Arz = reader.GetInt32(3);
                    c.Resim = !reader.IsDBNull(4) ? reader.GetString(4) : "none.png";
                    c.Fiyat = reader.GetDecimal(5);
                    c.Durum = reader.GetBoolean(6);
                }
                return c;
            }
            catch
            {
                return null;
            }
            finally { con.Close(); }
        }

        #endregion
        #region Nft Kontrol
        public bool NftEkle(Nftler nft)
        {
            try
            {
                cmd.CommandText = "INSERT INTO NFT (Isim,Fiyat,Resim) Values (@isim,@Fiyat,@resim)";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@isim", nft.Isim);
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
                cmd.Parameters.AddWithValue("@durum", d);
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
                    t.OnayTarih = !reader.IsDBNull(7) ? reader.GetDateTime(7) : reader.GetDateTime(6);
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
        public bool BakiyeOnay(Talepler t)
        {
            try
            {
                cmd.CommandText = "Update Talepler Set Durum=2 Where ID=@id Update Uyeler Set Bakiye=Bakiye+@miktar WHERE ID=@Uye_ID ";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", t.ID);
                cmd.Parameters.AddWithValue("@miktar", t.Miktar);
                cmd.Parameters.AddWithValue("@Uye_ID", t.UyeID);
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
        public Talepler TalepGetir(int id)
        {
            try
            {
                Talepler t = new Talepler();
                cmd.CommandText = "Select T.ID, T.Uye_ID, U.Isim, T.Yonetici_ID, Y.Isim, T.Miktar, T.TalepTarih, T.OnayTarihi, T.Durum From Talepler AS T JOIN Uyeler AS U ON T.Uye_ID=U.ID JOIN Yoneticiler AS Y ON T.Yonetici_ID=Y.ID WHERE T.ID=@id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("id", id);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    t.ID = reader.GetInt32(0);
                    t.UyeID = reader.GetInt32(1);
                    t.UyeAdi = reader.GetString(2);
                    t.YoneticiID = reader.GetInt32(3);
                    t.YoneticiAdi = reader.GetString(4);
                    t.Miktar = reader.GetDecimal(5);
                    t.TalepTarih = reader.GetDateTime(6);
                    t.OnayTarih = !reader.IsDBNull(7) ? reader.GetDateTime(7) : reader.GetDateTime(6);
                    t.Durum = reader.GetByte(8);

                }
                return t;
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
        public void talepUpdate(Talepler t)
        {
            try
            {
                cmd.CommandText = "Update Talepler Set OnayTarihi=@onayTarihi, Yonetici_ID=@yid WHERE ID=@id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("onaytarihi", t.OnayTarih);
                cmd.Parameters.AddWithValue("@yid", t.YoneticiID);
                cmd.Parameters.AddWithValue("@id", t.ID);
                con.Open();
                cmd.ExecuteNonQuery();
            }

            finally
            {
                con.Close();
            }
        }

        public bool bakiyeReddet(int id)
        {
            try
            {
                cmd.CommandText = "Update Talepler Set Durum=3 WHERE ID=@id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch { return false; }
            finally { con.Close(); }
        }
        #endregion
    }

}