using MyMiniGame.Fighters.Classes;
using MyMiniGame.Fighters.Effects.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace MyMiniGame.Fighters.Effects
{
    struct Shield : IEffect
    {
        public string Name => "Магический Щит";
        public string FullName => "Магический щит, которой даёт небольшую защиту 10% от атаки";
        public sbyte Ticks { get; set; }
        public bool IsAttackOrDeffence => true;
        public bool IsPositiveOrNegative => true;
        public bool IsActiveOrPassive => false;
        public void SetTicks()
        {
            Ticks = 5;
        }
        public void Run(BaseFighter fighter)
        {
            fighter.TempDamage = (fighter.TempDamage / 100) * 90;
            Ticks--;
        }
    }
}
