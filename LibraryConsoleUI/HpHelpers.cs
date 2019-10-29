using System;
using System.Collections.Generic;

namespace LibraryConsoleUI
{
    /// <summary>
    /// My personal class library that helps me with such things as getting input (with error handling)
    /// from user, displaying a menu etc.
    /// </summary>
    public static class HpHelpers
    {
        /// <summary>
        /// Closes the application after user confirmation
        /// </summary>
        public static void ExitApp()
        {
            System.Console.WriteLine("Do you want to exit the application? y/n");
            var userInput = Console.ReadKey();
            if (userInput.Key == ConsoleKey.Y)
            {
                Environment.Exit(-1);              
            }
        }

    	/// <summary>
    	/// Takes an array of menu titles and returns the index of the title selected by the user
    	/// </summary>
    	/// <param name="menuItems"></param>
    	/// <returns>The selected index of the provided menu options in array</returns>
		public static int MenuHandler(string[] menuItems)
		{
			int selectedIndex = 0;
			string[] menuOptions = menuItems;

			while (true)
			{
                Console.Clear();

				for (int i = 0; i < menuItems.Length; i++)
				{
					if (i == selectedIndex)
					{
						Console.ForegroundColor = ConsoleColor.Blue;
						System.Console.WriteLine(menuItems[i]);
						Console.ResetColor();
					}
					else
					{
					System.Console.WriteLine(menuItems[i]);
					}
				}

				// Read user input
				var inputKey = Console.ReadKey();

				if (inputKey.Key == ConsoleKey.DownArrow && selectedIndex < (menuItems.Length -1))
				{
					selectedIndex++;
				}
				else if (inputKey.Key == ConsoleKey.UpArrow && selectedIndex > 0)
				{
					selectedIndex--;          
				}
				else if (inputKey.Key == ConsoleKey.Enter)
				{
					return selectedIndex;
				}
			}
		}

        // Overloaded Generic menuhandler
        public static T MenuHandler<T>(List<T> menuItems)
        {
            int selectedIndex = 0;
            while (true)
			{
                Console.Clear();

                for (int i = 0; i < menuItems.Count; i++)
                {
                    if (i == selectedIndex)
					{
						Console.ForegroundColor = ConsoleColor.Blue;
						System.Console.WriteLine(menuItems[i].ToString());
						Console.ResetColor();
					}
					else
					{
					System.Console.WriteLine(menuItems[i].ToString());
					}                    
                }

                // Read user input
				var inputKey = Console.ReadKey();
				if (inputKey.Key == ConsoleKey.DownArrow && selectedIndex < (menuItems.Count -1))
				{
					selectedIndex++;
				}
				else if (inputKey.Key == ConsoleKey.UpArrow && selectedIndex > 0)
				{
					selectedIndex--;          
				}
				else if (inputKey.Key == ConsoleKey.Enter)
				{
					return menuItems[selectedIndex];
				}
            }
        }

        /// <summary>
        /// Returns an int. Prints out message in console
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public static int GetInt(string message)
        {
            int output = 0;
            System.Console.Write(message);
            while(!Int32.TryParse(Console.ReadLine(), out output))
            {
                System.Console.WriteLine("Unvalid input!");
                System.Console.Write(message);
            }
            return output;
        }

        /// <summary>
        /// Returns a boolean value. Prints out message in console
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public static bool GetBool(string message)
        {
            string[] yesNo = new string[] {"Yes", "No"};
            System.Console.Write(message + "y/n?");
            var selection = Console.ReadKey();
            if (selection.Key == ConsoleKey.Y)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Returns a long value. Prints out message in console
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public static long GetLong(string message)
        {
            long output;
            System.Console.Write(message);
            while(!long.TryParse(Console.ReadLine(), out output))
            {
                System.Console.WriteLine("Unvalid input!");
                System.Console.Write(message);
            }
            return output;
        }
        
        /// <summary>
        /// Returns an decimal. Prints out message provided to user
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public static decimal GetDecimal(string message)
        {
            decimal output = 0;
            System.Console.Write(message);
            while(!Decimal.TryParse(Console.ReadLine(), out output))
            {
                System.Console.WriteLine("Unvalid input!");
                System.Console.Write(message);
            }
            return output;
        }

        /// <summary>
        /// Returns an string. Prints out message provided to user
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public static string GetString(string message)
        {
            System.Console.Write(message);
            return Console.ReadLine();
        }

        /// <summary>
        /// Converts a string to have the first character uppercase, and the rest lowercase
        /// </summary>
        /// <param name="inputString"></param>
        /// <returns></returns>
        public static string FirstToUpper(string inputString)
        {
            string output = "";
            //String has to be longer than 2 chars
            if (inputString.Length > 1)
            {
                // Take first letter
                string firstPart = inputString.Substring(0, 1);
                // And take the rest of the string
                string secondPart = inputString.Substring(1);
                // Make first character uppercase
                firstPart = firstPart.ToUpper();
                // Make the second part lowercase
                secondPart = secondPart.ToLower();
                // Concatinate the two parts to one part and set it as output
                output = firstPart + secondPart;
            }
            else if (inputString.Length == 1)
            {
                // Only one character in input, return it uppercase.
                output = inputString.ToUpper();
            }
            else
            {
                // No string long enough, return same string as input
                output = inputString;
            }
            return output;
        }

        /// <summary>
        /// Extension method that trims a string to maximum length given as input(width)
        /// </summary>
        /// <param name="text"></param>
        /// <param name="width"></param>
        /// <returns></returns>
        public static string FormatStringLength(this string text, int width)
        {
            // If string is longer then width, return substring with length(width), else return the string unmodified.
            string output = text.Length > width ? text.Substring(0, width) : text;
            return output;
        }      
    }
}