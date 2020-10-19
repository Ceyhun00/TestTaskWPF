using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Net.NetworkInformation;

namespace TestTaskWPF.Models
{
    public class D
    {
        [Key]
        public  int DId { get; set; }
        public  int count { get; set; }
        public  List<Book> items { get; set; }
    }
}