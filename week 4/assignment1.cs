using System;
using System.Collections.Generic;

class RestaurantOrderSystem
{
    static Dictionary<string, double> menu = new Dictionary<string, double>()
    {
        { "Burger", 8.99 },
        { "Pizza", 10.99 },
        { "Salad", 6.99 },
        { "Fries", 3.99 },
        { "Drink", 1.99 }
    };

    static Dictionary<string, int> currentOrder = new Dictionary<string, int>();

    static void DisplayMenu()
    {
        Console.WriteLine("Menu:");
        foreach (var item in menu)
        {
            Console.WriteLine($"{item.Key}: ${item.Value}");
        }
    }

    static void PlaceOrder()
    {
        string itemName;
        int quantity;

        do
        {
            DisplayMenu();
            Console.Write("Enter the name of the item you want to order: ");
            itemName = Console.ReadLine().Trim();

            if (menu.ContainsKey(itemName))
            {
                Console.Write("Enter the quantity: ");
                while (!int.TryParse(Console.ReadLine(), out quantity) || quantity <= 0)
                {
                    Console.Write("Invalid quantity. Please enter a valid quantity: ");
                }

                if (currentOrder.ContainsKey(itemName))
                    currentOrder[itemName] += quantity;
                else
                    currentOrder[itemName] = quantity;

                Console.WriteLine($"Added {quantity} {itemName}(s) to your order.");
            }
            else
            {
                Console.WriteLine("Invalid item. Please select an item from the menu.");
            }

            Console.Write("Do you want to order anything else? (yes/no): ");
        } while (Console.ReadLine().Trim().ToLower() == "yes");
    }

    static void ReviewOrder()
    {
        Console.WriteLine("Current Order:");
        foreach (var item in currentOrder)
        {
            Console.WriteLine($"{item.Key}: {item.Value}");
        }
    }

    static void ModifyOrder()
    {
        string itemName;
        int quantity;

        do
        {
            ReviewOrder();
            Console.Write("Enter the name of the item you want to modify or remove: ");
            itemName = Console.ReadLine().Trim();

            if (currentOrder.ContainsKey(itemName))
            {
                Console.Write($"Current quantity of {itemName}: {currentOrder[itemName]}. Enter the new quantity: ");
                while (!int.TryParse(Console.ReadLine(), out quantity) || quantity <= 0)
                {
                    Console.Write("Invalid quantity. Please enter a valid quantity: ");
                }

                if (quantity == 0)
                {
                    currentOrder.Remove(itemName);
                    Console.WriteLine($"{itemName} removed from the order.");
                }
                else
                {
                    currentOrder[itemName] = quantity;
                    Console.WriteLine($"Quantity of {itemName} updated to {quantity}.");
                }
            }
            else
            {
                Console.WriteLine("Item not found in the current order.");
            }

            Console.Write("Do you want to modify anything else? (yes/no): ");
        } while (Console.ReadLine().Trim().ToLower() == "yes");
    }

    static double CalculateTotal()
    {
        double subtotal = 0;
        foreach (var item in currentOrder)
        {
            subtotal += item.Value * menu[item.Key];
        }
        return subtotal;
    }

    static void Checkout()
    {
        double subtotal = CalculateTotal();
        double tax = subtotal * 0.13; // HST (13%)
        double total = subtotal + tax;

        Console.WriteLine($"Subtotal: ${subtotal:F2}");
        Console.WriteLine($"Tax: ${tax:F2}");
        Console.WriteLine($"Total: ${total:F2}");
    }

    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the Restaurant Order Management System!");

        PlaceOrder();
        ModifyOrder();
        Checkout();

        Console.WriteLine("Thank you for your order!");
    }
}
