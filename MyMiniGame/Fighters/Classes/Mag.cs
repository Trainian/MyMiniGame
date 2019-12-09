﻿using System;
using System.Collections.Generic;
using System.Text;
using MyMiniGame.Fighters.Abilitys;

namespace MyMiniGame.Fighters.Classes
{
    /// <summary>
    /// Класс : Маг
    /// </summary>
    /// 
    class Mag : BaseFighter
    {
        public override EnumClasses Class { get; set; } = EnumClasses.Mag;
        public override byte Level { get; set; } = 1;
        public override int Strength { get; set; } = 5;
        public override int Defence { get; set; } = 5;
        public override int Agility { get; set; } = 5;
        public override int Intellegence { get; set; } = 10;
        public override int Health { get; set; }
        public override int Mana { get; set; }
        public Mag(string name) : base(name)
        {
            Ability = new FireBall();
        }
    }
}
