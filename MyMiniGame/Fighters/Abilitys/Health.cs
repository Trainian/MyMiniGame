using MyMiniGame.Fighters.Abilitys.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using static MyMiniGame.Program;

namespace MyMiniGame.Fighters
{
    public class Health : IAbility
    {
        public string Name { get; } = "Health";
        public string FullInfo { get; } = "Восстанавливает немного здоровья";

        public void Use(BaseFighter fighterOne, BaseFighter fighterTwo)
        {
            if(fighterOne.Mana >= 25)
            {
                fighterOne.Health += fighterOne.Intellegence * 1;
                fighterOne.Mana -= 25;
                messager($"{fighterOne.Name} лечится !");
            }
            else
                messager("Мана закончилась :(");
        }
    }
}
