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
	public class Security : ISecurity
	{
		private SecurityLoginLogic _slLogic;
		private SecurityRoleLogic _srLogic;
		private SecurityLoginsRoleLogic _slrLogic;
		private SecurityLoginsLogLogic _sllLogic;

		public Security()
		{
			EFGenericRepository<SecurityLoginPoco> slRepo =
				new EFGenericRepository<SecurityLoginPoco>(false);
			_slLogic = new SecurityLoginLogic(slRepo);

			EFGenericRepository<SecurityLoginsLogPoco> sllRepo =
				new EFGenericRepository<SecurityLoginsLogPoco>(false);
			_sllLogic = new SecurityLoginsLogLogic(sllRepo);


			EFGenericRepository<SecurityLoginsRolePoco> slrRepo =
				new EFGenericRepository<SecurityLoginsRolePoco>(false);
			_slrLogic = new SecurityLoginsRoleLogic(slrRepo);


			EFGenericRepository<SecurityRolePoco> srRepo =
				new EFGenericRepository<SecurityRolePoco>(false);
			_srLogic = new SecurityRoleLogic(srRepo);
		}

		public void AddSecurityLogins(SecurityLoginPoco[] item)
		{
			_slLogic.Add(item);
		}

		public void AddSecurityLoginsLog(SecurityLoginsLogPoco[] item)
		{
			_sllLogic.Add(item);
		}

		public void AddSecurityLoginsRoles(SecurityLoginsRolePoco[] item)
		{
			_slrLogic.Add(item);
		}

		public void AddSecurityRoles(SecurityRolePoco[] item)
		{
			_srLogic.Add(item);
		}

		public List<SecurityLoginPoco> GetAllSecurityLogins()
		{
			return _slLogic.GetAll();
		}

		public List<SecurityLoginsLogPoco> GetAllSecurityLoginsLog()
		{
			return _sllLogic.GetAll();
		}

		public List<SecurityLoginsRolePoco> GetAllSecurityLoginsRoles()
		{
			return _slrLogic.GetAll();
		}

		public List<SecurityRolePoco> GetAllSecurityRoles()
		{
			return _srLogic.GetAll();
		}

		public SecurityLoginPoco GetSingleSecurityLogins(Guid Id)
		{
			return _slLogic.Get(Id);
		}

		public SecurityLoginsLogPoco GetSingleSecurityLoginsLog(Guid Id)
		{
			return _sllLogic.Get(Id);
		}

		public SecurityLoginsRolePoco GetSingleSecurityLoginsRoles(Guid Id)
		{
			return _slrLogic.Get(Id);
		}

		public SecurityRolePoco GetSingleSecurityRoles(Guid Id)
		{
			return _srLogic.Get(Id);
		}

		public void RemoveSecurityLogins(SecurityLoginPoco[] item)
		{
			_slLogic.Delete(item);
		}

		public void RemoveSecurityLoginsLog(SecurityLoginsLogPoco[] item)
		{
			_sllLogic.Delete(item);
		}

		public void RemoveSecurityLoginsRoles(SecurityLoginsRolePoco[] item)
		{
			_slrLogic.Delete(item);
		}

		public void RemoveSecurityRoles(SecurityRolePoco[] item)
		{
			_srLogic.Delete(item);
		}

		public void UpdateSecurityLogins(SecurityLoginPoco[] items)
		{
			_slLogic.Update(items);
		}

		public void UpdateSecurityLoginsLog(SecurityLoginsLogPoco[] items)
		{
			_sllLogic.Update(items);
		}

		public void UpdateSecurityLoginsRoles(SecurityLoginsRolePoco[] items)
		{
			_slrLogic.Update(items);
		}

		public void UpdateSecurityRoles(SecurityRolePoco[] items)
		{
			_srLogic.Update(items);
		}
	}
}
