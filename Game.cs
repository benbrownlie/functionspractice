using System;
using System.Collections.Generic;
using System.Text;

namespace HelloWorld
{


    struct Item
    {
        public int statBoost;

    }

    class Game
    {
        bool _gameOver = false;
        Player _player1;
        Player _player2;
        Item sword;
        Item axe;

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

        public void InitializePlayers()
        {
            _player1.health = 100;
            _player1.damage = 5;

            _player2.health = 100;
            _player2.damage = 5;
        }

        public void InitializeItems()
        {
            sword.statBoost = 10;
            axe.statBoost = 15;
        }

        //Displays options to the player, Outputs the choice of the two options
        public void GetInput(out char input, string option1, string option2, string query)
        {
            //Prints descriptions to the console
            Console.WriteLine(query);
            //prints options to the console
            Console.WriteLine("1." +option1);
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
        //Equip items to both players at the beginning of the game
        public void SelectItems()
        {
            //Get input from Player1
            char input;
            GetInput(out input, "Sword", "Axe", "Welcome! Player 1 choose a weapon.");
            //Equip item based on input value
            if (input == '1')
            {
                _player1.EquipItem(sword);
            }
            else if (input == '2')
            {
                _player1.EquipItem(axe);
            }
            Console.WriteLine("Player 1");
            _player1.PrintStats();

            //Get input from Player2
            GetInput(out input, "Sword", "Axe", "Welcome! Player 2 choose a weapon.");
            //Equip item based on input value
            if (input == '1')
            {
                _player2.EquipItem(sword);
            }
            else if (input == '2')
            {
                _player2.EquipItem(axe);
            }
            Console.WriteLine("Player 2");
            _player2.PrintStats();
        }

        public void CreateCharacter(Player player)
        {
            Console.WriteLine("What is your name?");
            string name = Console.ReadLine();
            Player player = new Player(name, 100, 10);
            SelectItems(player);
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
                GetInput(out input, "Attack", "No", "\nYour turn Player 1");

                if (input == '1')
                {
                    _player1.Attack(_player2);
                }
                else
                {
                    Console.WriteLine("NOOOOOOOOOOOO");
                }

                GetInput(out input, "Attack", "No", "\nYour turn Player 2");

                if (input == '1')
                {
                    _player2.Attack(_player1);
                }
                else
                {
                    Console.WriteLine("NOOOOOOOOOOOO");
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


        //Performed once when the game begins
        public void Start()
        {
            //InitializePlayers();
            InitializeItems();
        }

        //Repeated until the game ends
        public void Update()
        {
            CreateCharacter(_player1 = CreateCharacter);
            CreateCharacter(_player2 = CreateCharacter);
            
            StartBattle();
        }

        //Performed once when the game ends
        public void End()
        {
            
        }
    }
}
