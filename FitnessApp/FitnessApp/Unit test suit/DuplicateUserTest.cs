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
    public class DuplicateUserTest
    {
        [TestMethod]
        public void Should_Not_Duplicate_User()
        {
            using (var connection = new SqlConnection(globals.connectionString))
            {
                connection.Open();
                var command = new SqlCommand("SELECT COUNT(*) FROM Users WHERE email='ahmet.yilmaz@example.com'", connection);
                int count = (int)command.ExecuteScalar();
                Assert.AreEqual(1, count);
            }
        }

    }
}
