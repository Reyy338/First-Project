using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using System.Text;

namespace RPG
{
    public class Stats
    {
        public Stats()
        {
            Name = "";
            Descrip = "";
            Hp = 0;
            MaxHP = 0;
            Dmg = 0;
            Spd = 0;
            Exp = 0;
            Lvl = 0;
        }

        public string Name;
        public string Descrip;
        public int Hp;
        public int MaxHP;
        public int Dmg;
        public int Spd;
        public int Exp;
        public int Lvl;

        public string GetName()
        {
            return Name;
        }

        public string GetDescrip()
        {
            return Descrip;
        }

        public int GetHp()
        {
            return Hp;
        }

        public int GetDmg()
        {
            return Dmg;
        }

        public int GetSpd()
        {
            return Spd;
        }

        public int GetExp()
        {
            return Exp;
        }

        public int GetLvl()
        {
            return Lvl;
        }
        public void GainExp(int exp)
        {
            Exp += exp;
        }
        public void IncreaseLevel()
        {
            Lvl += 1;
        }
        public void LevelUp()
        {
            Thread.Sleep(500);
            Console.WriteLine("\n>>>>>>>- You have leveled up!-<<<<<<<");
            Thread.Sleep(500);
            Lvl += 1;
            MaxHP += 40 + (Lvl * 2);  
            Dmg += 15 + (Lvl * 2);     
            Spd += 5;     
            Hp = MaxHP;
            Exp -= 100;
            Exp = Math.Max(Exp, 0);
        }
    }

    public class ClassChar
    {
        public static Stats CreateWarrior()
        {
            Stats classPlayer = new Stats
            {
                Name = "Warrior",
                Descrip = "The Warrior, originally from the amazon, trained with the sword and has good a goo build.",
                Hp = 220,
                MaxHP = 200,
                Dmg = 40,
                Spd = 50,
                Lvl = 1,
                Exp = 0
            };
            return classPlayer;
        }

        public static Stats CreateArcher()
        {
            Stats classPlayer = new Stats
            {
                Name = "Archer",
                Descrip = "The Archer, equiped with a bow and good aim able to shoot enemies at a range with good dexterity.",
                Hp = 140,
                MaxHP = 140,
                Dmg = 55,
                Spd = 65,
                Lvl = 1,
                Exp = 0
            };
            return classPlayer;
        }

        public static Stats CreateMage()
        {
            Stats classPlayer = new Stats
            {
                Name = "Mage",
                Descrip = "The Mage, a spell caster able to do magic which kills the enemy at a pace.",
                Hp = 150,
                MaxHP = 150,
                Dmg = 60,
                Spd = 50,
                Lvl = 1,
                Exp = 0
            };
            return classPlayer;
        }

        public static Stats CreateAssassin()
        {
            Stats classPlayer = new Stats
            {
                Name = "Assassin",
                Descrip = "The Assassin, a heavy hitter with fast movement. Glass canon",
                Hp = 110,
                MaxHP = 110,
                Dmg = 80,
                Spd = 70,
                Lvl = 1,
                Exp = 0
            };
            return classPlayer;
        }
    }

    public class Enemies
    {
        public static Stats CreateGhoulEnemy()
        {
            Stats enemy = new Stats
            {
                Name = "Ghoul",
                Descrip = "An undead. Weak",
                Hp = 150,
                Dmg = 30,
                Spd = 45,
                Lvl = 1,
                Exp = 35
            };
            return enemy;
        }

        public static Stats CreateOrcEnemy()
        {
            Stats enemy = new Stats
            {
                Name = "Orc",
                Descrip = "A giant formidable enemy born with a tanky body",
                Hp = 300,
                Dmg = 40,
                Spd = 60,
                Lvl = 2,
                Exp = 55
            };
            return enemy;
        }

        public static Stats CreateNightLurchEnemy()
        {
            Stats enemy = new Stats
            {
                Name = "Night Lurch",
                Descrip = "A four-legged being with claws and frog-like legs. Has high speed and can inflict bleeding",
                Hp = 760,
                Dmg = 120,
                Spd = 150,
                Lvl = 10,
                Exp = 200
            };
            return enemy;
        }

        public static Stats CreateDarkPriestEnemy()
        {
            Stats enemy = new Stats
            {
                Name = "Dark Priest",
                Descrip = "A priest that follows the being of chaos and fear, mostly does magic damage, weak but deals heavy damage",
                Hp = 550,
                Dmg = 90,
                Spd = 95,
                Lvl = 6,
                Exp = 90
            };
            return enemy;
        }

        public static Stats CreateCrawMaulerEnemy()
        {
            Stats enemy = new Stats
            {
                Name = "Craw Mauler",
                Descrip = "An enemy that wears the head of a Crow. Human-sized but is a mutant able to kill to do massive damage",
                Hp = 1800,
                Dmg = 200,
                Spd = 225,
                Lvl = 18,
                Exp = 350
            };
            return enemy;
        }

        public static Stats CreateBeing()
        {
            Stats enemy = new Stats
            {
                Name = "God of Rpg",
                Descrip = "#############################",
                Hp = 9999999,
                Dmg = 9999999,
                Spd = 9999999,
                Lvl = 999,
                Exp = 99999999
            };
            return enemy;
        }
    
        public static bool BatlleLogic(Stats playerClass, Stats enemyClass)
        {
            Thread.Sleep(500);
            Console.WriteLine($"\n==========\nYou have encountered an enemy {enemyClass.GetName()}");
            bool life = true;
            
            while (playerClass.GetHp() > 0 && enemyClass.GetHp() > 0)
            {
                if (enemyClass.GetSpd() > playerClass.GetSpd())
                {
                    FirstMoveEnemy(playerClass, enemyClass);
                }
                else
                {
                    FirstMovePlayer(playerClass, enemyClass);
                }

                if (playerClass.GetHp() <= 0)
                {
                    Console.WriteLine("You Died.");
                    life = false;
                    return life;
                    if (life == false)
                    {
                        Driver.ReTry();
                    }
                }

                if (playerClass.GetHp() > 0 && enemyClass.GetHp() <= 0)
                {
                    Console.WriteLine($"You defeated the {enemyClass.GetName()}!");
                    int expGained = enemyClass.GetExp();
                    playerClass.GainExp(expGained);
                    Console.WriteLine($"You gained {expGained} experience points!");
                    while (playerClass.GetExp() >= 100)
                    {
                        playerClass.LevelUp();
                        Driver.DisplayClassDetails(playerClass);
                    }
                }
            }        
            return life;
        }



        private static void FirstMoveEnemy(Stats player, Stats enemy)
        {
            Console.WriteLine("Enemy attacks first!");
            while (player.GetHp() > 0 && enemy.GetHp() > 0)
            {
                if (player.GetHp() <= 0)
                {
                    return;
                }
                if (enemy.GetHp() <= 0)
                {
                    return;
                }
                else
                {
                    EnemyTurn(player, enemy);
                    PlayerTurn(player, enemy);
                }
            }
        }

        private static void FirstMovePlayer(Stats player, Stats enemy)
        {
            Console.WriteLine("You attack first!");
            while (player.GetHp() > 0 && enemy.GetHp() > 0)
            {
                if (player.GetHp() <= 0)
                {
                    return;
                }
                if (enemy.GetHp() <= 0)
                {
                    return;
                }
                else
                {
                    PlayerTurn(player, enemy);
                    EnemyTurn(player, enemy);
                }
            }
        }
        private static void EnemyTurn(Stats player, Stats enemy)
        {
            if (player.GetHp() <= 0)
            {
                return;
            }
            if (enemy.GetHp() <= 0)
            {
                return;
            }
            else
            {
            Driver.Loading();
            int damage = CalculateDamage(enemy.GetDmg());
            player.Hp -= damage;
            Console.WriteLine($"==========\n{enemy.GetName()} attacked! You received |{damage}| damage.\n==========");
            DisplayHealth(player, enemy);
            }
            
        }

        private static void PlayerTurn(Stats player, Stats enemy)
        {
            if (player.GetHp() < 0)
            {
                return;
            }
            
            if (enemy.GetHp() <= 0)
            {
                return;
            }
            else
            {
            Driver.Loading();
            int damage = CalculateDamage(player.GetDmg());
            enemy.Hp -= damage;
            Console.WriteLine($"==========\nYou attacked {enemy.GetName()}! Inflicted |{damage}| damage.\n==========");
            DisplayHealth(player, enemy);
            }
        }



        private static int CalculateDamage(int damage)
        {
            return damage;
        }

        private static void DisplayHealth(Stats player, Stats enemy)
        {
            Console.WriteLine($"Your HP: |{player.GetHp()}| | {enemy.GetName()}'s HP: |{enemy.GetHp()}|");
        }
    }

    public class Driver
    {
        private static Stats playerClass;
        private static Stats enemyClass;
        public static void Main()
        {
            // Player name input
            Console.WriteLine("Enter your name: ");
            string namePlayer = Console.ReadLine();
            Console.WriteLine("Welcome, " + namePlayer + "!\n");
            Thread.Sleep(500);

            // Game Story and Class choosing
            Console.WriteLine("Welcome to the world of rpg. A world where due to the mistakes of a couple of adventurers, birthed a being of chaos and fear");
            Console.WriteLine("-------------------------------------------------------------------");
            Thread.Sleep(500);
            Console.WriteLine("Good luck in the quest given. Godspeed!");

            // Class choosing... Hanggang dto lng labling tinamad ako
            classChoosing:
            Console.WriteLine(
                "\nChoose your class:" +
                "\nWarrior\nArcher\nMage\nAssassin");
            string classChoice = Console.ReadLine();
            switch (classChoice)
            {
                case "Warrior":
                    playerClass = ClassChar.CreateWarrior();
                    break;
                case "Archer":
                    playerClass = ClassChar.CreateArcher();
                    break;
                case "Mage":
                    playerClass = ClassChar.CreateMage();
                    break;
                case "Assassin":
                    playerClass = ClassChar.CreateAssassin();
                    break;
                default:
                    Console.WriteLine("Invalid class choice. Choose again.");
                    goto classChoosing;
            }

            DisplayClassDetails(playerClass);

            Thread.Sleep(500);
            Console.WriteLine($"{classChoice}: You are at the castle of where the being resides.");
            Movement();
            ReTry();
        }

        private static void Movement()
        {
            Console.WriteLine("Where will you go?");
            Console.WriteLine("============================\nMines\nPrison\nLibrary\nDungeon\nTemple\nHidden Room\n============================");
            string placeChoice = Console.ReadLine();
            Console.WriteLine($"\nYou went to the {placeChoice}");
            if (placeChoice == "Mines" || placeChoice == "Dungeon")
            {
                Console.Clear();
                MinesorDungeon();
            }
            if (placeChoice == "Prison")
            {
                Console.Clear();
                Prison();
            }
            if (placeChoice == "Library")
            {
                Console.Clear();
                Library();
            }
            if (placeChoice == "Temple")
            {
                Console.Clear();
                Temple();
            }
            if (placeChoice == "Hidden Room")
            {
                Console.Clear();
                HiddenRoom();
            }
            else
            {
                Console.Clear();
                Console.WriteLine ("Invalid action");
                Movement();
            }
        }

        public static void DisplayClassDetails(Stats character)
        {
            Console.WriteLine($"\n{character.GetName()} Details:" +
                              $"\nDescription: {character.GetDescrip()}" +
                              $"\nHP: {character.GetHp()}" +
                              $"\nDMG: {character.GetDmg()}" +
                              $"\nSPD: {character.GetSpd()}" +
                              $"\nLVL: {character.GetLvl()}" +
                              $"\nEXP: {character.GetExp()}");
        }

        public static void DisplayEnemyClassDetails(Stats enemy)
        {
            Console.WriteLine($"\n{enemy.GetName()} Details:" +
                              $"\nDescription: {enemy.GetDescrip()}" +
                              $"\nHP: {enemy.GetHp()}" +
                              $"\nDMG: {enemy.GetDmg()}" +
                              $"\nSPD: {enemy.GetSpd()}" +
                              $"\nLVL: {enemy.GetLvl()}" +
                              $"\nEXP: {enemy.GetExp()}");
        }

        public static void MinesorDungeon()
        {
            bool life = true;
            while (life)
            {
                Menu();
                int exploreChoice = Convert.ToInt32(Console.ReadLine());

                if (exploreChoice == 1)
                {
                    Console.WriteLine("You encountered enemies. Pick which to fight:\n[1] Ghoul\n[2] Orc");
                    int enemyChoice = Convert.ToInt32(Console.ReadLine());

                    Stats enemy = (enemyChoice == 1) ? Enemies.CreateGhoulEnemy() : Enemies.CreateOrcEnemy();

                    if (playerClass.GetLvl() < enemy.GetLvl())
                    {
                        Driver.DisplayEnemyClassDetails(enemy);
                        Thread.Sleep(500);
                        Console.WriteLine("!!!WARNING ENEMY DIFFICULTY TOO HIGH FOR YOUR LEVEL!!!\nDo you wish to proceed?\n[Y] or [N]");
                        string proceed = Console.ReadLine();
                        if (proceed == "Y")
                        {
                            life = Enemies.BatlleLogic(playerClass, enemy);
                            if (!life)
                            {
                                ReTry();
                            }
                        }
                    }
                    else
                    {
                        Driver.DisplayEnemyClassDetails(enemy);
                        life = Enemies.BatlleLogic(playerClass, enemy);
                        if (!life)
                        {
                            ReTry();
                        }
                    }
                }
                else if (exploreChoice == 2)
                {
                    HpHeal(playerClass);
                }
                else if (exploreChoice == 3)
                {
                    DisplayClassDetails(playerClass);
                }
                else if (exploreChoice == 4)
                {
                    Movement();
                }
                else
                {
                    Console.WriteLine("Invalid action");
                    MinesorDungeon();
                }
            }
        }


        public static void Prison()
        {
            bool life = true;
            while(life)
            {
                Menu();
                int exploreChoice = Convert.ToInt32(Console.ReadLine());
                if (exploreChoice == 1)
                {
                    Console.WriteLine("While exploring the prison you encountered the Night Lurch.");
                    
                    Stats enemy = Enemies.CreateNightLurchEnemy();
                    
                    if (playerClass.GetLvl() < enemy.GetLvl())
                    {
                        Driver.DisplayEnemyClassDetails(enemy);
                        Thread.Sleep(500);
                        Console.WriteLine("!!!WARNING ENEMY DIFFICULTY TO HIGH FOR YOU LEVEL!!!\nDo you wish to proceed?\n[Y] or [N]");
                        string proceed = Console.ReadLine();
                        if (proceed == "Y")
                        {
                            life = Enemies.BatlleLogic(playerClass, enemy);
                            if (life == false)
                            {
                                ReTry();
                            }
                        }
                    } 
                    else
                    {
                        Driver.DisplayEnemyClassDetails(enemy);
                        life = Enemies.BatlleLogic(playerClass, enemy);
                        if (life == false)
                        {
                            ReTry();
                        }
                    }
                    
                }
                else if (exploreChoice == 2)
                {
                    HpHeal(playerClass);
                }
                else if (exploreChoice == 3)
                {
                    DisplayClassDetails(playerClass);
                }
                else if (exploreChoice == 4)
                {
                    Movement();
                }
                else
                {
                    Console.WriteLine ("Invalid action");
                    Prison();
                }
            }
        }

        public static void Library()
        {
            bool life = true;
            while(life)
            {
                Menu();
                int exploreChoice = Convert.ToInt32(Console.ReadLine());
                if (exploreChoice == 1)
                {
                    Console.WriteLine("While exploring the prison you encountered a Dark Priest.");
                    
                    Stats enemy = Enemies.CreateDarkPriestEnemy();
                    
                    if (playerClass.GetLvl() < enemy.GetLvl())
                    {
                        Driver.DisplayEnemyClassDetails(enemy);
                        Thread.Sleep(500);
                        Console.WriteLine("!!!WARNING ENEMY DIFFICULTY TO HIGH FOR YOU LEVEL!!!\nDo you wish to proceed?\n[Y] or [N]");
                        string proceed = Console.ReadLine();
                        if (proceed == "Y")
                        {
                            life = Enemies.BatlleLogic(playerClass, enemy);
                            if (life == false)
                        {
                            ReTry();
                        }
                        }
                    } 
                    else
                    {
                        Driver.DisplayEnemyClassDetails(enemy);
                        life = Enemies.BatlleLogic(playerClass, enemy);
                        if (life == false)
                        {
                            ReTry();
                        }
                    }
                    
                }
                else if (exploreChoice == 2)
                {
                    HpHeal(playerClass);
                }
                else if (exploreChoice == 3)
                {
                    DisplayClassDetails(playerClass);
                }
                else if (exploreChoice == 4)
                {
                    Movement();
                }
                else
                {
                    Console.WriteLine ("Invalid action");
                    Library();
                }
            }
        }

        public static void Temple()
        {
            bool life = true;
            while(life)
            {
                Menu();
                int exploreChoice = Convert.ToInt32(Console.ReadLine());
                if (exploreChoice == 1)
                {
                    Console.WriteLine("While exploring the prison you encountered the Crow Mauler.");
                    
                    Stats enemy = Enemies.CreateCrawMaulerEnemy();
                    
                    if (playerClass.GetLvl() < enemy.GetLvl())
                    {
                        Driver.DisplayEnemyClassDetails(enemy);
                        Thread.Sleep(500);
                        Console.WriteLine("!!!WARNING ENEMY DIFFICULTY TO HIGH FOR YOU LEVEL!!!\nDo you wish to proceed?\n[Y] or [N]");
                        string proceed = Console.ReadLine();
                        if (proceed == "Y")
                        {
                            life = Enemies.BatlleLogic(playerClass, enemy);
                            if (life == false)
                        {
                            ReTry();
                        }
                        }
                    } 
                    else
                    {
                        Driver.DisplayEnemyClassDetails(enemy);
                        life = Enemies.BatlleLogic(playerClass, enemy);
                        if (life == false)
                        {
                            ReTry();
                        }
                    }
                    
                }
                else if (exploreChoice == 2)
                {
                    HpHeal(playerClass);
                }
                else if (exploreChoice == 3)
                {
                    DisplayClassDetails(playerClass);
                }
                else if (exploreChoice == 4)
                {
                    Movement();
                }
                else
                {
                    Console.WriteLine ("Invalid action");
                    Temple();
                }
            }
        }

        public static void HiddenRoom()
        {
            bool life = true;
            while(life)
            {
                Menu();
                int exploreChoice = Convert.ToInt32(Console.ReadLine());
                if (exploreChoice == 1)
                {
                    Console.WriteLine(">>>YOU WENT STRAIGHT TO THE BOSS<<<\n!!!YOU CANNOT ESCAPE!!!");
                    
                    Stats enemy = Enemies.CreateBeing();
                    
                    if (playerClass.GetLvl() < enemy.GetLvl())
                    {
                        Driver.DisplayEnemyClassDetails(enemy);
                        Thread.Sleep(500);
                        life = Enemies.BatlleLogic(playerClass, enemy);
                        if (life == false)
                        {
                            ReTry();
                        }
                        if (life == true)
                        {
                            Console.WriteLine("Congratulations you defeated the boss!");
                            ReTry();
                        }                       
                    } 
                    else
                    {
                        Driver.DisplayEnemyClassDetails(enemy);
                        life = Enemies.BatlleLogic(playerClass, enemy);
                        if (life == false)
                        {
                            ReTry();
                        }
                    }
                    
                }
                else if (exploreChoice == 2)
                {
                    HpHeal(playerClass);
                }
                else if (exploreChoice == 3)
                {
                    DisplayClassDetails(playerClass);
                }
                else if (exploreChoice == 4)
                {
                    Movement();
                }
                else
                {
                    Console.WriteLine ("Invalid action");
                    HiddenRoom();
                }
            }
        }

        public static void Menu()
        {
            Thread.Sleep(500);
            Console.WriteLine(@"
===================================
[1] Explore 
[2] Drink an HP pot
[3] Check Stats
[4] Go back 
===================================
            ");
        }

        public static void HpHeal(Stats playerClass)
        {
            int maxHp = playerClass.MaxHP;
            playerClass.Hp = maxHp;
            Console.WriteLine("You used a Hp pot. You're fully healed");
            Console.WriteLine($"HP at: {playerClass.Hp}");
        }
        
        public static void ReTry()
        {
            Console.WriteLine("\n=====================\nPlay Again?\n[Y] or [N]");
            string res = Console.ReadLine();
            if (res == "Y")
            {
                playerClass = null;
                enemyClass = null;
                Driver.Main();
            }
            else
            {
                Console.WriteLine("Thanks for playing my game. I miss my ex.");
                Environment.Exit(0);
            }
        }

        public static void Loading()
        {   
            Thread.Sleep(300);
            Console.WriteLine("==========\nBattling ");
            for (int i = 0; i < 3; i++)
            {
                Console.Write(".");
                Thread.Sleep(300);
            }

            Console.WriteLine(); 
        }
    }
}