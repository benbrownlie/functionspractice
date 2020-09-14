using System;
using System.Collections.Generic;
using System.Text;

namespace HelloWorld
{
    struct Player
    {
        public int health;
        public int damage;
    }

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
        public void EquipItems()
        {
            //Get input from Player1
            char input;
            GetInput(out input, "Sword", "Axe", "Welcome! Player 1 choose a weapon.");
            //Equip item based on input value
            if (input == '1')
            {
              _player1.damage += sword.statBoost;

            }
            else if (input == '2')
            {
              _player1.damage += axe.statBoost;
            }
            Console.WriteLine("Player 1");
            PrintStats(_player1);

            //Get input from Player2
            GetInput(out input, "Sword", "Axe", "Welcome! Player 2 choose a weapon.");
            //Equip item based on input value
            if (input == '1')
            {
                _player2.damage += sword.statBoost;

            }
            else if (input == '2')
            {
                _player2.damage += axe.statBoost;
            }
            Console.WriteLine("Player 2");
            PrintStats(_player2);
        }

        public void StartBattle()
        {
            Console.Clear();
            Console.WriteLine("Begin battle!");

            while(_player1.health > 0 && _player2.health > 0)
            {
                //prints player stats to console
                Console.WriteLine("\nPlayer 1");
                PrintStats(_player1);
                Console.WriteLine("\nPlayer 2");
                PrintStats(_player2);
                //Player 1 turn start
                //Get player input
                char input;
                GetInput(out input, "Attack", "No", "\nYour turn Player 1");

                if (input == '1')
                {
                    _player2.health -= _player1.damage;
                    Console.WriteLine("Player 1 swung their weapon and dealt " + _player1.damage + " damage to Player 2");
                }
                else
                {
                    Console.WriteLine("NOOOOOOOOOOOO");
                }

                GetInput(out input, "Attack", "No", "\nYour turn Player 2");

                if (input == '1')
                {
                    _player1.health -= _player2.damage;
                    Console.WriteLine("Player 2 swung their weapon and dealt " + _player2.damage + " damage to Player 1");
                }
                else
                {
                    Console.WriteLine("NOOOOOOOOOOOO");
                }
                Console.Clear();
            }

            if(_player1.health > 0)
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

        //Prints player stats to the console
        public void PrintStats(Player player)
        {
            Console.WriteLine("Health: " + player.health);
            Console.WriteLine("Damage: " + player.damage);
        }


        //Performed once when the game begins
        public void Start()
        {
            InitializePlayers();
            InitializeItems();
        }

        //Repeated until the game ends
        public void Update()
        {
            EquipItems();
            StartBattle();
        }

        //Performed once when the game ends
        public void End()
        {
            
        }
    }
}
