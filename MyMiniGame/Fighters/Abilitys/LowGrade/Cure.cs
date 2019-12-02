﻿using MyMiniGame.Fighters.Abilitys.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using static MyMiniGame.Program;
using static MyMiniGame.Messager;

namespace MyMiniGame.Fighters.Abilitys
{
    public struct Cure : IAbility
    {
        public Classes IdClass => Classes.Cleric;
        public string FullInfo => "Восстанавливает немного здоровья";

        public void Use(BaseFighter fighterOne, BaseFighter fighterTwo)
        {
            int hlth = fighterOne.Intellegence * 1;
            messager?.Invoke($"---> {fighterOne.Name} лечится на {hlth}! <---");
            fighterOne.Health += hlth;
        }
    }
}
