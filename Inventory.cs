using Test;

Product test = new Product();
decimal? price = Product.ValidProduct("pro1").price;

Console.WriteLine(price);

