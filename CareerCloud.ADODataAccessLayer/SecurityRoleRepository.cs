﻿using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CareerCloud.ADODataAccessLayer
{
	public class SecurityRoleRepository : BaseADO, IDataRepository<SecurityRolePoco>
	{
		public void Add(params SecurityRolePoco[] items)
		{
			using (SqlConnection conn = new SqlConnection(connString))
			{
				SqlCommand command = new SqlCommand();
				command.Connection = conn;

				foreach (SecurityRolePoco poco in items)
				{
					command.CommandText = @"INSERT INTO [dbo].[Security_Roles]
							([Id],[Role],[Is_Inactive])
							Values
							(@Id, @Role, @Is_Inactive)";

					command.Parameters.AddWithValue("@Id", poco.Id);
					command.Parameters.AddWithValue("@Role", poco.Role);
					command.Parameters.AddWithValue("@Is_Inactive", poco.IsInactive);
				}

				conn.Open();
				int numOfRows = command.ExecuteNonQuery();
				conn.Close();
			}
		}

		public void CallStoredProc(string name, params Tuple<string, string>[] parameters)
		{
			throw new NotImplementedException();
		}

		public IList<SecurityRolePoco> GetAll(params Expression<Func<SecurityRolePoco, object>>[] navigationProperties)
		{
			SecurityRolePoco[] pocos = new SecurityRolePoco[500];
			using (SqlConnection conn = new SqlConnection(connString))
			{
				SqlCommand command = new SqlCommand("Select * from Security_Roles", conn);
				conn.Open();

				int position = 0;

				SqlDataReader reader = command.ExecuteReader();

				while (reader.Read())
				{
					SecurityRolePoco poco = new SecurityRolePoco();

					poco.Id = reader.GetGuid(0);
					poco.Role = reader.GetString(1);
					poco.IsInactive = reader.GetBoolean(2);
					

					pocos[position] = poco;
					position++;
				}

				conn.Close();
			}
			return pocos.Where(a => a != null).ToList();

		}

		public IList<SecurityRolePoco> GetList(Expression<Func<SecurityRolePoco, bool>> where, params Expression<Func<SecurityRolePoco, object>>[] navigationProperties)
		{
			throw new NotImplementedException();
		}

		public SecurityRolePoco GetSingle(Expression<Func<SecurityRolePoco, bool>> where, params Expression<Func<SecurityRolePoco, object>>[] navigationProperties)
		{
			IQueryable<SecurityRolePoco> pocos = GetAll().AsQueryable();
			return pocos.Where(where).FirstOrDefault();

		}

		public void Remove(params SecurityRolePoco[] items)
		{

			using (SqlConnection conn = new SqlConnection(connString))
			{
				SqlCommand cmd = new SqlCommand();
				cmd.Connection = conn;

				foreach (SecurityRolePoco poco in items)
				{
					cmd.CommandText = @"DELETE FROM [dbo].[Security_Roles] where Id = @ID";
					cmd.Parameters.AddWithValue("@Id", poco.Id);

					conn.Open();
					int numOfRows = cmd.ExecuteNonQuery();
					conn.Close();
				}
			}



		}

		public void Update(params SecurityRolePoco[] items)
		{
			using (SqlConnection conn = new SqlConnection(connString))
			{
				SqlCommand cmd = new SqlCommand();
				cmd.Connection = conn;

				foreach (SecurityRolePoco poco in items)
				{
					cmd.CommandText = @"UPDATE Security_Roles
						SET Role = @Role, 
							Is_Inactive = @Is_Inactive
							WHERE Id = @Id";

					cmd.Parameters.AddWithValue("@Role", poco.Role);
					cmd.Parameters.AddWithValue("@Is_Inactive", poco.IsInactive);
					cmd.Parameters.AddWithValue("@Id", poco.Id);

					conn.Open();
					int numOfRows = cmd.ExecuteNonQuery();
					conn.Close();

				}
			}

		}
	}
}
