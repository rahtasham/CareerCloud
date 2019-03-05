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

		public void AddSecurityLogin(SecurityLoginPoco[]item)
		{
			_slLogic.Add(item);
		}

		public void AddSecurityLoginsLog(SecurityLoginsLogPoco[] item)
		{
			_sllLogic.Add(item);
		}

		public void AddSecurityLoginsRole(SecurityLoginsRolePoco[] item)
		{
			_slrLogic.Add(item);
		}

		public void AddSecurityRole(SecurityRolePoco[] item)
		{
			_srLogic.Add(item);
		}

		public List<SecurityLoginPoco> GetAllSecurityLogin()
		{
			return _slLogic.GetAll();
		}

		public List<SecurityLoginsLogPoco> GetAllSecurityLoginsLog()
		{
			return _sllLogic.GetAll();
		}

		public List<SecurityLoginsRolePoco> GetAllSecurityLoginsRole()
		{
			return _slrLogic.GetAll();
		}

		public List<SecurityRolePoco> GetAllSecurityRole()
		{
			return _srLogic.GetAll();
		}

		public SecurityLoginPoco GetSingleSecurityLogin(string Id)
		{
			return _slLogic.Get(Guid.Parse(Id));
		}

		public SecurityLoginsLogPoco GetSingleSecurityLoginsLog(string Id)
		{
			return _sllLogic.Get(Guid.Parse(Id));
		}

		public SecurityLoginsRolePoco GetSingleSecurityLoginsRole(string Id)
		{
			return _slrLogic.Get(Guid.Parse(Id));
		}

		public SecurityRolePoco GetSingleSecurityRole(string Id)
		{
			return _srLogic.Get(Guid.Parse(Id));
		}

		public void RemoveSecurityLogin(SecurityLoginPoco[] item)
		{
			_slLogic.Delete(item);
		}

		public void RemoveSecurityLoginsLog(SecurityLoginsLogPoco[] item)
		{
			_sllLogic.Delete(item);
		}

		public void RemoveSecurityLoginsRole(SecurityLoginsRolePoco[] item)
		{
			_slrLogic.Delete(item);
		}

		public void RemoveSecurityRole(SecurityRolePoco[] item)
		{
			_srLogic.Delete(item);
		}

		public void UpdateSecurityLogin(SecurityLoginPoco[] items)
		{
			_slLogic.Update(items);
		}

		public void UpdateSecurityLoginsLog(SecurityLoginsLogPoco[] items)
		{
			_sllLogic.Update(items);
		}

		public void UpdateSecurityLoginsRole(SecurityLoginsRolePoco[] items)
		{
			_slrLogic.Update(items);
		}

		public void UpdateSecurityRole(SecurityRolePoco[] items)
		{
			_srLogic.Update(items);
		}
	}
}
