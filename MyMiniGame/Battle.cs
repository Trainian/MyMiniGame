using MyMiniGame.Fighters.Classes;
using MyMiniGame.Fighters.Effects.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using MyMiniGame.Menus;
using static MyMiniGame.Messager;

namespace MyMiniGame
{
    static class Battle
    {
        private static int _damage;
        private static BaseFighter _attacking;
        private static BaseFighter _protecting;


        /// <summary>
        /// Старт атаки
        /// </summary>
        /// <param name="fighter">Атакующий</param>
        /// <param name="enemy">Защитник</param>
        /// <param name="choise">Выбор атакаи, обычная или магичская</param>
        /// <returns>true - Смерть одного из бойцов</returns>
        public static void StartAttack(this BaseFighter fighter, BaseFighter enemy, EnumAttackChoise choice)
        {
            _attacking = fighter;
            _protecting = enemy;
            _damage = 0;

            switch (choice)
            {
                case EnumAttackChoise.BaseAttack:
                    BaseAttack();
                    break;
                case EnumAttackChoise.MagicAttack:
                    SuperAbility();
                    break;
                default:
                    throw new NullReferenceException("Ошибка выбора атаки");
            }
            _protecting.Health -= _damage;
            FighterInfoHelper.AttackMessage(fighter, enemy, _damage);
        }


        /// <summary>
        /// Обычная такая
        /// </summary>
        /// <param name="fighterOne">Атакующий</param>
        /// <param name="fighterTwo">Защищающийся</param>
        private static void BaseAttack()
        {
            _damage = (_attacking.Strength * 10) - _protecting.Defence;
            EffectsInAttack(_attacking);
            EffectsInDefence(_protecting);
        }


        /// <summary>
        /// Использование супер-способностей
        /// </summary>
        /// <param name="fighterOne">Атакующий</param>
        /// <param name="fighterTwo">Защищающийся</param>
        private static void SuperAbility()
        {
            _damage = _attacking.Ability.Use(_attacking, _protecting);
            if(_attacking.Ability.IsAttack)
            {
                EffectsInAttack(_attacking);
                EffectsInDefence(_protecting);
            }
        }


        /// <summary>
        /// Запуск атакующих эффектов
        /// </summary>
        /// <param name="fighter">Боец</param>
        public static void EffectsInAttack(BaseFighter fighter)
        {
            var attackEffects = fighter?.GetEffects().FindAll(x => x.IsAttackOrDeffence == true);
            RunEffects(attackEffects, fighter);
        }


        /// <summary>
        /// Запуск пзащитных эффектов
        /// </summary>
        /// <param name="fighter">Боец</param>
        public static void EffectsInDefence(BaseFighter fighter)
        {
            var deffenceEffects = fighter?.GetEffects().FindAll(x => x.IsAttackOrDeffence == false);
            RunEffects(deffenceEffects, fighter);
        }



        /// <summary>
        /// Выполняет эффекты и удаляет уже завершившиеся
        /// </summary>
        /// <param name="effects">Лист эффектов для выполнения, Негативные или Положительные</param>
        /// <param name="fighter">Боей, чьи эффекты будут запускаться</param>
        private static void RunEffects (List<IEffect> effects, BaseFighter fighterUseEffect)
        {
            foreach (var effect in effects)
            {
                _damage = effect.Run(fighterUseEffect, _damage);
                if (effect.Ticks <= 0)
                    fighterUseEffect.RemoveEffect(effect);
            }
        }
    }
}