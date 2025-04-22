using System.Data.SQLite;
using FitnessApp;

public class DatabaseHelper
{
    public static void InitializeDatabase()
    {
        string sql = @"
        PRAGMA foreign_keys = ON;

        CREATE TABLE IF NOT EXISTS user (
            id INTEGER PRIMARY KEY AUTOINCREMENT,
            name TEXT,
            email TEXT UNIQUE,
            password TEXT,
            created_at DATETIME DEFAULT CURRENT_TIMESTAMP,
            role TEXT
        );

        CREATE TABLE IF NOT EXISTS userInfos (
            infoId INTEGER PRIMARY KEY AUTOINCREMENT,
            userId INTEGER,
            updated_at DATETIME,
            age INTEGER,
            height REAL,
            weight REAL,
            body_mass_index REAL,
            muscle_ratio REAL,
            fat_ratio REAL,
            gender TEXT,
            waistCircumference REAL,
            FOREIGN KEY (userId) REFERENCES user(id)
        );

        CREATE TABLE IF NOT EXISTS workoutPlan (
            planId INTEGER PRIMARY KEY AUTOINCREMENT,
            userId INTEGER,
            trainerId INTEGER,
            description TEXT,
            coverage INTEGER,
            FOREIGN KEY (userId) REFERENCES user(id),
            FOREIGN KEY (trainerId) REFERENCES user(id)
        );

        CREATE TABLE IF NOT EXISTS fitnessGoals (
            goalId INTEGER PRIMARY KEY AUTOINCREMENT,
            trainer_id INTEGER,
            user_id INTEGER,
            description TEXT,
            target_date DATE,
            created_at DATETIME DEFAULT CURRENT_TIMESTAMP,
            coverage INTEGER,
            FOREIGN KEY (trainer_id) REFERENCES user(id),
            FOREIGN KEY (user_id) REFERENCES user(id)
        );
        ";

        using (var connection = new SQLiteConnection(globals.connectionString))
        {
            connection.Open();
            SQLiteCommand command = new SQLiteCommand(sql, connection);
            command.ExecuteNonQuery();
        }
    }
}
