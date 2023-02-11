using Bogus;
using Param_.Net_Practicum.Core.Domain.Entities;
using Param_.Net_Practicum.Infrastructure.Persistence.Context;

namespace Param_.Net_Practicum.Infrastructure.Persistence.Extensions
{
    /// <summary>
    /// Create Dummy data and send to database
    /// </summary>
    public static class DataGenerator
    {
        public static WebApplication GenerateProductData(this WebApplication app, int categoryCount, int productCount)
        {
            using var scope = app.Services.CreateScope();
            var context = scope.ServiceProvider.GetService<ApplicationContext>();
            context.Categories.AddRange(CreateCategoriesWithProduct(categoryCount, productCount));
            context.SaveChanges();
            return app;
        }

        private static List<Category> CreateCategoriesWithProduct(int categoryCount, int productCount)
        {
            Faker<Product> productFaker = new()
            {
                Locale = "tr"
            };
            productFaker.RuleFor(x => x.Id, y => Guid.NewGuid());
            productFaker.RuleFor(x => x.Name, y => y.Commerce.ProductName());
            productFaker.RuleFor(x => x.CreateDate, DateTime.Now);
            productFaker.RuleFor(x => x.Price, y => decimal.Parse(y.Commerce.Price()));
            productFaker.RuleFor(x => x.Description, y => y.Commerce.ProductDescription());


            Faker<Category> categoryFaker = new() { Locale = "tr" };
            categoryFaker.RuleFor(x => x.Id, y => Guid.NewGuid());
            categoryFaker.RuleFor(x => x.Name, y => y.Commerce.Categories(1)[0]);
            categoryFaker.RuleFor(x => x.ImageUrl, y => y.Image.LoremPixelUrl());
            categoryFaker.RuleFor(x => x.Products, y => productFaker.Generate(productCount));

            return categoryFaker.Generate(categoryCount);
        }
    }
}
