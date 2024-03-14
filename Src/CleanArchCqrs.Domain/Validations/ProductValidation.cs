using CleanArchCqrs.Domain.Entities;
using CleanArchCqrs.Domain.Exceptions;
using CleanArchCqrs.Domain.Interfaces.DataRepositories;
using CleanArchCqrs.Domain.Interfaces.DomainValidations;

namespace CleanArchCqrs.Domain.Validations
{
    public class ProductValidation : IProductValidation
    {
        private readonly ICategoryRepository _categoryRepository;

        private readonly IProductRepository _productRepository;

        public ProductValidation(ICategoryRepository categoryRepository, IProductRepository productRepository)
        {
            _categoryRepository = categoryRepository;
            _productRepository = productRepository;
        }

        public async Task ValidateCreateAsync(Product product)
        {
            ValidateName(product.Name);
            await ValidateCategoryIdAsync(product.CategoryId);
        }

        public async Task ValidateUpdateAsync(Product product)
        {
            await ValidateIdAsync(product.Id);
            ValidateName(product.Name);
            await ValidateCategoryIdAsync(product.CategoryId);
        }

        public async Task ValidateDeleteAsync(Product product)
        {
            await ValidateIdAsync(product.Id);
        }

        private async Task ValidateIdAsync(int id)
        {
            DomainException.When(id < 0, "Id is invalid");
            DomainException.When(await _productRepository.GetByIdAsync(id) == null, "Product not found");
        }

        private void ValidateName(string name)
        {
            DomainException.When(string.IsNullOrEmpty(name), "Name is required");
            DomainException.When(name.Length < 3, "Name is too short. Minimum 3 characters");
        }

        private async Task ValidateCategoryIdAsync(int categoryId)
        {
            DomainException.When(categoryId < 0, "CategoryId is invalid");
            DomainException.When(await _categoryRepository.GetByIdAsync(categoryId) == null, "Category not found");
        }
    }
}
