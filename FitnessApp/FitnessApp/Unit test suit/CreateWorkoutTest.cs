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
    public class CreateWorkOutTest
    {
        [TestMethod]
        public void Should_Have_WorkoutPlan_For_User()
        {
            using (var connection = new SqlConnection(globals.connectionString))
            {
                connection.Open();
                var command = new SqlCommand("SELECT COUNT(*) FROM WorkoutPlan WHERE userId = 2", connection);
                int count = (int)command.ExecuteScalar();
                Assert.AreEqual(1, count);
            }
        }

    }
}