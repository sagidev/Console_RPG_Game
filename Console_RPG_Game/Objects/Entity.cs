using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_RPG_Game.Objects
{
    enum CharacterStat
    {
        Health,
        MaxHealth,
        Attack,
        Experience,
        ExperienceToNextLevel,
        Level,
        Gold
    }

    enum CharacterClass
    {
        Warrior,
        Mage,
        Archer,
        NPC
    }

    internal class Entity
    {
        public Inventory inventory;

        private CharacterClass characterClass;

        private string name;
        private int health;
        private int maxHealth;
        private int attack;
        private int experience;
        private int experienceToNextLevel;
        private int level;
        private int gold = 0;
        public bool isAlive;

        public Entity(string name)
        {
            this.name = name;
            health = 100;
            maxHealth = 100;
            attack = 10;
            experience = 0;
            experienceToNextLevel = 100;
            level = 1;
            isAlive = true;

            inventory = new Inventory();

            characterClass = CharacterClass.Warrior;
        }

        public string GetName()
        {
            return name;
        }
        
        public int GetStat(CharacterStat stat)
        {
            switch (stat)
            {
                case CharacterStat.Health:
                    return health;
                case CharacterStat.MaxHealth:
                    return maxHealth;
                case CharacterStat.Attack:
                    return attack;
                case CharacterStat.Experience:
                    return experience;
                case CharacterStat.ExperienceToNextLevel:
                    return experienceToNextLevel;
                case CharacterStat.Level:
                    return level;
                case CharacterStat.Gold:
                    return gold;
                default:
                    return 0;
            }
        }


        public void AttackEnemy(Entity enemy)
        {
            enemy.TakeDamage(GetDamage());
            if (enemy.GetStat(CharacterStat.Health) <= 0)
            {
                KillTarget(enemy);
            }
        }

        public void TakeDamage(int damage)
        {
            this.health -= damage;
            if (this.health <= 0)
            {
                this.health = 0;
            }
        }

        public void KillTarget(Entity enemy)
        {
            enemy.isAlive = false;
            enemy.health = 0;
            Random rng = new Random();
            int chance = rng.Next(0, 100);
            if(chance>50)
            {
                this.inventory.AddWeapon(enemy.inventory.equippedWeapon);
                Utils.PrintNotification("You dropped a " + enemy.inventory.equippedWeapon + "!!");
            }
            this.AddExperience(enemy.experience);
            this.AddGold(enemy.gold);
        }

        public int GetDamage()
        {
            return (int)inventory.equippedWeapon.GetDamage();
        }

        public void AddExperience(int experience)
        {
            this.experience += experience;
            if (this.experience >= this.experienceToNextLevel)
            {
                this.experience -= this.experienceToNextLevel;
                this.experienceToNextLevel += 100;
                this.level++;
                this.health = this.maxHealth;
                Utils.PrintNotification("Level up!");
            }
        }

        public void AddGold(int gold)
        {
            this.gold += gold;
        }

        public void RemoveGold(int gold)
        {
            this.gold -= gold;
        }

        public int GetGold()
        {
            return this.gold;
        }

        public int GetLevel()
        {
            return this.level;
        }
        
        public void Heal(int value)
        {
            this.health += value;
            if (this.health > this.maxHealth)
            {
                this.health = this.maxHealth;
            }
        }

        public void PrintEntity(bool isEnemy =false, bool isLeft = true)
        {
            if (!isLeft)
            {
                Utils.print_coord("#########################################", 60, 14);

                Utils.print_coord("#                                       #", 60, 15);

                Utils.print_coord("#  Name: " + this.name + " [" + this.level + "]", 60, 16);
                Utils.print_coord("Gold: " + this.gold, 85, 16);
                Utils.print_coord("#", 100, 16);

                Utils.print_coord("#  Health: " + this.health + "/" + this.maxHealth, 60, 17);
                Utils.print_coord("#", 100, 17);

                if (isEnemy)
                {
                    Utils.print_coord("#  Experience: " + this.experience, 60, 18);
                }
                else
                {
                    Utils.print_coord("#  Experience: " + this.experience + "/" + this.experienceToNextLevel, 60, 18);
                }
                Utils.print_coord("#", 100, 18);

                Utils.print_coord("#  Class: " + this.characterClass, 60, 19);
                Utils.print_coord("#", 100, 19);

                Utils.print_coord("#  Damage: " + this.GetDamage(), 60, 20);
                Utils.print_coord("#", 100, 20);

                Utils.print_coord("#  Weapon: " + this.inventory.equippedWeapon, 60, 21);
                Utils.print_coord("#", 100, 21);

                Utils.print_coord("#                                       #", 60, 22);

                Utils.print_coord("#########################################", 60, 23);

                Utils.print_coord("# - " + this.name, 60, 24);
            }
            else
            {
                Utils.print_coord("#########################################", 5, 5);

                Utils.print_coord("#                                       #", 5, 6);

                Utils.print_coord("#  Name: " + this.name + " [" + this.level + "]", 5, 7);
                Utils.print_coord("Gold: " + this.gold, 32, 7);
                Utils.print_coord("#", 45, 7);

                Utils.print_coord("#  Health: " + this.health + "/" + this.maxHealth, 5, 8);
                Utils.print_coord("#", 45, 8);

                if (isEnemy)
                {
                    Utils.print_coord("#  Experience: " + this.experience, 5, 9);
                }
                else
                {
                    Utils.print_coord("#  Experience: " + this.experience + "/" + this.experienceToNextLevel, 5, 9);
                }
                Utils.print_coord("#", 45, 9);

                Utils.print_coord("#  Class: " + this.characterClass, 5, 10);
                Utils.print_coord("#", 45, 10);

                Utils.print_coord("#  Damage: " + this.GetDamage(), 5, 11);
                Utils.print_coord("#", 45, 11);

                Utils.print_coord("#  Weapon: " + this.inventory.equippedWeapon, 5, 12);
                Utils.print_coord("#", 45, 12);

                Utils.print_coord("#                                       #", 5, 13);

                Utils.print_coord("#########################################", 5, 14);

                Utils.print_coord("# - " + this.name, 5, 15);
            }
        }

        

        public override string ToString()
        {
            return " [" + this.name + "][" + this.level + "][" + this.characterClass + "][DMG:" + this.GetDamage() + "]";
        }
    }
}
