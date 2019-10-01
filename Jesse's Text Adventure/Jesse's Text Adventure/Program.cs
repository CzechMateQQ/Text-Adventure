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
        //Create new player from Player class
        public static Player user = new Player();

        //Introduction method
        public static void Intro()
        {
            Console.WriteLine("Welcome to Jesse's Text Adventure!");
            Console.Clear();


            Console.WriteLine("Please enter your character's name (At least 3 characters).");

            user.playerName = Console.ReadLine();

            //Loop until user enters valid name
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

        //Initialize enemies
        public static Enemy.Wolf wolf = new Enemy.Wolf();
        public static Enemy.Zombie zombie = new Enemy.Zombie();
        public static Enemy.Dragon dragon = new Enemy.Dragon();

        //Initializes store and inventory
        public static Inventory playerInv = new Inventory();
        public static Inventory store = new Inventory();

        static void Main(string[] args)
        {
            Intro();

            Console.WriteLine("We begin our adventure at the edge of a clearing in a forest.\n\nNot far ahead of you, your eyes fall upon the " +
                "mouth of an eerie cave.\n\nSitting on a rock near the cave's entrance " +
                "is an old, hunch-backed hermit with an overflowing sack of equipment.\n" +
                "\nHe appears to be asleep...\n");
            Console.ReadKey();

            Console.WriteLine("Will you approach the hermit or continue into the cave?\n1. Approach the hermit\n2. Enter the cave");

            string choiceA = Console.ReadLine();

            //Waits for proper input
            while (choiceA != "1" && choiceA != "2")
            {
                Console.WriteLine("Not a valid input, please enter your choice number");
                choiceA = Console.ReadLine();
            }

            //Conditional statement for options
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

            //Loads CSV documents
            //One for store and one for player inventory
            store.LoadCSV("VendorStore.csv");
            playerInv.LoadCSV("PlayerInventory.csv");

            //Shop method from inventory class
            store.Shop(playerInv);
            //Save method from Inventory class
            store.SaveCsv();

            //Shop method to be called after every battle
            void ShopKeeper()
            {
                bool StayInLoop = true;
                //Loop to choose between "buy", "sell", and "leave"
                while (StayInLoop)
                {
                    Console.WriteLine("\nWhat would you like to do next? \"buy\", \"sell\", \"leave\"");
                    string shopOptions = Console.ReadLine().ToLower();
                    while (shopOptions != "buy" && shopOptions != "sell" && shopOptions != "leave")
                    {
                        Console.WriteLine("Invalid input, please try again");
                        shopOptions = Console.ReadLine().ToLower();
                    }
                    switch (shopOptions)
                    {
                        case "buy":
                            Console.Clear();
                            store.Shop(playerInv);
                            store.SaveCsv();
                            break;

                        case "sell":
                            Console.Clear();
                            playerInv.Sell(store);
                            playerInv.SaveCsv();
                            break;

                        case "leave":
                            StayInLoop = false;
                            break;
                    }
                }
            }

            ShopKeeper();

            Console.Clear();

            Console.WriteLine("These are your weapons:\n");
            playerInv.DisplayWeapons();
            Console.ReadKey();
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
                ShopKeeper();
                Console.WriteLine("Feeling slightly more prepared, you put on a brave face and let the darkness engulf you as you step forward into the maw of the cave...");
                Console.ReadKey();
            }

            Console.WriteLine("\nJust as the last remnants of light fade out behind you, torches along the cave wall mysteriously spring to life, \nilluminating your surroundings and beyond.");
            Console.ReadKey();
            Console.WriteLine("\nIt is then you notice a growling wolf blocking your path!\n\n" +
                "//Press any key to begin fight//");
            Console.ReadKey();
            Console.Clear();

            //Battle method called from Enemy class
            wolf.BattleOne();
            ShopKeeper();

            Console.Clear();
            Console.WriteLine("Leaving the corpse of the wolf behind you, you continue farther into the cave." +
                "Around a corner farther up the path, \n" +
                "you here a garbled groaning sound that seems to be getting louder...\n");
            Console.ReadKey();
            Console.WriteLine("\nJust as the shadow of it appears around the bend, the source of the noise becomes clear...It's a ZOMBIE!\n\n" +
                "//Press any key to begin fight//");
            Console.ReadKey();
            Console.Clear();

            //Battle method called from Enemy class
            zombie.BattleTwo();
            ShopKeeper();

            Console.Clear();
            Console.WriteLine("Leaving the corpse of the...corpse behind you, you continue onward yet again, wondering what your next dance with death will involve.\n" +
                "Maybe a bear? Or possibly a troll?");
            Console.ReadKey();
            Console.WriteLine("\nYou notice the light in the cave begin to intensify, though the winding path obstructs your vision from what this second source of light may be.\n\n" +
                "The temperature around you seems to rise in tandem  with the brightness.\n\n" +
                "And then a mighty roar confirms your fears...\n\n");
            Console.ReadKey();
            Console.WriteLine("The final enemy is a fire breathing dragon!\n\n" +
                "//Press any key to begin fight//");
            Console.ReadKey();
            Console.Clear();

            //Battle method called from Enemy class
            dragon.BattleThree();
            ShopKeeper();

            Console.Clear();
            Console.WriteLine("Exhausted from the days battles, and lugging your inventory around, you depart the cave for the first and last time.\n" +
                "You wave to the old vendor, who gives only a nod in return, and head home with your loot to take a well-earned nap.");
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("Congratulations, You WIN!!!");
            Console.ReadKey();
            return;
        }
    }
}
