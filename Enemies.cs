using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace HelloWorld
{
    class Enemies
    {
        public string _monstername;
        public int _monsterhealth;
        public int _monsterdamage;

        public Enemies()
        {
            //Default enemy stats
            _monsterhealth = 0;
            _monsterdamage = 0;
        }

        public Enemies(int enemyHealthVal, int enemyDamageVal, string enemyNameVal)
        {
            _monsterdamage = enemyDamageVal;
            _monsterhealth = enemyHealthVal;
            _monstername = enemyNameVal;
        }

        public bool GetEnemyAlive()
        {
            return _monsterhealth > 0;
        }

        public void EnemyDealDamage(Enemies enemy)
        {
           //Enemies.EnemyTakeDamage(_enemyDamage);
        }

        public void EnemyTakeDamage(int enemyDamageVal)
        {
            if (GetEnemyAlive())
            {
                _monsterhealth -= enemyDamageVal;
            }
        }
        
    }
}
