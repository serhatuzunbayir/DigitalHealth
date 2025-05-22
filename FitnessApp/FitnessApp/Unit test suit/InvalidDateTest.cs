using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unit_test_suit
{
    [TestClass]
    public class InvalidDateTest
    {
        [TestMethod]
        public void Should_Set_TargetDate_In_The_Future()
        {
            using (var connection = new SqlConnection(globals.connectionString))
            {
                connection.Open();
                var command = new SqlCommand("SELECT target_date FROM FitnessGoals WHERE user_id = 2", connection);
                DateTime targetDate = (DateTime)command.ExecuteScalar();
                Assert.IsTrue(targetDate > DateTime.Now);
            }
        }

    }
}
