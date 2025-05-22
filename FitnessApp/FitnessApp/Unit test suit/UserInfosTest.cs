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
    public class UserInfosTest
    {
        [TestMethod]
        public void Should_Have_Unique_Emails_In_Users()
        {
            using (var connection = new SqlConnection(globals.connectionString))
            {
                connection.Open();
                var command = new SqlCommand(@"
            SELECT email, COUNT(*) AS cnt 
            FROM Users 
            GROUP BY email 
            HAVING COUNT(*) > 1", connection);
                using (var reader = command.ExecuteReader())
                {
                    Assert.IsFalse(reader.HasRows); // Should not contain duplicate e-mails.
                }
            }
        }
    }
}
