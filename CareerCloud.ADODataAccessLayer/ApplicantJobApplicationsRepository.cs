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
	public class ApplicantJobApplicationsRepository : BaseADO, IDataRepository<ApplicantJobApplicationPoco>
	{
		public void Add(params ApplicantJobApplicationPoco[] items)
		{
			using (SqlConnection conn = new SqlConnection(connString))
			{
				SqlCommand command = new SqlCommand();
				command.Connection = conn;

				foreach (ApplicantJobApplicationPoco poco in items)
				{
					command.CommandText = @"INSERT INTO [dbo].[Applicant_Job_Applications]
							([Id], [Applicant], [Job], [Application_Date][Time_Stamp])
							Values
							(@Id, @Applicant, @Job, @Application_Date, @Time_Stamp)";

					command.Parameters.AddWithValue("@Id", poco.Id);
					command.Parameters.AddWithValue("@Applicant", poco.Applicant);
					command.Parameters.AddWithValue("@Job", poco.Job);
					command.Parameters.AddWithValue("@Application_Date", poco.ApplicationDate);
					command.Parameters.AddWithValue("@Time_Stamp", poco.TimeStamp);
				}
			}
		}

		public void CallStoredProc(string name, params Tuple<string, string>[] parameters)
		{
			throw new NotImplementedException();
		}

		public IList<ApplicantJobApplicationPoco> GetAll(params Expression<Func<ApplicantJobApplicationPoco, object>>[] navigationProperties)
		{
			ApplicantJobApplicationPoco[] pocos = new ApplicantJobApplicationPoco[500];

			using (SqlConnection conn = new SqlConnection(connString))
			{
				SqlCommand command = new SqlCommand("Select * from [dbo].[Applicant_Job_Applications]", conn);

				int position = 0;

				SqlDataReader reader = command.ExecuteReader();

				while (reader.Read())
				{
					ApplicantJobApplicationPoco poco = new ApplicantJobApplicationPoco();

					poco.Id = reader.GetGuid(0);
					poco.Applicant = reader.GetGuid(1);
					poco.Job = reader.GetGuid(2);
					poco.ApplicationDate = reader.GetDateTime(3);
					poco.TimeStamp = (byte[])reader[4];

					pocos[position] = poco;
					position++;
				}
			}
			return pocos.ToList();
		}

		public IList<ApplicantJobApplicationPoco> GetList(Expression<Func<ApplicantJobApplicationPoco, bool>> where, params Expression<Func<ApplicantJobApplicationPoco, object>>[] navigationProperties)
		{
			throw new NotImplementedException();
		}

		public ApplicantJobApplicationPoco GetSingle(Expression<Func<ApplicantJobApplicationPoco, bool>> where, params Expression<Func<ApplicantJobApplicationPoco, object>>[] navigationProperties)
		{
			IQueryable<ApplicantJobApplicationPoco> pocos = GetAll().AsQueryable();
			return pocos.Where(where).FirstOrDefault();
		}

		public void Remove(params ApplicantJobApplicationPoco[] items)
		{
			throw new NotImplementedException();
		}

		public void Update(params ApplicantJobApplicationPoco[] items)
		{
			using (SqlConnection conn = new SqlConnection(connString))
			{
				SqlCommand cmd = new SqlCommand();
				cmd.Connection = conn;

				foreach (ApplicantJobApplicationPoco poco in items)
				{
					cmd.CommandText = @"UPDATE Applicant_Job_Applications
						SET Applicant = @Applicant, 
							Job = @Job,
							Application_Date = @Application_Date
							WHERE Id = @Id";

					cmd.Parameters.AddWithValue("@Applicant", poco.Applicant);
					cmd.Parameters.AddWithValue("@Job", poco.Job);
					cmd.Parameters.AddWithValue("@Application_Date", poco.ApplicationDate);
					cmd.Parameters.AddWithValue("@Id", poco.Id);

					conn.Open();
					int numOfRows = cmd.ExecuteNonQuery();
					conn.Close();

				}
			}

		}
	}
}