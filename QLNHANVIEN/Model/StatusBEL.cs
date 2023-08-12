using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLNHANVIEN.Model
{
    public class StatusBEL
    {
        public int Matt { get; set; }
        public string Tentt { get; set; }
        public List<TimekeepingBEL> Timekeepings { get; set; }
    }
}
