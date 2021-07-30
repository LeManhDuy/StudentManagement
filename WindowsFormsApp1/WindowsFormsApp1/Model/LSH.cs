using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.ViewModel;

namespace WindowsFormsApp1.Model
{
    public class LSH
    {
        [Key]
        public int ID_Lop { get; set; }
        public string NameLop { get; set; }
        public virtual List<SV> SVs { get; set; }
        //public LSH() { }
        //public LSH(LSHVM shvm)
        //{
        //    this.ID_Lop = shvm.ID_Lop;
        //    this.NameLop = shvm.NameLop;
        //}
    }
}
