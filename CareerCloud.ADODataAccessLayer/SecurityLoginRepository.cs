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
			using (SqlConnection conn = new SqlConnection(connString))
			{
				SqlCommand command = new SqlCommand();
				command.Connection = conn;

				foreach (SecurityLoginPoco poco in items)
				{
					command.CommandText = @"INSERT INTO [dbo].[Security_Logins]
							([Id],[Login],[Password],[Created_Date],[Password_Update_Date],
							[Agreement_Accepted_Date],[Is_Locked],[Is_Inactive],[Email_Address],
							[Phone_Number],[Full_Name],[Force_Change_Password],[Prefferred_Language],
							[Time_Stamp])
							Values
							(@Id, @Login, @Password, @Created_Date, @Password_Update_Date, @Agreement_Accepted_Date, 
								@Is_Locked,@Is_Inactive, @Email_Address, @Phone_Number,	@Full_Name,
								@Force_Change_Password, @Prefferred_Language, @Time_Stamp)";

					command.Parameters.AddWithValue("@Id", poco.Id);
					command.Parameters.AddWithValue("@Login", poco.Login);
					command.Parameters.AddWithValue("@Password", poco.Password);
					command.Parameters.AddWithValue("@Created_Date", poco.Created);
					command.Parameters.AddWithValue("@Password_Update_Date", poco.PasswordUpdate);
					command.Parameters.AddWithValue("@Agreement_Accepted_Date", poco.AgreementAccepted);
					command.Parameters.AddWithValue("@Is_Locked", poco.IsLocked); ;
					command.Parameters.AddWithValue("@Is_Inactive", poco.IsInactive);
					command.Parameters.AddWithValue("@Email_Address", poco.EmailAddress);
					command.Parameters.AddWithValue("@Phone_Number", poco.PhoneNumber);
					command.Parameters.AddWithValue("@Full_Name", poco.FullName);
					command.Parameters.AddWithValue("@Force_Change_Password", poco.ForceChangePassword);
					command.Parameters.AddWithValue("@Prefferred_Language", poco.PrefferredLanguage);
					command.Parameters.AddWithValue("@Time_Stamp", poco.TimeStamp);
				}
			}

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
			IQueryable<SecurityLoginPoco> pocos = GetAll().AsQueryable();
			return pocos.Where(where).FirstOrDefault();

		}

		public void Remove(params SecurityLoginPoco[] items)
		{
			throw new NotImplementedException();
		}

		public void Update(params SecurityLoginPoco[] items)
		{
			using (SqlConnection conn = new SqlConnection(connString))
			{
				SqlCommand cmd = new SqlCommand();
				cmd.Connection = conn;

				foreach (SecurityLoginPoco poco in items)
				{
					cmd.CommandText = @"UPDATE Security_Logins
						SET Login = @Login, 
							Password = @Password,
							Created_Date = @Created_Date,
							Password_Update_Date = @Password_Update_Date,
							Agreement_Accepted_Date = @Agreement_Accepted_Date,
							Is_Locked = @Is_Locked,
							Is_Inactive = @Is_Inactive,
							Email_Address = @Email_Address,
							Phone_Number = @Phone_Number,
							Full_Name = @Full_Name,
							Force_Change_Password = @Force_Change_Password,
							Prefferred_Language = @Prefferred_Language
							WHERE Id = @Id";

					cmd.Parameters.AddWithValue("@Login", poco.Login);
					cmd.Parameters.AddWithValue("@Password", poco.Password);
					cmd.Parameters.AddWithValue("@Created_Date", poco.Created);
					cmd.Parameters.AddWithValue("@Password_Update_Date", poco.PasswordUpdate);
					cmd.Parameters.AddWithValue("@Agreement_Accepted_Date", poco.AgreementAccepted);
					cmd.Parameters.AddWithValue("@Is_Locked", poco.IsLocked); ;
					cmd.Parameters.AddWithValue("@Is_Inactive", poco.IsInactive);
					cmd.Parameters.AddWithValue("@Email_Address", poco.EmailAddress);
					cmd.Parameters.AddWithValue("@Phone_Number", poco.PhoneNumber);
					cmd.Parameters.AddWithValue("@Full_Name", poco.FullName);
					cmd.Parameters.AddWithValue("@Force_Change_Password", poco.ForceChangePassword);
					cmd.Parameters.AddWithValue("@Prefferred_Language", poco.PrefferredLanguage);
					cmd.Parameters.AddWithValue("@Id", poco.Id);

					conn.Open();
					int numOfRows = cmd.ExecuteNonQuery();
					conn.Close();

				}
			}



		}
	}
}
