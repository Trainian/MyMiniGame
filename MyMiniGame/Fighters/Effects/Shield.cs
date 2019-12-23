using MyMiniGame.Fighters.Classes;
using MyMiniGame.Fighters.Effects.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace MyMiniGame.Fighters.Effects
{
    class Shield : IEffect
    {
        public string Name => "Магический Щит";
        public string FullName => "Магический щит, которой даёт небольшую защиту 10% от атаки";
        public sbyte Ticks { get; set; } = 5;
        public bool IsPositive => true;
        public bool IsActive => false;

        public int Run(int dmg)
        {
            dmg = (dmg / 100) * 90;
            Ticks--;
            return dmg;
        }
    }
}
