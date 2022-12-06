using CodeFirst.DataAccess;
using CodeFirst.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
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

namespace CodeFirst
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        LibraryContext _context = new LibraryContext();
        public MainWindow()
        {
            InitializeComponent();

            _context.Database.CreateIfNotExists();
            #region Add Category


            
            Get();

            #endregion

        }

        public async void Get()
        {
            if(_context.Categories.Count()==0)
            await AddCategories();
            var categories = _context.Categories;
            categoriesGrid.ItemsSource = await categories.ToListAsync();

            if (_context.Authors.Count() == 0)
                await AddAuthors();
            var authors = _context.Authors;
            authorsGrid.ItemsSource=await authors.ToListAsync();
        }

        public async Task AddCategories()
        {
            _context.Categories.Add(new Category
            {
                Name = "Adventure"
            });
            _context.Categories.Add(new Category
            {
                Name = "Science-Fiction"
            });
            _context.Categories.Add(new Category
            {
                Name = "Programming"
            });
            await _context.SaveChangesAsync();
        }

        public async Task AddAuthors()
        {
            _context.Authors.Add(new Author
            {
                Firstname="Linus",
                Lastname="Torvalds",
                 Age=35
            });
            _context.Authors.Add(new Author
            {
                Firstname = "Leyla",
                Lastname = "Mammadova",
                Age = 20
            });
            _context.Authors.Add(new Author
            {
                Firstname = "Axmed",
                Lastname = "Axmedli",
                Age = 43
            });
            await _context.SaveChangesAsync();
        }
    }
}