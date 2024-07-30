﻿using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Haulage.BaseClasses;
using Haulage.BaseClasses.BillingHandler;


namespace Haulage.DatabaseExecutionServices
{
    public static class BillExecutionService
    {
        public static List<Billing> GetBills()
        {
            var bills = new List<Billing>();
            var sql = "SELECT [BillId]" +
                ",[Fullname]" +
                ",[Email]" +
                ",[Item]" +
                ",[ItemDesc]" +
                ",[Cost]" +
                "FROM [Bill];";

            using (var connection = new SQLiteConnection(DatabaseSetup.GetDatabasePath()))
            {
                var command = new SQLite.SQLiteCommand(connection);
                command.CommandText = sql;
                bills = command.ExecuteQuery<Billing>();
            }

            return bills;
        }

        public static void DeleteBill(int BillId)
        {
            var bills = new List<Billing>();
            var sql = $"DELETE FROM [Bill] WHERE [BillId] = {BillId}";


            using (var connection = new SQLiteConnection(DatabaseSetup.GetDatabasePath()))
            {
                var command = new SQLite.SQLiteCommand(connection);
                command.CommandText = sql;
                command.ExecuteNonQuery();
            }

        }
        public static void SaveBill(Billing billing)
        {
            var sql = $"INSERT INTO [Bill] ([BillId], [Fullname], [Email], [Item], [ItemDesc], [Cost]) VALUES ('{billing.BillId}','{billing.Fullname}', '{billing.Email}', '{billing.Item}', '{billing.ItemDesc}', '{billing.Cost}');";

            using (var connection = new SQLiteConnection(DatabaseSetup.GetDatabasePath()))
            {
                var command = new SQLite.SQLiteCommand(connection);
                command.CommandText = sql;
                command.ExecuteNonQuery();
            }


        }

    }
}