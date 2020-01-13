using MyMiniGame.Fighters.Classes;
using MyMiniGame.Fighters.Effects.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyMiniGame.Fighters.Effects
{
    struct Bleeding : IEffect
    {
        public string Name => "Кровотечение";
        public string FullName => "В течении определенного времени наносит не большой урон";
        public bool IsAttackOrDeffence => true;
        public bool IsPositiveOrNegative => false;
        public bool IsActiveOrPassive => false;
        public sbyte Ticks { get; set; }
        public void SetTicks()
        {
            Ticks = 3;
        }
        public void Run(BaseFighter fighter)
        {
            fighter.TempDamage += 1;
            Ticks--;
        }
    }
}
