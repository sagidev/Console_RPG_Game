using Console_RPG_Game.Locations;
using Console_RPG_Game.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Console_RPG_Game
{
    class Game
    {
        int stage = 1;
        bool ingame = false;
        bool gameover = false;
        Entity player;
        Shop shop;
        Dungeon dungeon;

        public Game()
        {
            StartGame();
        }

        public void StartGame()
        {
            //tworzenie herosa

            player = new Entity("Player");
            player.inventory.AddWeapon(new Weapon("Sword", 10, 1, WeaponRarity.Common));
            player.inventory.AddWeapon(new Weapon("Chuj Sword", 11, 1, WeaponRarity.Rare));
            player.AddGold(100);
            shop = new Shop(player);

            while (!gameover)
            {
                DrawMainMenu();
            }
            Console.ReadKey();
        }

        public void DrawMainMenu()
        {
            Console.Clear();
            Utils.print_coord("# MAIN MENU", 2, 2);
            Utils.print_coord("1. Start Stage", 2, 3);
            Utils.print_coord("2. Open Equipment", 2, 4);
            Utils.print_coord("3. Open Shop", 2, 5);
            Utils.print_coord("4. Go to Dryad", 2, 6);
            Utils.print_coord("0. Exit", 2, 7);
            switch (Utils.GetInput())
            {
                case '0':
                    Environment.Exit(0);
                    break;
                case '1':
                    dungeon = new Dungeon("Dungeon");
                    dungeon.StartDungeon(stage, player);
                    break;
                case '2':
                    Console.Clear();
                    player.PrintEntity(false, true);
                    player.inventory.PrintInventory();
                    Utils.print_coord("# What you gonna do?", 5, 20);
                    Utils.print_coord("1. Change weapon", 5, 21);
                    Utils.print_coord("2. Back", 5, 22);
                    switch (Utils.GetInput())
                    {
                        case '1':
                            Utils.print_coord("# Select weapon to equip:", 5, 24);
                            char input = Utils.GetInput();
                            int id = input - '0';
                            if (id < 0 || id > player.inventory.GetWeapons().Count)
                                Console.WriteLine("error xd   " + id);
                            else
                                player.inventory.EquipWeapon(player.inventory.GetWeapons()[id - 1]);
                            break;
                        case '2':
                            break;
                    }
                    break;
                case '3':
                    Console.Clear();
                    player.PrintEntity(false, true);
                    shop.PrintShop();
                    Utils.print_coord("# What you gonna do?", 5, 20);
                    Utils.print_coord("1. Buy weapon", 5, 21);
                    //Utils.print_coord("2. Sell weapon", 5, 22);
                    Utils.print_coord("2. Exit", 5, 23);
                    switch (Utils.GetInput())
                    {
                        case '1':
                            Utils.print_coord("# Select weapon to buy:", 5, 25);
                            char input = Utils.GetInput();
                            int id = input - '0';
                            if (id < 0 || id > shop.GetWeapons().Count)
                                Console.WriteLine("error xd   " + id);
                            else
                            {
                                shop.BuyWeapon(shop.GetWeapons()[id - 1]);
                                Thread.Sleep(1000);
                            }
                            break;
                        case '2':
                            //Utils.print_coord("# Select weapon to sell:", 5, 25);
                            //char input1 = Utils.GetInput();
                            //int id1 = input1 - '0';
                            //if (id1 < 0 || id1 > player.inventory.GetWeapons().Count)
                            //    Console.WriteLine("error xd   " + id1);
                            //else
                            //{
                            //    shop.SellWeapon(player.inventory.GetWeapons()[id1 - 1]);
                            //}
                            break;

                    }
                    break;
                case '4':
                    Console.Clear();
                    player.PrintEntity(false, true);
                    int price = 50 + (player.GetLevel() * 10);
                    Utils.print_coord("# You just entered the Dryad's house. Do you need healing?", 5, 20);
                    Utils.print_coord("Current price: " + (price), 5, 21);
                    Utils.print_coord("1. Heal", 5, 23);
                    Utils.print_coord("2. Exit", 5, 24);
                    switch (Utils.GetInput())
                    {
                        case '1':
                            if (player.GetGold() >= price)
                            {
                                player.AddGold(-price);
                                player.Heal(player.GetStat(CharacterStat.MaxHealth));
                                Utils.print_coord("# You have been healed!", 5, 25);
                                Thread.Sleep(250);
                            }
                            else
                            {
                                Utils.print_coord("# You don't have enough gold!", 5, 25);
                                Thread.Sleep(250);
                            }
                            break;
                    }
                    break;
            }
        }
    }
}
