using System;
using System.Globalization;
using System.Security;

class Lab07
{
    // Each product is spread across three arrays.
    // The same index means the same product:
    // names[0], prices[0], and ratings[0] are all "Wireless Mouse".
    static string[] names = {
        "Wireless Mouse", "Phone Charger", "Laptop Stand", "Bluetooth Speaker",
        "Phone Case", "Desk Lamp", "Webcam", "Water Bottle"
    };
    static double[] prices = { 24.99, 9.99, 34.50, 49.99, 12.99, 29.00, 59.95, 18.75 };
    static double[] ratings = { 4.5, 4.1, 4.7, 4.3, 3.9, 4.6, 4.0, 4.8 };

    static void Main()
    {
        Console.WriteLine("===== Snow Shop =====");
        PrintProducts();

        while (true)
        {
            Console.WriteLine();
            Console.WriteLine("1. Sort by price: low to high");
            Console.WriteLine("2. Sort by rating: high to low");
            Console.WriteLine("3. Sort by name: A to Z");
            Console.WriteLine("4. Quit");
            Console.Write("Choose: ");
            string choice = Console.ReadLine();

            if (choice == "1")
            {
                SortByPriceLowToHigh();
                PrintProducts();
            }
            else if (choice == "2")
            {
                SortByRatingHighToLow();
                PrintProducts();
            }
            else if (choice == "3")
            {
                SortByNameAToZ();
                PrintProducts();
            }
            else if (choice == "4")
            {
                break;
            }
            else
            {
                Console.WriteLine("Please enter 1, 2, 3, or 4.");
            }
        }
    }

    // TODO 1: Sort the products by price, cheapest first.
    // Use BUBBLE SORT.
    // Compare prices[...], but use Swap(i, j) to move the whole product.
    static void SortByPriceLowToHigh()
    {
        for (int i = 0; i < prices.Length-1; i++)
            {
                bool swapped = false;

                for (int j = 0; j < prices.Length-i-1; j++)
                    {
                    if (prices[j] > prices[j+1])
                        {
                        Swap(j, j+1);
                        swapped = true;
                        }
                    }
            if (swapped == false) {break;}
            }
    }

    // TODO 2: Sort the products by rating, best rating first.
    // Use SELECTION SORT.
    // Hint: each pass, find the HIGHEST rating instead of the lowest.
    static void SortByRatingHighToLow()
    {
        for (int i = 0; i < ratings.Length; i++)
        {
            int maxIndex = i;
            for (int j = i + 1; j < ratings.Length; j++)
            {
                if (ratings[j] > ratings[maxIndex])
                {
                    maxIndex = j;
                }
            }
            Swap(maxIndex,i);
        }
    }

    // TODO 3: Sort the products by name, A to Z.
    // Use INSERTION SORT.
    // Hint: to check if two names are out of order, use
    //     string.Compare(names[a], names[b]) > 0
    // To slide a product left, keep calling Swap(j - 1, j) and move j left.
    static void SortByNameAToZ()
    {
        for (int i = 1; i < names.Length; i++)
        {
            string temp = names[i];
            double temp1 = prices[i];
            double temp2 = ratings[i];
            int j = i - 1;
            while (j > -1 && string.Compare(temp,names[j]) < 0)
            {
                names[j+1] = names[j];
                prices[j+1] = prices[j];
                ratings[j+1] = ratings[j];
                j--;
                
            }
            names[j+1] = temp;
            prices[j+1] = temp1;
            ratings[j+1] = temp2;
        }


    }

    // ===================== HELPERS (do not change) =====================

    // Swaps product i and product j in ALL THREE arrays,
    // so each name stays with its own price and rating.
    static void Swap(int i, int j)
    {
        string tempName = names[i];
        names[i] = names[j];
        names[j] = tempName;

        double tempPrice = prices[i];
        prices[i] = prices[j];
        prices[j] = tempPrice;

        double tempRating = ratings[i];
        ratings[i] = ratings[j];
        ratings[j] = tempRating;
    }

    static void PrintProducts()
    {
        Console.WriteLine();
        Console.WriteLine("Product".PadRight(20) + "Price".PadRight(10) + "Rating");
        Console.WriteLine("====================================");
        for (int i = 0; i < names.Length; i++)
        {
            Console.WriteLine(names[i].PadRight(20)
                + ("$" + prices[i].ToString("F2")).PadRight(10)
                + ratings[i]);
        }
    }
}
