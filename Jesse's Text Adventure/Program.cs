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

        public string cmd = "";
        //while(cmd != "leave"){}

        public static Enemy wolf = new Enemy();
        public static Enemy zombie = new Enemy();
        public static Enemy dragon = new Enemy();

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

            while (choiceA != "1" && choiceA != "2")
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

            Console.WriteLine("\n\"Come hither, young adventurer, and browse my wares!\"\n\n//Press any key to enter shop//");
            Console.ReadKey();
            Console.Clear();

            Inventory store = new Inventory();
            store.LoadCSV("VendorStore.csv");

            Inventory playerInv = new Inventory();
            playerInv.LoadCSV("PlayerInventory.csv");

            store.Shop(playerInv);
            store.SaveCsv();

            Console.WriteLine("\n\"Would you like to buy anything else?\" Enter \"yes\" or \"no\"");
            string choiceB = Console.ReadLine().ToLower();

            while (choiceB != "yes" && choiceB != "no")
            {
                Console.WriteLine("Invalid input, enter \"yes\" or \"no\"");
                choiceB = Console.ReadLine().ToLower();
            }

            if (choiceB == "yes")
            {
                Console.Clear();
                store.Shop(playerInv);
                store.SaveCsv();
            }

            else if (choiceB == "no")
            {
                Console.WriteLine("\n\"Very well then.\"");
            }

            Console.WriteLine("\"Would you Like to sell anything?\" Enter \"yes\" or \"no\"");
            string choiceC = Console.ReadLine().ToLower();

            while (choiceC != "yes" && choiceC != "no")
            {
                Console.WriteLine("Invalid input, enter \"yes\" or \"no\"");
                choiceC = Console.ReadLine().ToLower();
            }

            if (choiceC == "yes")
            {
                Console.Clear();
                playerInv.Sell(store);
                playerInv.SaveCsv();
            }

            else if (choiceC == "no")
            {
                Console.WriteLine("\"Very well adventurer.\"");
            }

            Console.Clear();

            Console.WriteLine($"\"I hope your new equipment serves you well, {user.playerName}, are you ready to venture onward? " +
                $"You may return to my shop after each encounter should you choose.\"" +
                $"\n1. Enter the cave\n2. Return to shop");

            string choiceD = Console.ReadLine();

            while (choiceD != "1" && choiceD != "2")
            {
                Console.WriteLine("Not a valid input, please enter your choice number");
                choiceD = Console.ReadLine();
                Console.Clear();
            }

            if (choiceD == "1")
            {
                Console.Clear();
                Console.WriteLine("You put on a brave face and let the darkness engulf you as you step forward into the maw of the cave...");
                Console.ReadKey();
            }

            else if (choiceD == "2")
            {
                Console.Clear();
                store.Shop(playerInv);
                store.SaveCsv();
                Console.Clear();
                Console.WriteLine("Feeling slightly more prepared, you put on a brave face and let the darkness engulf you as you step forward into the maw of the cave...");
                Console.ReadKey();
            }

            Console.WriteLine("\nJust as the last remnants of light fade out behind you, torches along the cave wall mysteriously spring to life, \nilluminating your surroundings and beyond.");
            Console.ReadKey();
            Console.WriteLine("\nIt is then you notice a growling wolf blocking your path!\n" +
                "Press any key to begin fight");
            Console.ReadKey();

            
            //user.playerAttack = 30;
            wolf.BattleOne();

            Console.Clear();
            Console.WriteLine("Leaving the corpse of the wolf behind you, you continue farther into the cave." +
                "Around a corner farther up the path, \n" +
                "you here a garbled groaning sound that seems to be getting louder...\n");
            Console.ReadKey();
            Console.WriteLine("\nJust as the shadow of it appears around the bend, the source of the noise becomes clear..." +
                "It's a ZOMBIE!\n\nPress any key to begin fight");
            Console.ReadKey();

            //BattleTwo();

            Console.Clear();
            Console.WriteLine("Leaving the corpse of the...corpse behind you, you continue onward yet again, wondering what your next dance with death will involve.\n" +
                "Maybe a bear? Or possibly a troll?");
            Console.ReadKey();
            Console.WriteLine("You notice the light in the cave begin to intensify, though the winding path obstructs your vision from what this second source of light may be.\n" +
                "The temperature around you seems to rise in tandem  with the brightness.\n" +
                "And then a mighty roar confirms your fears...\n\n");
            Console.ReadKey();
            Console.WriteLine("The final enemy is a fire breathing dragon!\n\nPress any key to begin fight");
            Console.ReadKey();

            //BattleThree();

            Console.Clear();
            Console.WriteLine("Exhausted from the days battles, and lugging your inventory around, you depart the cave for the first and last time.\n" +
                "You wave to the old vendor, who gives only a nod in return, and head home to take a well-earned nap.");
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("Congratulations, You WIN!!!");
            Console.ReadKey();
            return;
        }
    }
    
}
