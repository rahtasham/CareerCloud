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
	public interface ISecurity
	{
		[OperationContract]
		void AddSecurityLogin(SecurityLoginPoco[] item);
		[OperationContract]
		List<SecurityLoginPoco> GetAllSecurityLogin();
		[OperationContract]
		SecurityLoginPoco GetSingleSecurityLogin(string Id);
		[OperationContract]
		void RemoveSecurityLogin(SecurityLoginPoco[] item);
		[OperationContract]
		void UpdateSecurityLogin(SecurityLoginPoco[] items);

		[OperationContract]
		void AddSecurityLoginsLog(SecurityLoginsLogPoco[] item);
		[OperationContract]
		List<SecurityLoginsLogPoco> GetAllSecurityLoginsLog();
		[OperationContract]
		SecurityLoginsLogPoco GetSingleSecurityLoginsLog(string Id);
		[OperationContract]
		void RemoveSecurityLoginsLog(SecurityLoginsLogPoco[] item);
		[OperationContract]
		void UpdateSecurityLoginsLog(SecurityLoginsLogPoco[] items);

		[OperationContract]
		void AddSecurityLoginsRole(SecurityLoginsRolePoco[] item);
		[OperationContract]
		List<SecurityLoginsRolePoco> GetAllSecurityLoginsRole();
		[OperationContract]
		SecurityLoginsRolePoco GetSingleSecurityLoginsRole(string Id);
		[OperationContract]
		void RemoveSecurityLoginsRole(SecurityLoginsRolePoco[] item);
		[OperationContract]
		void UpdateSecurityLoginsRole(SecurityLoginsRolePoco[] items);

		[OperationContract]
		void AddSecurityRole(SecurityRolePoco[] item);
		[OperationContract]
		List<SecurityRolePoco> GetAllSecurityRole();
		[OperationContract]
		SecurityRolePoco GetSingleSecurityRole(string Id);
		[OperationContract]
		void RemoveSecurityRole(SecurityRolePoco[] item);
		[OperationContract]
		void UpdateSecurityRole(SecurityRolePoco[] items);

	}
}
