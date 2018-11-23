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
	public class CompanyJobSkillRepository : BaseADO, IDataRepository<CompanyJobSkillPoco>
	{
		public void Add(params CompanyJobSkillPoco[] items)
		{
			using (SqlConnection conn = new SqlConnection(connString))
			{
				SqlCommand command = new SqlCommand();
				command.Connection = conn;

				foreach (CompanyJobSkillPoco poco in items)
				{
					command.CommandText = @"INSERT INTO [dbo].[Company_Job_Skills]
							([Id], [Job], [Skill], [Skill_Level], [Importance])
							Values
							(@Id, @Job, @Skill, @Skill_Level, @Importance)";

					command.Parameters.AddWithValue("@Id", poco.Id);
					command.Parameters.AddWithValue("@Job", poco.Job);
					command.Parameters.AddWithValue("@Skill", poco.Skill);
					command.Parameters.AddWithValue("@Skill_Level", poco.SkillLevel);
					command.Parameters.AddWithValue("@Importance", poco.Importance);
				}

				conn.Open();
				int numOfRows = command.ExecuteNonQuery();
				conn.Close();

			}

		}

		public void CallStoredProc(string name, params Tuple<string, string>[] parameters)
		{
			throw new NotImplementedException();
		}

		public IList<CompanyJobSkillPoco> GetAll(params Expression<Func<CompanyJobSkillPoco, object>>[] navigationProperties)
		{
			CompanyJobSkillPoco[] pocos = new CompanyJobSkillPoco[5001];
			using (SqlConnection conn = new SqlConnection(connString))
			{
				SqlCommand command = new SqlCommand("Select * from Company_Job_Skills", conn);

				conn.Open();

				int position = 0;

				SqlDataReader reader = command.ExecuteReader();

				while (reader.Read())
				{
					CompanyJobSkillPoco poco = new CompanyJobSkillPoco();

					poco.Id = reader.GetGuid(0);
					poco.Job = reader.GetGuid(1);
					poco.Skill = reader.GetString(2);
					poco.SkillLevel = reader.GetString(3);
					poco.Importance = reader.GetInt32(4);
					poco.TimeStamp = (byte[])reader[5];

					pocos[position] = poco;
					position++;
				}

				conn.Close();
			}
			return pocos.Where(a => a != null).ToList();

		}

		public IList<CompanyJobSkillPoco> GetList(Expression<Func<CompanyJobSkillPoco, bool>> where, params Expression<Func<CompanyJobSkillPoco, object>>[] navigationProperties)
		{
			throw new NotImplementedException();
		}

		public CompanyJobSkillPoco GetSingle(Expression<Func<CompanyJobSkillPoco, bool>> where, params Expression<Func<CompanyJobSkillPoco, object>>[] navigationProperties)
		{
			IQueryable<CompanyJobSkillPoco> pocos = GetAll().AsQueryable();
			return pocos.Where(where).FirstOrDefault();

		}

		public void Remove(params CompanyJobSkillPoco[] items)
		{
			using (SqlConnection conn = new SqlConnection(connString))
			{
				SqlCommand cmd = new SqlCommand();
				cmd.Connection = conn;

				foreach (CompanyJobSkillPoco poco in items)
				{
					cmd.CommandText = @"DELETE FROM [dbo].[Company_Job_Skills] where Id = @ID";
					cmd.Parameters.AddWithValue("@Id", poco.Id);

					conn.Open();
					int numOfRows = cmd.ExecuteNonQuery();
					conn.Close();
				}
			}
		}

		public void Update(params CompanyJobSkillPoco[] items)
		{
			using (SqlConnection conn = new SqlConnection(connString))
			{
				SqlCommand cmd = new SqlCommand();
				cmd.Connection = conn;

				foreach (CompanyJobSkillPoco poco in items)
				{
					cmd.CommandText = @"UPDATE Company_Job_Skills
						SET Job = @Job, 
							Skill = @Skill,
							Skill_Level = @Skill_Level,
							Importance = @Importance
							WHERE Id = @Id";

					cmd.Parameters.AddWithValue("@Job", poco.Job);
					cmd.Parameters.AddWithValue("@Skill", poco.Skill);
					cmd.Parameters.AddWithValue("@Skill_Level", poco.SkillLevel);
					cmd.Parameters.AddWithValue("@Importance", poco.Importance);
					cmd.Parameters.AddWithValue("@Id", poco.Id);

					conn.Open();
					int numOfRows = cmd.ExecuteNonQuery();
					conn.Close();

				}
			}

		}
	}
}
