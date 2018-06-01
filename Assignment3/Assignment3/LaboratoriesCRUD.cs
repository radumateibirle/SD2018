using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using BLL.Models;

namespace Assignment3
{
    public partial class LaboratoriesCRUD : Form
    {
        LaboratoryServices lS = new LaboratoryServices();

        public async void initGridV()
        {
            dataGridView1.DataSource = await lS.getAll();
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns.Add("", "");
            dataGridView1.Columns.Add("", "");
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                var row = dataGridView1.Rows[i];
                DataGridViewButtonCell bEdit = new DataGridViewButtonCell();
                bEdit.Value = "edit";
                row.Cells[dataGridView1.ColumnCount - 2] = bEdit;
                DataGridViewButtonCell bDelete = new DataGridViewButtonCell();
                bDelete.Value = "delete";
                row.Cells[dataGridView1.ColumnCount - 1] = bDelete;
            }
        }

        public async void refreshGridV()
        {
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
            dataGridView1.Refresh();

            dataGridView1.DataSource = await lS.getAll();
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns.Add("", "");
            dataGridView1.Columns.Add("", "");
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                var row = dataGridView1.Rows[i];
                DataGridViewButtonCell bEdit = new DataGridViewButtonCell();
                bEdit.Value = "edit";
                row.Cells[dataGridView1.ColumnCount - 2] = bEdit;
                DataGridViewButtonCell bDelete = new DataGridViewButtonCell();
                bDelete.Value = "delete";
                row.Cells[dataGridView1.ColumnCount - 1] = bDelete;
            }
        }

        public LaboratoriesCRUD()
        {
            InitializeComponent();
            initGridV();
        }

        private void addLaboratoryButton_Click(object sender, EventArgs e)
        {
            if (titleTextBox.Text == null) return;
            if (curriculaTextBox.Text == null) return;
            if (numberTextBox.Text == null) return;
            if (descriptionTextBox.Text == null) return;

            int nr = 0;
            if (Int32.TryParse(numberTextBox.Text, out nr) == false) return;

            LaboratoryModelAPI lab = new LaboratoryModelAPI();
            lab.Title = titleTextBox.Text;
            lab.Curricula = curriculaTextBox.Text;
            lab.Number = nr;
            lab.Description = descriptionTextBox.Text;
            lab.Date = datePicker.Value.Date;

            lS.addLaboratory(lab);
            for (int i = 0; i < 100000000; i++) ;
            refreshGridV();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == (dataGridView1.ColumnCount - 2))
            {
                //edit
                var row = dataGridView1.Rows[e.RowIndex];
                LaboratoryModel lm = new LaboratoryModel();
                int ID = Int32.Parse(row.Cells["ID"].Value.ToString());
                lm.ID = ID;
                if (row.Cells["Title"].Value == null) lm.Title = null;
                else lm.Title = row.Cells["Title"].Value.ToString();
                if (row.Cells["Curricula"].Value == null) lm.Curricula = null;
                else lm.Curricula = row.Cells["Curricula"].Value.ToString();
                if (row.Cells["Number"].Value == null) lm.Number = 0;
                else lm.Number = Int32.Parse(row.Cells["Number"].Value.ToString());
                if (row.Cells["Description"].Value == null) lm.Description = null;
                else lm.Description = row.Cells["Description"].Value.ToString();

                DateTime dt;
                DateTime.TryParse(row.Cells["Date"].Value.ToString(), out dt);
                lm.Date = dt;

                lS.update(lm);
                for (int i = 0; i < 100000000; i++) ;
                refreshGridV();

            }
            if (e.ColumnIndex == (dataGridView1.ColumnCount - 1))
            {
                //delete
                var row = dataGridView1.Rows[e.RowIndex];
                lS.deleteByID(Int32.Parse(row.Cells["ID"].Value.ToString()));
                for (int i = 0; i < 100000000; i++) ;
                refreshGridV();
            }
        }
    }
}
