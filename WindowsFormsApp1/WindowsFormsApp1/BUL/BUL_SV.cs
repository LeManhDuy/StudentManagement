using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.DataAccess;
using WindowsFormsApp1.Model;
using WindowsFormsApp1.ViewModel;

namespace WindowsFormsApp1.BUL
{
    public class BUL_SV
    {
        private readonly SMContext _db;
        public BUL_SV()
        {
            _db = new SMContext();
        }
        public List<CBBItem> getCBBSV()
        {
            List<CBBItem> cbbList = new List<CBBItem>();
            cbbList.AddRange(new CBBItem[]
            {
                new CBBItem{ Value = 0, Text = "NameSV" },
                new CBBItem{ Value = 1, Text = "Gender" },
                new CBBItem{ Value = 2, Text = "NgaySinh" },
                new CBBItem{ Value = 3, Text = "NameLop" },
            });
            return cbbList;
        }
        public List<CBBItem> getCBBLop()
        {
            List<CBBItem> cbbList = new List<CBBItem>();
            foreach (LSHVM l in GetAllListLSHVM())
            {
                cbbList.Add(new CBBItem { Value = l.ID_Lop, Text = l.NameLop });
            }
            return cbbList;
        }
        public List<SVVM> GetAllListSVVM()
        {
            List<SV> list = _db.SVs.ToList();
            return list.Select(c => new SVVM(c)).ToList();
        }
        public List<LSHVM> GetAllListLSHVM()
        {
            List<LSH> list = _db.LSHs.ToList();
            return list.Select(c => new LSHVM(c)).ToList();
        }
        public List<SVVM> GetSVByIdLopAndName(int id, string name)
        {
            List<SV> list = _db.SVs.ToList();
            if (id == 0)
            {
                return list.Where(c => c.Name.Contains(name)).Select(c => new SVVM(c)).ToList();
            }
            else
            {
                return list.Where(c => c.Name.Contains(name) && c.ID_Lop == id).Select(c => new SVVM(c)).ToList();
            }
        }
        public SV GetListSVVMByMSSV(string id)
        {
            var list = _db.SVs.Find(id);
            return list;
        }
        public void Deploy(SV s)
        {
            try
            {
                SV sv = _db.SVs.Find(s.MSSV);
                if (sv != null)
                {
                    sv.Name = s.Name;
                    sv.NS = s.NS;
                    sv.Gender = s.Gender;
                    sv.ID_Lop = s.ID_Lop;
                    _db.SaveChanges();
                }
                else
                {
                    _db.SVs.Add(s);
                    _db.SaveChanges();
                }
            }
            catch
            {
                MessageBox.Show("vui long lien he to IT");
            }
        }
        public void DelSV(DataGridViewSelectedRowCollection r)
        {
            try
            {
                List<string> del = new List<string>();
                foreach (DataGridViewRow i in r)
                {
                    del.Add(i.Cells["MSSV"].Value.ToString());
                }
                foreach (String str in del)
                {
                    foreach (SV sv in _db.SVs)
                    {
                        if (sv.MSSV == str)
                        {
                            _db.SVs.Remove(sv);
                            break;
                        }
                    }
                    _db.SaveChanges();
                }
            }
            catch
            {
                MessageBox.Show("vui long lien he to IT");
            }
        }
        public List<SVVM> SortSV(List<string> LMSSV, int Value)
        {
            List<SVVM> list = new List<SVVM>();
            foreach (SV sv in _db.SVs.ToList())
            {
                if (LMSSV.Contains(sv.MSSV))
                {
                    list.Add(new SVVM { MSSV = sv.MSSV, Gender = sv.Gender, LSHName = sv.LSH.NameLop, Name = sv.Name, NS = sv.NS });
                }
            }
            List<SVVM> sorted = new List<SVVM>();
            switch (Value)
            {
                case 0:
                    sorted = list.OrderBy(x => x.Name).ToList();
                    break;
                case 1:
                    sorted = list.OrderBy(x => x.Gender).ToList();
                    break;
                case 2:
                    sorted = list.OrderBy(x => x.NS).ToList();
                    break;
                case 3:
                    sorted = list.OrderBy(x => x.LSHName).ToList();
                    break;
                default:
                    break;
            }
            return sorted;
        }
    }
}
