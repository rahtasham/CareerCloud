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
	public class CompanyJobEducationRepository : BaseADO, IDataRepository<CompanyJobEducationPoco>
	{
		public void Add(params CompanyJobEducationPoco[] items)
		{
			throw new NotImplementedException();
		}

		public void CallStoredProc(string name, params Tuple<string, string>[] parameters)
		{
			throw new NotImplementedException();
		}

		public IList<CompanyJobEducationPoco> GetAll(params Expression<Func<CompanyJobEducationPoco, object>>[] navigationProperties)
		{
			CompanyJobEducationPoco[] pocos = new CompanyJobEducationPoco[500];
			using (SqlConnection conn = new SqlConnection(connString))
			{
				SqlCommand command = new SqlCommand("Select * from Company_Job_Educations", conn);

				int position = 0;

				SqlDataReader reader = command.ExecuteReader();

				while (reader.Read())
				{
					CompanyJobEducationPoco poco = new CompanyJobEducationPoco();

					poco.Id = reader.GetGuid(0);
					poco.Job = reader.GetGuid(1);
					poco.Major = reader.GetString(2);
					poco.Importance = reader.GetInt16(3);
					poco.TimeStamp = (byte[])reader[4];

					pocos[position] = poco;
					position++;
				}
			}
			return pocos.ToList();

		}

		public IList<CompanyJobEducationPoco> GetList(Expression<Func<CompanyJobEducationPoco, bool>> where, params Expression<Func<CompanyJobEducationPoco, object>>[] navigationProperties)
		{
			throw new NotImplementedException();
		}

		public CompanyJobEducationPoco GetSingle(Expression<Func<CompanyJobEducationPoco, bool>> where, params Expression<Func<CompanyJobEducationPoco, object>>[] navigationProperties)
		{
			throw new NotImplementedException();
		}

		public void Remove(params CompanyJobEducationPoco[] items)
		{
			throw new NotImplementedException();
		}

		public void Update(params CompanyJobEducationPoco[] items)
		{
			throw new NotImplementedException();
		}
	}
}
