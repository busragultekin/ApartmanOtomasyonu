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
            foreach (Control item in this.groupBox1.Controls)
            {
                if (item is RadioButton)
                {
                    RadioButton rb = item as RadioButton;
                    if (rb.Checked == true)
                    {                      
                        Gider yeniGider = new Gider();
                        yeniGider.Tarih = dateTimePicker1.Value;
                        yeniGider.Tutar = numericUpDown1.Value;
                        yeniGider.GiderTuru = (GiderTuru)Enum.Parse(typeof(GiderTuru), item.Text);
                        gider.InsertGider(yeniGider);
                    }
                }

            }
          
            FillGrid();
        }

        private void FillGrid()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = gider.GetGider();
        }

        private void Giderler_Load(object sender, EventArgs e)
        {
            Grid();
            GiderTuru();
            FillGrid();
           
        }
        public void GiderTuru()
        {
            int a = 0;
            Type t = typeof(GiderTuru);
            foreach (var item in t.GetEnumNames())
            {
                RadioButton rb = new RadioButton();
                rb.Text = item;
                a += 20;
                rb.Top = a ;
                rb.Left = 5;
                groupBox1.Controls.Add(rb);                  
            }
            
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            gider.DeleteGider((int)dataGridView1.CurrentRow.Cells[0].Value);
            FillGrid();
        }

    private void Grid()
        {
           // dataGridView1.Columns[0].Visible = false;
            //dataGridView1.Columns["GiderTuru"].HeaderText = "Gider Türü";
        }
    }
}
