using System.Collections.ObjectModel;
using System.Windows.Input;
using WPF_TimeTracker.Models;

namespace WPF_TimeTracker.ViewModels
{
    public class CategoryViewModel : BaseViewModel
    {
        private CategoryModel _selectedCategory;

        public ObservableCollection<CategoryModel> Categories { get; set; }
        public CategoryModel SelectedCategory
        {
            get => _selectedCategory;
            set => SetProperty(ref _selectedCategory, value);
        }

        public ICommand AddCategoryCommand { get; }
        public ICommand RemoveCategoryCommand { get; }

        public CategoryViewModel()
        {
            Categories = new ObservableCollection<CategoryModel>();
            AddCategoryCommand = new RelayCommand(AddCategory);
            RemoveCategoryCommand = new RelayCommand(RemoveCategory, CanRemoveCategory);
        }

        private void AddCategory()
        {
            Categories.Add(new CategoryModel { Name = "New Category" });
        }

        private void RemoveCategory()
        {
            Categories.Remove(SelectedCategory);
        }

        private bool CanRemoveCategory()
        {
            return SelectedCategory != null;
        }
    }
}
