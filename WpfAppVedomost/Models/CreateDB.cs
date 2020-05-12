using System;
using System.IO;
using System.Data;
using System.Data.Common;
using System.Data.SQLite;
using System.Windows;

namespace WpfAppVedomost
{
    class CreateDB
    {
       public void Create()
        {
            string baseName = "Dekanat.db3";

            SQLiteConnection.CreateFile(baseName);

            SQLiteFactory factory = (SQLiteFactory)DbProviderFactories.GetFactory("System.Data.SQLite");
            using (SQLiteConnection connection = (SQLiteConnection)factory.CreateConnection())
            {
                connection.ConnectionString = "Data Source = " + baseName;
                connection.Open();

              /*  using (SQLiteCommand command = new SQLiteCommand(connection))
                {
                    command.CommandText = @"CREATE TABLE [workers] (
                    [id] integer PRIMARY KEY AUTOINCREMENT NOT NULL,
                    [name] char(100) NOT NULL,
                    [family] char(100) NOT NULL,
                    [age] int NOT NULL,
                    [profession] char(100) NOT NULL
                    );";
                    command.CommandType = CommandType.Text;
                    command.ExecuteNonQuery();
                }*/
                using (SQLiteCommand command = new SQLiteCommand(connection))
                {
                    command.CommandText = @"CREATE TABLE [Squad] (
                    [IdGroup] integer PRIMARY KEY AUTOINCREMENT NOT NULL,
                    [NumberGroup] int NOT NULL                
                    );";
                    command.CommandType = CommandType.Text;
                    command.ExecuteNonQuery();
                }
                using (SQLiteCommand command = new SQLiteCommand(connection))
                {
                    command.CommandText = @"CREATE TABLE [Discipline] (
                    [IdDiscipline] integer PRIMARY KEY AUTOINCREMENT NOT NULL,
                    [Discipline] char(100)                 
                    );";
                    command.CommandType = CommandType.Text;
                    command.ExecuteNonQuery();
                }
                  using (SQLiteCommand command = new SQLiteCommand(connection))
                  {
                      command.CommandText = @"CREATE TABLE [Sheet] (
                      [IdSheet] integer PRIMARY KEY AUTOINCREMENT NOT NULL,
                      [IdGroup] INT FOREIGNKEY REFERENCES Squad(IdGroup),
                      [IdDiscipline] INT FOREIGNKEY REFERENCES Discipline(IdDiscipline)             
                      );";
                      command.CommandType = CommandType.Text;
                      command.ExecuteNonQuery();
                  }
                  using (SQLiteCommand command = new SQLiteCommand(connection))
                  {
                      command.CommandText = @"CREATE TABLE [Students] (
                      [IdStudent] integer PRIMARY KEY AUTOINCREMENT NOT NULL,
                      [LastName] char(100) NOT NULL,
                      [FirstName] char(100) NOT NULL,
                      [Patronimic] char(100),
                      [RecordNumber] INT,
                      [IdGroup] INT FOREIGNKEY REFERENCES Squad(IdGroup)                               
                      );";
                      command.CommandType = CommandType.Text;
                      command.ExecuteNonQuery();
                  }
                MessageBox.Show("Success");

            }
        }
    }
}
