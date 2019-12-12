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
        public List<EnumClasses> IdClass => new List<EnumClasses>(new EnumClasses[] {EnumClasses.Cleric});
        public string FullInfo => "Восстанавливает немного здоровья";

        public int Cost => 10;

        public void Use(BaseFighter fighterOne, BaseFighter fighterTwo)
        {
            int hlth = (int)(fighterOne.Intellegence * 0.25);
            messager?.Invoke($"---> {fighterOne.Name} лечится на {hlth}! <---");
            fighterOne.Health += hlth;
        }
    }
}
