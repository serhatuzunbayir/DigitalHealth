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
    public class CoverageTest
    {
        [TestMethod]
        public void Should_Have_Valid_Coverage_Values()
        {
            using (var connection = new SqlConnection(globals.connectionString))
            {
                connection.Open();
                var command = new SqlCommand(@"
            SELECT COUNT(*) 
            FROM FitnessGoals 
            WHERE coverage < 0 OR coverage > 100", connection);
                int invalidCount = (int)command.ExecuteScalar();
                Assert.AreEqual(0, invalidCount);
            }
        }

    }
}
