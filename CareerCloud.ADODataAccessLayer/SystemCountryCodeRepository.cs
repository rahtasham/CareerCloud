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
	public class SystemCountryCodeRepository : BaseADO, IDataRepository<SystemCountryCodePoco>
	{
		public void Add(params SystemCountryCodePoco[] items)
		{
			using (SqlConnection conn = new SqlConnection(connString))
			{
				SqlCommand command = new SqlCommand();
				command.Connection = conn;

				foreach (SystemCountryCodePoco poco in items)
				{
					command.CommandText = @"INSERT INTO [dbo].[System_Country_Codes]
							([Code],[Name])
							Values
							(@Code, @Name)";

					command.Parameters.AddWithValue("@Code", poco.Code);
					command.Parameters.AddWithValue("@Name", poco.Name);
				}
			}
		}

		public void CallStoredProc(string name, params Tuple<string, string>[] parameters)
		{
			throw new NotImplementedException();
		}

		public IList<SystemCountryCodePoco> GetAll(params Expression<Func<SystemCountryCodePoco, object>>[] navigationProperties)
		{
			SystemCountryCodePoco[] pocos = new SystemCountryCodePoco[500];
			using (SqlConnection conn = new SqlConnection(connString))
			{
				SqlCommand command = new SqlCommand("Select * from System_Country_Codes", conn);

				int position = 0;

				SqlDataReader reader = command.ExecuteReader();

				while (reader.Read())
				{
					SystemCountryCodePoco poco = new SystemCountryCodePoco();

					
					poco.Code = reader.GetString(0);
					poco.Name = reader.GetString(1);
					
					pocos[position] = poco;
					position++;
				}
			}
			return pocos.ToList();

		}

		public IList<SystemCountryCodePoco> GetList(Expression<Func<SystemCountryCodePoco, bool>> where, params Expression<Func<SystemCountryCodePoco, object>>[] navigationProperties)
		{
			throw new NotImplementedException();
		}

		public SystemCountryCodePoco GetSingle(Expression<Func<SystemCountryCodePoco, bool>> where, params Expression<Func<SystemCountryCodePoco, object>>[] navigationProperties)
		{
			IQueryable<SystemCountryCodePoco> pocos = GetAll().AsQueryable();
			return pocos.Where(where).FirstOrDefault();

		}

		public void Remove(params SystemCountryCodePoco[] items)
		{
			throw new NotImplementedException();
		}

		public void Update(params SystemCountryCodePoco[] items)
		{
			using (SqlConnection conn = new SqlConnection(connString))
			{
				SqlCommand cmd = new SqlCommand();
				cmd.Connection = conn;

				foreach (SystemCountryCodePoco poco in items)
				{
					cmd.CommandText = @"UPDATE System_Country_Code
						SET Name = @Name
							WHERE Code = @Code";

					
					cmd.Parameters.AddWithValue("@Name", poco.Name);
					cmd.Parameters.AddWithValue("@Code", poco.Code);

					conn.Open();
					int numOfRows = cmd.ExecuteNonQuery();
					conn.Close();

				}
			}

		}
	}
}
