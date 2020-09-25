﻿using System;
using System.Collections.Generic;
using System.Text;

namespace HelloWorld
{
    class Wizard : Character
    {
        private float _mana;

        public Wizard(float manaVal) : base()
        {
            _mana = 100;
        }

        public Wizard(float healthVal, string nameVal, float damageVal, float manaval) : base(healthVal, nameVal, damageVal)
        {
            _mana = manaval;
        }

        public override float Attack(Character enemy)
        {
            float damageTaken = 0.0f;
            if (_mana >= 4)
            {
                float totalDamage = _damage + _mana * .25f;
                _mana -= _mana * .25f;
                damageTaken = enemy.TakeDamage(totalDamage);
                return damageTaken;
            }
            base.Attack(enemy);
            return damageTaken;
        }
    }
}
