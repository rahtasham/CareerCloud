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
	public class ApplicantResumeRepository : BaseADO, IDataRepository<ApplicantResumePoco>
	{
		public void Add(params ApplicantResumePoco[] items)
		{
			using (SqlConnection conn = new SqlConnection(connString))
			{
				SqlCommand command = new SqlCommand();
				command.Connection = conn;

				foreach (ApplicantResumePoco poco in items)
				{
					command.CommandText = @"INSERT INTO [dbo].[Applicant_Resumes]
							([Id], [Applicant],[Resume], [Last_Updated] )
							Values
							(@Id, @Applicant, @Resume, @Last_Updated)";

					command.Parameters.AddWithValue("@Id", poco.Id);
					command.Parameters.AddWithValue("@Applicant", poco.Applicant);
					command.Parameters.AddWithValue("@Resume", poco.Resume);
					command.Parameters.AddWithValue("@Last_Updated", poco.LastUpdated);
					
				}
			}

		}

		public void CallStoredProc(string name, params Tuple<string, string>[] parameters)
		{
			throw new NotImplementedException();
		}

		public IList<ApplicantResumePoco> GetAll(params Expression<Func<ApplicantResumePoco, object>>[] navigationProperties)
		{
			ApplicantResumePoco[] pocos = new ApplicantResumePoco[500];
			using (SqlConnection conn = new SqlConnection(connString))
			{
				SqlCommand command = new SqlCommand("Select * from Applicant_Resumes", conn);

				int position = 0;

				SqlDataReader reader = command.ExecuteReader();

				while (reader.Read())
				{
					ApplicantResumePoco poco = new ApplicantResumePoco();

					poco.Id = reader.GetGuid(0);
					poco.Applicant = reader.GetGuid(1);
					poco.Resume = reader.GetString(2);

					if (!reader.IsDBNull(3))
					{
						poco.LastUpdated = reader.GetDateTime(3);
					}
					else
					{
						poco.LastUpdated = null;
					}
					poco.LastUpdated = reader.GetDateTime(3);

					pocos[position] = poco;
					position++;
				}
			}
			return pocos.ToList();
		}

		public IList<ApplicantResumePoco> GetList(Expression<Func<ApplicantResumePoco, bool>> where, params Expression<Func<ApplicantResumePoco, object>>[] navigationProperties)
		{
			throw new NotImplementedException();
		}

		public ApplicantResumePoco GetSingle(Expression<Func<ApplicantResumePoco, bool>> where, params Expression<Func<ApplicantResumePoco, object>>[] navigationProperties)
		{
			IQueryable<ApplicantResumePoco> pocos = GetAll().AsQueryable();
			return pocos.Where(where).FirstOrDefault();

		}

		public void Remove(params ApplicantResumePoco[] items)
		{
			using (SqlConnection conn = new SqlConnection(connString))
			{
				SqlCommand cmd = new SqlCommand();
				cmd.Connection = conn;

				foreach (ApplicantResumePoco poco in items)
				{
					cmd.CommandText = @"DELETE FROM Applicant_Resumes where Id = @ID";
					cmd.Parameters.AddWithValue("@Id", poco.Id);

					conn.Open();
					int numOfRows = cmd.ExecuteNonQuery();
					conn.Close();
				}
			}
		}

		public void Update(params ApplicantResumePoco[] items)
		{
			using (SqlConnection conn = new SqlConnection(connString))
			{
				SqlCommand cmd = new SqlCommand();
				cmd.Connection = conn;

				foreach (ApplicantResumePoco poco in items)
				{
					cmd.CommandText = @"UPDATE Applicant_Resumes
						SET Applicant = @Applicant, 
							Resume = @Resume,
							Last_Updated = @Last_Updated
							WHERE Id = @Id";

					cmd.Parameters.AddWithValue("@Applicant", poco.Applicant);
					cmd.Parameters.AddWithValue("@Resume", poco.Resume);
					cmd.Parameters.AddWithValue("@Last_Updated", poco.LastUpdated);
					cmd.Parameters.AddWithValue("@Id", poco.Id);

					conn.Open();
					int numOfRows = cmd.ExecuteNonQuery();
					conn.Close();

				}
			}

		}
	}
}
