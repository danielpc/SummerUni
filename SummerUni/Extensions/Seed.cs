using System.Collections.Generic;
using SummerUni.Entities;

namespace SummerUni.Extensions
{
    public static class Seed
    {
        public static void EnsureSeedDataForContext(this ShopContext context)
        {
            context.Users.RemoveRange(context.Users);
            context.SaveChanges();

            var users = new List<User>
            {
                new User
                {
                    Id = 100,
                    UserName = "Daniel",
                    Cart = new Cart
                    {
                        Id = 1,
                        Products = new List<Product>
                        {
                            new Product
                            {
                                Id = 1,
                                Title = "Banan"
                            },
                            new Product
                            {
                                Id = 2,
                                Title = "Æble"
                            }
                        }
                    }
                }
            };
            
            context.Users.AddRange(users);
            context.SaveChanges();
        }
        
    }
}