using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW4
{
    class Program
    {
        static void Main(string[] args)
        {
            //initializes the list, makes the rng
            LinkedList list = new LinkedList();
            Random rand = new Random();

            while(true)
            {
                //asks the user for input, changes the response to all lowercase
                Console.Write("Type a string: ");
                string userInput = Console.ReadLine().ToLower();

                //ends the program if the user types q or quit
                if(userInput == "quit" || userInput == "q")
                {
                    break;
                }

                //prints the elements of the list out if the user types print
                else if(userInput == "print")
                {
                    //doesn't print anything if the list is empty
                    if(list.Count == 0)
                    {
                        Console.WriteLine("There are no items in the list.");
                    }

                    //for loop that runs through the entire list
                    for(int i = 0; i < list.Count; i++)
                    {
                        Console.WriteLine(list.GetElement(i));
                    }
                }

                //clears the list entirely if the user types clear
                else if(userInput == "clear")
                {
                    list.Clear();
                    Console.WriteLine("List cleared");
                }

                //removes random element from the list
                else if(userInput == "remove")
                {
                    //if there is nothing in the list, nothing can be removed
                    if (list.Count == 0)
                    {
                        Console.WriteLine("List empty. Can't remove.");
                        continue;
                    }

                    list.Remove(rand.Next(0, list.Count));
                    Console.WriteLine("Random item removed.");
                }

                //mixes up the items of the list
                else if(userInput == "scramble")
                {
                    //if there's nothing in the list, scramble cannot be completed
                    if(list.Count == 0)
                    {
                        Console.WriteLine("List empty. Can't scramble.");
                        continue;
                    }

                    list.Insert(list.Remove(rand.Next(0, list.Count)), rand.Next(0, list.Count));
                    Console.WriteLine("Random item has been scrambled.");
                }

                //tells the user how long the list is
                else if(userInput == "count")
                {
                    Console.WriteLine("Count: " + list.Count);
                }

                //otherwise, adds whatever the user types to the list
                else
                {
                    list.Add(userInput);
                    Console.WriteLine(userInput + " has been added to the list.");
                }

            }

            //ends the program
            Console.WriteLine("Goodbye.");
        }
    }
}
