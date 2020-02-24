using MyMiniGame.Fighters.Classes;
using MyMiniGame.Fighters.Effects.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace MyMiniGame.Fighters.Effects
{
    public class Shield : IEffect
    {
        public Shield()
        {
            Ticks = 3;
        }

        public string Name => "Магический Щит";
        public string FullName => "Магический щит, которой даёт небольшую защиту 10% от атаки";
        public sbyte Ticks { get; set; }
        public bool IsAttackOrDeffence => true;
        public bool IsPositiveOrNegative => true;
        public bool IsActiveOrPassive => false;
        public void Run(BaseFighter fighter)
        {
            fighter.TempDamage = (fighter.TempDamage / 100) * 90;
            Ticks--;
        }
    }
}
//TODO: Не верно работает щит, урон того кто накладывал равен 0-ю, хотя должен уменьшать наносимый ему урон