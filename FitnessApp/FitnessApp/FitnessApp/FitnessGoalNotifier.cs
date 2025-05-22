using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessApp
{
    public delegate void GoalReachedEventHandler(object sender, EventArgs e);

    public class FitnessTracker
    {
        public event GoalReachedEventHandler GoalReached;

        public void CheckGoal(float currentWeight, float targetWeight)
        {
            if (currentWeight <= targetWeight)
            {
                GoalReached?.Invoke(this, EventArgs.Empty);
            }
        }
    }

    public class UIHandler
    {
        public void Subscribe(FitnessTracker tracker)
        {
            tracker.GoalReached += OnGoalReached;
        }

        private void OnGoalReached(object sender, EventArgs e)
        {
            Console.WriteLine("🎯 Goal Reached! Congratulations!");
        }
    }
}