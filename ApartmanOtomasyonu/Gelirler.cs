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
    public partial class Gelirler : Form
    {
        public Gelirler()
        {
            InitializeComponent();
        }
        GelirRepo gelir = new GelirRepo();
        private void Gelirler_Load(object sender, EventArgs e)
        {
            FillGrid();

        }

        private void FillGrid()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = gelir.GetGelir();
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            Gelir newGelir = new Gelir();
            newGelir.DaireNo = (int)num_daire.Value;
            newGelir.Tarih = dateTimePicker1.Value;
            newGelir.Tutar = numtutar.Value;
            gelir.InsertGelir(newGelir);
            FillGrid();
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            gelir.DeleteGelir((int)dataGridView1.CurrentRow.Cells[0].Value);
            FillGrid();
        }
    }
}
