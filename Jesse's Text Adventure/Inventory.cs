using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Jesse_s_Text_Adventure
{
    public class Inventory
    {
        public List<Item> ItemList = new List<Item>();
        public void LoadCSV(string ItemString)
        {
            List<string> ItemStringList = new List<string>();

            using (StreamReader stream1 = new StreamReader(ItemString))
            {
                stream1.ReadLine();
                while(!stream1.EndOfStream)
                {
                    ItemStringList.Add(stream1.ReadLine());
                }
            }

            string[] tmpValues;

            List<Item> items = new List<Item>();

            foreach (string line in ItemStringList)
            {
                Item tmpItem = new Item();
                tmpValues = line.Split(',');
                tmpItem.ItemId = int.Parse(tmpValues[0]);
                tmpItem.ItemName = tmpValues[1];
                tmpItem.Attack = int.Parse(tmpValues[2]);
                tmpItem.Armor = int.Parse(tmpValues[3]);
                tmpItem.Weight = int.Parse(tmpValues[4]);
                tmpItem.Cost = int.Parse(tmpValues[5]);

                ItemList.Add(tmpItem);
            }
           
        }

        public void ShowItemList()
        {
            for (int idx = 0; idx < ItemList.Count; ++idx)
            {
                Console.WriteLine($"ID #: {ItemList[idx].ItemId}, Name: {ItemList[idx].ItemName}, Attack Power: {ItemList[idx].Attack}," +
                    $" Armor: {ItemList[idx].Armor}, Weight: {ItemList[idx].Weight}, Cost: {ItemList[idx].Cost}");
                Console.WriteLine("\n");
            }
        }
       
        public void ShowItem(Item it)
        {
            Console.WriteLine($"{it.ItemName}, Attack: {it.Attack}, Armor: {it.Armor}, Weight: {it.Weight}, Cost: {it.Cost}");
        }

        public void Shop()
        {
            ShowItemList();

            Console.WriteLine("\n//Select item's ID # to purchase//");

            int purchaseItem;
            while(! int.TryParse(Console.ReadLine(), out purchaseItem))
            { }

            if (Program.user.playerGold > ItemList[purchaseItem - 1].Cost)
            {


                Console.WriteLine("You have purchased: ");
                ShowItem(ItemList[purchaseItem - 1]);     

                Console.ReadKey();

                Console.Clear();
            }

        }

        public void Sell()
        {
            ShowItemList();

            Console.WriteLine("//Select item's ID # to sell//");

            int sellItem;
            while (!int.TryParse(Console.ReadLine(), out sellItem))
            { }

            Console.WriteLine("You have sold: ");
            ShowItem(ItemList[sellItem - 1]);

            Console.ReadKey();
        }
    }
}


