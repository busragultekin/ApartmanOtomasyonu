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
                g.GiderTuru = (GiderTuru)row["GiderTuru"];
                list.Add(g);
            }
            return list;
        }
        public void InsertGider(Gider newGider)
        {          
            SqlParameter p1 = new SqlParameter("Tarih", newGider.Tarih);
            SqlParameter p2 = new SqlParameter("Tutar", newGider.Tutar);
            SqlParameter p3 = new SqlParameter("GiderTuru", newGider);
            Program.SqlHelper.ExecutePro("InsertGider", p1, p2,p3);
        }
        
    }
}
