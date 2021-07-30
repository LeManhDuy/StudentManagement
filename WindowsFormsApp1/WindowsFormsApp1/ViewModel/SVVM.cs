using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.Model;

namespace WindowsFormsApp1.ViewModel
{
    public class SVVM
    {
        public string MSSV { get; set; }
        [DisplayName("Ten sinh vien")]
        public string Name { get; set; }
        [DisplayName("Gioi tinh")]
        public bool Gender { get; set; }
        [DisplayName("Ngay sinh")]
        public DateTime NS { get; set; }
        [Browsable(false)]
        public int ID_Lop { get; set; }
        [DisplayName("Ten lop")]
        public string LSHName { get; set; }
        public SVVM() { }
        public SVVM(SV sv) {
            this.MSSV = sv.MSSV;
            this.Name = sv.Name;
            this.Gender = sv.Gender;
            this.NS = sv.NS;
            this.ID_Lop = sv.ID_Lop;
            this.LSHName = sv.LSH.NameLop;
        }
    }
}
