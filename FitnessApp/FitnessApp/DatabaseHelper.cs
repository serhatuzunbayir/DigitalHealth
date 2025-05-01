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
            role TEXT DEFAULT 'trainer'
        );
        
        CREATE TABLE IF NOT EXISTS customer_trainer_matches(
            customer_id INTEGER PRIMARY KEY,
            trainer_id INTEGER
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
        
        --Örnek user olması için manuel bilgiler girdim.

        -- Users (1 trainer, 2 customers)
        INSERT OR IGNORE INTO user (id, name, email, password, role) VALUES
            (1, 'Ahmet Yılmaz', 'ahmet.yilmaz@example.com', 'ahmet123', 'trainer'),
            (2, 'Zeynep Demir', 'zeynep.demir@example.com', 'zeynep123', 'customer'),
            (3, 'Mehmet Kaya', 'mehmet.kaya@example.com', 'mehmet123', 'customer');

        -- Trainer matches
        INSERT OR IGNORE INTO customer_trainer_matches (customer_id, trainer_id) VALUES
            (2, 1),
            (3, 1);

        -- UserInfos
        INSERT OR IGNORE INTO userInfos (userId, updated_at, age, height, weight, body_mass_index, muscle_ratio, fat_ratio, gender, waistCircumference) VALUES
            (1, CURRENT_TIMESTAMP, 35, 180, 80, 24.7, 45.0, 18.5, 'Male', 85),
            (2, CURRENT_TIMESTAMP, 29, 165, 58, 21.3, 38.0, 24.2, 'Female', 74),
            (3, CURRENT_TIMESTAMP, 32, 175, 90, 29.4, 35.0, 30.1, 'Male', 98);

        -- Workout Plans
        INSERT OR IGNORE INTO workoutPlan (userId, trainerId, description, coverage) VALUES
            (2, 1, 'Beginner-friendly fat burning plan with cardio and light strength.', 60),
            (3, 1, 'High-intensity training focused on muscle gain and endurance.', 70);

        -- Fitness Goals
        INSERT OR IGNORE INTO fitnessGoals (trainer_id, user_id, description, target_date, coverage) VALUES
            (1, 2, 'Lose 5 kg and reduce waist circumference in 2 months.', date('now', '+60 days'), 20),
            (1, 3, 'Gain 4 kg of muscle mass in 3 months through hypertrophy training.', date('now', '+90 days'), 10);


        ";

        using (var connection = new SQLiteConnection(globals.connectionString))
        {
            connection.Open();
            SQLiteCommand command = new SQLiteCommand(sql, connection);
            command.ExecuteNonQuery();
        }
    }
}
