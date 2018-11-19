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
	public class CompanyProfileRepository : BaseADO, IDataRepository<CompanyProfilePoco>
	{
		public void Add(params CompanyProfilePoco[] items)
		{
			using (SqlConnection conn = new SqlConnection(connString))
			{
				SqlCommand command = new SqlCommand();
				command.Connection = conn;

				foreach (CompanyProfilePoco poco in items)
				{
					command.CommandText = @"INSERT INTO [dbo].[Company_Profiles]
							([Id],[Registration_Date],[Company_Website],[Contact_Phone],
								[Contact_Name],[Company_Logo],  [Time_Stamp])
							Values
							(@Id, @Registration_Date, @Company_Website, @Contact_Phone, @Contact_Name, 
							@Company_Logo, @Time_Stamp)";

					command.Parameters.AddWithValue("@Id", poco.Id);
					command.Parameters.AddWithValue("@Registration_Date", poco.RegistrationDate);
					command.Parameters.AddWithValue("@Company_Website", poco.CompanyWebsite);
					command.Parameters.AddWithValue("@Contact_Phone", poco.ContactPhone);
					command.Parameters.AddWithValue("@Contact_Name", poco.ContactName);
					command.Parameters.AddWithValue("@Company_Logo", poco.CompanyLogo);
					command.Parameters.AddWithValue("@Time_Stamp", poco.TimeStamp);
				}
			}
		}

		public void CallStoredProc(string name, params Tuple<string, string>[] parameters)
		{
			throw new NotImplementedException();
		}

		public IList<CompanyProfilePoco> GetAll(params Expression<Func<CompanyProfilePoco, object>>[] navigationProperties)
		{
			CompanyProfilePoco[] pocos = new CompanyProfilePoco[500];
			using (SqlConnection conn = new SqlConnection(connString))
			{
				SqlCommand command = new SqlCommand("Select * from Company_Profiles", conn);

				int position = 0;

				SqlDataReader reader = command.ExecuteReader();

				while (reader.Read())
				{
					CompanyProfilePoco poco = new CompanyProfilePoco();

					poco.Id = reader.GetGuid(0);
					poco.RegistrationDate = reader.GetDateTime(1);
					poco.CompanyWebsite = reader.GetString(2);
					poco.ContactPhone = reader.GetString(3);
					poco.ContactName = reader.GetString(4);
					poco.CompanyLogo = (byte[])reader[5];
					poco.TimeStamp = (byte[])reader[6];

					pocos[position] = poco;
					position++;
				}
			}
			return pocos.ToList();

		}

		public IList<CompanyProfilePoco> GetList(Expression<Func<CompanyProfilePoco, bool>> where, params Expression<Func<CompanyProfilePoco, object>>[] navigationProperties)
		{
			throw new NotImplementedException();
		}

		public CompanyProfilePoco GetSingle(Expression<Func<CompanyProfilePoco, bool>> where, params Expression<Func<CompanyProfilePoco, object>>[] navigationProperties)
		{
			IQueryable<CompanyProfilePoco> pocos = GetAll().AsQueryable();
			return pocos.Where(where).FirstOrDefault();

		}

		public void Remove(params CompanyProfilePoco[] items)
		{
			throw new NotImplementedException();
		}

		public void Update(params CompanyProfilePoco[] items)
		{
			using (SqlConnection conn = new SqlConnection(connString))
			{
				SqlCommand cmd = new SqlCommand();
				cmd.Connection = conn;

				foreach (CompanyProfilePoco poco in items)
				{
					cmd.CommandText = @"UPDATE Company_Profiles
						SET Registration_Date = @Registration_Date, 
							Company_Website = @Company_Website,
							Contact_Phone = @Contact_Phone,
							Contact_Name = @Contact_Name,
							Company_Logo = @Company_Logo
							WHERE Id = @Id";

					cmd.Parameters.AddWithValue("@Registration_Date", poco.RegistrationDate);
					cmd.Parameters.AddWithValue("@Company_Website", poco.CompanyWebsite);
					cmd.Parameters.AddWithValue("@Contact_Phone", poco.ContactPhone);
					cmd.Parameters.AddWithValue("@Contact_Name", poco.ContactName);
					cmd.Parameters.AddWithValue("@Company_Logo", poco.CompanyLogo);
					cmd.Parameters.AddWithValue("@Id", poco.Id);

					conn.Open();
					int numOfRows = cmd.ExecuteNonQuery();
					conn.Close();

				}
			}



		}
	}
}
