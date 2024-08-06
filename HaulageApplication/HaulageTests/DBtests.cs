using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections.Generic;
using Xunit;
using SQLite;
using Haulage.BaseClasses.BillingHandler; // Update the namespace to match your project's structure

namespace HaulageTests
{
    public class DatabaseSetupTests
    {
        private SQLiteConnection GetInMemoryConnection()
        {
            var connection = new SQLiteConnection(":memory:");
            return connection;
        }

        [Fact]
        public void GetDatabasePath_ShouldReturnCorrectPath()
        {
            // Act
            var path = DatabaseSetup.GetDatabasePath();

            // Assert
            Assert.False(string.IsNullOrEmpty(path));
            Assert.True(Path.IsPathRooted(path));
        }

        [Fact]
        public void InitializeDatabase_ShouldDropAndCreateTables()
        {
            // Arrange
            using var connection = GetInMemoryConnection();

            // Act
            DatabaseSetup.CreateTables(connection);
            DatabaseSetup.InitializeDatabase();

            // Assert
            AssertTablesExist(connection);
        }

        [Fact]
        public void DropTables_ShouldDropAllTables()
        {
            // Arrange
            using var connection = GetInMemoryConnection();
            DatabaseSetup.CreateTables(connection);

            // Act
            DatabaseSetup.DropTables(connection);

            // Assert
            AssertTablesNotExist(connection);
        }

        [Fact]
        public void GenerateData_ShouldInsertDataIntoTables()
        {
            // Arrange
            using var connection = GetInMemoryConnection();
            DatabaseSetup.CreateTables(connection);

            // Act
            DatabaseSetup.GenerateData(connection);

            // Assert
            var command = new SQLiteCommand(connection)
            {
                CommandText = "SELECT COUNT(*) FROM Vehicle"
            };
            var count = command.ExecuteScalar<int>();
            Assert.Equal(3, count); // Ensure 3 vehicles are inserted
        }

        [Fact]
        public void CreateTables_ShouldCreateAllTables()
        {
            // Arrange
            using var connection = GetInMemoryConnection();

            // Act
            DatabaseSetup.CreateTables(connection);

            // Assert
            AssertTablesExist(connection);
        }

        private void AssertTablesExist(SQLiteConnection connection)
        {
            List<string> tables = new List<string>
            {
                "User", "Bill", "Event", "Expense", "Item", "Role", "Trip", "TripManifest", "Vehicle"
            };

            foreach (var table in tables)
            {
                var command = new SQLiteCommand(connection)
                {
                    CommandText = $"SELECT name FROM sqlite_master WHERE type='table' AND name='{table}';"
                };
                var result = command.ExecuteScalar<string>();
                Assert.NotNull(result);
            }
        }

        private void AssertTablesNotExist(SQLiteConnection connection)
        {
            List<string> tables = new List<string>
            {
                "User", "Bill", "Event", "Expense", "Item", "Role", "Trip", "TripManifest", "Vehicle"
            };

            foreach (var table in tables)
            {
                var command = new SQLiteCommand(connection)
                {
                    CommandText = $"SELECT name FROM sqlite_master WHERE type='table' AND name='{table}';"
                };
                var result = command.ExecuteScalar<string>();
                Assert.Null(result);
            }
        }
    }
}