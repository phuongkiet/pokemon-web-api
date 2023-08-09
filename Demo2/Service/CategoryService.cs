using AutoMapper;
using Demo2.Entity;
using Demo2.Interfaces;
using Demo2.Models.ResponseModel;
using Demo2.Repository;

namespace Demo2.Service
{
    public interface ICategoryService
    {
        public Task<ICollection<Category>> GetCategories();
        public Task CreateCategory(Category category);

        public Task UpdateCategory(Category category);

        public Task DeleteCategory(Category category);

        public bool CategoriesExists(int categoryId);

        public Task<Category> GetCategoryById(int categoryId);
    }

    public class CategoryService : ICategoryService
    {
        private readonly CategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryService(IMapper mapper, CategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<ICollection<Category>> GetCategories()
        {
            var category = await _categoryRepository.GetAll();
            return category.ToList();
        }

        public async Task CreateCategory(Category category)
        {
            await _categoryRepository.Add(category);
        }

        public async Task DeleteCategory(Category category)
        {
            await _categoryRepository.Delete(category);
        }

        public async Task UpdateCategory(Category category)
        {
            await _categoryRepository.Update(category);
        }

        public bool CategoriesExists(int categoryId)
        {
            return _categoryRepository.CategoryExists(categoryId);
        }

        public async Task<Category> GetCategoryById(int categoryId)
        {
           return await _categoryRepository.GetByIntId(categoryId);
        }
    }
}
