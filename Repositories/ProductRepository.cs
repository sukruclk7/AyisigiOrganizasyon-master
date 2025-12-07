using Entities.Models;
using Entities.RequestParameters;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Repositories.Contracts;
using Repositories.Extensions;

namespace Repositories
{
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(RepositoryContext context) : base(context)
        {

        }

        public void CreateOneProduct(Product product)=>Create(product);

        public void DeleteOneProduct(Product? product)=> Remove(product);

        public IQueryable<Product> GetAllProducts(bool trackChanges)=>FindAll(trackChanges);

        public IQueryable<Product> GetAllProductsWithDetails(ProductRequestParameters p)
        {
            return _context
                .Products
                .FilteredByCategoryId(p.CategoryId)
                .FilteredBySearchTerm(p.SearchTerm)
                .FilteredByPrice(p.MinPrice, p.MaxPrice, p.IsValidPrice)
                .ToPaginate(p.PageNumber, p.PageSize);
        }

        public Product? GetOneProduct(int id,bool trackChanges)
        {
            return FindByCondition(p => p.ProductId.Equals(id),trackChanges);
        }

        public IQueryable<Product> GetShowcaseProducts(bool trackChanges)
        {
            return FindAll(trackChanges)
                .Where(p => p.ShowCase.Equals(true));
        }

        public void UpdateOneProduct(Product entitiy)=>Update(entitiy);
    
    }
}