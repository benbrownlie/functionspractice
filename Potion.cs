using System;
using System.Collections.Generic;
using System.Text;

namespace HelloWorld
{
    class Potions
    {
        private string _itemName;
        private int _regen;
        private int _boost;


        public Potions()
        {
            _regen = 20;
            _boost = 10;
        }

        public Potions(string itemNameVal, int regenVal, int boostVal)
        {
            _itemName = itemNameVal;
            _regen = regenVal;
            _boost = boostVal;
        }

        public void PotionStand()
        {
            char input = ' ';
            Console.WriteLine("Welcome to the brewery! What are you looking for friend?");
            Console.WriteLine("1. Health Potion");
            Console.WriteLine("2. Damage Potion");
            if (input == '1')
            {
                Console.WriteLine("You chose the Health Potion!");
                _itemName = "Health Potion";
                _regen = 30;
                _boost = 0;
            }

            else if(input == '2')
            {
                Console.WriteLine("You chose the Damage Potion!");
                _itemName = "Damage Potion";
                _regen = 0;
                _boost = 10;
            }

        }

    }
}
