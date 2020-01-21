using System;
using System.Collections.Generic;
using System.Text;
using MyMiniGame.Fighters.Abilitys.Interfaces;
using MyMiniGame.Fighters.Classes;
using MyMiniGame.Fighters.Effects;
using static MyMiniGame.Messager;

namespace MyMiniGame.Fighters.Abilitys
{
    class BloodBlade : IAbility
    {
        public List<EnumClasses> IdClass => new List<EnumClasses>(new EnumClasses[]{EnumClasses.Thief});

        public string FullInfo => "Кровавый меч, наносит урон и накладывать эффект кровотечения";

        public int Cost => 50;

        public string Name => "Слабый Кровавый меч";

        public void Use(BaseFighter fighter, BaseFighter enemy)
        {
            int dmg = (fighter.Strength * 10 / 3) - enemy.Defence;
            if (dmg < 0)
                dmg = 0;

            enemy.TempDamage = (uint)dmg;
            fighter.Mana -= Cost;
            enemy.AddEffect(new Bleeding());
            Console.WriteLine($"{fighter.Name} Использует BloodBLade и наносит: {enemy.TempDamage}");
            enemy.Health -= (int)enemy.TempDamage;
        }
    }
}
