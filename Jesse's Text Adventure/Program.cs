using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using system IO;

namespace Jesse_s_Text_Adventure
{
    class Program
    {
        static void Main(string[] args)
        {
            string playerName;
            Console.WriteLine("Please enter your character's name.");

            playerName = Console.ReadLine();

            Console.WriteLine($"\nHi {playerName}! Welcome to Jesse's Text Adventure.\nPress any key to begin.");
            Console.ReadKey();
            Console.Clear();

            Console.WriteLine("\nWe begin our adventure at the edge of a clearing in a forest.\nNot far ahead of you, your eyes fall upon the " +
                "mouth of an eerie cave.\nSitting on a rock near the cave's enterance " +
                "is an old, hunch-backed hermit with an overflowing sack of equipment.\n" +
                "He appears to be asleep...\n");
            Console.ReadKey();

            Console.WriteLine("Will you approach the hermit or continue into the cave?\n1. Approach the hermit\n2. Enter the cave");

            string firstChoice = Console.ReadLine();

            if (firstChoice == "1")
            {
                Console.WriteLine($"You approach the hermit slowly so as not to startle him.\nWithout moving, he whispers, \"{playerName}, I've been expecting you.");
                Console.ReadKey();
                Console.WriteLine("\"There are dangerous enemies lurking in this cave and you are needed to vanquish them\", he continues, " +
                    "\"but fear not, for I have items to help you with this task!\"");
                Console.ReadKey();
            }

            else if (firstChoice == "2")
            {
                Console.WriteLine("You attempt to quietly walk past the old man, but he leaps up from his rock with a wild look in his eyes.\n" +
                    $"\"{playerName}! It's about time you showed up!\"");
                Console.ReadKey();
                Console.WriteLine("\"There are dangerous enemies lurking in this cave and you are needed to vanquish them\", he continues, " +
                    "\"but fear not, for I have items to help you with this task!\"");
                Console.ReadKey();
            }

            else
            {
                Console.WriteLine("Not a valid input, please enter your choice number");
                Console.ReadKey();
            }
        }

        public static void Start()
        {

        }

        public static void Clearing()
        {


        }
    //using (streamreader
    }
}
