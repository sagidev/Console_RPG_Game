using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Console_RPG_Game.Objects
{
    class Shop
    {
        Entity player;
        public List<Weapon> weapons;
        public List<Armor> armors;

        public Shop(Entity player)
        {
            weapons = new List<Weapon>();
            armors = new List<Armor>();
            this.player = player;

            AddWeapon(new Weapon("Sword", 10, 1, WeaponRarity.Common, 10));
            AddWeapon(new Weapon("Axe", 15, 2, WeaponRarity.Common, 10));
            AddWeapon(new Weapon("Mace", 20, 3, WeaponRarity.Common, 15));
            AddWeapon(new Weapon("Spear", 25, 4, WeaponRarity.Common, 25));
            AddWeapon(new Weapon("Bow", 30, 5, WeaponRarity.Common, 25));
            AddWeapon(new Weapon("Staff", 35, 6, WeaponRarity.Common, 30));

            AddArmor(new Armor("Cloth", 10, 1, ArmorRarity.Common, 10));
            AddArmor(new Armor("Leather", 15, 2, ArmorRarity.Common, 10));
            AddArmor(new Armor("Chainmail", 20, 3, ArmorRarity.Common, 15));
            AddArmor(new Armor("Plate", 25, 4, ArmorRarity.Common, 25));
            AddArmor(new Armor("Dragon", 30, 5, ArmorRarity.Common, 25));
            AddArmor(new Armor("God", 35, 6, ArmorRarity.Common, 30));
        }

        public List<Weapon> GetWeapons()
        {
            return weapons;
        }

        public List<Armor> GetArmors()
        {
            return armors;
        }

        public void AddWeapon(Weapon weapon)
        {
            weapons.Add(weapon);
        }

        public void AddArmor(Armor armor)
        {
            armors.Add(armor);
        }

        public void BuyWeapon(Weapon weapon)
        {
            if (weapons.Contains(weapon))
            {
                if (player.GetGold() >= weapon.GetPrice())
                {
                    player.RemoveGold(weapon.GetPrice());
                    player.inventory.AddWeapon(weapon);
                    weapons.Remove(weapon);
                }
            }
        }

        public void SellWeapon(Weapon weapon)
        {
            if (player.inventory.weapons.Contains(weapon))
            {
                player.AddGold(weapon.GetPrice());
                player.inventory.RemoveWeapon(weapon);
                weapons.Add(weapon);
            }
        }

        public void PrintShop()
        {
            Utils.print_coord("#########################################", 60, 14);

            Utils.print_coord("#                                       #", 60, 15);

            int i = 0;

            foreach (Weapon weapon in weapons)
            {
                if (i < 10)
                {
                    Utils.print_coord("#  " + (i + 1) + ": " + weapon, 60, 16 + i);
                    Utils.print_coord(weapon.GetPrice().ToString() + "$", 95, 16 + i);
                }
                else
                {
                    Utils.print_coord("#  " + (i + 1) + ":" + weapon, 60, 16 + i);
                    Utils.print_coord(weapon.GetPrice().ToString() + "$", 95, 16 + i);
                }
                Utils.print_coord("#", 100, 16 + i);
                i++;
            }

            Utils.print_coord("#                                       #", 60, 16 + i);

            foreach (Armor armor in armors)
            {
                if(i<9)
                {
                    Utils.print_coord("#  " + (i + 1) + ": " + armor, 60, 16 + i + 1);
                    Utils.print_coord(armor.GetPrice().ToString() + "$", 95, 16 + i + 1);
                }
                else
                {
                    Utils.print_coord("#  " + (i + 1) + ":" + armor, 60, 16 + i + 1);
                    Utils.print_coord(armor.GetPrice().ToString() + "$", 95, 16 + i + 1);
                }
                Utils.print_coord("#", 100, 16 + i + 1);
                i++;
            }

            Utils.print_coord("#                                       #", 60, 16 + i + 1);
            i++;
            Utils.print_coord("#########################################", 60, 16 + i + 1);
            i++;
            Utils.print_coord("# - Shop", 60, 16 + i + 1);
        }
    }
}
