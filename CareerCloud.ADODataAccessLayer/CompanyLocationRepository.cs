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
	public class CompanyLocationRepository : BaseADO, IDataRepository<CompanyLocationPoco>
	{
		public void Add(params CompanyLocationPoco[] items)
		{
			throw new NotImplementedException();
		}

		public void CallStoredProc(string name, params Tuple<string, string>[] parameters)
		{
			throw new NotImplementedException();
		}

		public IList<CompanyLocationPoco> GetAll(params Expression<Func<CompanyLocationPoco, object>>[] navigationProperties)
		{
			CompanyLocationPoco[] pocos = new CompanyLocationPoco[500];
			using (SqlConnection conn = new SqlConnection(connString))
			{
				SqlCommand command = new SqlCommand("Select * from Company_Locations", conn);

				int position = 0;

				SqlDataReader reader = command.ExecuteReader();

				while (reader.Read())
				{
					CompanyLocationPoco poco = new CompanyLocationPoco();

					poco.Id = reader.GetGuid(0);
					poco.Company = reader.GetGuid(1);
					poco.CountryCode = reader.GetString(2);
					poco.Province = reader.GetString(3);
					poco.City = reader.GetString(4);
					poco.PostalCode = reader.GetString(5);
					poco.TimeStamp = (byte[])reader[6];

					pocos[position] = poco;
					position++;
				}
			}
			return pocos.ToList();

		}

		public IList<CompanyLocationPoco> GetList(Expression<Func<CompanyLocationPoco, bool>> where, params Expression<Func<CompanyLocationPoco, object>>[] navigationProperties)
		{
			throw new NotImplementedException();
		}

		public CompanyLocationPoco GetSingle(Expression<Func<CompanyLocationPoco, bool>> where, params Expression<Func<CompanyLocationPoco, object>>[] navigationProperties)
		{
			throw new NotImplementedException();
		}

		public void Remove(params CompanyLocationPoco[] items)
		{
			throw new NotImplementedException();
		}

		public void Update(params CompanyLocationPoco[] items)
		{
			throw new NotImplementedException();
		}
	}
}
