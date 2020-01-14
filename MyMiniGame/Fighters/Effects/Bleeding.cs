using MyMiniGame.Fighters.Classes;
using MyMiniGame.Fighters.Effects.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyMiniGame.Fighters.Effects
{
    class Bleeding : IEffect
    {
        public Bleeding()
        {
            Ticks = 3;
        }

        public string Name => "Кровотечение";
        public string FullName => "В течении определенного времени наносит не большой урон";
        public bool IsAttackOrDeffence => true;
        public bool IsPositiveOrNegative => false;
        public bool IsActiveOrPassive => false;
        public sbyte Ticks { get; set; }
        public void Run(BaseFighter fighter)
        {
            int dmg = 5;
            fighter.Health -= dmg;
            Console.WriteLine($"{fighter.Name} получает урон от кровотечения {dmg}");
            Ticks--;
        }
    }
}
