using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;
using System.Data.SqlClient;
using System.Data;

namespace DataAccessLayer
{
    public class DALPersonel
    {
        public static List<EntityPersonel> PersonelListesi()
        {

            List<EntityPersonel> ent = new List<EntityPersonel>();
            SqlCommand komut = new SqlCommand("Select *From TBLBILGI", Baglanti.bgl);
            if (komut.Connection.State != ConnectionState.Open)
            {
                komut.Connection.Open();
            }
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                EntityPersonel personel = new EntityPersonel();
                personel.Id = int.Parse(dr["ID"].ToString());
                personel.Ad = dr["AD"].ToString();
                personel.Soyad = dr["SOYAD"].ToString();
                personel.Gorev = dr["GOREV"].ToString();
                personel.Sehir = dr["SEHIR"].ToString();
                personel.Maas = short.Parse(dr["MAAS"].ToString());
                ent.Add(personel);
            }
            dr.Close();
            return ent;
        }
        public static int PersonelEkle(EntityPersonel p)
        {
            SqlCommand komut2 = new SqlCommand("Insert into TBLBILGI (AD,SOYAD,SEHIR,GOREV,MAAS) VALUES(@p1,@p2,@p3,@p4,@p5)", Baglanti.bgl);
            if (komut2.Connection.State != ConnectionState.Open)
            {
                komut2.Connection.Open();
            }
            komut2.Parameters.AddWithValue("@p1", p.Ad);
            komut2.Parameters.AddWithValue("@p2", p.Soyad);
            komut2.Parameters.AddWithValue("@p3", p.Sehir);
            komut2.Parameters.AddWithValue("@p4", p.Gorev);
            komut2.Parameters.AddWithValue("@p5", p.Maas);

            return komut2.ExecuteNonQuery();
        }
        public static bool PersonelSil(int p)
        {
            SqlCommand komut3 = new SqlCommand("Delete from TBLBILGI where ID=@p1", Baglanti.bgl);
            if (komut3.Connection.State != ConnectionState.Open)
            {
                komut3.Connection.Open();
            }
            komut3.Parameters.AddWithValue("@p1", p);

//          --   METHOD TÜRÜ BOOL olduğu için -- 
            return komut3.ExecuteNonQuery() > 0;
        }
        public static bool PersonelGuncelle(EntityPersonel p)
        {
            SqlCommand komut4 = new SqlCommand("Update TBLBILGI set AD=@p1, SOYAD=@p2, GOREV=@p3, SEHIR=@p4, MAAS=@p5 where ID=@p6", Baglanti.bgl);
            if (komut4.Connection.State != ConnectionState.Open)
            {
                komut4.Connection.Open();
            }
            komut4.Parameters.AddWithValue("@p1", p.Ad);
            komut4.Parameters.AddWithValue("@p2", p.Soyad);
            komut4.Parameters.AddWithValue("@p3", p.Gorev);
            komut4.Parameters.AddWithValue("@p4", p.Sehir);
            komut4.Parameters.AddWithValue("@p5", p.Maas);
            komut4.Parameters.AddWithValue("@p6", p.Id);

            return komut4.ExecuteNonQuery() > 0;
        }
    }
}
