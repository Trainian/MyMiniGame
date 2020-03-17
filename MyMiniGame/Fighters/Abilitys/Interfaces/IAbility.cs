using MyMiniGame.Fighters.Classes;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyMiniGame.Fighters.Abilitys.Interfaces
{
    public interface IAbility
    {
        /// <summary>
        /// Классы, которые могут использовать Абилку
        /// </summary>
        List<EnumClasses> IdClass { get; }
        /// <summary>
        /// Наименование
        /// </summary>
        string Name { get; }
        /// <summary>
        /// Информация о Способности
        /// </summary>
        string FullInfo { get; }
        /// <summary>
        /// Стоимость способности
        /// </summary>
        int Cost { get; }
        /// <summary>
        /// Абилка атакующая ?
        /// true - Да
        /// false - Нет
        /// </summary>
        bool IsAttack { get; }
        /// <summary>
        /// Использовать Способность
        /// </summary>
        /// <param name="fighter">Атакующий</param>
        /// <param name="enemy">Защищающийся</param>   
        int Use(BaseFighter fighter, BaseFighter enemy);
    }
}
