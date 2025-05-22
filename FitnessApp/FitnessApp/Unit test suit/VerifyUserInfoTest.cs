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
    public class VerifyUserInfoTest
    {
        [TestMethod]
        public void Should_Have_Correct_UserInfo_Values()
        {
            using (var connection = new SqlConnection(globals.connectionString))
            {
                connection.Open();
                var command = new SqlCommand("SELECT age, height, weight FROM UserInfos WHERE userId = 2", connection);
                using (var reader = command.ExecuteReader())
                {
                    reader.Read();
                    Assert.AreEqual(29, reader.GetInt32(0));
                    Assert.AreEqual(165, reader.GetInt32(1));
                    Assert.AreEqual(58, reader.GetInt32(2));
                }
            }
        }

    }
}
