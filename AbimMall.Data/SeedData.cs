using AbimMall.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AbimMall.Database
{
    public static class SeedData
    {
        
        public static async Task<bool> SeedCustomerData(AbimMallDbContext dbContext)
        {
            var baseDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            try
            {
                dbContext.Database.EnsureCreated();
                if (!dbContext.Products.Any())
                {
                    var path = File.ReadAllText(baseDir + @"/jsons/product.json");

                    var listOfProducts = JsonConvert.DeserializeObject<List<Product>>(path);
                    await dbContext.Products.AddRangeAsync(listOfProducts);
                }

                if (!dbContext.Categories.Any())
                {
                    var path = File.ReadAllText(baseDir + @"/jsons/category.json");

                    var listOfCategories = JsonConvert.DeserializeObject<List<Category>>(path);
                    await dbContext.Categories.AddRangeAsync(listOfCategories);
                }

                await dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new AccessViolationException($"Error occur while accessing the database: {ex}");
            }
        }
    }
}
