using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using WPF_TimeTracker.Commands;
using WPF_TimeTracker.Models;

namespace WPF_TimeTracker.ViewModels
{
    public class CategoryViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<CategoryModel> _categories;
        private string _newCategoryName;
        private string _selectedCategoryId;

        public ObservableCollection<CategoryModel> Categories
        {
            get => _categories;
            set
            {
                _categories = value;
                OnPropertyChanged();
            }
        }

        public string NewCategoryName
        {
            get => _newCategoryName;
            set
            {
                _newCategoryName = value;
                OnPropertyChanged();
            }
        }

        public string SelectedCategoryId
        {
            get => _selectedCategoryId;
            set
            {
                _selectedCategoryId = value;
                OnPropertyChanged();
            }
        }

        public ICommand AddCategoryCommand { get; }
        public ICommand DeleteCategoryCommand { get; }

        public event PropertyChangedEventHandler PropertyChanged;

        public CategoryViewModel()
        {
            Categories = new ObservableCollection<CategoryModel>();
            AddCategoryCommand = new RelayCommand(AddCategory);
            DeleteCategoryCommand = new RelayCommand(DeleteCategory);
        }

        private void AddCategory()
        {
            if (!string.IsNullOrEmpty(NewCategoryName))
            {
                var newCategory = new CategoryModel
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = NewCategoryName
                };
                Categories.Add(newCategory);
                NewCategoryName = string.Empty;
            }
        }

        private void DeleteCategory()
        {
            var categoryToDelete = Categories.FirstOrDefault(c => c.Id == SelectedCategoryId);
            if (categoryToDelete != null)
            {
                Categories.Remove(categoryToDelete);
            }
        }

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
