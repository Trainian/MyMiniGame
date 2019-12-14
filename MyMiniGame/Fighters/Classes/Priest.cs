using System;
using System.Collections.Generic;
using System.Text;
using MyMiniGame.Fighters.Abilitys;
using MyMiniGame.Fighters.Abilitys.Interfaces;

namespace MyMiniGame.Fighters.Classes
{
    /// <summary>
    /// Класс : Священник
    /// </summary>
    class Priest : BaseFighter
    {
        public override EnumClasses Class { get; set; } = EnumClasses.Priest;
        public override int Strength { get; set; } = 5;
        public override int Defence { get; set; } = 5;
        public override int Agility { get; set; } = 5;
        public override int Intellegence { get; set; } = 10;
        public Priest(string name) : base(name) 
        {
            Ability = new Cure();
        }
    }
}
