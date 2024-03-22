using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace week10_lab
{
    public static class InventoryDB
    {
        // create the list
        public static List<InventoryItem> items = new List<InventoryItem>();
        private const string Path = @"C:\Users\Taken\Desktop\App Dev C#.Net\grocery_inventory_items.txt";
        private const char Delimiter = '|';


        public static List<InventoryItem> GetItems()
        {
            
            items.Clear();   //clear one should be here in order to work properly

            // create the object for the input stream for a text file
            StreamReader textIn =
                new StreamReader(
                new FileStream(Path, FileMode.OpenOrCreate, FileAccess.Read));


            // read the data from the file and store it in the list
            while (textIn.Peek() != -1)
            {
                string row = textIn.ReadLine() ?? "";
                string[] columns = row.Split(Delimiter);


                if (columns.Length == 3)
                {
                    InventoryItem item = new InventoryItem()
                    {
                        ItemN = Convert.ToInt32(columns[0]),
                        Description = columns[1],
                        Price = Convert.ToDouble(columns[2])
                    };
                    items.Add(item);
                }
            }


            // close the input stream for the text file
            textIn.Close();


            return items;
        }


        public static void SaveItems(List<InventoryItem> items)
        {
            // create the output stream for a text file that exists
             StreamWriter textOut =
                new StreamWriter(
                new FileStream(Path, FileMode.Create, FileAccess.Write));


            // write each item
            foreach (InventoryItem item in items)
            {
                textOut.Write(item.ItemN.ToString() + Delimiter);
                textOut.Write(item.Description.ToString() + Delimiter);
                textOut.WriteLine(item.Price.ToString());
            }


            // close the output stream for the text file
            textOut.Close();
        }
        // method to delete the item from the listbox
        public static void RemoveItem(InventoryItem item)
        {
           items.Remove(item);
        }
    }
}
