using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerCloud.BusinessLogicLayer
{
	public class CompanyJobEducationLogic : BaseLogic<CompanyJobEducationPoco>
	{
		public CompanyJobEducationLogic(IDataRepository<CompanyJobEducationPoco> repository) : base(repository)
		{
		}
		public override void Add(CompanyJobEducationPoco[] pocos)
		{
			Verify(pocos);
			base.Add(pocos);
		}

		public override void Update(CompanyJobEducationPoco[] pocos)
		{
			Verify(pocos);
			base.Update(pocos);
		}

		protected override void Verify(CompanyJobEducationPoco[] pocos)
		{
			List<ValidationException> exceptions = new List<ValidationException>();

			foreach (CompanyJobEducationPoco item in pocos)
			{
				if(string.IsNullOrEmpty(item.Major))
				{
					exceptions.Add(new ValidationException(200, $"Major for {item.Id} must be at least 2 characters long"));
				}
				else if (item.Major.Length < 2)
				{
					exceptions.Add(new ValidationException(200, $"Major for {item.Id} must be at least 2 characters long"));
				}
				if (item.Importance < 0)
				{
					exceptions.Add(new ValidationException(201, $"Importance for {item.Id} cannot be less than zero"));
				}
			}

			if (exceptions.Count > 0)
			{
				throw new AggregateException(exceptions);
			}
		}
	}
}
