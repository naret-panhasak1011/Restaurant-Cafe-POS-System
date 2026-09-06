using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using Microsoft.Data.SqlClient;

namespace RestaurantPOS.DataAccess
{
    /// <summary>
    /// Thin ADO.NET helper wrapping SqlConnection/SqlCommand so repositories
    /// don't repeat connection/command boilerplate. Every method opens and
    /// disposes its own connection (short-lived connections, ADO.NET best practice).
    /// </summary>
    public static class DatabaseHelper
    {
        private static string ConnectionString =>
            ConfigurationManager.ConnectionStrings["RestaurantPOSDB"].ConnectionString;

        public static SqlConnection GetConnection() => new SqlConnection(ConnectionString);

        /// <summary>Executes an INSERT/UPDATE/DELETE (or a proc doing the same) and returns rows affected.</summary>
        public static int ExecuteNonQuery(string commandText, CommandType commandType, params SqlParameter[] parameters)
        {
            using var conn = GetConnection();
            using var cmd = new SqlCommand(commandText, conn) { CommandType = commandType };
            if (parameters != null) cmd.Parameters.AddRange(parameters);
            conn.Open();
            return cmd.ExecuteNonQuery();
        }

        /// <summary>Executes a query and returns a single scalar value.</summary>
        public static object ExecuteScalar(string commandText, CommandType commandType, params SqlParameter[] parameters)
        {
            using var conn = GetConnection();
            using var cmd = new SqlCommand(commandText, conn) { CommandType = commandType };
            if (parameters != null) cmd.Parameters.AddRange(parameters);
            conn.Open();
            return cmd.ExecuteScalar();
        }

        /// <summary>Executes a query and returns a fully-materialized, disconnected DataTable.</summary>
        public static DataTable ExecuteDataTable(string commandText, CommandType commandType, params SqlParameter[] parameters)
        {
            using var conn = GetConnection();
            using var cmd = new SqlCommand(commandText, conn) { CommandType = commandType };
            if (parameters != null) cmd.Parameters.AddRange(parameters);
            using var adapter = new SqlDataAdapter(cmd);
            var table = new DataTable();
            adapter.Fill(table);
            return table;
        }

        /// <summary>
        /// Executes a stored procedure that returns an OUTPUT parameter (e.g. sp_CreateOrder's @OrderID).
        /// Returns the value of the named output parameter after execution.
        /// </summary>
        public static object ExecuteWithOutput(string procedureName, string outputParamName, params SqlParameter[] parameters)
        {
            using var conn = GetConnection();
            using var cmd = new SqlCommand(procedureName, conn) { CommandType = CommandType.StoredProcedure };
            if (parameters != null) cmd.Parameters.AddRange(parameters);
            conn.Open();
            cmd.ExecuteNonQuery();
            return cmd.Parameters[outputParamName]?.Value;
        }

        public static SqlParameter Param(string name, object value)
        {
            return new SqlParameter(name, value ?? DBNull.Value);
        }

        public static SqlParameter OutputParam(string name, SqlDbType type, int size = 0)
        {
            var p = size > 0 ? new SqlParameter(name, type, size) : new SqlParameter(name, type);
            p.Direction = ParameterDirection.Output;
            return p;
        }
    }
}
