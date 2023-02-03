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
        public static WebApplication GenerateProductData(this WebApplication app, int count)
        {
            using var scope = app.Services.CreateScope();
            var context = scope.ServiceProvider.GetService<ApplicationContext>();
            context.Products.AddRange(GetProducts(count));
            context.SaveChanges();
            return app;
        }

        private static List<Product> GetProducts(int count)
        {
            Faker<Product> Faker = new()
            {
                Locale = "tr"
            };
            Faker.RuleFor(x => x.Id, y => Guid.NewGuid());
            Faker.RuleFor(x => x.Name, y => y.Commerce.ProductName());
            Faker.RuleFor(x => x.CategoryName, y => y.Commerce.Categories(1)[0]);
            Faker.RuleFor(x => x.CreateDate, DateTime.Now);
            Faker.RuleFor(x => x.Price, y => decimal.Parse(y.Commerce.Price()));
            Faker.RuleFor(x => x.Description, y => y.Commerce.ProductDescription());
            return Faker.Generate(count);
        }
    }
}
