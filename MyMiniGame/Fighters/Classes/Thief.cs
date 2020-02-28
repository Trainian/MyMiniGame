﻿using MyMiniGame.Fighters.Abilitys;
using System;
using System.Collections.Generic;
using System.Text;
using MyMiniGame.Fighters.Abilitys.LowGrade;

namespace MyMiniGame.Fighters.Classes
{
    /// <summary>
    /// Класс : Вор
    /// </summary>
    /// 
    public class Thief : BaseFighter
    {
        public override EnumClasses Class { get; set; } = EnumClasses.Thief;
        public override int Strength { get; set; } = 5;
        public override int Defence { get; set; } = 5;
        public override int Agility { get; set; } = 10;
        public override int Intellegence { get; set; } = 5;
        public Thief(string name) : base(name)
        {
            Ability = new BloodBlade();
        }
    }
}
