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
    public class UserDatabaseTest
    {
        [TestMethod]
        public void Should_Have_Three_Users_In_Database()
        {
            using (var connection = new SqlConnection(globals.connectionString))
            {
                connection.Open();
                var command = new SqlCommand("SELECT COUNT(*) FROM Users", connection);
                int count = (int)command.ExecuteScalar();
                Assert.AreEqual(3, count);
            }
        }

    }
}
