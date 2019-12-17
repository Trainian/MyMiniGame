using MyMiniGame.Fighters.Abilitys.Interfaces;
using MyMiniGame.Fighters.Effects.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyMiniGame.Fighters.Classes
{
    public abstract class BaseFighter
    {
        private IAbility _ability;
        private List<IEffect> _effects;

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
        public abstract EnumClasses Class { get; set; }
        /// <summary>
        /// Уровень, каждый уровень даёт +3 очка
        /// </summary>
        public byte Level { get; set; } = 1;
        /// <summary>
        /// Опыт, чем больше опыта, тем выше уровень
        /// </summary>
        public uint Exp { get; set; } = 0;
        /// <summary>
        /// Кол-во очков для повышения характеристик
        /// </summary>
        public uint LvlUp { get; set; } = 0;
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
        public int Health { get; set; }
        /// <summary>
        /// Мана = Интеллект * 10
        /// </summary>
        public int Mana { get; set; }
        /// <summary>
        /// Деньги
        /// </summary>
        /// <value></value>//
        public uint Money { get; set; }
        /// <summary>
        /// Спецспособность
        /// Каждый класс может иметь только свои Способности
        /// </summary>
        public virtual IAbility Ability
        {
            get => _ability;
            set
            {
                foreach (var item in value.IdClass)
                {
                    if (Class == item)
                        _ability = value;
                }
            }
        }
        /// <summary>
        /// Наложенные эффекты, будь то защита, отравление и т.д.
        /// </summary>
        public virtual List<IEffect> Effects
        {
            get => _effects;
            set
            {
                // Ищим эффекты, которые совпадают уже с существующими
                // если существует, то обновляем эффект
                // после чего удаляем их из новых, которые уже обновили старые
                foreach (var myEffect in _effects)
                {
                    foreach (var newEffect in value)
                    {
                        if (myEffect.Name == newEffect.Name)
                        {
                            myEffect.Ticks = newEffect.Ticks;
                            value.Remove(newEffect);
                        }
                    }
                }
                // Перебираем эффекты, которые не существовали
                // и добавляем в список эффектов
                value.ForEach(x => _effects.Add(x));
            }
        }
        /// <summary>
        /// Конструктор для задания Жизней и Маны
        /// </summary>
        /// <param name="name">Имя персонажа</param>
        public BaseFighter(string name)
        {
            Name = name;
            Health = Strength * 10;
            Mana = Intellegence * 10;
            _effects = new List<IEffect>();
            Level = 1;
        }

    }
}
