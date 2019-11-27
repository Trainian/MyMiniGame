using System;
using System.Collections.Generic;
using System.Text;
using MyMiniGame.Fighters;
using MyMiniGame.Fighters.Abilitys.Interfaces;

namespace MyMiniGame
{
    /// <summary>
    /// Класс : Священник
    /// </summary>
    class Priest : BaseFighter
    {
        public override string Class { get; set; } =  "Priest";
        public override byte Level { get; set; } = 1;
        public override int Strength { get; set; } = 5;
        public override int Defence { get; set; } = 5;
        public override int Agility { get; set; } = 5;
        public override int Intellegence { get; set; } = 10;
        public override int Health { get; set; }
        public override int Mana { get; set; }
        public override IAbility Ability { get; set; } = new Health();

        public Priest(string name) : base(name){}

    }
}
