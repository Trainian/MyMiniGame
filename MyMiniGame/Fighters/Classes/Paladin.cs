using MyMiniGame.Fighters.Abilitys;
using System;
using System.Collections.Generic;
using System.Text;
using MyMiniGame.Fighters.Abilitys.LowGrade;

namespace MyMiniGame.Fighters.Classes
{
    /// <summary>
    /// Класс : Паладин
    /// </summary>
    /// 
    class Paladin : BaseFighter
    {
        public override EnumClasses Class { get; set; } = EnumClasses.Paladin;
        public override int Strength { get; set; } = 5;
        public override int Defence { get; set; } = 10;
        public override int Agility { get; set; } = 5;
        public override int Intellegence { get; set; } = 5;
        public Paladin(string name) : base(name)
        {
            Ability = new MagicShiled();
        }
    }
}
