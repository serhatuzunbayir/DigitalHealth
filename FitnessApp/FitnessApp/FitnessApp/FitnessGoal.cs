using System;

namespace FitnessApp
{
    public class FitnessGoal
    {
        public int GoalId { get; set; }
        public int TrainerId { get; set; }
        public int UserId { get; set; }
        public string Description { get; set; }
        public DateTime TargetDate { get; set; }
        public DateTime CreatedAt { get; set; }
        public int Coverage { get; set; }
    }
}
