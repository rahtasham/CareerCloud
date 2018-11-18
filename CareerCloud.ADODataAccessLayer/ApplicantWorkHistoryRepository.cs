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
			throw new NotImplementedException();
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
			throw new NotImplementedException();
		}

		public void Remove(params ApplicantWorkHistoryPoco[] items)
		{
			throw new NotImplementedException();
		}

		public void Update(params ApplicantWorkHistoryPoco[] items)
		{
			throw new NotImplementedException();
		}
	}
}
