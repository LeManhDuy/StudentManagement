using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.BUL;
using WindowsFormsApp1.DataAccess;
using WindowsFormsApp1.Model;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        //vấn đề tồn đọng : 
        //khi thêm hoặc sửa xong thì vẫn chưa load lại form 1
        BUL_SV bulSV = new BUL_SV();
        public Form1()
        {
            InitializeComponent();
            getDataGrid();
            getCBB();
        }
        private void getDataGrid()
        {
            grvList.DataSource = bulSV.GetAllListSVVM();
            grvList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        private void getCBB()
        {
            cbbLopSH.Items.Add(new CBBItem { Value = 0, Text = "All" });
            cbbSort.Items.AddRange(bulSV.getCBBSV().ToArray());
            cbbLopSH.Items.AddRange(bulSV.getCBBLop().ToArray());
            cbbLopSH.SelectedIndex = 0;
            cbbSort.SelectedIndex = 0;
        }
        private void showHandler(int id, string name)
        {
            grvList.DataSource = bulSV.GetSVByIdLopAndName(id, name);
        }
        private void btnShow_Click(object sender, EventArgs e)
        {
            showHandler(((CBBItem)cbbLopSH.SelectedItem).Value, txtSearch.Text);
        }

        private void btnSort_Click(object sender, EventArgs e)
        {
            if (grvList.DataSource == null) return;
            List<string> LMSSV = new List<string>();
            foreach (DataGridViewRow i in grvList.Rows)
            {
                LMSSV.Add(i.Cells["MSSV"].Value.ToString());
            }
            grvList.DataSource = bulSV.SortSV(LMSSV, ((CBBItem)cbbSort.SelectedItem).Value);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2("0");
            f.d += new Form2.MyDel(showHandler);
            f.Show();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (grvList.SelectedRows.Count == 1)
            {
                Form2 f = new Form2(grvList.SelectedRows[0].Cells["MSSV"].Value.ToString());
                f.d += new Form2.MyDel(showHandler);
                f.Show();
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            bulSV.DelSV(grvList.SelectedRows);
            showHandler(((CBBItem)cbbLopSH.SelectedItem).Value, txtSearch.Text);
        }
    }
}
