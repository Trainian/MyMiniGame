using MyMiniGame.Fighters.Abilitys.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using static MyMiniGame.Program;
using static MyMiniGame.Messager;
using MyMiniGame.Fighters.Classes;

namespace MyMiniGame.Fighters.Abilitys
{
    public struct Cure : IAbility
    {
        public List<EnumClasses> IdClass => new List<EnumClasses>(new EnumClasses[] {EnumClasses.Priest});
        public string FullInfo => "Восстанавливает немного здоровья";

        public int Cost => 30;

        public string Name => "Лёгкое Лечение";

        public bool IsAttack => false;

        public void Use(BaseFighter fighter, BaseFighter enemy)
        {
            int hlth = (int)(fighter.Intellegence * 0.25);
            fighter.Mana -= Cost;
            Console.WriteLine($"---> {fighter.Name} лечится на {hlth}! <---");
            fighter.Health += hlth;
        }
    }
}
