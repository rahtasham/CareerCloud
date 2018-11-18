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
	public class ApplicantSkillRepository : BaseADO, IDataRepository<ApplicantSkillPoco>
	{
		public void Add(params ApplicantSkillPoco[] items)
		{
			throw new NotImplementedException();
		}

		public void CallStoredProc(string name, params Tuple<string, string>[] parameters)
		{
			throw new NotImplementedException();
		}

		public IList<ApplicantSkillPoco> GetAll(params Expression<Func<ApplicantSkillPoco, object>>[] navigationProperties)
		{
			ApplicantSkillPoco[] pocos = new ApplicantSkillPoco[500];
			using (SqlConnection conn = new SqlConnection(connString))
			{
				SqlCommand command = new SqlCommand("Select * from [dbo].[Applicant_Skills]", conn);

				int position = 0;

				SqlDataReader reader = command.ExecuteReader();

				while (reader.Read())
				{
					ApplicantSkillPoco poco = new ApplicantSkillPoco();

					poco.Id = reader.GetGuid(0);
					poco.Applicant = reader.GetGuid(1);
					poco.Skill = reader.GetString(2);
					poco.SkillLevel = reader.GetString(3);
					poco.StartMonth = reader.GetByte(4);
					poco.StartYear = reader.GetInt32(5);
					poco.EndMonth = reader.GetByte(6);
					poco.EndYear = reader.GetInt32(7);									
					poco.TimeStamp = (byte[])reader[8];

					pocos[position] = poco;
					position++;
				}
			}
			return pocos.ToList();
		}

		public IList<ApplicantSkillPoco> GetList(Expression<Func<ApplicantSkillPoco, bool>> where, params Expression<Func<ApplicantSkillPoco, object>>[] navigationProperties)
		{
			throw new NotImplementedException();
		}

		public ApplicantSkillPoco GetSingle(Expression<Func<ApplicantSkillPoco, bool>> where, params Expression<Func<ApplicantSkillPoco, object>>[] navigationProperties)
		{
			throw new NotImplementedException();
		}

		public void Remove(params ApplicantSkillPoco[] items)
		{
			throw new NotImplementedException();
		}

		public void Update(params ApplicantSkillPoco[] items)
		{
			throw new NotImplementedException();
		}
	}
}
