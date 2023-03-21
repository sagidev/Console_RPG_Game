using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Console_RPG_Game.Objects
{
    enum ArmorRarity
    {
        Common,
        Uncommon,
        Rare,
        Mythic,
        Legendary
    }

    internal class Armor
    {
        private string name;
        private float armor;
        private int level;
        private int price;
        private ArmorRarity armorRarity { get; set; }

        public Armor(string name, float armor, int level, ArmorRarity armorRarity, int price = 0)
        {
            this.name = name;
            this.armor = armor;
            this.level = level;
            this.armorRarity = armorRarity;
            this.price = 0;
        }

        public override string ToString()
        {
            return (" [" + this.level + "][" + this.armorRarity + "] " + this.name + " [" + this.armor + "]");
        }

        public void SetPrice(int price)
        {
            this.price = price;
        }

        public int GetPrice()
        {
            return price;
        }

        public int GetArmor()
        {
            return (int)armor;
        }
    }
}
