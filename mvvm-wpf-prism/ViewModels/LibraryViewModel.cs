using mvvm_wpf_prism.Models;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mvvm_wpf_prism.ViewModels
{
    public class LibraryViewModel : BindableBase
    {
        #region Constructor
        public LibraryViewModel()
        {
            AddBookCommand = new DelegateCommand(AddNewBook);
            RemoveBookCommand = new DelegateCommand(RemoveBook, CanRemoveBook);
            Books = new ObservableCollection<Book>();
            Books.Add(new Book() { Author = "Jon Skeet", Title = "C# in Depth", Count = 3, SN = "ISBN: 9781617291340", Year = new DateTime(2013, 9, 10) });
            Books.Add(new Book() { Author = "Martin Fowler", Title = "Refactoring: Improving the Design of Existing Code", Count = 2, SN = "ISBN-10: 0201485672", Year = new DateTime(1999, 7, 8) });
            Books.Add(new Book() { Author = "Jeffrey Richter", Title = "CLR via C# (Developer Reference)", Count = 5, SN = "ISBN-10: 0735667454", Year = new DateTime(2012, 12, 4) });
        }
        #endregion

        #region Public Properties
        public ObservableCollection<Book> Books { get; set; }

        private Book _selectedBook;
        public Book SelectedBook
        {
            get { return _selectedBook; }
            set
            {
                _selectedBook = value;
                RaisePropertyChanged("SelectedBook");
                RemoveBookCommand.RaiseCanExecuteChanged();
            }
        }
        #endregion

        #region Command
        public DelegateCommand AddBookCommand { get; private set; }

        public DelegateCommand RemoveBookCommand { get; private set; }
        #endregion

        private void AddNewBook()
        {
            Books.Add(new Book() { Author = "Test1", Title = "Test1", Count = 5, SN = "ISBN-10: 0735667454", Year = DateTime.Now });
        }

        private void RemoveBook()
        {
            Books.Remove(SelectedBook);
        }

        private bool CanRemoveBook()
        {
            if (SelectedBook == null)
                return false;
            var book = FindBook(SelectedBook);
            if (book == null)
                return false;

            return true;
        }

        private Book FindBook(Book findBook)
        {
            if (findBook == null)
                return null;

            return Books.FirstOrDefault(book => book.Author == findBook.Author
                                        && book.Title == findBook.Title
                                        && book.SN == findBook.SN
                                        && book.Year == findBook.Year);
        }
    }
}
