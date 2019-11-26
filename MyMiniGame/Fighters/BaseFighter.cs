using MyMiniGame.Fighters.Abilitys.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyMiniGame
{
    public abstract class BaseFighter 
    {
        public string Name { get; set; }
        public abstract string Class { get; set; }
        public abstract byte Level { get; set; }
        public abstract int Strength { get; set; }
        public abstract int Defence { get; set; }
        public abstract int Agility { get; set; }
        public abstract int Intellegence { get; set; }
        public abstract int Health { get; set; }
        public abstract int Mana { get; set; }
        public abstract IAbility Ability { get; set; }

        public BaseFighter(string name)
        {
            Name = name;
            Health = Strength * 10;
            Mana = Intellegence * 10;
        }
    }
}
