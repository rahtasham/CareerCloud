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
	public class SecurityLoginRepository : BaseADO, IDataRepository<SecurityLoginPoco>
	{
		public void Add(params SecurityLoginPoco[] items)
		{
			throw new NotImplementedException();
		}

		public void CallStoredProc(string name, params Tuple<string, string>[] parameters)
		{
			throw new NotImplementedException();
		}

		public IList<SecurityLoginPoco> GetAll(params Expression<Func<SecurityLoginPoco, object>>[] navigationProperties)
		{
			SecurityLoginPoco[] pocos = new SecurityLoginPoco[500];
			using (SqlConnection conn = new SqlConnection(connString))
			{
				SqlCommand command = new SqlCommand("Select * from Security_Logins", conn);

				int position = 0;

				SqlDataReader reader = command.ExecuteReader();

				while (reader.Read())
				{
					SecurityLoginPoco poco = new SecurityLoginPoco();

					poco.Id = reader.GetGuid(0);
					poco.Login = reader.GetString(1);
					poco.Password = reader.GetString(2);
					poco.Created = reader.GetDateTime(3);
					
					if (!reader.IsDBNull(4))
					{
						poco.PasswordUpdate = reader.GetDateTime(4);
					}
					else
					{
						poco.PasswordUpdate = null;
					}

					if (!reader.IsDBNull(5))
					{
						poco.AgreementAccepted = reader.GetDateTime(5);
					}
					else
					{
						poco.AgreementAccepted = null;
					}

					poco.IsLocked = reader.GetBoolean(6);
					poco.IsInactive = reader.GetBoolean(7);
					poco.EmailAddress = reader.GetString(8);
					poco.PhoneNumber =reader.GetString(9);
					poco.FullName = reader.GetString(10);
					poco.ForceChangePassword = reader.GetBoolean(11);
					poco.PrefferredLanguage = reader.GetString(12);
					poco.TimeStamp = (byte[])reader[13];

					pocos[position] = poco;
					position++;
				}
			}
			return pocos.ToList();

		}

		public IList<SecurityLoginPoco> GetList(Expression<Func<SecurityLoginPoco, bool>> where, params Expression<Func<SecurityLoginPoco, object>>[] navigationProperties)
		{
			throw new NotImplementedException();
		}

		public SecurityLoginPoco GetSingle(Expression<Func<SecurityLoginPoco, bool>> where, params Expression<Func<SecurityLoginPoco, object>>[] navigationProperties)
		{
			throw new NotImplementedException();
		}

		public void Remove(params SecurityLoginPoco[] items)
		{
			throw new NotImplementedException();
		}

		public void Update(params SecurityLoginPoco[] items)
		{
			throw new NotImplementedException();
		}
	}
}
