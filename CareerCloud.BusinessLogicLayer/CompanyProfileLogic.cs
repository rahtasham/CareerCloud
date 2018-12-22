using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerCloud.BusinessLogicLayer
{
	public class CompanyProfileLogic : BaseLogic<CompanyProfilePoco>
	{
		public CompanyProfileLogic(IDataRepository<CompanyProfilePoco> repository) : base(repository)
		{
		}
		public override void Add(CompanyProfilePoco[] pocos)
		{
			Verify(pocos);
			base.Add(pocos);
		}

		public override void Update(CompanyProfilePoco[] pocos)
		{
			Verify(pocos);
			base.Update(pocos);
		}

		protected override void Verify(CompanyProfilePoco[] pocos)
		{
			List<ValidationException> exceptions = new List<ValidationException>();
			string[] requiredExtendedWebsite = new string[] { ".ca", ".com", ".biz" };

			foreach (CompanyProfilePoco item in pocos)
			{
				if (string.IsNullOrEmpty(item.CompanyWebsite))
				{
					exceptions.Add(new ValidationException(600, $"Company website for { item.Id } must end with .ca, .com, or .biz"));
				}
				else if (!requiredExtendedWebsite.Any(t => item.CompanyWebsite.Contains(t)))
				{
					exceptions.Add(new ValidationException(600, $"Company website for { item.Id } must end with .ca, .com, or .biz"));
				}


				if (string.IsNullOrEmpty(item.ContactPhone))
				{
					exceptions.Add(new ValidationException(601, $"PhoneNumber for {item.Id} is not in the required format."));
				}
				else
				{
					string[] phoneComponents = item.ContactPhone.Split('-');
					if (phoneComponents.Length < 3)
					{
						exceptions.Add(new ValidationException(601, $"PhoneNumber for {item.Id} is not in the required format."));
					}
					else
					{
						if (phoneComponents[0].Length < 3)
						{
							exceptions.Add(new ValidationException(601, $"PhoneNumber for {item.Id} is not in the required format."));
						}
						else if (phoneComponents[1].Length < 3)
						{
							exceptions.Add(new ValidationException(601, $"PhoneNumber for {item.Id} is not in the required format."));
						}
						else if (phoneComponents[2].Length < 4)
						{
							exceptions.Add(new ValidationException(601, $"PhoneNumber for {item.Id} is not in the required format."));
						}
					}

				}
			}


					if (exceptions.Count > 0)
					{
						throw new AggregateException(exceptions);
					}
				}
			}
		}

	



