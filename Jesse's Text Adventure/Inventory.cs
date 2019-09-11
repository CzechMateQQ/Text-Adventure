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
        public string fileName;
        public void LoadCSV(string ItemString)
        {
            List<string> ItemStringList = new List<string>();
            fileName = ItemString;
            using (StreamReader sr = new StreamReader(ItemString))
            {
                sr.ReadLine();
                while (!sr.EndOfStream)
                {
                    ItemStringList.Add(sr.ReadLine());
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
                Console.WriteLine(
                    $"ID #: {idx + 1}, " +
                    $"Name: {ItemList[idx].ItemName}, " +
                    $"Attack Power: {ItemList[idx].Attack}, " +
                    $"Armor: {ItemList[idx].Armor}, " +
                    $"Weight: {ItemList[idx].Weight}, " +
                    $"Cost: {ItemList[idx].Cost}");
                Console.WriteLine("\n");
            }
        }

        public void ShowItem(Item it)
        {
            Console.WriteLine($"{it.ItemName}, " +
                $"Attack: {it.Attack}, " +
                $"Armor: {it.Armor}, " +
                $"Weight: {it.Weight}, " +
                $"Cost: {it.Cost}");
        }

        public void Shop(Inventory customer)
        {
            ShowItemList();
            Console.WriteLine($"\nYou currently have {Program.user.playerGold} gold.");
            Console.WriteLine("\n//Select item's ID # to purchase//");

            int purchaseItem;
            while (!int.TryParse(Console.ReadLine(), out purchaseItem))
            { }

            while (Program.user.playerGold < ItemList[purchaseItem - 1].Cost)
            {
                Console.WriteLine($"You only have {Program.user.playerGold} gold.");
                while (!int.TryParse(Console.ReadLine(), out purchaseItem))
                { }
            }

            customer.ItemList.Add(ItemList[purchaseItem - 1]);
            ItemList.RemoveAt(purchaseItem - 1);

            Console.Clear();
            Console.WriteLine("You have purchased:\n");

            ShowItem(ItemList[purchaseItem - 1]);
            Program.user.playerGold -= ItemList[purchaseItem - 1].Cost;
            Console.WriteLine($"\nYou now have {Program.user.playerGold} gold.");
            Console.ReadKey();

        }

        public void Sell(Inventory seller)
        {
            ShowItemList();

            Console.WriteLine("//Select item's ID # to sell//");

            int sellItem;
            while (!int.TryParse(Console.ReadLine(), out sellItem))
            { }

            seller.ItemList.Add(ItemList[sellItem - 1]);
            ItemList.RemoveAt(sellItem - 1);

            Console.WriteLine("You have sold: ");
            ShowItem(ItemList[sellItem - 1]);
            Program.user.playerGold += ItemList[sellItem - 1].Cost;
            Console.WriteLine($"\nYou now have {Program.user.playerGold} gold.");
            Console.ReadKey();
        }

        public void SaveCsv()
        {
            using (StreamWriter sw = new StreamWriter(fileName))
            {
                sw.WriteLine("ItemId,ItemName,Attack,Armor,Weight,Cost");

                foreach (Item it in ItemList)
                {
                    sw.WriteLine($"{it.ItemId}," +
                        $"{it.ItemName}," +
                        $"{it.Attack}," +
                        $"{it.Armor}," +
                        $"{it.Weight}," +
                        $"{it.Cost}");
                }
                sw.Close();
            }
        }
    }        
}


