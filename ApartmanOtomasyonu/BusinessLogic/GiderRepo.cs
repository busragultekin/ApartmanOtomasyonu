using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ApartmanOtomasyonu.BusinessLogic
{
    class GiderRepo
    {
        public  List<Gider> GetGider()
        {
            List<Gider> list = new List<Gider>();
            DataTable dt = Program.SqlHelper.GetTable("select * from Gider");
            foreach (DataRow row in dt.Rows)
            {
                Gider g = new Gider();
                g.ID =(int) row["GiderID"];
                g.Tarih = (DateTime)row["Tarih"];
                g.Tutar = (decimal)row["Tutar"];
                g.GiderTuru = (GiderTuru)Enum.Parse(typeof(GiderTuru), row["GiderTuru"].ToString());
                list.Add(g);
            }
            return list;
        }
        public void InsertGider(Gider yeniGider)
        {          
            SqlParameter p1 = new SqlParameter("Tarih", yeniGider.Tarih);
            SqlParameter p2 = new SqlParameter("Tutar", yeniGider.Tutar);
            SqlParameter p3 = new SqlParameter("GiderTuru", SqlDbType.NVarChar,50);
            p3.Value = yeniGider.GiderTuru;
            Program.SqlHelper.ExecutePro("InsertGider", p1, p2,p3);
        }
        public void DeleteGider(int id)
        {
            Program.SqlHelper.ExecuteCommand("delete  from Gider where GiderID='" + id + "'");

        }

    }
}
