using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTaskWPF.Models;

namespace TestTaskWPF
{
    class TestWpfContext : DbContext
    {
        public TestWpfContext() : base("DefaultConnection")
        {

        }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
    }
}