using MyMiniGame.Fighters.Classes;
using MyMiniGame.Fighters.Effects.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using static MyMiniGame.Messager;

namespace MyMiniGame
{
    static class Battle
    {
        /// <summary>
        /// Обычная такая
        /// </summary>
        /// <param name="fighterOne">Атакующий</param>
        /// <param name="fighterTwo">Защищающийся</param>
        /// <returns>Возвращает атаку = Силе + Эффекты</returns>
        public static int BaseAttack(this BaseFighter fighterOne, BaseFighter fighterTwo)
        {
            int dmg = 0;
            dmg += fighterOne.Strength;
            //Находим все Атакующие\Пассивные эффекты
            var effects = fighterOne.Effects.FindAll(x => x.IsActiveOrPassive == true && x.IsActiveOrPassive == false);
            foreach (var effect in effects)
            {
                effect.Run(dmg);
            }
            return dmg;
        }
        /// <summary>
        /// Использование супер-способностей
        /// </summary>
        /// <param name="fighterOne">Атакующий</param>
        /// <param name="fighterTwo">Защищающийся</param>
        /// <returns>Накладывает положительные или отрицательные эффекты</returns>
        public static int SuperAbility(this BaseFighter fighterOne, BaseFighter fighterTwo)
        {
            // Если Абилка не атакующая то используем и возвращаем -1, для обозначения что была не атакующая абилка
            if (fighterOne.Ability.IsAttack == false)
            {
                fighterOne.Ability.Use(fighterOne, fighterTwo);
                return -1;
            }
            else
            {
                int dmg = 0;

                fighterOne.Mana -= fighterOne.Ability.Cost;
                dmg += fighterOne.Ability.Use(fighterOne, fighterTwo);

                return dmg;
            }
        }
        /// <summary>
        /// Подсчет атаки или защиты Положительных и Отриацательных эффектов.
        /// </summary>
        /// <param name="fighterOne">Атакующий</param>
        /// <param name="FighterTwo">Защищающийся</param>
        /// <returns>Возвращается разница между уроном эффектов</returns>
        public static int Effects(this BaseFighter fighterOne, BaseFighter FighterTwo)
        {
            int dmg = 0;
            var posEffects = FighterTwo.Effects.FindAll(x => x.IsPositiveOrNegative == true);
            dmg += RunEffects(posEffects, FighterTwo);

            var negEffects = FighterTwo.Effects.FindAll(x => x.IsPositiveOrNegative == false);
            dmg += RunEffects(negEffects, FighterTwo);

            return dmg;
        }
        /// <summary>
        /// Выполняет эффекты и удаляет уже завершившиеся
        /// </summary>
        /// <param name="effects">Лист эффектов для выполнения, Негативные или Положительные</param>
        /// <param name="fighter">Боей, чьи эффекты будут запускаться</param>
        /// <returns>Возвращает урон от эффектов в int</returns>
        public static int RunEffects (List<IEffect> effects, BaseFighter fighter)
        {
            int dmg = 0;
            foreach (var effect in effects)
            {
                dmg += effect.Run(dmg);
                if (effect.Ticks <= 0)
                    fighter.Effects.Remove(effect);
            }
            return dmg;
        }
        /// <summary>
        /// Проверяет на смерть
        /// </summary>
        /// <param name="fighter">Боец</param>
        /// <returns>Возвращает TRUE - если мертв и FALSE - если жив</returns>
        public static bool IsDeath(this BaseFighter fighter)
        {
            if (fighter.Health <= 0)
                return true;
            else
                return false;
        }
    }
}