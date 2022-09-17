﻿using ZooLabLibrary.Animals.Birds;
using ZooLabLibrary.Animals.Medicines;
using ZooLabLibrary.Animals.Foods;
using ZooLabLibrary.Enclosures;
using ZooLabLibrary.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooLabLibrary.Animals;
using Xunit;


namespace ZooLabLibrary.Test.Animals.Birds
{
    public class PenguinTest
    {
        [Fact]
        public void ShouldBeAbleToCreateParrot()
        {
            Penguin penguin = new Penguin();
            Assert.NotNull(penguin);
        }

        [Fact]
        public void ShouldBeAbleToCreateSickParrot()
        {
            Penguin penguin = new Penguin(isSick: true);
            Assert.NotNull(penguin);
            Assert.True(penguin.IsSick);
        }

        [Fact]
        public void ShouldBeAbleToCreateSickAndHungryParrot()
        {
            Penguin penguin = new Penguin(isSick: true, isHungry: true);
            Assert.NotNull(penguin);
            Assert.True(penguin.IsSick);
            Assert.True(penguin.IsHungry);
        }

        [Fact]
        public void ShouldBeAbleToReturnRequiredSpaceSqFt()
        {
            Penguin penguin = new Penguin();
            var requiredSpaceSqFt = penguin.RequiredSpaceSqFt;
            Assert.Equal(10, requiredSpaceSqFt);
        }

        [Fact]
        public void ShouldBeAbleToReturnFavouriteFood()
        {
            Penguin penguin = new Penguin();
            var favouriteFood = penguin.FavouriteFood;
            Assert.Contains("Vegetable", favouriteFood);
            Assert.Contains("Grass", favouriteFood);
        }

        [Fact]
        public void ShouldBeAbleToAssessIsAnimalFriendlyOrNot()
        {

            Penguin penguin = new Penguin();
            Parrot parrot = new Parrot();
            Assert.False(penguin.IsFriendlyWith(parrot));
        }


        [Fact]
        public void ShouldBeAbleToFeedPenguin()
        {
            Penguin penguin = new Penguin();
            penguin.IsHungry = true;
            Meat pieceOfMeat = new Meat();
            penguin.Feed(pieceOfMeat);
            Assert.True(penguin.IsHungry);
            Vegetable vegetable = new Vegetable();
            penguin.Feed(vegetable);
            Assert.False(penguin.IsHungry);
        }


        [Fact]
        public void ShouldBeAbleToAddScheduale()
        {
            Penguin penguin = new Penguin();
            var hours = new List<int>() { 10, 15 };
            penguin.AddScheduale(hours);
            Assert.Contains(10, penguin.FeedScheduale);
            Assert.Contains(15, penguin.FeedScheduale);
        }


        [Fact]
        public void ShouldBeAbleToHealParrot()
        {
            Penguin penguin = new Penguin(isSick: true);
            var antiInflammatory = new AntiInflammatory();
            penguin.Heal(antiInflammatory);
            Assert.False(penguin.IsSick);
        }


    }
}