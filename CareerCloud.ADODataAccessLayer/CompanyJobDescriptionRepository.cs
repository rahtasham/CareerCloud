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
	public class CompanyJobDescriptionRepository : BaseADO, IDataRepository<CompanyJobDescriptionPoco>
	{
		public void Add(params CompanyJobDescriptionPoco[] items)
		{
			throw new NotImplementedException();
		}

		public void CallStoredProc(string name, params Tuple<string, string>[] parameters)
		{
			throw new NotImplementedException();
		}

		public IList<CompanyJobDescriptionPoco> GetAll(params Expression<Func<CompanyJobDescriptionPoco, object>>[] navigationProperties)
		{
			CompanyJobDescriptionPoco[] pocos = new CompanyJobDescriptionPoco[500];
			using (SqlConnection conn = new SqlConnection(connString))
			{
				SqlCommand command = new SqlCommand("Select * from Applicant_Educations", conn);

				int position = 0;

				SqlDataReader reader = command.ExecuteReader();

				while (reader.Read())
				{
					CompanyJobDescriptionPoco poco = new CompanyJobDescriptionPoco();

					poco.Id = reader.GetGuid(0);
					poco.Job = reader.GetGuid(1);
					poco.JobName = reader.GetString(2);
					poco.JobDescriptions = reader.GetString(3);
					poco.TimeStamp = (byte[])reader[7];

					pocos[position] = poco;
					position++;
				}
			}
			return pocos.ToList();

		}

		public IList<CompanyJobDescriptionPoco> GetList(Expression<Func<CompanyJobDescriptionPoco, bool>> where, params Expression<Func<CompanyJobDescriptionPoco, object>>[] navigationProperties)
		{
			throw new NotImplementedException();
		}

		public CompanyJobDescriptionPoco GetSingle(Expression<Func<CompanyJobDescriptionPoco, bool>> where, params Expression<Func<CompanyJobDescriptionPoco, object>>[] navigationProperties)
		{
			throw new NotImplementedException();
		}

		public void Remove(params CompanyJobDescriptionPoco[] items)
		{
			throw new NotImplementedException();
		}

		public void Update(params CompanyJobDescriptionPoco[] items)
		{
			throw new NotImplementedException();
		}
	}
}
