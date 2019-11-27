using MyMiniGame.Fighters.Abilitys.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyMiniGame
{
    public abstract class BaseFighter 
    {
        /// <summary>
        /// Имя персонажа, является идентификатором
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Цвет, которым выделяется персонаж
        /// </summary>
        public ConsoleColor Color { get; set; }
        /// <summary>
        /// Класс, определяет способности
        /// </summary>
        public abstract string Class { get; set; }
        /// <summary>
        /// Уровень, каждый уровень даёт +3 очка
        /// </summary>
        public abstract byte Level { get; set; }
        /// <summary>
        /// Сила, увеличивает атаку и немного добовляет жизней
        /// </summary>
        public abstract int Strength { get; set; }
        /// <summary>
        /// Защита, увеличивает сопротивляемость урону
        /// </summary>
        public abstract int Defence { get; set; }
        /// <summary>
        /// Ловкость, даёт шанс уклониться и сделать два удара подрят
        /// </summary>
        public abstract int Agility { get; set; }
        /// <summary>
        /// Интеллект, увеличивает силу Спецспособности и колличествово Маны
        /// </summary>
        public abstract int Intellegence { get; set; }
        /// <summary>
        /// Здоровье = Сила * 10
        /// </summary>
        public abstract int Health { get; set; }
        /// <summary>
        /// Мана = Интеллект * 10
        /// </summary>
        public abstract int Mana { get; set; }
        /// <summary>
        /// Спецспособность
        /// </summary>
        public abstract IAbility Ability { get; set; }
        /// <summary>
        /// Конструктор для задания Жизней и Маны
        /// </summary>
        /// <param name="name">Имя персонажа</param>
        public BaseFighter(string name)
        {
            Name = name;
            Health = Strength * 10;
            Mana = Intellegence * 10;
        }
    }
}
