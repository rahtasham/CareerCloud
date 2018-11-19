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
	public class CompanyJobRepository : BaseADO, IDataRepository<CompanyJobPoco>
	{
		public void Add(params CompanyJobPoco[] items)
		{
			using (SqlConnection conn = new SqlConnection(connString))
			{
				SqlCommand command = new SqlCommand();
				command.Connection = conn;

				foreach (CompanyJobPoco poco in items)
				{
					command.CommandText = @"INSERT INTO [dbo].[Company_Jobs]
							([Id], [Company], [Profile_Created], [Is_Inactive],[Is_Company_Hidden],
								[Time_Stamp])
							Values
							(@Id, @Company, @Major, @Profile_Created, @Is_Inactive, @Is_Company_Hidden, 
								@Completion_Percent, @Time_Stamp)";

					command.Parameters.AddWithValue("@Id", poco.Id);
					command.Parameters.AddWithValue("@Company", poco.Company);
					command.Parameters.AddWithValue("@Profile_Created", poco.ProfileCreated);
					command.Parameters.AddWithValue("@Is_Inactive", poco.IsInactive);
					command.Parameters.AddWithValue("@Is_Company_Hidden", poco.IsCompanyHidden);
					command.Parameters.AddWithValue("@Time_Stamp", poco.TimeStamp);

				}
			}
		}	

		public void CallStoredProc(string name, params Tuple<string, string>[] parameters)
		{
			throw new NotImplementedException();
		}

		public IList<CompanyJobPoco> GetAll(params Expression<Func<CompanyJobPoco, object>>[] navigationProperties)
		{
			CompanyJobPoco[] pocos = new CompanyJobPoco[500];
			using (SqlConnection conn = new SqlConnection(connString))
			{
				SqlCommand command = new SqlCommand("Select * from Company_Jobs", conn);

				int position = 0;

				SqlDataReader reader = command.ExecuteReader();

				while (reader.Read())
				{
					CompanyJobPoco poco = new CompanyJobPoco();

					poco.Id = reader.GetGuid(0);
					poco.Company = reader.GetGuid(1);
					poco.ProfileCreated = reader.GetDateTime(2);
					poco.IsInactive = reader.GetBoolean(3);
					poco.IsCompanyHidden = reader.GetBoolean(4);
					poco.TimeStamp = (byte[])reader[7];

					pocos[position] = poco;
					position++;
				}
			}
			return pocos.ToList();

		}

		public IList<CompanyJobPoco> GetList(Expression<Func<CompanyJobPoco, bool>> where, params Expression<Func<CompanyJobPoco, object>>[] navigationProperties)
		{
			throw new NotImplementedException();
		}

		public CompanyJobPoco GetSingle(Expression<Func<CompanyJobPoco, bool>> where, params Expression<Func<CompanyJobPoco, object>>[] navigationProperties)
		{
			IQueryable<CompanyJobPoco> pocos = GetAll().AsQueryable();
			return pocos.Where(where).FirstOrDefault();

		}

		public void Remove(params CompanyJobPoco[] items)
		{
			throw new NotImplementedException();
		}

		public void Update(params CompanyJobPoco[] items)
		{
			using (SqlConnection conn = new SqlConnection(connString))
			{
				SqlCommand cmd = new SqlCommand();
				cmd.Connection = conn;

				foreach (CompanyJobPoco poco in items)
				{
					cmd.CommandText = @"UPDATE Company_Jobs
						SET Company = @Company, 
							Profile_Created = @Profile_Created,
							Is_Inactive = @Is_Inactive,
							Is_Company_Hidden = @Is_Company_Hidden
							WHERE Id = @Id";

					cmd.Parameters.AddWithValue("@Company", poco.Company);
					cmd.Parameters.AddWithValue("@Profile_Created", poco.ProfileCreated);
					cmd.Parameters.AddWithValue("@Is_Inactive", poco.IsInactive);
					cmd.Parameters.AddWithValue("@Is_Company_Hidden", poco.IsCompanyHidden);
					cmd.Parameters.AddWithValue("@Id", poco.Id);

					conn.Open();
					int numOfRows = cmd.ExecuteNonQuery();
					conn.Close();

				}
			}

		}
	}
}
