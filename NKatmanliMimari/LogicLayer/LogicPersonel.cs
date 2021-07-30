using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;
using DataAccessLayer;


namespace LogicLayer
{
    public class LogicPersonel
    {
        public static List<EntityPersonel> LLPersonelListesi()
        {
            return DALPersonel.PersonelListesi();
        }
        public static int LLPersonelEkle(EntityPersonel personel)
        {
            if (personel.Ad != "" && personel.Soyad != "" && personel.Gorev != "" && personel.Maas > 2400)
            {
                return DALPersonel.PersonelEkle(personel);
            }
            else
                return -1;


        }
        public static bool LLPersonelSil(int personel)
        {
            if (personel >= 1)
            {
                return DALPersonel.PersonelSil(personel);
            }
            else
                return false;
        }
        public static bool LLPersonelGuncelle(EntityPersonel personel)
        {
            if (personel.Ad != "" && personel.Soyad != "" && personel.Gorev != "" && personel.Maas > 2500 && personel.Sehir !="")
            {
                return DALPersonel.PersonelGuncelle(personel);
            }
            else
                return false;
        }
    }
}
