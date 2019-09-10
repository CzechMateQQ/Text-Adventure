using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Jesse_s_Text_Adventure
{
    class Program
    {
        public static Player user = new Player();
        public static void Intro()
        {
            Console.WriteLine("Welcome to Jesse's Text Adventure!");
            Console.Clear();

            
            Console.WriteLine("Please enter your character's name (At least 3 characters).");

            user.playerName = Console.ReadLine();

            while (user.playerName.Length < 3)
            {
                Console.WriteLine("Your name must be at least 3 characters long, please try again");
                user.playerName = Console.ReadLine();
            }

            Console.Clear();
            Console.WriteLine($"Hi {user.playerName}! Welcome to Jesse's Text Adventure.\n\n//Press any key to begin//");
            Console.ReadKey();
            Console.Clear();
        }
        static void Main(string[] args)
        {
            Intro();

            Console.WriteLine("We begin our adventure at the edge of a clearing in a forest.\n\nNot far ahead of you, your eyes fall upon the " +
                "mouth of an eerie cave.\n\nSitting on a rock near the cave's enterance " +
                "is an old, hunch-backed hermit with an overflowing sack of equipment.\n" +
                "\nHe appears to be asleep...\n");
            Console.ReadKey();

            Console.WriteLine("Will you approach the hermit or continue into the cave?\n1. Approach the hermit\n2. Enter the cave");

            string choiceA = Console.ReadLine();

            while (choiceA != "1" && choiceA != "2" )
            {
                Console.WriteLine("Not a valid input, please enter your choice number");
                choiceA = Console.ReadLine();
            }

            if (choiceA == "1")
            {
                Console.WriteLine($"\nYou approach the hermit slowly so as not to startle him.\nWithout moving, he whispers, \"{user.playerName}, I've been expecting you.");
                Console.ReadKey();
                Console.WriteLine("\n\"There are dangerous enemies lurking in this cave and you are needed to vanquish them\", he continues, " +
                    "\"but fear not, for I have items to help you with this task!\"");
                Console.ReadKey();
            }

            else if (choiceA == "2")
            {
                Console.WriteLine("\nYou attempt to quietly walk past the old man, but he leaps up from his rock with a wild look in his eyes.\n" +
                    $"\"{user.playerName}! It's about time you showed up!\"");
                Console.ReadKey();
                Console.WriteLine("\n\"There are dangerous enemies lurking in this cave and you are needed to vanquish them\", he continues, " +
                    "\"but fear not, for I have items to help you with this task!\"");
                Console.ReadKey();
            }

            Console.WriteLine("\nCome hither, young adventurer, and browse my wares!\n\n//Press any key to enter shop//");
            Console.ReadKey();
            Console.Clear();

            Inventory store = new Inventory();
            store.LoadCSV("VendorStore.csv");

            store.Shop();

            Inventory playerInv = new Inventory();
            playerInv.LoadCSV("PlayerInventory.csv");


            Console.WriteLine("Would you Like to sell anything? Enter \"yes\" or \"no\"");          
            string choiceB = Console.ReadLine().ToLower();

            while(choiceB != "yes" && choiceB != "no")
            {
                Console.WriteLine("Invalid input, enter \"yes\" or \"no\"");
                choiceB = Console.ReadLine().ToLower();
            }

            if (choiceB == "yes")
            {
                playerInv.Sell();
            }

            else if (choiceB == "no")
            {
                Console.WriteLine("Very well adventurer.");
            }




            

            Console.WriteLine($"I hope your new equipment serves you well, {user.playerName}, are you ready to venture onward? " +
                $"You may return to my shop after each encounter should you choose." +
                $"\n1. Enter the cave\n2. Return to shop");

            string choiceC = Console.ReadLine();

            while (choiceC != "1" && choiceC != "2")
            {
                Console.WriteLine("Not a valid input, please enter your choice number");
                choiceC = Console.ReadLine();
                Console.Clear();
            }

            if (choiceC == "1")
            {
                Console.Clear();
                Console.WriteLine("You put on a brave face and let the darkness engulf you as you step forward into the maw of the cave...");
                Console.ReadKey();
            }

            else if (choiceC == "2")
            {
                Console.Clear();
                //store
                //Console.Clear();
                Console.WriteLine("Feeling slightly more prepared, you put on a brave face and let the darkness engulf you as you step forward into the maw of the cave...");
                Console.ReadKey();
            }

            Console.WriteLine("\nJust as the last remnants of light fade out behind you, torches along the cave wall mysteriously spring to life, \nilluminating your surroundings and beyond.");
            Console.ReadKey();
            Console.WriteLine("\nIt is then you notice a growling wolf blocking your path!\n" +
                "Press any key to begin fight");
            Console.ReadKey();

            //BattleOne();



        }
    
    }
}
