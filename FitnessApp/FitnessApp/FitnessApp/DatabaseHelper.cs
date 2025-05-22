using System;
using System.Data.SqlClient;
using System.Data.SQLite;
using FitnessApp;

public class DatabaseHelper
{
    public static void InitializeDatabase()
    {
        string sql = @"
-- 1) Users (Kimlik sütununa explicit değer verebilmek için IDENTITY_INSERT açıyoruz)
SET IDENTITY_INSERT [dbo].[Users] ON;

IF NOT EXISTS (SELECT 1 FROM [dbo].[Users] WHERE [id] = 1)
    INSERT INTO [dbo].[Users] ([id],[name],[email],[password],[role],[created_at])
    VALUES (1,'Ahmet Yılmaz','ahmet.yilmaz@example.com','ahmet123','trainer',GETDATE());

IF NOT EXISTS (SELECT 1 FROM [dbo].[Users] WHERE [id] = 2)
    INSERT INTO [dbo].[Users] ([id],[name],[email],[password],[role],[created_at])
    VALUES (2,'Zeynep Demir','zeynep.demir@example.com','zeynep123','customer',GETDATE());

IF NOT EXISTS (SELECT 1 FROM [dbo].[Users] WHERE [id] = 3)
    INSERT INTO [dbo].[Users] ([id],[name],[email],[password],[role],[created_at])
    VALUES (3,'Mehmet Kaya','mehmet.kaya@example.com','mehmet123','customer',GETDATE());

SET IDENTITY_INSERT [dbo].[Users] OFF;

-- 2) Customer–Trainer Matches
IF NOT EXISTS (SELECT 1 FROM [dbo].[CustomerTrainerMatches] WHERE [customer_id]=2 AND [trainer_id]=1)
    INSERT INTO [dbo].[CustomerTrainerMatches] ([customer_id],[trainer_id]) VALUES (2,1);

IF NOT EXISTS (SELECT 1 FROM [dbo].[CustomerTrainerMatches] WHERE [customer_id]=3 AND [trainer_id]=1)
    INSERT INTO [dbo].[CustomerTrainerMatches] ([customer_id],[trainer_id]) VALUES (3,1);

-- 3) UserInfos
IF NOT EXISTS (SELECT 1 FROM [dbo].[UserInfos] WHERE [userId]=1)
    INSERT INTO [dbo].[UserInfos]
        ([userId],[updated_at],[age],[height],[weight],[body_mass_index],[muscle_ratio],[fat_ratio],[gender],[waistCircumference])
    VALUES
        (1, GETDATE(), 35, 180, 80, 24.7, 45.0, 18.5, 'Male', 85);

IF NOT EXISTS (SELECT 1 FROM [dbo].[UserInfos] WHERE [userId]=2)
    INSERT INTO [dbo].[UserInfos]
        ([userId],[updated_at],[age],[height],[weight],[body_mass_index],[muscle_ratio],[fat_ratio],[gender],[waistCircumference])
    VALUES
        (2, GETDATE(), 29, 165, 58, 21.3, 38.0, 24.2, 'Female', 74);

IF NOT EXISTS (SELECT 1 FROM [dbo].[UserInfos] WHERE [userId]=3)
    INSERT INTO [dbo].[UserInfos]
        ([userId],[updated_at],[age],[height],[weight],[body_mass_index],[muscle_ratio],[fat_ratio],[gender],[waistCircumference])
    VALUES
        (3, GETDATE(), 32, 175, 90, 29.4, 35.0, 30.1, 'Male', 98);

-- 4) WorkoutPlan
IF NOT EXISTS (SELECT 1 FROM [dbo].[WorkoutPlan] WHERE [userId]=2 AND [trainerId]=1)
    INSERT INTO [dbo].[WorkoutPlan] ([userId],[trainerId],[description],[coverage])
    VALUES (2,1,'Beginner-friendly fat burning plan with cardio and light strength.',60);

IF NOT EXISTS (SELECT 1 FROM [dbo].[WorkoutPlan] WHERE [userId]=3 AND [trainerId]=1)
    INSERT INTO [dbo].[WorkoutPlan] ([userId],[trainerId],[description],[coverage])
    VALUES (3,1,'High-intensity training focused on muscle gain and endurance.',70);

-- 5) FitnessGoals
IF NOT EXISTS (SELECT 1 FROM [dbo].[FitnessGoals] WHERE [trainer_id]=1 AND [user_id]=2)
    INSERT INTO [dbo].[FitnessGoals]
        ([trainer_id],[user_id],[description],[target_date],[created_at],[coverage])
    VALUES
        (1,2,'Lose 5 kg and reduce waist circumference in 2 months.', DATEADD(day,60,GETDATE()), GETDATE(), 20);

IF NOT EXISTS (SELECT 1 FROM [dbo].[FitnessGoals] WHERE [trainer_id]=1 AND [user_id]=3)
    INSERT INTO [dbo].[FitnessGoals]
        ([trainer_id],[user_id],[description],[target_date],[created_at],[coverage])
    VALUES
        (1,3,'Gain 4 kg of muscle mass in 3 months through hypertrophy training.', DATEADD(day,90,GETDATE()), GETDATE(), 10);
";


        using (var connection = new SqlConnection(globals.connectionString))
        {
            connection.Open();
            SqlCommand command = new SqlCommand(sql, connection);
            command.ExecuteNonQuery();
        }
    }

    public static object Login(string v1, string v2)
    {
        throw new NotImplementedException();
    }

    public static bool RegisterUser(string v1, string v2, string v3, string v4)
    {
        throw new NotImplementedException();
    }
}
