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
        int stage = 0;
        bool ingame = false;
        bool gameover = false;
        Entity player;
        Shop shop;

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
            Utils.print_coord("0. Exit", 2, 6);

            //var key = Console.ReadKey();

            //int input = Convert.ToInt32(Console.ReadLine());
            switch (Utils.GetInput())
            {
                case '0':
                    Environment.Exit(0);
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
                    Utils.print_coord("2. Sell weapon", 5, 22);
                    Utils.print_coord("3. Exit", 5, 23);
                    switch (Utils.GetInput())
                    {
                        case '1':
                            Utils.print_coord("# Select weapon to buy:", 5, 25);
                            char input = Utils.GetInput();
                            int id = input - '0';
                            if (id < 0 || id > player.inventory.GetWeapons().Count)
                                Console.WriteLine("error xd   " + id);
                            else
                            {
                                shop.BuyWeapon(player.inventory.GetWeapons()[id - 1]);
                            }
                            break;
                        case '2':
                            Utils.print_coord("# Select weapon to sell:", 5, 25);
                            char input1 = Utils.GetInput();
                            int id1 = input1 - '0';
                            if (id1 < 0 || id1 > player.inventory.GetWeapons().Count)
                                Console.WriteLine("error xd   " + id1);
                            else
                            {
                                shop.SellWeapon(player.inventory.GetWeapons()[id1 - 1]);
                            }
                            break;

                    }
                    break;
            }
        }
    }
}
