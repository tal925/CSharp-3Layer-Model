using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BO;
using BlApi;

namespace BLTest2
{
    internal class Program
    {
        private static IBL s_bl = BlApi.Factory.Get();

        static void Main(string[] args)
        {
            DalTest.Initialization.Initialize();

            Console.WriteLine("--- Welcome to Order System Test ---");

            string? choice;
            do
            {
                Console.WriteLine("\nChoose an option:");
                Console.WriteLine("1: Start New Order Simulation");
                Console.WriteLine("0: Exit");
                Console.Write("Enter your choice: ");

                choice = Console.ReadLine();

                try
                {
                    switch (choice)
                    {
                        case "1":
                            OrderSimulation();
                            break;
                        case "0":
                            Console.WriteLine("Exiting... Goodbye!");
                            break;
                        default:
                            Console.WriteLine("Invalid selection. Please try again.");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"\n[Error]: {ex.Message}");
                }

            } while (choice != "0");
        }

        private static void OrderSimulation()
        {
            Console.WriteLine("\n--- NEW ORDER STARTED ---");

            // יצירת אובייקט זמני בזיכרון 
            Order currentOrder = new Order
            {
                ProductInOrder = new List<ProductInOrder>(),
                IsFavoraite = false
            };

            bool addMore = true;
            while (addMore)
            {
                Console.WriteLine("\n--- Adding Product ---");
                Console.Write("Enter Product ID: ");
                if (!int.TryParse(Console.ReadLine(), out int pId)) break;

                Console.Write("Enter Amount: ");
                if (!int.TryParse(Console.ReadLine(), out int amount)) break;

                // קריאה למתודה (סדר פרמטרים: ID, כמות, הזמנה)
                var salesUsed = s_bl.Order.AddProductToOrder(currentOrder,pId, amount);

                Console.WriteLine("\nItem(s) added successfully.");
                if (salesUsed != null && salesUsed.Count() > 0)
                {
                    Console.WriteLine("Sales applied to this item!");
                }

                // הדפסת המצב הנוכחי של ההזמנה
                Console.WriteLine($"Current Total Price: {currentOrder.EndPrice}");

                Console.Write("\nAdd another product to this order? (y/n): ");
                if (Console.ReadLine()?.ToLower() != "y") addMore = false;
            }

            // סיכום סופי לפני ביצוע
            Console.WriteLine("\n--- FINAL ORDER SUMMARY ---");
            Console.WriteLine(currentOrder.ToStringProperty());

            Console.Write("\nConfirm and execute order? (y/n): ");
            if (Console.ReadLine()?.ToLower() == "y")
            {
                // קריאה לביצוע הסופי (עדכון מלאי)
                s_bl.Order.DoOrder(currentOrder);
                Console.WriteLine("Order processed! Stock has been updated.");
            }
            else
            {
                Console.WriteLine("Order cancelled. Data not saved.");
            }
        }
    }
}

