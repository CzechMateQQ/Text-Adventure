using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jesse_s_Text_Adventure
{
    public class Enemy
    {
        //Initializes enemy stat variables
        public int health = -1;

        public int attack = -1;

        //Uses class inheritance to derive multiple enemy types from the base Enemy class
        public class Wolf : Enemy
        {
            //Creates random attack numbers for each enemy type
            Random wolfRand = new Random();
            public Wolf()
            {
                health = 100;
                attack = wolfRand.Next(5, 10);
            }
        }

        public class Zombie : Enemy
        {
            Random zombRand = new Random();
            public Zombie()
            {
               health = 150;
               attack = zombRand.Next(10, 15);
            }
        }

        public class Dragon : Enemy
        {
            Random dragRand = new Random();
            public Dragon()
            {
                health = 200;
                attack = dragRand.Next(20, 25);
            }
        }

        //Method for each instance of combat called in main program
        public void BattleOne()
        {
            Console.WriteLine("//Wolf battle commence//");
            //Loop while both player and enemy have health remaining
            while (Player.PlayerHealth() > 0 && Program.wolf.health > 0)
            {
                Program.user.playerHealth -= Program.wolf.attack;
                Console.WriteLine($"\nThe wolf attacks and does {Program.wolf.attack} damage!\n" +
                    $"You have {Player.PlayerHealth()} health remaining.");
                Console.ReadKey();
                Program.wolf.health -= Player.PlayerAttack();
                Console.WriteLine($"\nYou attack the wolf for {Player.PlayerAttack()} damage!\n" +
                    $"The wolf has {Program.wolf.health} remaining.");
                Console.ReadKey();
            }

            //If wolf dies
            if (Program.wolf.health <= 0)
            {
                Console.Clear();
                Console.WriteLine("You have defeated the wolf!");
                Program.user.playerGold += 150;
                Console.WriteLine("You earned 150 gold!");
                Console.ReadKey();
            }

            //If player dies
            else if (Player.PlayerHealth() <= 0)
            {
                Console.Clear();
                Console.WriteLine("\nYOU LOSE.....");
                Console.ReadKey();
                return;
            }
        }

        public void BattleTwo()
        {
            Console.WriteLine("//Zombie battle commence//");
            while (Player.PlayerHealth() > 0 && Program.zombie.health > 0)
            {
                Program.user.playerHealth -= Program.zombie.attack;
                Console.WriteLine($"\nThe zombie attacks and does {Program.zombie.attack} damage!\n" +
                    $"You have {Player.PlayerHealth()} health remaining.");
                Console.ReadKey();
                Program.zombie.health -= Player.PlayerAttack();
                Console.WriteLine($"\nYou attack the zombie for {Player.PlayerAttack()} damage!\n" +
                    $"The zombie has {Program.zombie.health} remaining.");
                Console.ReadKey();
            }

            if (Program.zombie.health <= 0)
            {
                Console.Clear();
                Console.WriteLine("You have defefated the zombie!");
                Program.user.playerGold += 200;
                Console.WriteLine("You earned 200 gold!");
                Console.ReadKey();
            }

            else if (Player.PlayerHealth() <= 0)
            {
                Console.Clear();
                Console.WriteLine("\nYOU LOSE.....");
                Console.ReadKey();
                return;
            }
        }

        public void BattleThree()
        {
            Console.WriteLine("//Dragon battle commence//");
            while (Player.PlayerHealth() > 0 && Program.dragon.health > 0)
            {
                Program.user.playerHealth -= Program.dragon.attack;
                Console.WriteLine($"\nThe dragon attacks and does {Program.dragon.attack} damage!\n" +
                    $"You have {Player.PlayerHealth()} health remaining.");
                Console.ReadKey();
                Program.dragon.health -= Player.PlayerAttack();
                Console.WriteLine($"\nYou attack the dragon for {Player.PlayerAttack()} damage!\n" +
                    $"The dragon has {Program.dragon.health} remaining.");
                Console.ReadKey();
            }

            if (Program.dragon.health <= 0)
            {
                Console.Clear();
                Console.WriteLine("You have defeated the dragon!");
                Program.user.playerGold += 500;
                Console.WriteLine("You earned 500 gold!!!");
                Console.ReadKey();
            }

            else if (Player.PlayerHealth() <= 0)
            {
                Console.Clear();
                Console.WriteLine("\nYOU LOSE.....");
                Console.ReadKey();
                return;
            }
        }

    }
}
