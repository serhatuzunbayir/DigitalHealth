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
    public class UpdateUserTest
    {
        [TestMethod]
        public void Should_Update_User_Weight()
        {
            using (var connection = new SqlConnection(globals.connectionString))
            {
                connection.Open();
                new SqlCommand("UPDATE UserInfos SET weight = 60 WHERE userId = 2", connection).ExecuteNonQuery();

                var command = new SqlCommand("SELECT weight FROM UserInfos WHERE userId = 2", connection);
                int weight = (int)command.ExecuteScalar();
                Assert.AreEqual(60, weight);
            }
        }

    }
}
