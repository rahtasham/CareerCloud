﻿using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerCloud.BusinessLogicLayer
{
	public class SystemCountryCodeLogic
	{
		protected IDataRepository<SystemCountryCodePoco> _repository;
		public SystemCountryCodeLogic(IDataRepository<SystemCountryCodePoco> repository)
		{
			_repository = repository;
		}

		public SystemCountryCodePoco Get(string code)
		{
			return _repository.GetSingle(c => c.Code == code);
		}

		public List<SystemCountryCodePoco> GetAll()
		{
			return _repository.GetAll().ToList();
		}

		public void Add(SystemCountryCodePoco[] pocos)
		{
			Verify(pocos);
			_repository.Add(pocos);
		}

		public void Update(SystemCountryCodePoco[] pocos)
		{
			Verify(pocos);
			_repository.Update(pocos);
		}

		public void Delete(SystemCountryCodePoco[] pocos)
		{
			_repository.Remove(pocos);
		}

		protected void Verify(SystemCountryCodePoco[] pocos)
		{
			List<ValidationException> exceptions = new List<ValidationException>();

			foreach (SystemCountryCodePoco item in pocos)
			{
				if (string.IsNullOrEmpty(item.Code))
				{
					exceptions.Add(new ValidationException(900, $"Code for {item.Code} cannot be empty"));
				}
				if (string.IsNullOrEmpty(item.Name))
				{
					exceptions.Add(new ValidationException(901, $"Name for {item.Code} cannot be empty"));
				}

			}

			if (exceptions.Count > 0)
			{
				throw new AggregateException(exceptions);
			}
		}

	}	
}
