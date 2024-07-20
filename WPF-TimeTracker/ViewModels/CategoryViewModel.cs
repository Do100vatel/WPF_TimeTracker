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
    public class CategoryViewModel : BaseViewModel
    {
        private ObservableCollection<CategoryModel> _categories;
        private string _newCategoryName;
        private CategoryModel _selectedCategory;

        public ICommand AddCategoryCommand { get; }
        public ICommand RemoveCategoryCommand {get;}
        public CategoryViewModel()
        {
            Categories = new ObservableCollection<CategoryModel>();
            AddCategoryCommand = new RelayCommand(AddCategory);
            RemoveCategoryCommand = new RelayCommand(RemoveCategory, CanRemoveCategory);
        }

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

        public CategoryModel SelectedCategory
        {
            get => _selectedCategory;
            set
            {
                _selectedCategory = value;
                OnPropertyChanged();
            }
        }


        private void AddCategory()
        {
            if (!string.IsNullOrWhiteSpace(NewCategoryName))
            {
                var newCategory = new CategoryModel { Id = Guid.NewGuid().ToString(), Name = NewCategoryName };
                Categories.Add(newCategory);
                NewCategoryName = string.Empty;
            }
        }

        private void RemoveCategory()
        {
            if (SelectedCategory != null)
            {
                Categories.Remove(SelectedCategory);
            }
        }

        private bool CanRemoveCategory()
        {
            return SelectedCategory != null;
        }

        public void AddTimeEntry(TimeEntryModel timeEntry)
        {
            if (SelectedCategory != null)
            {
                var category = Categories.FirstOrDefault(c => c.Id == SelectedCategory.Id);
                if (category != null)
                {
                    category.TimeEntries.Add(timeEntry);
                }
            }
        }
    }
}