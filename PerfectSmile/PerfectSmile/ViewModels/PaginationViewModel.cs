using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using PerfectSmile.Common;
using PerfectSmile.Repository.Abstract;
using PerfectSmile.Repository.Implementation;
using PerfectSmile.Service;
using PerfectSmile.Views;
using Prism.Commands;
using Prism.Interactivity.InteractionRequest;

namespace PerfectSmile.ViewModels
{
    public class PaginationViewModel : BaseViewModel
    {
        #region Commands
        public ICommand PreviousCommand { get; set; }
        public ICommand NextCommand { get; set; }
        public ICommand FirstCommand { get; set; }
        public ICommand LastCommand { get; set; }

        public ICommand SearchByColumnCommand { get; set; }

        #endregion

        #region Fields And Properties
        public int itemPerPage = 10;
        private int itemcount;
        private int _currentPageIndex;

        public string SearchByName
        {
            get { return _searchByName; }
            set
            {
                _searchByName = value;
                OnPropertyChanged();
            }
        }

        public string SearchById
        {
            get { return _searchById; }
            set
            {
                _searchById = value;
                OnPropertyChanged();
            }
        }


        public int CurrentPageIndex
        {
            get { return _currentPageIndex; }
            set
            {
                _currentPageIndex = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(CurrentPage));
            }
        }
        public int CurrentPage
        {
            get { return _currentPageIndex + 1; }
        }

        private int _totalPages;
        public int TotalPages
        {
            get { return _totalPages; }
            private set
            {
                _totalPages = value;
                OnPropertyChanged();
            }
        }

        public CollectionViewSource ViewList
        {
            get { return _viewList; }
            set
            {
                _viewList = value;
                OnPropertyChanged();
            }
        }

        //private ObservableCollection<EmpFormViewModel> _empList;
        private CollectionViewSource _viewList = new CollectionViewSource();
        private string _searchByName;
        private string _searchById;


        public ObservableCollection<dynamic> PeopleList     // EmpFormViewModel
        {
            //get { return new ObservableCollection<EmpFormViewModel>(_empList); }
            set
            {
                //_empList = value;
                OnPropertyChanged();
                //ViewList.Source = PeopleList;
                //itemcount = _empList.Count;
                CalculateTotalPages();
            }
        }

        #endregion

        #region Pagination Methods
        public void ShowNextPage()
        {
            CurrentPageIndex++;
            ViewList.View.Refresh();
        }

        public void ShowPreviousPage()
        {
            CurrentPageIndex--;
            ViewList.View.Refresh();
        }

        public void ShowFirstPage()
        {
            CurrentPageIndex = 0;
            ViewList.View.Refresh();
        }

        public void ShowLastPage()
        {
            CurrentPageIndex = TotalPages - 1;
            ViewList.View.Refresh();
        }

        public void FilterNameByName()
        {
            ViewList.View.Refresh();
        }


        private void CalculateTotalPages()
        {
            if (itemcount % itemPerPage == 0)
            {
                TotalPages = (itemcount / itemPerPage);
            }
            else
            {
                TotalPages = (itemcount / itemPerPage) + 1;
            }
        }
        #endregion

        public PaginationViewModel()
        {
            CurrentPageIndex = 0;

            //NextCommand = new NextPageCommand(this);
            //PreviousCommand = new PreviousPageCommand(this);
            //FirstCommand = new FirstPageCommand(this);
            //LastCommand = new LastPageCommand(this);
        }
    }
}
