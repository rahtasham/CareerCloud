using CareerCloud.Pocos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace CareerCloud.WCF
{
	[ServiceContract]
	public interface ISystem
	{

		[OperationContract]
		void AddSystemCountryCodes(SystemCountryCodePoco[] item);
		[OperationContract]
		List<SystemCountryCodePoco> GetAllSystemCountryCodes();
		[OperationContract]
		SystemCountryCodePoco GetSingleSystemCountryCodes(String Code);
		[OperationContract]
		void RemoveSystemCountryCodes(SystemCountryCodePoco[] item);
		[OperationContract]
		void UpdateSystemCountryCodes(SystemCountryCodePoco[] items);

		[OperationContract]
		void AddSystemLanguageCodes(SystemLanguageCodePoco[] item);
		[OperationContract]
		List<SystemLanguageCodePoco> GetAllSystemLanguageCodes();
		[OperationContract]
		SystemLanguageCodePoco GetSingleSystemLanguageCodes(String Code);
		[OperationContract]
		void RemoveSystemLanguageCodes(SystemLanguageCodePoco[] item);
		[OperationContract]
		void UpdateSytemLanguageCodes(SystemLanguageCodePoco[] items);
	}
}
