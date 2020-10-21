using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Newtonsoft.Json;
using TestTaskWPF.Models;

namespace TestTaskWPF
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private TestWpfContext Context;
        public static string fileName;
        public MainWindow()
        {
            Context = new TestWpfContext();
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dialog = new Microsoft.Win32.OpenFileDialog();
            bool? result = dialog.ShowDialog();
            if (result == true)
            {

                fileName = dialog.FileName;
                string fileText = File.ReadAllText(fileName);
                TextBox1.Text = fileText;

            }


        }

        public JObject ParseJson(string fileText)
        {
            var jObject = JObject.Parse(fileText);
            return jObject;
        }

        private void Download_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AddDbButton_Click_1(object sender, RoutedEventArgs e)
        {
            string fileText = File.ReadAllText(fileName);
            var parsed = ParseJson(fileText);
            var dItems = parsed["D"]?["items"];
            if (parsed["Q"]?.ToString() == "BOOKS")
            {
                if (dItems != null)
                {
                    foreach (var item in dItems)
                    {
                        var authors = new List<Author>();
                        var obj = JsonConvert.DeserializeObject<Book>(item.ToString());
                        if (obj.authors != null)
                        {
                            foreach (var t in obj.authors)
                            {
                                var authorId = t.id;
                                var author = Context.Authors.First(x => x.id == authorId);
                                authors.Add(author);
                            }
                        }
                        obj.authors = authors;
                        Context.Books.Add(obj);
                    }
                }
            }
            else if (parsed["Q"]?.ToString() == "AUTHORS")
            {
                if (dItems != null)
                {
                    foreach (var item in dItems)
                    {
                        var books = new List<Book>();

                        var obj = JsonConvert.DeserializeObject<Author>(item.ToString());
                        if (obj.Books != null)
                        {
                            foreach (var t in obj.Books)
                            {
                                var bookId = t.id;
                                var book = Context.Books.First(x => x.id == bookId);
                                books.Add(book);
                            }

                        }
                        obj.Books = books;
                        Context.Authors.Add(obj);
                    }

                }
            }
            Context.SaveChanges();
        }
    }
}