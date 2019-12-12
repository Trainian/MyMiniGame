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

        public int Cost => 15;

        public void Use(BaseFighter fighter, BaseFighter enemy)
        {
            int dmg = enemy.Defence - (fighter.Strength / 2);
            enemy.Effects.Add(new Bleeding());
            enemy.Health -= dmg;
            messager?.Invoke($"{fighter.Name} Использует BloodBLade и наносит: {dmg}");
        }
    }
}
