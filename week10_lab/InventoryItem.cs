using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace week10_lab
{
    public class InventoryItem
    {
        public int ItemN {  get; set; }

        public string Description { get; set; }

        public double Price { get; set; }


        public override string ToString()
        {
            return ItemN + "|" + Description + "|" + Price;
        }
    }
}
