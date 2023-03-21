using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Console_RPG_Game.Objects
{
    class Inventory
    {
        public List<Weapon> weapons;
        public List<Armor> armors;

        public Weapon equippedWeapon;
        public Armor equippedArmor;

        public Inventory()
        {
            weapons = new List<Weapon>();
            armors = new List<Armor>();
            equippedWeapon = new Weapon("Fists", 1, 0, WeaponRarity.Common);
            AddWeapon(equippedWeapon);
            equippedArmor = new Armor("Cloth", 1, 0, ArmorRarity.Common);
            AddArmor(equippedArmor);
        }

        public void AddWeapon(Weapon weapon)
        {
            weapons.Add(weapon);
        }

        public void AddArmor(Armor armor)
        {
            armors.Add(armor);
        }

        public void EquipWeapon(Weapon weapon)
        {
            if (weapons.Contains(weapon))
            {
                equippedWeapon = weapon;
            }
        }

        public void EquipArmor(Armor armor)
        {
            if (armors.Contains(armor))
            {
                equippedArmor = armor;
            }
        }

        public void RemoveWeapon(Weapon weapon)
        {
            if (weapons.Contains(weapon))
            {
                weapons.Remove(weapon);
            }
        }

        public void RemoveArmor(Armor armor)
        {
            if (armors.Contains(armor))
            {
                armors.Remove(armor);
            }
        }

        public List<Weapon> GetWeapons()
        {
            return weapons;
        }

        public Weapon GetEquippedWeapon()
        {
            return equippedWeapon;
        }

        public void PrintInventory()
        {
            Utils.print_coord("#########################################", 60, 14);

            Utils.print_coord("#                                       #", 60, 15);

            int i = 0;

            foreach (Weapon weapon in weapons)
            {
                if (weapon == equippedWeapon)
                {
                    Utils.print_coord("#  " + (i + 1) + ": " + weapon + "      [EQ]", 60, 16 + i);
                }
                else
                {
                    Utils.print_coord("#  " + (i + 1) + ": " + weapon, 60, 16 + i);
                }
                
                Utils.print_coord("#", 100, 16 + i);
                i++;
            }

            Utils.print_coord("#                                       #", 60, 16 + i);
            i++;
            foreach (Armor armor in armors)
            {
                if(armor == equippedArmor)
                {
                    Utils.print_coord("#  " + (i + 1) + ": " + armor + "      [EQ]", 60, 16 + i);
                }
                else
                {
                    Utils.print_coord("#  " + (i + 1) + ": " + armor, 60, 16 + i);
                }
                Utils.print_coord("#  " + (i+1) + ": " + armor, 60, 16 + i);
                Utils.print_coord("#", 100, 16 + i);
                i++;
            }

            Utils.print_coord("#                                       #", 60, 16 + i);
            i++;
            Utils.print_coord("#########################################", 60, 16 + i);
            i++;
            Utils.print_coord("# - Inventory", 60, 16+i);



            //int index = 1;
            //Console.WriteLine("Weapons:");
            //foreach (Weapon weapon in weapons)
            //{
            //    if (weapon == equippedWeapon)
            //        Console.WriteLine(" " + index + ": * " + weapon);
            //    else
            //        Console.WriteLine(" " + index + ":   " + weapon);
            //    index++;
            //    Console.WriteLine(weapon.ToString());
            //}
            //index = 1;
            //Console.WriteLine("Armors:");
            //foreach (Armor armor in armors)
            //{
            //    if (armor == equippedArmor)
            //        Console.WriteLine(" " + index + ": * " + armor);
            //    else
            //        Console.WriteLine(" " + index + ":   " + armor);
            //    index++;
            //    Console.WriteLine(armor.ToString());
            //}
        }

        public void PrintEquipped()
        {
            Console.WriteLine("Equipped Weapon: " + equippedWeapon);
            Console.WriteLine("Equipped Armor: " + equippedArmor);
        }

        
    }
}
