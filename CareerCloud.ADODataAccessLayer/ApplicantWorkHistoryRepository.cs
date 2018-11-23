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
	public class ApplicantWorkHistoryRepository : BaseADO, IDataRepository<ApplicantWorkHistoryPoco>
	{
		public void Add(params ApplicantWorkHistoryPoco[] items)
		{
			using (SqlConnection conn = new SqlConnection(connString))
			{
				SqlCommand command = new SqlCommand();
				command.Connection = conn;

				foreach (ApplicantWorkHistoryPoco poco in items)
				{
					command.CommandText = @"INSERT INTO [dbo].[Applicant_Educations]
							([Id], [Applicant], [Company_Name],[Country_Code],[Location],[Job_Title],
								[Job_Description],[Start_Month],[Start_Year],[End_Month],
								[End_Year],[Time_Stamp] )
							Values
							(@Id, @Applicant, @Major, @Certificate_Diploma, @Start_Date, @Completion_Date, 
								@Completion_Percent, @Time_Stamp)";

					command.Parameters.AddWithValue("@Id", poco.Id);
					command.Parameters.AddWithValue("@Applicant", poco.Applicant);
					command.Parameters.AddWithValue("@Company_Name", poco.CompanyName);
					command.Parameters.AddWithValue("@Country_Code", poco.CountryCode);
					command.Parameters.AddWithValue("@Location", poco.Location);
					command.Parameters.AddWithValue("@Job_Title", poco.JobTitle);
					command.Parameters.AddWithValue("@Job_Description", poco.JobDescription);
					command.Parameters.AddWithValue("@Start_Month", poco.StartMonth);
					command.Parameters.AddWithValue("@Start_Year", poco.StartYear);
					command.Parameters.AddWithValue("@End_Month", poco.EndMonth);
					command.Parameters.AddWithValue("@End_Year", poco.EndYear);
					command.Parameters.AddWithValue("@Time_Stamp", poco.TimeStamp);
				}
			}

		}

		public void CallStoredProc(string name, params Tuple<string, string>[] parameters)
		{
			throw new NotImplementedException();
		}

		public IList<ApplicantWorkHistoryPoco> GetAll(params Expression<Func<ApplicantWorkHistoryPoco, object>>[] navigationProperties)
		{
			ApplicantWorkHistoryPoco[] pocos = new ApplicantWorkHistoryPoco[500];
			using (SqlConnection conn = new SqlConnection(connString))
			{
				SqlCommand command = new SqlCommand("Select * from [dbo].[Applicant_Work_History]", conn);

				int position = 0;

				SqlDataReader reader = command.ExecuteReader();

				while (reader.Read())
				{
					ApplicantWorkHistoryPoco poco = new ApplicantWorkHistoryPoco();

					poco.Id = reader.GetGuid(0);
					poco.Applicant = reader.GetGuid(1);
					poco.CompanyName = reader.GetString(2);
					poco.CountryCode = reader.GetString(3);
					poco.Location = reader.GetString(4);
					poco.JobTitle = reader.GetString(5);
					poco.JobDescription = reader.GetString(6);
					poco.StartMonth = reader.GetInt16(7);
					poco.StartYear = reader.GetInt32(8);
					poco.EndMonth = reader.GetInt16(9);
					poco.EndYear = reader.GetInt32(10);
					poco.TimeStamp = (byte[])reader[11];

					pocos[position] = poco;
					position++;
				}
			}
			return pocos.ToList();

		}

		public IList<ApplicantWorkHistoryPoco> GetList(Expression<Func<ApplicantWorkHistoryPoco, bool>> where, params Expression<Func<ApplicantWorkHistoryPoco, object>>[] navigationProperties)
		{
			throw new NotImplementedException();
		}

		public ApplicantWorkHistoryPoco GetSingle(Expression<Func<ApplicantWorkHistoryPoco, bool>> where, params Expression<Func<ApplicantWorkHistoryPoco, object>>[] navigationProperties)
		{
			IQueryable<ApplicantWorkHistoryPoco> pocos = GetAll().AsQueryable();
			return pocos.Where(where).FirstOrDefault();

		}

		public void Remove(params ApplicantWorkHistoryPoco[] items)
		{
			using (SqlConnection conn = new SqlConnection(connString))
			{
				SqlCommand cmd = new SqlCommand();
				cmd.Connection = conn;

				foreach (ApplicantWorkHistoryPoco poco in items)
				{
					cmd.CommandText = @"DELETE FROM Applicant_Work_History where Id = @ID";
					cmd.Parameters.AddWithValue("@Id", poco.Id);

					conn.Open();
					int numOfRows = cmd.ExecuteNonQuery();
					conn.Close();
				}
			}

		}

		public void Update(params ApplicantWorkHistoryPoco[] items)
		{
			using (SqlConnection conn = new SqlConnection(connString))
			{
				SqlCommand cmd = new SqlCommand();
				cmd.Connection = conn;

				foreach (ApplicantWorkHistoryPoco poco in items)
				{
					cmd.CommandText = @"UPDATE Applicant_Educations
						SET Applicant = @Applicant, 
							Company_Name = @Company_Name,
							Country_Code = @Country_Code,
							Location = @Location,
							Job_Title = @Job_Title,
							Job_Description = @Job_Description
							Start_Month = @Start_Month,
							Start_Year = @Start_Year,
							End_Month = @End_Month,
							End_Year = @End_Year
							WHERE Id = @Id";

					cmd.Parameters.AddWithValue("@Applicant", poco.Applicant);
					cmd.Parameters.AddWithValue("@Company_Name", poco.CompanyName);
					cmd.Parameters.AddWithValue("@Country_Code", poco.CountryCode);
					cmd.Parameters.AddWithValue("@Location", poco.Location);
					cmd.Parameters.AddWithValue("@Job_Title", poco.JobTitle);
					cmd.Parameters.AddWithValue("@Job_Description", poco.JobDescription);
					cmd.Parameters.AddWithValue("@Start_Month", poco.StartMonth);
					cmd.Parameters.AddWithValue("@Start_Year", poco.StartYear);
					cmd.Parameters.AddWithValue("@End_Month", poco.EndMonth);
					cmd.Parameters.AddWithValue("@End_Year", poco.EndYear);
					cmd.Parameters.AddWithValue("@Id", poco.Id);

					conn.Open();
					int numOfRows = cmd.ExecuteNonQuery();
					conn.Close();

				}
			}












		}
	}
}
