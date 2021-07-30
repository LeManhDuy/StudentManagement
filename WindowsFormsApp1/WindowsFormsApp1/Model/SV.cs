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
    [Table("SinhVien")]
    public class SV
    {
        [Key]
        public string MSSV { get; set; }
        public string Name { get; set; }
        public bool Gender { get; set; }
        public DateTime NS { get; set; }
        public int ID_Lop { get; set; }
        [ForeignKey("ID_Lop")]
        public virtual LSH LSH { get; set; }

        public SV() { }
        public SV(SVVM svvm) {
            this.MSSV = svvm.MSSV;
            this.Name = svvm.Name;
            this.Gender = svvm.Gender;
            this.NS = svvm.NS;
            this.ID_Lop = svvm.ID_Lop;
        }
    }
}
