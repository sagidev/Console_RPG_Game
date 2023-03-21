﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_RPG_Game.Objects
{
    enum WeaponRarity
    {
        Common,
        Uncommon,
        Rare,
        Mythic,
        Legendary
    }

    internal class Weapon
    {
        private string name;
        private float damage;
        private int level;
        private WeaponRarity weaponRarity { get; set; }

        public Weapon(string name, float damage, int level, WeaponRarity weaponRarity)
        {
            this.name = name;
            this.damage = damage;
            this.level = level;
            this.weaponRarity = weaponRarity;
        }

        public override string ToString()
        {
            return (" [" + this.level + "][" + this.weaponRarity + "] " + this.name + " [" + this.damage + "]");
        }

        public int GetDamage()
        {
            return (int)damage;
        }
    }
}
