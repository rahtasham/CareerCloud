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
	public class SystemLanguageCodeRepository : BaseADO, IDataRepository<SystemLanguageCodePoco>
	{
		public void Add(params SystemLanguageCodePoco[] items)
		{
			throw new NotImplementedException();
		}

		public void CallStoredProc(string name, params Tuple<string, string>[] parameters)
		{
			throw new NotImplementedException();
		}

		public IList<SystemLanguageCodePoco> GetAll(params Expression<Func<SystemLanguageCodePoco, object>>[] navigationProperties)
		{
			SystemLanguageCodePoco[] pocos = new SystemLanguageCodePoco[500];
			using (SqlConnection conn = new SqlConnection(connString))
			{
				SqlCommand command = new SqlCommand("Select * from System_Language_Codes", conn);

				int position = 0;

				SqlDataReader reader = command.ExecuteReader();

				while (reader.Read())
				{
					SystemLanguageCodePoco poco = new SystemLanguageCodePoco();

					poco.LanguageID = reader.GetString(0);
					poco.Name = reader.GetString(1);
					poco.NativeName = reader.GetString(2);
					
					pocos[position] = poco;
					position++;
				}
			}
			return pocos.ToList();

		}

		public IList<SystemLanguageCodePoco> GetList(Expression<Func<SystemLanguageCodePoco, bool>> where, params Expression<Func<SystemLanguageCodePoco, object>>[] navigationProperties)
		{
			throw new NotImplementedException();
		}

		public SystemLanguageCodePoco GetSingle(Expression<Func<SystemLanguageCodePoco, bool>> where, params Expression<Func<SystemLanguageCodePoco, object>>[] navigationProperties)
		{
			throw new NotImplementedException();
		}

		public void Remove(params SystemLanguageCodePoco[] items)
		{
			throw new NotImplementedException();
		}

		public void Update(params SystemLanguageCodePoco[] items)
		{
			throw new NotImplementedException();
		}
	}
}
