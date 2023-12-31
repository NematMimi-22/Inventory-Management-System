﻿using IMS.Repositories;
using Microsoft.Data.SqlClient;
using System.Data;
namespace IMS
{
    public class MSSQLProductRepository : IProductRepository
    {
        private string connectionString = "Server=DESKTOP-CUQN3UP\\SQLEXPRESS;Database=IMS;Integrated Security=True;TrustServerCertificate=true;";

        public Product GetValidProduct(string productName)
        {
            using var connection = new SqlConnection(connectionString);
            connection.Open();
            var query = "SELECT * FROM Products WHERE [PName] = @productName";
            using var command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@productName", productName);
            using var reader = command.ExecuteReader();
            if (reader.Read())
            {
                var product = new Product
                {
                    Name = Convert.ToString(reader["PName"]),
                    Price = Convert.ToInt16(reader["Price"]),
                    Quantity = Convert.ToInt16(reader["Quantity"]),
                };
                return product;
            }
            return null;
        }

        public void CreateProduct(Product product)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                {
                    var query = "INSERT INTO Products (PName, Price, Quantity) VALUES (@PName, @Price, @Quantity)";
                    using (var command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@PName", product.Name);
                        command.Parameters.AddWithValue("@Price", product.Price);
                        command.Parameters.AddWithValue("@Quantity", product.Quantity);
                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                }
            }
        }

        public void DisplayProducts()
        {
            var productsTable = new DataTable();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                var query = "SELECT * FROM Products";
                using (var command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    using (var adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(productsTable);
                    }
                }
            }
            foreach (DataRow row in productsTable.Rows)
            {
                foreach (DataColumn column in productsTable.Columns)
                {
                    Console.WriteLine($"{column.ColumnName}: {row[column]}");
                }
                Console.WriteLine("------------");
            }
        }

        public void UpdateProduct(Product product)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "UPDATE Products SET PName = @NewProductName, Price = @Price, Quantity = @Quantity WHERE PName = @OldProductName";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    Console.WriteLine("Update the product: ");
                    var userInputHandler = new UserInputHandler();
                    var newName = userInputHandler.GetProductName();
                    var isValidPrice = userInputHandler.TryGetProductPrice(out var price);
                    var isValidQuantity = userInputHandler.TryGetProductQuantity(out var quantity);
                    if (isValidPrice && isValidQuantity)
                    {
                        command.Parameters.AddWithValue("@NewProductName", newName);
                        command.Parameters.AddWithValue("@Price", price);
                        command.Parameters.AddWithValue("@Quantity", quantity);
                        command.Parameters.AddWithValue("@OldProductName", product.Name);
                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                }
            }
        }

        public void DeleteProduct(string productName)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM Products WHERE PName = @PName";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@PName", productName);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}