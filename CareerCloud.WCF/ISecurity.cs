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
		void AddSecurityLogins(SecurityLoginPoco[] item);
		[OperationContract]
		List<SecurityLoginPoco> GetAllSecurityLogins();
		[OperationContract]
		SecurityLoginPoco GetSingleSecurityLogins(Guid Id);
		[OperationContract]
		void RemoveSecurityLogins(SecurityLoginPoco[] item);
		[OperationContract]
		void UpdateSecurityLogins(SecurityLoginPoco[] items);

		[OperationContract]
		void AddSecurityLoginsLog(SecurityLoginsLogPoco[] item);
		[OperationContract]
		List<SecurityLoginsLogPoco> GetAllSecurityLoginsLog();
		[OperationContract]
		SecurityLoginsLogPoco GetSingleSecurityLoginsLog(Guid Id);
		[OperationContract]
		void RemoveSecurityLoginsLog(SecurityLoginsLogPoco[] item);
		[OperationContract]
		void UpdateSecurityLoginsLog(SecurityLoginsLogPoco[] items);

		[OperationContract]
		void AddSecurityLoginsRoles(SecurityLoginsRolePoco[] item);
		[OperationContract]
		List<SecurityLoginsRolePoco> GetAllSecurityLoginsRoles();
		[OperationContract]
		SecurityLoginsRolePoco GetSingleSecurityLoginsRoles(Guid Id);
		[OperationContract]
		void RemoveSecurityLoginsRoles(SecurityLoginsRolePoco[] item);
		[OperationContract]
		void UpdateSecurityLoginsRoles(SecurityLoginsRolePoco[] items);

		[OperationContract]
		void AddSecurityRoles(SecurityRolePoco[] item);
		[OperationContract]
		List<SecurityRolePoco> GetAllSecurityRoles();
		[OperationContract]
		SecurityRolePoco GetSingleSecurityRoles(Guid Id);
		[OperationContract]
		void RemoveSecurityRoles(SecurityRolePoco[] item);
		[OperationContract]
		void UpdateSecurityRoles(SecurityRolePoco[] items);

	}
}
