using FitnessApp;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unit_test_suit
{
    [TestClass]
    public class FitnessGoalTest
    {
        [TestMethod]
        public void Should_Create_FitnessGoal_Object_Correctly()
        {
            var goal = new FitnessGoal
            {
                GoalId = 1,
                TrainerId = 1,
                UserId = 2,
                Description = "Lose 5kg",
                TargetDate = DateTime.Today.AddDays(60),
                CreatedAt = DateTime.Today,
                Coverage = 20
            };

            Assert.AreEqual("Lose 5kg", goal.Description);
            Assert.AreEqual(20, goal.Coverage);
        }

    }
}
