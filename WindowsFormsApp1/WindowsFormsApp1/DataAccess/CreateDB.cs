using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.Model;

namespace WindowsFormsApp1.DataAccess
{
    class CreateDB : CreateDatabaseIfNotExists<SMContext>
    {
        protected override void Seed(SMContext context)
        {
            context.LSHs.AddRange(new LSH[]
            {
                new LSH{ID_Lop = 1, NameLop = "DT1"},
                new LSH{ID_Lop = 2, NameLop = "DT2"}, 
                new LSH{ID_Lop = 3, NameLop = "DT3"},
            });
            context.SVs.AddRange(new SV[]
            {
                new SV{MSSV="101",Name="NVA",Gender=true, NS=DateTime.Now,ID_Lop=1},
                new SV{MSSV="102",Name="NVB",Gender=false, NS=DateTime.Now,ID_Lop=2},
                new SV{MSSV="103",Name="NVC",Gender=true, NS=DateTime.Now,ID_Lop=3},
                new SV{MSSV="104",Name="NVD",Gender=false, NS=DateTime.Now,ID_Lop=1},
            });
            context.SaveChanges();
        }
    }
}
