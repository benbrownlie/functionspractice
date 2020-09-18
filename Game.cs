using System;
using System.Collections.Generic;
using System.Text;

namespace HelloWorld
{


    struct Item
    {
        public string name;
        public int statBoost;

    }

    class Game
    {
        bool _gameOver = false;
        Player _player1;
        Player _player2;
        Item sword;
        Item axe;
        Item bow;
        Item spear;
        Item bomb;
        Item hammer;
        public Enemies monster;

        //Run the game
        public void Run()
        {
            Start();

            while(_gameOver == false)
            {
                Update();
            }

            End();
        }

        public void InitializeItems()
        {
            sword.name = "Sword";
            sword.statBoost = 15;
            axe.name = "Axe";
            axe.statBoost = 20;
            bow.name = "Bow";
            bow.statBoost = 12;
            spear.name = "Spear";
            spear.statBoost = 18;
            bomb.name = "Bomb";
            bomb.statBoost = 30;
            hammer.name = "Hammer";
            hammer.statBoost = 35;
        }
        
        public void SelectGameMode()
        {
            Console.WriteLine("Welcome to the test garden! Please select a gamemode.");
            char input;
            GetInput(out input, "Singleplayer", "Multiplayer", "Choose");
            if (input == '1')
            {
                Console.Clear();
                Console.WriteLine("You have chosen singleplayer!");
            }
            else
            {
                Console.Clear();
                Console.WriteLine("You have chosen multiplayer!");
                _player1 = CreateCharacter();
                _player2 = CreateCharacter();
                StartBattle();
            }
        }

        //Displays options to the player, Outputs the choice of the two options
        public void GetInput(out char input, string option1, string option2, string query)
        {
            //Prints descriptions to the console
            Console.WriteLine(query);
            //prints options to the console
            Console.WriteLine("1." + option1);
            Console.WriteLine("2." + option2);
            Console.Write(">");

            input = ' ';
            //loop until valid input is recieved
            while (input != '1' && input != '2')
            {
                input = Console.ReadKey().KeyChar;
                if(input != '1' && input != '2')
                {
                    Console.WriteLine("Invalid input");
                }
            }
        }

        public void GetInput(out char input, string option1, string option2, string option3, string query)
        {
            //Prints descriptions to the console
            Console.WriteLine(query);
            //prints options to the console
            Console.WriteLine("1." + option1);
            Console.WriteLine("2." + option2);
            Console.WriteLine("3." + option3);
            Console.Write(">");

            input = ' ';
            //loop until valid input is recieved
            while (input != '1' && input != '2' && input != '3')
            {
                input = Console.ReadKey().KeyChar;
                if (input != '1' && input != '2' && input != '3')
                {
                    Console.WriteLine("Invalid input");
                }
            }
        }

        //Equip items to both players at the beginning of the game
        public void SelectLoadout(Player player)
        {
            Console.WriteLine("Loadout 1: ");
            Console.WriteLine(sword.name);
            Console.WriteLine(bow.name);
            Console.WriteLine(spear.name);

            Console.WriteLine("\nLoadout 2: ");
            Console.WriteLine(axe.name);
            Console.WriteLine(hammer.name);
            Console.WriteLine(bomb.name);
            Console.WriteLine();
            //Get input from Player1
            char input;
            GetInput(out input, "Loadout 1", "Loadout 2", "Welcome! Please choose a weapon.");
            //Equip item based on input value
            if (input == '1')
            {
                player.AddItemToInventory(sword, 0);
                player.AddItemToInventory(bow, 1);
                player.AddItemToInventory(spear, 2);
            }
            else if (input == '2')
            {
                player.AddItemToInventory(axe, 0);
                player.AddItemToInventory(hammer, 1);
                player.AddItemToInventory(bomb, 2);
            };
        }

        public Player CreateCharacter()
        {
            Console.WriteLine("What is your name?");
            string name = Console.ReadLine();
            Player player = new Player(name, 100, 10, 3);
            SelectLoadout(player);
            return player;
        }

        public void SwitchWeapons(Player player)
        {
            Item[] inventory = player.GetInventory();

            char input = ' ';
            //Prints all items to the screen
            for(int i = 0; i < inventory.Length; i++)
            {
                Console.WriteLine((i+1) + ". " + inventory[i].name + "\n Damage: " + inventory[1].statBoost);
            }
            Console.WriteLine("> ");

            switch(input)
            {
                case '1':
                    {
                        player.EquipItem(0);
                        Console.WriteLine("You equipped " + inventory[0].name);
                        Console.WriteLine("Base damage increased by " + inventory[0].statBoost);
                        break;
                    }
                case '2':
                    {
                        player.EquipItem(1);
                        Console.WriteLine("You equipped " + inventory[1].name);
                        Console.WriteLine("Base damage increased by " + inventory[1].statBoost);
                        break;
                    }
                case '3':
                    {
                        player.EquipItem(2);
                        Console.WriteLine("You equipped " + inventory[2].name);
                        Console.WriteLine("Base damage increased by " + inventory[2].statBoost);
                        break;
                    }
                default:
                    {
                        player.UnequipItem();
                        Console.WriteLine("You accidentally dropped your weapon. \nPepehands");
                        break;
                    }
            }
        }

        public void StartBattle()
        {
            Console.Clear();
            Console.WriteLine("Begin battle!");

            while(_player1.GetIsAlive() && _player2.GetIsAlive())
            {
                //prints player stats to console
                Console.WriteLine("\nPlayer 1");
                _player1.PrintStats();
                Console.WriteLine("\nPlayer 2");
                _player2.PrintStats();
                //Player 1 turn start
                //Get player input
                char input;
                GetInput(out input, "Attack", "Change Weapon", "\nYour turn Player 1");

                if (input == '1')
                {
                    _player1.Attack(_player2);
                }
                else
                {
                    SwitchWeapons(_player1);
                }

                GetInput(out input, "Attack", "No", "\nYour turn Player 2");

                if (input == '1')
                {
                    _player2.Attack(_player1);
                }
                else
                {
                    SwitchWeapons(_player2);
                }
                Console.Clear();
            }

            if(_player1.GetIsAlive())
            {
                Console.WriteLine("Player 1 wins!!!");
            }
            else
            {
                Console.WriteLine("Player 2 wins!!!");
            }
            Console.ReadKey();
            _gameOver = true;
        }

        public void EnemyBattle()
        {
            while(_player1.GetIsAlive() && monster.GetEnemyAlive())
            {
                Console.WriteLine("\nPlayer");
                _player1.PrintStats();
                char input;
                GetInput(out input, "Attack", "Potion", "What will you do?");
                if (input == '1')
                {
                    _player1.Attack(monster);

                }
                else
                {

                }
            }
        }
        public void BattleArena(int enemyWave, int enemyHealthVal, int enemyDamageVal, string enemyNameVal)
        {//Wave based enemy fight
            Console.WriteLine("You enter into the arena.");
            Console.WriteLine("An enemy steps out before you.");
            switch (enemyWave)
            {
                case 1:
                    {
                        Console.WriteLine("A skeleton enters the arena!");
                        enemyNameVal = "Skeleton";
                        enemyHealthVal = 30;
                        enemyDamageVal = 10;
                        break;
                    }
                case 2:
                    {
                        Console.WriteLine("A ghoul enters the arena!");
                        enemyNameVal = "Ghoul";
                        enemyHealthVal = 50;
                        enemyDamageVal = 40;
                        break;
                    }
                case 3:
                    {
                        Console.WriteLine("A phantom enters the arena");
                        enemyNameVal = "Phantom";
                        enemyHealthVal = 80;
                        enemyDamageVal = 30;
                        break;
                    }
                case 4:
                    {
                        Console.WriteLine("The final boss enters the arena");
                        enemyNameVal = "Final Boss";
                        enemyHealthVal = 150;
                        enemyDamageVal = 40;
                        break;
                    }
                default:
                    {
                        Console.WriteLine("You made it to the end!");
                        break;
                    }
            }
        }

        public void ArenaWave(int enemyWave)
        {
            switch (enemyWave)
            {
                case 1:
                    {
                        Console.WriteLine("Wave 1.");
                        break;
                    }
                case 2:
                    {
                        Console.WriteLine("Wave 2.");
                        break;
                    }
                case 3:
                    {
                        Console.WriteLine("Wave 3.");
                        break;
                    }
                case 4:
                    {
                        Console.WriteLine("FINAL WAVE.");
                        break;
                    }
            }
            int waveNum = 0;
            //if (EnemyBattle(enemyWave, waveNum))
            {

            }

        }


        //Performed once when the game begins
        public void Start()
        {
            InitializeItems();
        }

        //Repeated until the game ends
        public void Update()
        {
            _player1 = CreateCharacter();
            _player2 = CreateCharacter();
            StartBattle();
        }

        //Performed once when the game ends
        public void End()
        {
            
        }
    }
}
