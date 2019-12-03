using System;
using System.Collections.Generic;
using System.Text;
using MyMiniGame.Fighters.Abilitys.Interfaces;
using static MyMiniGame.Messager;

namespace MyMiniGame.Fighters.Abilitys
{
    class BloodBlade : IAbility
    {
        public List<EnumClasses> IdClass => new List<EnumClasses>(new EnumClasses[]{EnumClasses.Thief});

        public string FullInfo => "Кровавый меч, который способен нанести урон и вернуть часть жизней владельцу";

        public void Use(BaseFighter fighter, BaseFighter enemy)
        {
            int dmg = enemy.Defence - (fighter.Strength / 2);
            int hlth = (enemy.Defence - (fighter.Strength / 2)) / 3;
            messager?.Invoke($"{fighter.Name} Использует BloodBLade и наносит: {dmg}");
            messager?.Invoke($"{fighter.Name} восстанавливает жизни на {hlth}");
            enemy.Health -= dmg;
            fighter.Health += hlth;
        }
    }
}
