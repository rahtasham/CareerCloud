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

		public void AddSystemCountryCode(SystemCountryCodePoco[] item)
		{
			_sccLogic.Add(item);
		}

		public void AddSystemLanguageCode(SystemLanguageCodePoco[] item)
		{
			_slcLogic.Add(item);
		}

		public List<SystemCountryCodePoco> GetAllSystemCountryCode()
		{
			return _sccLogic.GetAll();
		}

		public List<SystemLanguageCodePoco> GetAllSystemLanguageCode()
		{
			return _slcLogic.GetAll();
		}

		public SystemCountryCodePoco GetSingleSystemCountryCode(string code)
		{
			return _sccLogic.Get(code);
		}

		public SystemLanguageCodePoco GetSingleSystemLanguageCode(string code)
		{
			return _slcLogic.Get(code);
		}

		public void RemoveSystemCountryCode(SystemCountryCodePoco[] item)
		{
			_sccLogic.Delete(item);
		}

		public void RemoveSystemLanguageCode(SystemLanguageCodePoco[] item)
		{
			_slcLogic.Delete(item);
		}

		public void UpdateSystemCountryCode(SystemCountryCodePoco[] item)
		{
			_sccLogic.Update(item);
		}

		public void UpdateSystemLanguageCode(SystemLanguageCodePoco[] item)
		{
			_slcLogic.Update(item);
		}
	}
}

		
			
