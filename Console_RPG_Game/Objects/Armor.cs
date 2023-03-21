using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        private ArmorRarity armorRarity { get; set; }

        public Armor(string name, float armor, int level, ArmorRarity armorRarity)
        {
            this.name = name;
            this.armor = armor;
            this.level = level;
            this.armorRarity = armorRarity;
        }

        public override string ToString()
        {
            return (" [" + this.level + "][" + this.armorRarity + "] " + this.name + " [" + this.armor + "]");
        }
    }
}
