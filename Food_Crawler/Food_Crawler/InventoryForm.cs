using System;
using System.Windows.Forms;
using System.Collections.Generic;

namespace Food_Crawler
{
    public partial class InventoryForm : Form//Tony 
    {
        public InventoryForm(List<int> ingredients)
        {
            InitializeComponent();
            if (ingredients == null || ingredients.Count == 0)
            {
                listBox1.Items.Add("No ingredients found.");
            }
            else
            {
                foreach (int item in ingredients)
                {
                    string itemName = item switch
                    {
                        <= 20 => "Apple",
                        <= 40 => "Armor Shard",
                        <= 60 => "Rusty Sword",
                        <= 80 => "Health Potion",
                        _ => "Mystery Item"
                    };
                    listBox1.Items.Add(itemName);
                }

            }
        }

        private void InitializeComponent()
        {
            this.listBox1 = new ListBox();
            this.SuspendLayout();
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 25;
            this.listBox1.Location = new System.Drawing.Point(12, 12);
            this.listBox1.Size = new System.Drawing.Size(360, 229);
            this.Controls.Add(this.listBox1);
            this.Text = "Inventory";
            this.ClientSize = new System.Drawing.Size(384, 261);
            this.ResumeLayout(false);
        }

        private ListBox listBox1;
    }
}
