using CareerCloud.DataAccessLayer;
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
	public class SecurityLoginsLogRepository : BaseADO, IDataRepository<SecurityLoginsLogPoco>
	{
		public void Add(params SecurityLoginsLogPoco[] items)
		{
			using (SqlConnection conn = new SqlConnection(connString))
			{
				SqlCommand command = new SqlCommand();
				command.Connection = conn;

				foreach (SecurityLoginsLogPoco poco in items)
				{
					command.CommandText = @"INSERT INTO [dbo].[Security_Logins_Log]
							([Id],[Login],[Source_IP],[Logon_Date],[Is_Succesful])
							Values
							(@Id, @Login, @Source_IP, @Logon_Date, @Is_Succesful)";

					command.Parameters.AddWithValue("@Id", poco.Id);
					command.Parameters.AddWithValue("@Login", poco.Login);
					command.Parameters.AddWithValue("@Source_IP", poco.SourceIP);
					command.Parameters.AddWithValue("@Logon_Date", poco.LogonDate);
					command.Parameters.AddWithValue("@Is_Succesful", poco.IsSuccesful);
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

		public IList<SecurityLoginsLogPoco> GetAll(params Expression<Func<SecurityLoginsLogPoco, object>>[] navigationProperties)
		{
			SecurityLoginsLogPoco[] pocos = new SecurityLoginsLogPoco[1723];
			using (SqlConnection conn = new SqlConnection(connString))
			{
				SqlCommand command = new SqlCommand("Select * from Security_Logins_Log", conn);

				conn.Open();
				int position = 0;

				SqlDataReader reader = command.ExecuteReader();

				while (reader.Read())
				{
					SecurityLoginsLogPoco poco = new SecurityLoginsLogPoco();

					poco.Id = reader.GetGuid(0);
					poco.Login = reader.GetGuid(1);
					poco.SourceIP = reader.GetString(2);
					poco.LogonDate = reader.GetDateTime(3);
					poco.IsSuccesful = reader.GetBoolean(4);

					pocos[position] = poco;
					position++;
				}

				conn.Close();
			}
			return pocos.Where(a => a != null).ToList();

		}

		public IList<SecurityLoginsLogPoco> GetList(Expression<Func<SecurityLoginsLogPoco, bool>> where, params Expression<Func<SecurityLoginsLogPoco, object>>[] navigationProperties)
		{
			throw new NotImplementedException();
		}

		public SecurityLoginsLogPoco GetSingle(Expression<Func<SecurityLoginsLogPoco, bool>> where, params Expression<Func<SecurityLoginsLogPoco, object>>[] navigationProperties)
		{
			IQueryable<SecurityLoginsLogPoco> pocos = GetAll().AsQueryable();
			return pocos.Where(where).FirstOrDefault();

		}

		public void Remove(params SecurityLoginsLogPoco[] items)
		{

			using (SqlConnection conn = new SqlConnection(connString))
			{
				SqlCommand cmd = new SqlCommand();
				cmd.Connection = conn;

				foreach (SecurityLoginsLogPoco poco in items)
				{
					cmd.CommandText = @"DELETE FROM [dbo].[Security_Logins_Log] where Id = @ID";
					cmd.Parameters.AddWithValue("@Id", poco.Id);

					conn.Open();
					int numOfRows = cmd.ExecuteNonQuery();
					conn.Close();
				}
			}

		}


			public void Update(params SecurityLoginsLogPoco[] items)
		{
			using (SqlConnection conn = new SqlConnection(connString))
			{
				SqlCommand cmd = new SqlCommand();
				cmd.Connection = conn;

				foreach (SecurityLoginsLogPoco poco in items)
				{
					cmd.CommandText = @"UPDATE Security_Logins_Log
						SET Login = @Login, 
							Source_IP = @Source_IP,
							Logon_Date = @Logon_Date,
							Is_Succesful = @Is_Succesful
							WHERE Id = @Id";

					cmd.Parameters.AddWithValue("@Login", poco.Login);
					cmd.Parameters.AddWithValue("@Source_IP", poco.SourceIP);
					cmd.Parameters.AddWithValue("@Logon_Date", poco.LogonDate);
					cmd.Parameters.AddWithValue("@Is_Succesful", poco.IsSuccesful);
					cmd.Parameters.AddWithValue("@Id", poco.Id);

					conn.Open();
					int numOfRows = cmd.ExecuteNonQuery();
					conn.Close();

				}
			}



		}
	}
}
