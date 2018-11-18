﻿using CareerCloud.DataAccessLayer;
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
	public class SecurityRoleRepository : BaseADO, IDataRepository<SecurityRolePoco>
	{
		public void Add(params SecurityRolePoco[] items)
		{
			throw new NotImplementedException();
		}

		public void CallStoredProc(string name, params Tuple<string, string>[] parameters)
		{
			throw new NotImplementedException();
		}

		public IList<SecurityRolePoco> GetAll(params Expression<Func<SecurityRolePoco, object>>[] navigationProperties)
		{
			SecurityRolePoco[] pocos = new SecurityRolePoco[500];
			using (SqlConnection conn = new SqlConnection(connString))
			{
				SqlCommand command = new SqlCommand("Select * from Security_Roles", conn);

				int position = 0;

				SqlDataReader reader = command.ExecuteReader();

				while (reader.Read())
				{
					SecurityRolePoco poco = new SecurityRolePoco();

					poco.Id = reader.GetGuid(0);
					poco.Role = reader.GetString(1);
					poco.IsInactive = reader.GetBoolean(2);
					

					pocos[position] = poco;
					position++;
				}
			}
			return pocos.ToList();

		}

		public IList<SecurityRolePoco> GetList(Expression<Func<SecurityRolePoco, bool>> where, params Expression<Func<SecurityRolePoco, object>>[] navigationProperties)
		{
			throw new NotImplementedException();
		}

		public SecurityRolePoco GetSingle(Expression<Func<SecurityRolePoco, bool>> where, params Expression<Func<SecurityRolePoco, object>>[] navigationProperties)
		{
			throw new NotImplementedException();
		}

		public void Remove(params SecurityRolePoco[] items)
		{
			throw new NotImplementedException();
		}

		public void Update(params SecurityRolePoco[] items)
		{
			throw new NotImplementedException();
		}
	}
}
