using MyMiniGame.Fighters.Classes;
using MyMiniGame.Fighters.Effects.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyMiniGame.Fighters.Effects
{
    public class Bleeding : IEffect
    {
        public Bleeding()
        {
            Ticks = 3;
        }

        public string Name => "Кровотечение";
        public string FullName => "В течении определенного времени наносит не большой урон";
        public bool IsAttackOrDeffence => false;
        public sbyte Ticks { get; set; }
        public bool IsNegative => true;
        public bool? IsActive { get; set; }

        public int Run(BaseFighter fighter, int dmg)
        {
            if (IsActive == null) // Первый запуск умения, что бы не использовался
                IsActive = true;
            else if (IsActive == true) // Если умение активно
            {
                int damage = fighter.Health / 100 * 5;
                fighter.AddMessage($"{fighter.Name} получает урон от кровотечения");
                Ticks--;
                return damage;
            }
            return dmg;
        }
    }
}
