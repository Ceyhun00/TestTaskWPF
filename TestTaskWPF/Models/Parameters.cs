using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTaskWPF.Models
{
    class Parameters
    {
        [Key]
        public string ParametersId { get; set; }
        public  string Q { get; set; }
        public int R { get; set; }
        public ulong T { get; set; }
        public D items { get; set; }
    }
}
