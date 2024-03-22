using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace week10_lab
{
    public partial class Addview : Form
    {
        public Addview()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            InventoryItem inventory = new InventoryItem();

            // Validate Item Number
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("Please enter an integer number for the Item number field.", "Entry Error");
                return; 
            }

            // Validate Description
            if (string.IsNullOrWhiteSpace(textBox2.Text))
            {
                MessageBox.Show("Please enter a description for the item.", "Entry Error");
                return; 
            }

            // Validate Price
            if (string.IsNullOrWhiteSpace(textBox3.Text))
            {
                MessageBox.Show("Please enter a price for the item.", "Entry Error");
                return; 
            }

            try
            {
                // Parse and set Item Number
                int itemN = Convert.ToInt32(textBox1.Text);
                inventory.ItemN = itemN;
            }
            catch (FormatException)
            {
                MessageBox.Show("Please enter a valid integer number for the Item number field.", "Entry Error");
                return; 
            }

            // Set Description
            inventory.Description = textBox2.Text;

            try
            {
                // Parse and set Price
                double price = Convert.ToDouble(textBox3.Text);
                inventory.Price = price;
            }
            catch (FormatException)
            {
                MessageBox.Show("Please enter a valid number for the price field.", "Entry Error");
                return; 
            }

            // If all validations pass, add the item to the inventory
            InventoryDB.items.Add(inventory);
            var temp = InventoryDB.items;
            InventoryDB.SaveItems(temp);

            
            this.Close();


        }

        private void Addview_Load(object sender, EventArgs e)
        {

        }
    }
}
