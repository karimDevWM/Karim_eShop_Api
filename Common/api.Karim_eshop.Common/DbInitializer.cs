using api.Karim_eshop.Data.Entity;
using api.Karim_eshop.Data.Entity.Model;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace api.Karim_eshop.Common
{
    public static class DbInitializer
    {
        public static async Task Initialize(KarimeshopDbContext context, UserManager<User> userManager)
        {
            if (!userManager.Users.Any())
            {
                var user = new User
                {
                    UserName = "bob",
                    Email = "bob@test.com",
                };

                await userManager.CreateAsync(user, "Pa$$w0rd");
                await userManager.AddToRoleAsync(user, "Member");

                var admin = new User
                {
                    UserName = "admin",
                    Email = "admin@test.com"
                };

                await userManager.CreateAsync(admin, "Pa$$w0rd");
                await userManager.AddToRolesAsync(admin, new[] { "Admin", "Member" });
            }

            if (context.Products.Any()) return;

            var products = new List<Product>
            {
                new Product
                {
                    Name = "Table basse en Or",
                    Description =
                        "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.",
                    Price = 20000,
                    PictureUrl = "/images/products/table_basse_or.png",
                    Brand = "Fluknumbluk",
                    Type = "table basse",
                    QuantityInStock = 100
                },
                new Product
                {
                    Name = "Lustre en diamant",
                    Description = "Nunc viverra imperdiet enim. Fusce est. Vivamus a tellus.",
                    Price = 15000,
                    PictureUrl = "/images/products/lustre_diamant.png",
                    Brand = "lustrulux",
                    Type = "Lustres",
                    QuantityInStock = 100
                },
                new Product
                {
                    Name = "Peignoir de douche en peau d'ours",
                    Description =
                        "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                    Price = 18000,
                    PictureUrl = "/images/products/peignoir_peau_ours.png",
                    Brand = "Louis Vuitton",
                    Type = "Vetement mixte",
                    QuantityInStock = 100
                },
                new Product
                {
                    Name = "robe de mariée satin bordé en or et diamant",
                    Description =
                        "Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Proin pharetra nonummy pede. Mauris et orci.",
                    Price = 30000,
                    PictureUrl = "/images/products/robe_marié_or_diamant.png",
                    Brand = "MariLux",
                    Type = "Vetement femme",
                    QuantityInStock = 100
                },
                new Product
                {
                    Name = "Pendule en or",
                    Description =
                        "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.",
                    Price = 25000,
                    PictureUrl = "/images/products/pendule_en_or.png",
                    Brand = "Tissot",
                    Type = "Horloge",
                    QuantityInStock = 100
                },
                new Product
                {
                    Name = "Chaussure peau crocodile",
                    Description =
                        "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.",
                    Price = 12000,
                    PictureUrl = "/images/products/chaussure_peau_crocodile.png",
                    Brand = "Lacoste",
                    Type = "Chaussure homme",
                    QuantityInStock = 100
                },
                new Product
                {
                    Name = "Sac en peau de gazelle",
                    Description =
                        "Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.",
                    Price = 1000,
                    PictureUrl = "/images/products/sac_peau_gazelle",
                    Brand = "Louis Vuitton",
                    Type = "Maroquinerie mixte",
                    QuantityInStock = 100
                },
                new Product
                {
                    Name = "Armoire en bois noble",
                    Description =
                        "Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.",
                    Price = 8000,
                    PictureUrl = "/images/products/armoire_noble.png",
                    Brand = "Noblerama",
                    Type = "Mobilier chambre à coucher",
                    QuantityInStock = 100
                },
                new Product
                {
                    Name = "Cendrier en or",
                    Description =
                        "Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.",
                    Price = 1500,
                    PictureUrl = "/images/products/cendrier en or.png",
                    Brand = "Cendrilux",
                    Type = "Divers",
                    QuantityInStock = 100
                },
                new Product
                {
                    Name = "Pipe en bois noble",
                    Description =
                        "Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.",
                    Price = 1800,
                    PictureUrl = "/images/products/pipe_en_bois_noble",
                    Brand = "Stanwell",
                    Type = "Divers",
                    QuantityInStock = 100
                }
            };

            foreach (var product in products)
            {
                context.Products.Add(product);
            }

            context.SaveChanges();
        }
    }
}
