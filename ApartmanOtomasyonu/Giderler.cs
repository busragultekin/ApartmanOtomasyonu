using ApartmanOtomasyonu.BusinessLogic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ApartmanOtomasyonu
{
    public partial class Giderler : Form
    {
        GiderRepo gider = new GiderRepo();
        public Giderler()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Gider newGider = new Gider();
            newGider.Tarih = dateTimePicker1.Value;
            newGider.Tutar = numericUpDown1.Value;            
            gider.InsertGider(newGider);
            FillGrid();
        }

        private void FillGrid()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = gider.GetGider();
        }

        private void Giderler_Load(object sender, EventArgs e)
        {
            GiderTuru();
            FillGrid();
           
        }
        public void GiderTuru()
        {
            int a = 0;
            Type t = typeof(GiderTuru);
            foreach (var item in t.GetEnumNames())
            {
                CheckBox c = new CheckBox();
                c.Text = item;
                a += 20;
                c.Top = a ;
                groupBox1.Controls.Add(c);                  
            }
            
        }
    }
}
