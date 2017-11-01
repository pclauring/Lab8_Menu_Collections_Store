using System;
using System.Collections;
using System.Collections.Generic;

namespace Lab8_Collections_Menu
{
    class Program
    {
        static void Main(string[] args)
        {
            //Dictionary to keep track of menu items - literal
            //ArrayList for items(strings) and prices(doubles)

            Dictionary<string, double> menu = new Dictionary<string, double>();
            ArrayList itemCart = new ArrayList();
            ArrayList itemPrice = new ArrayList();

            string[] itemNumbers = { "fish", "cat", "dog", "parrot", "mouse", "rabbit", "snake", "frog" };

            bool anotherItem = false;

            menu.Add("fish", 4.75);
            menu.Add("cat", 70.22);
            menu.Add("dog", 100.99);
            menu.Add("parrot", 249.33);
            menu.Add("mouse", 7.89);
            menu.Add("rabbit", 16.57);
            menu.Add("snake", 60.20);
            menu.Add("frog", 30.61);

            Console.WriteLine("Welcome to the Pet Store!\nCheck out our Animal Menu");


            do
            {
                int count = 1;
                Console.WriteLine("#   Item          Price\n========================");
                foreach (KeyValuePair<string, double> animal in menu)
                {
                    Console.WriteLine($"{count,-4}{animal.Key,-10} {animal.Value,-10}");
                    count++;
                }

                Console.Write("\nPlease enter the animal you would like to add to your Cart!\nEnter Animal Name or Item #: ");

                string selection = Console.ReadLine().ToLower();

                if (menu.ContainsKey(selection))
                {
                    itemCart.Add(selection);
                    itemPrice.Add(menu[selection]);
                    Console.WriteLine($"You added {selection} to your cart, it costs ${menu[selection]}");
                }
                else if (selection == "1" || selection == "2" || selection == "3" || selection == "4" || selection == "5" || selection == "6" || selection == "7" || selection == "8")
                {
                    selection = itemNumbers[Convert.ToInt16(selection) - 1];
                    itemCart.Add(selection);
                    itemPrice.Add(menu[selection]);
                    Console.WriteLine($"You added {selection} to your cart, it costs ${menu[selection]}");

                }
                else
                {
                    Console.WriteLine("That animal is not in our store...");
                }

                Console.WriteLine("Would you like to add another item? (y/n)");
                anotherItem = GetYesorNo();

            } while (anotherItem);
            Console.WriteLine("Thanks for your order!");
            Console.WriteLine("Your Cart contains: ");
            for (int i = 0; i < itemCart.Count; i++)
            {
                Console.WriteLine($"{itemCart[i],-10} {itemPrice[i],-10}");

            }

            //getting the total of the cart
            double totalPrice = TotalOfDoubles(itemPrice);
            double averagePrice = AverageOfDoubles(itemPrice);

            string averagePriceString = string.Format("{0:0.00}", averagePrice);

            Console.WriteLine($"Your total is: ${totalPrice}");
            Console.WriteLine($"The average item price in your cart is ${averagePriceString}\n");
            Console.WriteLine("Thank you for shopping at our Pet Store!");

        }

        private static double TotalOfDoubles(ArrayList itemPrice)
        {
            double totalPrice = 0;
            for (int i = 0; i < itemPrice.Count; i++)
            {

                double itemCost = (double)itemPrice[i];
                totalPrice += itemCost;
            }

            return totalPrice;
        }

        private static double AverageOfDoubles(ArrayList itemPrice)
        {
            return TotalOfDoubles(itemPrice) / itemPrice.Count;
        }

        private static bool GetYesorNo()
        {
            bool valid = true;
            bool repeat = true;
            while (valid)
            {
                string answer = Console.ReadLine().ToLower();
                if (answer == "y" || answer == "yes")
                {
                    valid = false;
                    repeat = true;
                }
                else if (answer == "n" || answer == "no")

                {
                    valid = false;
                    repeat = false;
                }
                else
                {
                    Console.Write("Did not enter a valid input. Please enter (y/n): ");
                }
            }

            return repeat;
        }
    }
}
