using System;
using System.Collections.Generic;
using MyMiniGame.Fighters.Abilitys.Interfaces;
using MyMiniGame.Fighters.Classes;
using MyMiniGame.Fighters.Effects;

namespace MyMiniGame.Fighters.Abilitys.LowGrade
{
    public struct BloodBlade : IAbility
    {
        public List<EnumClasses> IdClass => new List<EnumClasses>(new EnumClasses[]{EnumClasses.Thief});

        public string FullInfo => "Кровавый меч, наносит урон и накладывать эффект кровотечения";

        public int Cost => 50;

        public string Name => "Слабый Кровавый меч";

        public bool IsAttack => true;

        public int Use(BaseFighter fighter, BaseFighter enemy)
        {
            int damage = ((fighter.Strength * 15) - enemy.Defence);
            if (damage < 0)
                damage = 0;

            fighter.Mana -= Cost;
            enemy.AddEffect(new Bleeding());
            Console.WriteLine($"{fighter.Name} Использует BloodBLade");
            return damage;
        }
    }
}
