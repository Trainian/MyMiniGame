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
        public uint Money { get; set; }
        /// <summary>
        /// Переменная для подсчета урона, наносится после прохождения
        /// по всем эффектам в конце
        /// </summary>
        public uint TempDamage { get; set; } = 0;
        /// <summary>
        /// Спецспособность
        /// Каждый класс может иметь только свои Способности
        /// </summary>
        public IAbility Ability
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
        public void AddEffect(IEffect newEffect)
        {
            if (_effects.Count != 0)
                foreach (var myEffect in _effects.ToArray())
                {
                    if (myEffect.Name == newEffect.Name)
                    {
                        _effects.Remove(myEffect);
                    }
                }
            _effects.Add(newEffect);
        }
        public void RemoveEffect(IEffect effect)
        {
            _effects.Remove(effect);
        }
        public List<IEffect> GetEffects()
        {
            return _effects;
        }
        /// <summary>
        /// Конструктор для задания Жизней и Маны
        /// </summary>
        /// <param name="name">Имя персонажа</param>
        public BaseFighter(string name)
        {
            Name = name;
            Health = Strength * 100;
            Mana = Intellegence * 100;
            _effects = new List<IEffect>();
            Level = 1;
        }
    }
}
