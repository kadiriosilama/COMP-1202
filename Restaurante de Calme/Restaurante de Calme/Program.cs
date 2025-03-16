using System;
using System.Collections.Generic;
namespace assignement1;
//Kadiri Osilama Osilama 
//101521804
 class RestaurantOrderSystem
{
    static Dictionary<string, double> menu = new Dictionary<string, double>()
    {
        { "Burger", 8.99 },
        { "Pizza", 10.99 },
        { "Poutine", 6.99 },
        { "Fries", 2.99 },
        { "Drink(Fruitopia)", 0.99 }
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
            Console.WriteLine("Options:");
            Console.WriteLine("1. Modify an item");
            Console.WriteLine("2. Remove an item");
            Console.WriteLine("3. Skip to receipt");

            Console.Write("Enter your choice: ");
            string choice = Console.ReadLine().Trim();

            switch (choice)
            {
                case "1":
                    Console.Write("Enter the name of the item you want to modify: ");
                    itemName = Console.ReadLine().Trim();
                    ModifyItem(itemName);
                    break;
                case "2":
                    Console.Write("Enter the name of the item you want to remove: ");
                    itemName = Console.ReadLine().Trim();
                    RemoveItem(itemName);
                    break;
                case "3":
                    return;
                default:
                    Console.WriteLine("Invalid option. Please enter a valid choice.");
                    break;
            }

            Console.Write("Do you want to modify anything else? (yes/no): ");
        } while (Console.ReadLine().Trim().ToLower() == "yes");
    }

    static void ModifyItem(string itemName)
    {
        int quantity;
        if (currentOrder.ContainsKey(itemName))
        {
            Console.Write($"Current quantity of {itemName}: {currentOrder[itemName]}. Enter the new quantity: ");
            while (!int.TryParse(Console.ReadLine(), out quantity) || quantity < 0)
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
    }

    static void RemoveItem(string itemName)
    {
        if (currentOrder.ContainsKey(itemName))
        {
            currentOrder.Remove(itemName);
            Console.WriteLine($"{itemName} removed from the order.");
        }
        else
        {
            Console.WriteLine("Item not found in the current order.");
        }
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
        //Console.WriteLine($"Total: ${total:F2}");

        Console.Write("Do you have a discount code? (yes/no): ");
        string discountChoice = Console.ReadLine().Trim().ToLower();
        double discount = 0;
        if (discountChoice == "yes")
        {
            Console.Write("Enter your discount code: ");
            string discountCode = Console.ReadLine().Trim();
            // You can implement your logic to validate and apply discount here
            // For simplicity, let's assume a fixed discount amount
            if (discountCode == "DISCOUNT0")
            {
                discount = total * 0.10; // 10% discount
                Console.WriteLine($"Discount applied: ${discount:F2}");
            }
            else
            {
                Console.WriteLine("Invalid discount code.");
            }
        }

        total -= discount;
        Console.WriteLine($"Total: ${total:F2}");
    }

    static void SaveOrderToFile(string fileName)
    {
        using (StreamWriter writer = new StreamWriter(fileName))
        {
            foreach (var item in currentOrder)
            {
                writer.WriteLine($"{item.Key},{item.Value}");
            }
        }
        Console.WriteLine("Order saved to file successfully.");
    }

    static void LoadOrderFromFile(string fileName)
    {
        currentOrder.Clear();
        try
        {
            using (StreamReader reader = new StreamReader(fileName))
            {
                string line;
                while ((line = Console.ReadLine()) != null)
                {
                    string[] parts = line.Split(',');
                    if (parts.Length == 2)
                    {
                        string itemName = parts[0];
                        int quantity;
                        if (int.TryParse(parts[1], out quantity))
                        {
                            currentOrder[itemName] = quantity;
                        }
                    }
                }
            }
            Console.WriteLine("Order loaded from file successfully.");
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("File not found. No previous order loaded.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading order: {ex.Message}");
        }
    }


    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to Calm Restaurant!");

        PlaceOrder();
        ModifyOrder();
        Checkout();

        Console.WriteLine("Thank you for your order!");
    }
}

