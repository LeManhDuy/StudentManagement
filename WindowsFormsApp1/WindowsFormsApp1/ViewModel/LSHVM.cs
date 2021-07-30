using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.Model;

namespace WindowsFormsApp1.ViewModel
{
    public class LSHVM
    {
        [DisplayName("IDLop")]
        public int ID_Lop { get; set; }
        [DisplayName("Ten Lop")]
        public string NameLop { get; set; }
        public LSHVM() { }
        public LSHVM(LSH sh)
        {
            this.ID_Lop = sh.ID_Lop;
            this.NameLop = sh.NameLop;
        }
    }
}
