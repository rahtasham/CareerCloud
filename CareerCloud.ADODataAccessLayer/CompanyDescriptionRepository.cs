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
	public class CompanyDescriptionRepository : BaseADO, IDataRepository<CompanyDescriptionPoco>
	{
		public void Add(params CompanyDescriptionPoco[] items)
		{
			throw new NotImplementedException();
		}

		public void CallStoredProc(string name, params Tuple<string, string>[] parameters)
		{
			throw new NotImplementedException();
		}

		public IList<CompanyDescriptionPoco> GetAll(params Expression<Func<CompanyDescriptionPoco, object>>[] navigationProperties)
		{
			CompanyDescriptionPoco[] pocos = new CompanyDescriptionPoco[500];
			using (SqlConnection conn = new SqlConnection(connString))
			{
				SqlCommand command = new SqlCommand("Select * from Company_Descriptions", conn);

				int position = 0;

				SqlDataReader reader = command.ExecuteReader();

				while (reader.Read())
				{
					CompanyDescriptionPoco poco = new CompanyDescriptionPoco();

					poco.Id = reader.GetGuid(0);
					poco.Company = reader.GetGuid(1);
					poco.LanguageId = reader.GetString(2);
					poco.CompanyName = reader.GetString(3);
					poco.CompanyDescription = reader.GetString(4);
					poco.TimeStamp = (byte[])reader[5];

					pocos[position] = poco;
					position++;
				}
			}
			return pocos.ToList();

		}

		public IList<CompanyDescriptionPoco> GetList(Expression<Func<CompanyDescriptionPoco, bool>> where, params Expression<Func<CompanyDescriptionPoco, object>>[] navigationProperties)
		{
			throw new NotImplementedException();
		}

		public CompanyDescriptionPoco GetSingle(Expression<Func<CompanyDescriptionPoco, bool>> where, params Expression<Func<CompanyDescriptionPoco, object>>[] navigationProperties)
		{
			throw new NotImplementedException();
		}

		public void Remove(params CompanyDescriptionPoco[] items)
		{
			throw new NotImplementedException();
		}

		public void Update(params CompanyDescriptionPoco[] items)
		{
			throw new NotImplementedException();
		}
	}
}
