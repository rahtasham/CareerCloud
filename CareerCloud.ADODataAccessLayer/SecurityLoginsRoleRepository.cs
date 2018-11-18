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
	public class SecurityLoginsRoleRepository : BaseADO, IDataRepository<SecurityLoginsRolePoco>
	{
		public void Add(params SecurityLoginsRolePoco[] items)
		{
			throw new NotImplementedException();
		}

		public void CallStoredProc(string name, params Tuple<string, string>[] parameters)
		{
			throw new NotImplementedException();
		}

		public IList<SecurityLoginsRolePoco> GetAll(params Expression<Func<SecurityLoginsRolePoco, object>>[] navigationProperties)
		{
			SecurityLoginsRolePoco[] pocos = new SecurityLoginsRolePoco[500];
			using (SqlConnection conn = new SqlConnection(connString))
			{
				SqlCommand command = new SqlCommand("Select * from Applicant_Educations", conn);

				int position = 0;

				SqlDataReader reader = command.ExecuteReader();

				while (reader.Read())
				{
					SecurityLoginsRolePoco poco = new SecurityLoginsRolePoco();

					poco.Id = reader.GetGuid(0);
					poco.Login = reader.GetGuid(1);
					poco.Role = reader.GetGuid(2);
					poco.TimeStamp = (byte[])reader[3];

					pocos[position] = poco;
					position++;
				}
			}
			return pocos.ToList();

		}

		public IList<SecurityLoginsRolePoco> GetList(Expression<Func<SecurityLoginsRolePoco, bool>> where, params Expression<Func<SecurityLoginsRolePoco, object>>[] navigationProperties)
		{
			throw new NotImplementedException();
		}

		public SecurityLoginsRolePoco GetSingle(Expression<Func<SecurityLoginsRolePoco, bool>> where, params Expression<Func<SecurityLoginsRolePoco, object>>[] navigationProperties)
		{
			throw new NotImplementedException();
		}

		public void Remove(params SecurityLoginsRolePoco[] items)
		{
			throw new NotImplementedException();
		}

		public void Update(params SecurityLoginsRolePoco[] items)
		{
			throw new NotImplementedException();
		}
	}
}
