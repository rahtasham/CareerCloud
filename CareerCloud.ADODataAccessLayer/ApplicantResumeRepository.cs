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
			throw new NotImplementedException();
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
			throw new NotImplementedException();
		}

		public void Remove(params ApplicantResumePoco[] items)
		{
			throw new NotImplementedException();
		}

		public void Update(params ApplicantResumePoco[] items)
		{
			throw new NotImplementedException();
		}
	}
}
