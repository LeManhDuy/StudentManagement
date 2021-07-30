using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.BUL;
using WindowsFormsApp1.Model;

namespace WindowsFormsApp1
{
    public partial class Form2 : Form
    {
        public delegate void MyDel(int ID_Lop, string Name);
        public MyDel d { get; set; }
        public string MSSV { get; set; }
        BUL_SV bulSV = new BUL_SV();
        public Form2(string id)
        {
            InitializeComponent();
            MSSV = id;
            setGUI();
        }
        private void getCBB()
        {
            cbbLopSH.Items.AddRange(bulSV.getCBBLop().ToArray());
        }
        private void setGUI()
        {
            var s = bulSV.GetListSVVMByMSSV(MSSV);
            if (s != null)
            {
                txtMSSV.Text = s.MSSV;
                txtName.Text = s.Name;
                dtBirth.Value = s.NS;
                if (s.Gender == true) rdMale.Checked = true;
                else rdFemale.Checked = true;
                getCBB();
                foreach (CBBItem i in cbbLopSH.Items)
                {
                    if (i.Value == s.ID_Lop)
                    {
                        cbbLopSH.SelectedIndex = cbbLopSH.Items.IndexOf(i);
                    }
                }
            }
            else
            {
                getCBB();
            }
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (txtName.Text == "" || txtMSSV.Text == ""|| cbbLopSH.SelectedItem == null || rdFemale.Checked == false && rdMale.Checked == false)
            {
                MessageBox.Show("Hay nhap day du thong tin SV");
            }
            else
            {
                SV s = new SV();
                s.MSSV = txtMSSV.Text;
                s.Name = txtName.Text;
                s.ID_Lop = ((CBBItem)cbbLopSH.SelectedItem).Value;
                s.NS = dtBirth.Value;
                if (rdMale.Checked) s.Gender = true;
                else s.Gender = false;
                bulSV.Deploy(s);
                this.Close();
            }
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            if (MSSV == "0")
            {
                cbbLopSH.SelectedIndex = 0;
            }
            else
            {
                txtMSSV.ReadOnly = true;
            }
        }
    }
}
