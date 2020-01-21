﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyMiniGame.Fighters.Classes;
using MyMiniGame.Fighters.Effects;
using MyMiniGame.Fighters.Effects.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyMiniGame.Fighters.Classes.Tests
{
    [TestClass()]
    public class BaseFighterTests
    {
        BaseFighter fighter, fighterTest;
        [TestInitialize]
        public void Setup ()
        {
            fighter = new Thief("Class");
            fighterTest = new Thief("TestClass");
        }

        [TestMethod()]
        public void Effects_ReNewEffect_OneEffect()
        {
            fighter.AddEffect(new Bleeding());
            fighterTest.AddEffect(new Bleeding());

            fighterTest.AddEffect(new Bleeding());

            CollectionAssert.AreEqual(fighter.GetEffects(), fighterTest.GetEffects());
        }
    }
}