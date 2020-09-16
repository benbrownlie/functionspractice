﻿using System;
using System.Collections.Generic;
using System.Text;

namespace HelloWorld
{
    class Player
    {
        private string _name;
        private int _health;
        private int _damage;
        private Item[] _inventory;

        public Player()
        {
            _inventory = new Item[3];
            _health = 100;
            _damage = 10;
        }

        public Player(string nameVal, int healthVal, int damageVal, int inventorySize)
        {
            _name = nameVal;
            _health = healthVal;
            _damage = damageVal;
            _inventory = new Item[inventorySize];
        }

        public void AddItemToInventory(Item item, int index)
        {
            _inventory[index] = item;
        }

        public void EquipItem(int itemIndex)
        {
            _damage = _inventory[itemIndex].statBoost;
        }

        public string GetName()
        {
            return _name;
        }

        public bool GetIsAlive()
        {
            return _health > 0;
        }

        public void Attack(Player enemy)
        {//Attack function for player fight
            enemy.TakeDamage(_damage);

        }

        public void Attack(Enemies monster)
        {//Attack function for monster fight
            monster.EnemyTakeDamage(_damage);
        }

        public void PrintStats()
        {
            Console.WriteLine("Name: " + _name);
            Console.WriteLine("Health: " + _health);
            Console.WriteLine("Damage: " + _damage);
        }

        private void TakeDamage(int damageVal)
        {//Take damage function for player fight
            if(GetIsAlive())
            {
                _health -= damageVal;
            }
            Console.WriteLine(_name + " took " + damageVal + "damage!");
        }

        public void TakeDamage(int enemyDamageVal, int enemyHealthVal)
        {//Take damage function for monster fight
            if(GetIsAlive())
            {
                _health -= enemyDamageVal;
            }
            Console.WriteLine(_name + " took " + enemyDamageVal + " damage!");
        }
    }
}
