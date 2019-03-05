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

	public class Company : ICompany
	{
		private CompanyDescriptionLogic _cdLogic;
		private CompanyJobEducationLogic _cjeLogic;
		private CompanyJobSkillLogic _cjsLogic;
		private CompanyJobLogic _cjLogic;
		private CompanyJobDescriptionLogic _cjdLogic;
		private CompanyLocationLogic _clLogic;
		private CompanyProfileLogic _cpLogic;


		public Company()
		{
			EFGenericRepository<CompanyDescriptionPoco> cdRepo =
				new EFGenericRepository<CompanyDescriptionPoco>(false);
			_cdLogic = new CompanyDescriptionLogic(cdRepo);


			EFGenericRepository<CompanyJobEducationPoco> cjeRepo =
				new EFGenericRepository<CompanyJobEducationPoco>(false);
			_cjeLogic = new CompanyJobEducationLogic(cjeRepo);

			EFGenericRepository<CompanyJobSkillPoco> cjsRepo =
				new EFGenericRepository<CompanyJobSkillPoco>(false);
			_cjsLogic = new CompanyJobSkillLogic(cjsRepo);


			EFGenericRepository<CompanyJobPoco> cjRepo =
				new EFGenericRepository<CompanyJobPoco>(false);
			_cjLogic = new CompanyJobLogic(cjRepo);


			EFGenericRepository<CompanyJobDescriptionPoco> cjdRepo =
				new EFGenericRepository<CompanyJobDescriptionPoco>(false);
			_cjdLogic = new CompanyJobDescriptionLogic(cjdRepo);


			EFGenericRepository<CompanyLocationPoco> clRepo =
				new EFGenericRepository<CompanyLocationPoco>(false);
			_clLogic = new CompanyLocationLogic(clRepo);


			EFGenericRepository<CompanyProfilePoco> cpRepo =
				new EFGenericRepository<CompanyProfilePoco>(false);
			_cpLogic = new CompanyProfileLogic(cpRepo);

		}

		public void AddCompanyDescription(CompanyDescriptionPoco[] item)
		{
			_cdLogic.Add(item);
		}

		public void AddCompanyJobDescription(CompanyJobDescriptionPoco[] item)
		{
			_cjdLogic.Add(item);
		}

		public void AddCompanyJobEducation(CompanyJobEducationPoco[] item)
		{
			_cjeLogic.Add(item);
		}

		public void AddCompanyJob(CompanyJobPoco[] item)
		{
			_cjLogic.Add(item);
		}

		public void AddCompanyJobSkill(CompanyJobSkillPoco[] item)
		{
			_cjsLogic.Add(item);
		}

		public void AddCompanyLocation(CompanyLocationPoco[] item)
		{
			_clLogic.Add(item);
		}

		public void AddCompanyProfile(CompanyProfilePoco[] item)
		{
			_cpLogic.Add(item);
		}

		public List<CompanyDescriptionPoco> GetAllCompanyDescription()
		{
			return _cdLogic.GetAll();
		}

		public List<CompanyJobDescriptionPoco> GetAllCompanyJobDescription()
		{
			return _cjdLogic.GetAll();
		}

		public List<CompanyJobEducationPoco> GetAllCompanyJobEducation()
		{
			return _cjeLogic.GetAll();
		}

		public List<CompanyJobPoco> GetAllCompanyJob()
		{
			return _cjLogic.GetAll();
		}

		public List<CompanyJobSkillPoco> GetAllCompanyJobSkill()
		{
			return _cjsLogic.GetAll();
		}

		public List<CompanyLocationPoco> GetAllCompanyLocation()
		{
			return _clLogic.GetAll();
		}

		public List<CompanyProfilePoco> GetAllCompanyProfile()
		{
			return _cpLogic.GetAll();
		}

		public CompanyDescriptionPoco GetSingleCompanyDescription(string Id)
		{
			return _cdLogic.Get(Guid.Parse(Id));
		}

		public CompanyJobDescriptionPoco GetSingleCompanyJobDescription(string Id)
		{
			return _cjdLogic.Get(Guid.Parse(Id));
		}

		public CompanyJobEducationPoco GetSingleCompanyJobEducation(string Id)
		{
			return _cjeLogic.Get(Guid.Parse(Id));
		}

		public CompanyJobPoco GetSingleCompanyJob(string Id)
		{
			return _cjLogic.Get(Guid.Parse(Id));
		}

		public CompanyJobSkillPoco GetSingleCompanyJobSkill(string Id)
		{
			return _cjsLogic.Get(Guid.Parse(Id));
		}

		public CompanyLocationPoco GetSingleCompanyLocation(string Id)
		{
			return _clLogic.Get(Guid.Parse(Id));
		}

		public CompanyProfilePoco GetSingleCompanyProfile(string Id)
		{
			return _cpLogic.Get(Guid.Parse(Id));
		}

		public void RemoveCompanyDescription(CompanyDescriptionPoco[] item)
		{
			_cdLogic.Delete(item);
		}

		public void RemoveCompanyJobDescription(CompanyJobDescriptionPoco[] item)
		{
			_cjdLogic.Delete(item);
		}

		public void RemoveCompanyJobEducation(CompanyJobEducationPoco[] item)
		{
			_cjeLogic.Delete(item);
		}

		public void RemoveCompanyJob(CompanyJobPoco[] item)
		{
			_cjLogic.Delete(item);
		}

		public void RemoveCompanyJobSkill(CompanyJobSkillPoco[] item)
		{
			_cjsLogic.Delete(item);
		}

		public void RemoveCompanyLocation(CompanyLocationPoco[] item)
		{
			_clLogic.Delete(item);
		}

		public void RemoveCompanyProfile(CompanyProfilePoco[] item)
		{
			_cpLogic.Delete(item);
		}

		public void UpdateCompanyDescription(CompanyDescriptionPoco[] items)
		{
			_cdLogic.Update(items);
		}

		public void UpdateCompanyJobDescription(CompanyJobDescriptionPoco[] items)
		{
			_cjdLogic.Update(items);
		}

		public void UpdateCompanyJobEducation(CompanyJobEducationPoco[] items)
		{
			_cjeLogic.Update(items);
		}

		public void UpdateCompanyJob(CompanyJobPoco[] items)
		{
			_cjLogic.Update(items);
		}

		public void UpdateCompanyJobSkill(CompanyJobSkillPoco[] items)
		{
			_cjsLogic.Update(items);
		}

		public void UpdateCompanyLocation(CompanyLocationPoco[] items)
		{
			_clLogic.Update(items);
		}

		public void UpdateCompanyProfile(CompanyProfilePoco[]item)
		{
			_cpLogic.Update(item);
		}
	}
}