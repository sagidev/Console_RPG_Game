﻿using Console_RPG_Game.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Console_RPG_Game.Locations
{
    internal class Dungeon : Location
    {
        public string Name { get; set; }

        public List<Weapon> Weapons { get; set; }
        public List<Armor> Armors { get; set; }
        public List<Entity> Enemies { get; set; }

        public Dungeon(string name)
        {
            Console.Clear();

            Name = name;
            Weapons = new List<Weapon>();
            Armors = new List<Armor>();
            Enemies = new List<Entity>();

            Entity enemy = new Entity("Skeleton");
            enemy.AddGold(50);
            enemy.AddExperience(50);
            Weapons.Add(new Weapon("dropik", 1, 1, WeaponRarity.Common));
            Weapons.Add(new Weapon("dropik2", 11, 1, WeaponRarity.Common));
            Enemies.Add(enemy);
        }

        public bool TryEscape()
        {
            Random rng = new Random();
            int rand = rng.Next(0, 100);
            if (rand > 30)
                return true;
            else
                return false;
        }

        public void PrintDamageRecap(Entity player, Entity enemy)
        {
            Utils.print_coord("# - Combat info", 55, 4);
            Utils.print_coord("###################################################", 55, 5);
            Utils.print_coord("#                                                 #", 55, 6);
            Utils.print_coord("#    " + player.GetName() + " attacked " + enemy.GetName() + " for [" + player.GetDamage() + "] Damage!", 55, 7);
            Utils.print_coord("#", 105, 7);
            Utils.print_coord("#    " + enemy.GetName() + " attacked " + player.GetName() + " for [" + enemy.GetDamage() + "] Damage!", 55, 8);
            Utils.print_coord("#", 105, 8);
            Utils.print_coord("#                                                 #", 55, 9);
            Utils.print_coord("###################################################", 55, 10);
        }

        public void Fight(Entity player, Entity enemy)
        {
            bool escaped = false;
            while (!escaped || player.isAlive || enemy.isAlive)
            {
                Utils.print_coord("# What you gonna do?", 5, 20);
                Utils.print_coord("1. Attack", 5, 21);
                Utils.print_coord("2. Try to run away", 5, 22);
                switch (Utils.GetInput())
                {
                    case '1':
                        enemy.PrintEntity(true, false);
                        player.PrintEntity(false, true);
                        player.AttackEnemy(enemy);
                        enemy.AttackEnemy(player);
                        PrintDamageRecap(player, enemy);
                        if (enemy.GetStat(CharacterStat.Health) <= 0)
                        {
                            Utils.print_coord("# You killed a " + enemy.GetName() + "!", 5, 24);
                            Thread.Sleep(1000);
                            escaped = true;
                            break;
                        }
                        if (player.GetStat(CharacterStat.Health) <= 0)
                        {
                            Utils.print_coord("# You died!", 5, 24);
                            Thread.Sleep(1000);
                            escaped = true;
                            break;
                        }
                        break;
                    case '2':
                        if (TryEscape())
                        {
                            Utils.print_coord("# You escaped!", 5, 24);
                            Thread.Sleep(1000);
                            escaped = true;
                            break;
                        }
                        else
                        {
                            Utils.print_coord("# You failed to escape!", 5, 24);
                            Thread.Sleep(1000);
                            break;
                        }
                }
            }
        }

        public void StartDungeon(int stage, Entity player)
        {
            Console.WriteLine(" Entering the dungeon..\n");
            Console.WriteLine(" Stage: " + stage);
            Console.WriteLine(" Enemies: " + Enemies.Count);
            Console.WriteLine(" Possible loot: ");
            
            foreach(Weapon weapon in Weapons)
            {
                Console.WriteLine(weapon);
            }

            Console.WriteLine("\n Press any key to continue..");
            Console.ReadKey();
            bool escaped = false;

            Console.Clear();
            Enemies.FirstOrDefault().PrintEntity(true, false);
            player.PrintEntity(false, true);
            while (!escaped)
            {
                
                Utils.print_coord("# What you gonna do?", 5, 20);
                Utils.print_coord("1. Attack", 5, 21);
                Utils.print_coord("2. Try to run away", 5, 22);
                switch(Utils.GetInput())
                {
                    case '1':
                        Enemies.FirstOrDefault().PrintEntity(true, false);
                        player.PrintEntity(false, true);
                        player.AttackEnemy(Enemies.FirstOrDefault());
                        Enemies.FirstOrDefault().AttackEnemy(player);
                        
                        if (Enemies.FirstOrDefault().GetStat(CharacterStat.Health) <= 0)
                        {
                            Utils.print_coord("# You killed a " + Enemies.FirstOrDefault().GetName() + "!", 5, 24);
                            Thread.Sleep(1000);
                            escaped = true;
                            break;
                        }
                        if (player.GetStat(CharacterStat.Health) <= 0)
                        {
                            Utils.print_coord("# You died!", 5, 24);
                            Thread.Sleep(1000);
                            break;
                        }
                        PrintDamageRecap(player, Enemies.FirstOrDefault());
                        break;
                    case '2':
                        if (TryEscape())
                            escaped = true;
                        else
                        {
                            if (player.GetGold() >= 30)
                            {
                                player.RemoveGold(30);
                            }
                        }
                            
                        break;
                }
            }
        }
    }
}
