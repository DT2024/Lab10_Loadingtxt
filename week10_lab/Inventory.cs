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
    public partial class Inventory : Form
    {

        public Inventory()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Addview form = new Addview();
            form.ShowDialog();
            LoadItemListBox();
        }

        private void Inventory_Load(object sender, EventArgs e)
        {
            LoadItemListBox();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            try
            {
                DialogResult messageConfirm = MessageBox.Show("Are you sure you want to delete this item?", "Delete Alert", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (messageConfirm == DialogResult.Yes)
                {
                    if (listBox1.SelectedItem != null)
                    {
                        InventoryItem selectedItem = (InventoryItem)listBox1.SelectedItem;
                        InventoryDB.RemoveItem(selectedItem);
                        var temp = InventoryDB.items;
                        InventoryDB.SaveItems(temp); // Save the updated items
                        LoadItemListBox(); // Reload the item list in the ListBox
                    }
                    else
                    {
                        MessageBox.Show("Please choose the item to delete.", "Selection Error");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while deleting the item: {ex.Message}", "Error");
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        public void LoadItemListBox(int Index = 0)
        {
            listBox1.Items.Clear();
            var items = InventoryDB.GetItems();

            foreach (InventoryItem s in items)
            {
                listBox1.Items.Add(s);
            }
        }
    }
}
