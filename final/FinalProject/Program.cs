using System;
using System.Collections.Generic;

public class Product
{
    public string Name { get; set; }
    public string Description { get; set; }
    public double Price { get; set; }
    public int StockQuantity { get; set; }
    public string Supplier { get; set; }
    public string Category { get; set; }

    public void AddProduct()
    {
        // Logic to add a product
    }

    public void ModifyProduct()
    {
        // Logic to modify a product
    }

    public void DeleteProduct()
    {
        // Logic to delete a product
    }

    public void GetProductDetails()
    {
        // Logic to get product details
    }
}

public class Category
{
    public string Name { get; set; }

    public void AddCategory()
    {
        // Logic to add a category
    }

    public void ModifyCategory()
    {
        // Logic to modify a category
    }

    public void DeleteCategory()
    {
        // Logic to delete a category
    }

    public List<Product> GetProductsByCategory()
    {
        // Logic to get products by category
        return new List<Product>(); // Change the return value as needed
    }
}

public class User
{
    public string Username { get; set; }
    public string Password { get; set; }
    public string Role { get; set; }

    public void AddUser()
    {
        // Logic to add a user
    }

    public void ModifyUser()
    {
        // Logic to modify a user
    }

    public void DeleteUser()
    {
        // Logic to delete a user
    }

    public bool AuthenticateUser()
    {
        // Logic to authenticate a user
        return false; // Change the return value as needed
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Here you can start interacting with your inventory system
        // For example:

        Product product1 = new Product();
        product1.Name = "Product 1";
        product1.Description = "Description of Product 1";
        product1.Price = 10.99;
        product1.StockQuantity = 50;
        product1.Supplier = "Supplier A";
        product1.Category = "Category 1";

        product1.AddProduct();
        product1.ModifyProduct();

        Category category1 = new Category();
        category1.Name = "Category 1";

        List<Product> productsInCategory1 = category1.GetProductsByCategory();

        User user1 = new User();
        user1.Username = "user1";
        user1.Password = "password123";
        user1.Role = "Admin";

        user1.AddUser();
        bool authenticated = user1.AuthenticateUser();
    }
}


// "Introducing the Inventory Management System, a purpose-built application aimed at empowering users to efficiently oversee and manage their business product inventory. At this juncture, I've laid the foundation with the establishment of three key classes: Product, Category, and User. Each of these classes incorporates vital attributes and methods to carry out crucial operations like adding, modifying, and removing items, as well as obtaining specific details. The foundational framework of the program is now in place, allowing seamless interaction with the inventory system through object instantiation and method calls. Moving forward, I'll delve into the meticulous implementation of logic for each method and construct more intricate interactions to provide users with effective control over their inventory. The project is underway and is poised to evolve further with the addition of functionalities and refinements in the design."




