﻿using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerCloud.BusinessLogicLayer
{
	public class SystemLanguageCodeLogic
	{
		protected IDataRepository<SystemLanguageCodePoco> _repository;
		public SystemLanguageCodeLogic(IDataRepository <SystemLanguageCodePoco> repository)
		{
			_repository = repository;
		}

		public SystemLanguageCodePoco Get(string languageID)
		{
			return _repository.GetSingle(c => c.LanguageID == languageID);
		}

		public List<SystemLanguageCodePoco> GetAll()
		{
			return _repository.GetAll().ToList();
		}

		public void Add(SystemLanguageCodePoco[] pocos)
		{
			 Verify(pocos);
			_repository.Add(pocos);
		}

		public void Update(SystemLanguageCodePoco[] pocos)
		{
			 Verify(pocos);
			_repository.Update(pocos);
		}

		public void Delete(SystemLanguageCodePoco[] pocos)
		{
			_repository.Remove(pocos);
		}

		protected void Verify(SystemLanguageCodePoco[] pocos)
		{
			List<ValidationException> exceptions = new List<ValidationException>();

			foreach (SystemLanguageCodePoco item in pocos)
			{
				if (string.IsNullOrEmpty(item.LanguageID))
				{
					exceptions.Add(new ValidationException(1000, $"LanguageID for {item.LanguageID} cannot be empty"));
				}
				if (string.IsNullOrEmpty(item.Name))
				{
					exceptions.Add(new ValidationException(1001, $"Name for {item.LanguageID} cannot be empty"));
				}
				if (string.IsNullOrEmpty(item.NativeName))
				{
					exceptions.Add(new ValidationException(1002, $"Native Name for {item.LanguageID} cannot be empty"));
				}
			}
			if (exceptions.Count > 0)
			{
				throw new AggregateException(exceptions);
			}
		}
	}
			
	}



