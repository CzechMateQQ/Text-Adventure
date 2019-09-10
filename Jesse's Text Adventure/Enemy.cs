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
    }

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


}
