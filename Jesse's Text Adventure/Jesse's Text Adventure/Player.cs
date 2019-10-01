using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jesse_s_Text_Adventure
{
    class Player
    {
        public string playerName;
        public int playerGold = 100;
        public int playerHealth = 100;
        public int playerAttack = 30;

        //Modifies player attack with weapon attack stat in inventory
        public static int PlayerAttack()
        {
            int total = 0;
            foreach(Item it in Program.playerInv.ItemList)
            {
               total += it.Attack;
            }
            return Program.user.playerAttack + total;
        }

        //Modifies player health with armor defense stat in inventory
        public static int PlayerHealth()
        {
            int total = 0;
            foreach (Item it in Program.playerInv.ItemList)
            {
                total += it.Armor;
            }
            return Program.user.playerHealth + total;
        }
    }
}
