using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jesse_s_Text_Adventure
{
    public class Enemy
    {
        public int wolfHealth = 100;
        public int zombieHealth = 150;
        public int dragonHealth = 200;

        public int wolfAttack;
        public int zombieAttack;
        public int dragonAttack;

        public class Wolf : Enemy
        {
            Random wolfRand = new Random();
            public Wolf()
            {
                wolfAttack = wolfRand.Next(5, 10);
            }
        }

        class Zombie : Enemy
        {
            Random zombRand = new Random();
            public Zombie()
            {
                zombieAttack = zombRand.Next(15, 20);
            }
        }

        class Dragon : Enemy
        {
            Random dragRand = new Random();
            public Dragon()
            {
                dragonAttack = dragRand.Next(30, 35);
            }
        }

        public void BattleOne()
        {
            Console.WriteLine("//Wolf battle commence//");
            while (Program.user.playerHealth > 0 && Program.wolf.wolfHealth > 0)
            {
                Program.user.playerHealth -= Program.wolf.wolfAttack;
                Console.WriteLine($"\nThe wolf attacks and does {Program.wolf.wolfAttack} damage!\n" +
                    $"You have {Program.user.playerHealth} health remaining.");
                Console.ReadKey();
                Program.wolf.wolfHealth -= Program.user.playerAttack;
                Console.WriteLine($"\nYou attack the wolf for {Program.user.playerAttack} damage!\n" +
                    $"The wolf has {Program.wolf.wolfHealth} remaining.");
                Console.ReadKey();
            }

            if (Program.wolf.wolfHealth <= 0)
            {
                Console.Clear();
                Console.WriteLine("You have defefated the wolf!");
                Program.user.playerGold += 150;
                Console.WriteLine("You earned 150 gold!");
                Console.ReadKey();
            }

            else if (Program.user.playerHealth <= 0)
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
            while (Program.user.playerHealth > 0 && Program.zombie.zombieHealth > 0)
            {
                Program.user.playerHealth -= Program.zombie.zombieAttack;
                Console.WriteLine($"\nThe zombie attacks and does {Program.zombie.zombieAttack} damage!\n" +
                    $"You have {Program.user.playerHealth} health remaining.");
                Console.ReadKey();
                Program.zombie.zombieHealth -= Program.user.playerAttack;
                Console.WriteLine($"\nYou attack the zombie for {Program.user.playerAttack} damage!\n" +
                    $"The zombie has {Program.zombie.zombieHealth} remaining.");
                Console.ReadKey();
            }

            if (Program.zombie.zombieHealth <= 0)
            {
                Console.Clear();
                Console.WriteLine("You have defefated the zombie!");
                Program.user.playerGold += 200;
                Console.WriteLine("You earned 200 gold!");
                Console.ReadKey();
            }

            else if (Program.user.playerHealth <= 0)
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
            while (Program.user.playerHealth > 0 && Program.dragon.dragonHealth > 0)
            {
                Program.user.playerHealth -= Program.dragon.dragonAttack;
                Console.WriteLine($"\nThe dragon attacks and does {Program.dragon.dragonAttack} damage!\n" +
                    $"You have {Program.user.playerHealth} health remaining.");
                Console.ReadKey();
                Program.dragon.dragonHealth -= Program.user.playerAttack;
                Console.WriteLine($"\nYou attack the dragon for {Program.user.playerAttack} damage!\n" +
                    $"The dragon has {Program.dragon.dragonHealth} remaining.");
                Console.ReadKey();
            }

            if (Program.dragon.dragonHealth <= 0)
            {
                Console.Clear();
                Console.WriteLine("You have defefated the dragon!");
                Program.user.playerGold += 500;
                Console.WriteLine("You earned 500 gold!!!");
                Console.ReadKey();
            }

            else if (Program.user.playerHealth <= 0)
            {
                Console.Clear();
                Console.WriteLine("\nYOU LOSE.....");
                Console.ReadKey();
                return;
            }
        }
    }
}
