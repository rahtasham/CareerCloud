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
	public class CompanyLocationRepository : BaseADO, IDataRepository<CompanyLocationPoco>
	{
		public void Add(params CompanyLocationPoco[] items)
		{
			using (SqlConnection conn = new SqlConnection(connString))
			{
				SqlCommand command = new SqlCommand();
				command.Connection = conn;

				foreach (CompanyLocationPoco poco in items)
				{
					command.CommandText = @"INSERT INTO [dbo].[Company_Locations]
							([Id], [Company], [Country_Code], [State_Province_Code],[Street_Address],
							  [City_Town],[Zip_Postal_Code], [Time_Stamp])
							Values
							(@Id, @Company, @Country_Code, @State_Province_Code, @Street_Address, 
								@City_Town, @Zip_Postal_Code, @Time_Stamp)";

					command.Parameters.AddWithValue("@Id", poco.Id);
					command.Parameters.AddWithValue("@Company", poco.Company);
					command.Parameters.AddWithValue("@Country_Code", poco.CountryCode);
					command.Parameters.AddWithValue("@State_Province_Code", poco.Province);
					command.Parameters.AddWithValue("@Street_Address", poco.Street);
					command.Parameters.AddWithValue("@City_Town", poco.City);
					command.Parameters.AddWithValue("@Zip_Postal_Code", poco.PostalCode);
					command.Parameters.AddWithValue("@Time_Stamp", poco.TimeStamp);
				}
			}
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
			IQueryable<CompanyLocationPoco> pocos = GetAll().AsQueryable();
			return pocos.Where(where).FirstOrDefault();

		}

		public void Remove(params CompanyLocationPoco[] items)
		{
			throw new NotImplementedException();
		}

		public void Update(params CompanyLocationPoco[] items)
		{
			using (SqlConnection conn = new SqlConnection(connString))
			{
				SqlCommand cmd = new SqlCommand();
				cmd.Connection = conn;

				foreach (CompanyLocationPoco poco in items)
				{
					cmd.CommandText = @"UPDATE Company_Locations
						SET Company = @Company, 
							Country_Code = @Country_Code,
							State_Province_Code = @State_Province_Code,
							Street_Address = @Street_Address,
							City_Town = @City_Town,
							Zip_Postal_Code = @Zip_Postal_Code
							WHERE Id = @Id";

					cmd.Parameters.AddWithValue("@Company", poco.Company);
					Parameters.AddWithValue("@Country_Code", poco.CountryCode);
					cmd.Parameters.AddWithValue("@State_Province_Code", poco.Province);
					cmd.Parameters.AddWithValue("@Street_Address", poco.Street);
					cmd.Parameters.AddWithValue("@City_Town", poco.City);
					cmd.Parameters.AddWithValue("@Zip_Postal_Code", poco.PostalCode);
					cmd.Parameters.AddWithValue("@Id", poco.Id);

					conn.Open();
					int numOfRows = cmd.ExecuteNonQuery();
					conn.Close();

				}
			}

		}
	}
}
