using System;
using System.Collections.Generic;

namespace InvoiceApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Welcome to InvoiceApp!");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Invoice Application");
            Console.ResetColor();

            Console.WriteLine();

            Dictionary<string, decimal> products = new Dictionary<string, decimal>
            {
                { "Product A", 10.99m },
                { "Product B", 19.99m },
                { "Product C", 7.50m },
                { "Product D", 14.99m },
                { "Product E", 5.99m },
                { "Product F", 12.49m }
            };

            Console.WriteLine("Available Products:");
            Console.WriteLine("-------------------");

            foreach (var product in products)
            {
                Console.WriteLine($"{product.Key} - ${product.Value}");
            }

            Console.WriteLine();

            Dictionary<string, int> selectedProducts = new Dictionary<string, int>();

            bool addMoreProducts = true;

            while (addMoreProducts)
            {
                Console.WriteLine("Enter the name of the product (or 'done' if finished):");
                string productName = Console.ReadLine().Trim();

                if (productName.Equals("done", StringComparison.OrdinalIgnoreCase))
                {
                    addMoreProducts = false;
                    break;
                }

                if (products.ContainsKey(productName))
                {
                    if (selectedProducts.ContainsKey(productName))
                    {
                        Console.WriteLine($"'{productName}' has already been selected.");
                    }
                    else
                    {
                        Console.Write($"Enter the quantity for '{productName}': ");
                        string quantityInput = Console.ReadLine();
                        int quantity;

                        while (!int.TryParse(quantityInput, out quantity) || quantity <= 0)
                        {
                            Console.WriteLine("Invalid quantity. Please enter a positive number.");
                            Console.Write($"Enter the quantity for '{productName}': ");
                            quantityInput = Console.ReadLine();
                        }

                        selectedProducts.Add(productName, quantity);
                        Console.WriteLine($"'{productName}' with quantity {quantity} has been added to your selection.");
                    }
                }
                else
                {
                    Console.WriteLine($"'{productName}' is not a valid product name. Please select from the provided options.");
                }
            }
        }
    }
}