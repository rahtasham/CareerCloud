using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using CareerCloud.BusinessLogicLayer;
using CareerCloud.EntityFrameworkDataAccess;
using CareerCloud.Pocos;


namespace CareerCloud.WCF
{
	public class System : ISystem
	{
		private SystemCountryCodeLogic _sccLogic;
		private SystemLanguageCodeLogic _slcLogic;
		public System()
		{
			EFGenericRepository<SystemCountryCodePoco> sccRepo =
				new EFGenericRepository<SystemCountryCodePoco>(false);
			_sccLogic = new SystemCountryCodeLogic(sccRepo);


			EFGenericRepository<SystemLanguageCodePoco> slcRepo =
				new EFGenericRepository<SystemLanguageCodePoco>(false);
			_slcLogic = new SystemLanguageCodeLogic(slcRepo);
		}

		public void AddSystemCountryCodes(SystemCountryCodePoco[] item)
		{
			_sccLogic.Add(item);
		}

		public void AddSystemLanguageCodes(SystemLanguageCodePoco[] item)
		{
			_slcLogic.Add(item);
		}

		public List<SystemCountryCodePoco> GetAllSystemCountryCodes()
		{
			return _sccLogic.GetAll();
		}

		public List<SystemLanguageCodePoco> GetAllSystemLanguageCodes()
		{
			return _slcLogic.GetAll();
		}

		public SystemCountryCodePoco GetSingleSystemCountryCodes(string Code)
		{
			return _sccLogic.Get(Code);
		}

		public SystemLanguageCodePoco GetSingleSystemLanguageCodes(string Code)
		{
			return _slcLogic.Get(Code);
		}


		public void RemoveSystemCountryCodes(SystemCountryCodePoco[] item)
		{
			_sccLogic.Delete(item);
		}

		public void RemoveSystemLanguageCodes(SystemLanguageCodePoco[] item)
		{
			_slcLogic.Delete(item);
		}

		public void UpdateSystemCountryCodes(SystemCountryCodePoco[] items)
		{
			_sccLogic.Update(items);
		}

		public void UpdateSytemLanguageCodes(SystemLanguageCodePoco[] items)
		{
			_slcLogic.Update(items);
		}
	}
}
