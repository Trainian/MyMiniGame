using MyMiniGame.Fighters.Classes;
using MyMiniGame.Fighters.Effects.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyMiniGame.Fighters.Effects
{
    class Bleeding : IEffect
    {
        public string Name => "Кровотечение";

        public string FullName => "В течении определенного времени наносит не большой урон";

        public bool IsPositive => false;

        public sbyte Ticks { get; set; } = 3;

        public bool IsActive => true;

        public int Run(int dmg)
        {
            dmg = 1;
            Ticks--;
            return dmg;
        }
    }
}
