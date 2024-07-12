using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace WPF_TimeTracker.ViewModels
{
    public class CategoryViewModel : INotifyPropertyChanged
    {
        private List<CategoryModel> _categories;
        private CategoryModel _selectedCategory;

        public CategoryViewModel()
        {
            _categories = new List<CategoryModel>();
        }

        public List<CategoryModel> Categories
        {
            get => _categories;
            set
            {
                _categories = value;
                OnPropertyChanged(nameof(Categories));
            }
        }

        public CategoryModel SelectedCategory
        {
            get => _selectedCategory;
            set
            {
                _selectedCategory = value;
                OnPropertyChanged(nameof(SelectedCategory));
            }
        }

        public void AddTimeEntry(TimeEntryModel timeEntry)
        {
            _selectedCategory?.TimeEntries.Add(timeEntry);
            OnPropertyChanged(nameof(SelectedCategory));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

    }
}
