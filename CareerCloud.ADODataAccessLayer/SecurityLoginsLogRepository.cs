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
	public class SecurityLoginsLogRepository : BaseADO, IDataRepository<SecurityLoginsLogPoco>
	{
		public void Add(params SecurityLoginsLogPoco[] items)
		{
			throw new NotImplementedException();
		}

		public void CallStoredProc(string name, params Tuple<string, string>[] parameters)
		{
			throw new NotImplementedException();
		}

		public IList<SecurityLoginsLogPoco> GetAll(params Expression<Func<SecurityLoginsLogPoco, object>>[] navigationProperties)
		{
			SecurityLoginsLogPoco[] pocos = new SecurityLoginsLogPoco[500];
			using (SqlConnection conn = new SqlConnection(connString))
			{
				SqlCommand command = new SqlCommand("Select * from Security_Logins_Log", conn);

				int position = 0;

				SqlDataReader reader = command.ExecuteReader();

				while (reader.Read())
				{
					SecurityLoginsLogPoco poco = new SecurityLoginsLogPoco();

					poco.Id = reader.GetGuid(0);
					poco.Login = reader.GetGuid(1);
					poco.SourceIP = reader.GetString(2);
					poco.LogonDate = reader.GetDateTime(3);
					poco.IsSuccesful = reader.GetBoolean(4);

					pocos[position] = poco;
					position++;
				}
			}
			return pocos.ToList();

		}

		public IList<SecurityLoginsLogPoco> GetList(Expression<Func<SecurityLoginsLogPoco, bool>> where, params Expression<Func<SecurityLoginsLogPoco, object>>[] navigationProperties)
		{
			throw new NotImplementedException();
		}

		public SecurityLoginsLogPoco GetSingle(Expression<Func<SecurityLoginsLogPoco, bool>> where, params Expression<Func<SecurityLoginsLogPoco, object>>[] navigationProperties)
		{
			throw new NotImplementedException();
		}

		public void Remove(params SecurityLoginsLogPoco[] items)
		{
			throw new NotImplementedException();
		}

		public void Update(params SecurityLoginsLogPoco[] items)
		{
			throw new NotImplementedException();
		}
	}
}
