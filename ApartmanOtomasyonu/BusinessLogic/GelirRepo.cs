using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApartmanOtomasyonu.BusinessLogic
{
    class GelirRepo
    {
        public  List<Gelir> GetGelir()
        {
            List<Gelir> list = new List<Gelir>();
            DataTable dt = Program.SqlHelper.GetTable("select * from Gelir");
            foreach (DataRow row in dt.Rows)
            {
                Gelir g = new Gelir();
                g.GelirID = (int)row["GelirID"];
                g.DaireNo = (int)row["DaireNo"];
                g.Tarih = (DateTime)row["Tarih"];
                g.Tutar = (decimal)row["Tutar"];
                list.Add(g);
            }
            return list;
        }
         public  void InsertGelir(Gelir yeniGelir)
        {
            SqlParameter p1 = new SqlParameter("DaireNo", yeniGelir.DaireNo);
            SqlParameter p2 = new SqlParameter("Tarih", yeniGelir.Tarih);
            SqlParameter p3 = new SqlParameter("Tutar", yeniGelir.Tutar);
            Program.SqlHelper.ExecutePro("InsertGelir", p1, p2, p3);
        }

        public  void DeleteGelir(int id)
        {
            Program.SqlHelper.ExecuteCommand("delete  from Gelir where GelirID='"+ id+ "'");
            
        }
    }
}
