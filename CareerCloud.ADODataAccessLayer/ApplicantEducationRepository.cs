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
	public class ApplicantEducationRepository : BaseADO, IDataRepository<ApplicantEducationPoco>
	{
		public void Add(params ApplicantEducationPoco[] items)
		{
			using (SqlConnection conn = new SqlConnection(connString))
			{
				SqlCommand command = new SqlCommand();
				command.Connection = conn;

				foreach (ApplicantEducationPoco poco in items)
					{
					command.CommandText = @"INSERT INTO [dbo].[Applicant_Educations]
							([Id], [Applicant], [Major], [Certificate_Diploma], [Start_Date], [Completion_Date], 
								[Completion_Percent], [Time_Stamp])
							Values
							(@Id, @Applicant, @Major, @Certificate_Diploma, @Start_Date, @Completion_Date, 
								@Completion_Percent, @Time_Stamp)";

					command.Parameters.AddWithValue("@Id", poco.Id);
					command.Parameters.AddWithValue("@Applicant", poco.Applicant);
					command.Parameters.AddWithValue("@Major", poco.Major);
					command.Parameters.AddWithValue("@Certificate_Diploma", poco.CertificateDiploma);
					command.Parameters.AddWithValue("@Start_Date", poco.StartDate);
					command.Parameters.AddWithValue("@Completion_Date", poco.CompletionDate);
					command.Parameters.AddWithValue("@Completion_Percent", poco.CompletionPercent);
					command.Parameters.AddWithValue("@Time_Stamp", poco.TimeStamp);

				}

				
			}
		}

		public void CallStoredProc(string name, params Tuple<string, string>[] parameters)
		{
			throw new NotImplementedException();
		}

		public IList<ApplicantEducationPoco> GetAll(params Expression<Func<ApplicantEducationPoco, object>>[] navigationProperties)
		{
			ApplicantEducationPoco[] pocos = new ApplicantEducationPoco[500];
			using (SqlConnection conn = new SqlConnection(connString))
			{
				SqlCommand command = new SqlCommand("Select * from Applicant_Educations", conn);

				int position = 0;

				SqlDataReader reader = command.ExecuteReader();

				while (reader.Read())
				{
					ApplicantEducationPoco poco = new ApplicantEducationPoco();

					poco.Id = reader.GetGuid(0);
					poco.Applicant = reader.GetGuid(1);
					poco.Major = reader.GetString(2);
					poco.CertificateDiploma = reader.GetString(3);
					if(!reader.IsDBNull(4))
						{
							poco.StartDate = reader.GetDateTime(4);
						}
					else
						{
							poco.StartDate = null;
						}

					if (!reader.IsDBNull(5))
						{
							poco.CompletionDate = reader.GetDateTime(5);
						}
					else
						{
							poco.CompletionDate = null;
						}

					if (!reader.IsDBNull(5))
						{
							poco.CompletionPercent = reader.GetByte(6);
						}
					else
						{
							poco.CompletionPercent = null;
						}
					poco.TimeStamp = (byte[])reader[7];

					pocos[position] = poco;
					position++;
				}
			}
			return pocos.ToList();
		}

		public IList<ApplicantEducationPoco> GetList(Expression<Func<ApplicantEducationPoco, bool>> where, params Expression<Func<ApplicantEducationPoco, object>>[] navigationProperties)
		{
			throw new NotImplementedException();
		}

		public ApplicantEducationPoco GetSingle(Expression<Func<ApplicantEducationPoco, bool>> where, params Expression<Func<ApplicantEducationPoco, object>>[] navigationProperties)
		{
			IQueryable<ApplicantEducationPoco> pocos = GetAll().AsQueryable();
			return pocos.Where(where).FirstOrDefault();
		}

		public void Remove(params ApplicantEducationPoco[] items)
		{
			throw new NotImplementedException();
		}

		public void Update(params ApplicantEducationPoco[] items)
		{
			using (SqlConnection conn = new SqlConnection(connString))
			{
				SqlCommand cmd = new SqlCommand();
				cmd.Connection = conn;

				foreach (ApplicantEducationPoco poco in items)
				{
					cmd.CommandText = @"UPDATE Applicant_Educations
						SET Applicant = @Applicant, 
							Major = @Major,
							Certificate_Diploma = @Certificate_Diploma,
							Start_Date = @Start_Date,
							Completion_Date = @Completion_Date,
							Completion_Percent = @Completion_Percent
							WHERE Id = @Id";

					cmd.Parameters.AddWithValue("@Applicant", poco.Applicant);
					cmd.Parameters.AddWithValue("@Major", poco.Major);
					cmd.Parameters.AddWithValue("@Certificate_Diploma", poco.CertificateDiploma);
					cmd.Parameters.AddWithValue("@Start_Date", poco.StartDate);
					cmd.Parameters.AddWithValue("@Completion_Date", poco.CompletionDate);
					cmd.Parameters.AddWithValue("@Completion_Percent", poco.CompletionPercent);
					cmd.Parameters.AddWithValue("@Id", poco.Id);

					conn.Open();
					int numOfRows = cmd.ExecuteNonQuery();
					conn.Close();

				}
			}
		}

