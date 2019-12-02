using MyMiniGame.Fighters.Abilitys;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyMiniGame.Fighters
{
    /// <summary>
    /// Класс : Вор
    /// </summary>
    /// 
    class Thief : BaseFighter
    {
        public override Classes Class { get; set; } = Classes.Thief;
        public override byte Level { get; set; } = 1;
        public override int Strength { get; set; } = 5;
        public override int Defence { get; set; } = 5;
        public override int Agility { get; set; } = 5;
        public override int Intellegence { get; set; } = 10;
        public override int Health { get; set; }
        public override int Mana { get; set; }
        public Thief(string name) : base(name)
        {
            Ability = new BloodBlade();
        }
    }
}
