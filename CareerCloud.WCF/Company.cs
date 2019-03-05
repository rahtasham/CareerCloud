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

		public void AddCompanyJobDescriptions(CompanyJobDescriptionPoco[] item)
		{
			_cjdLogic.Add(item);
		}

		public void AddCompanyJobEducation(CompanyJobEducationPoco[] item)
		{
			_cjeLogic.Add(item);
		}

		public void AddCompanyJobs(CompanyJobPoco[] item)
		{
			_cjLogic.Add(item);
		}

		public void AddCompanyJobSkills(CompanyJobSkillPoco[] item)
		{
			_cjsLogic.Add(item);
		}

		public void AddCompanyLocations(CompanyLocationPoco[] item)
		{
			_clLogic.Add(item);
		}

		public void AddCompanyProfiles(CompanyProfilePoco[] item)
		{
			_cpLogic.Add(item);
		}

		public List<CompanyDescriptionPoco> GetAllCompanyDescription()
		{
			return _cdLogic.GetAll();
		}

		public List<CompanyJobDescriptionPoco> GetAllCompanyJobDescriptions()
		{
			return _cjdLogic.GetAll();
		}

		public List<CompanyJobEducationPoco> GetAllCompanyJobEducation()
		{
			return _cjeLogic.GetAll();
		}

		public List<CompanyJobPoco> GetAllCompanyJobs()
		{
			return _cjLogic.GetAll();
		}

		public List<CompanyJobSkillPoco> GetAllCompanyJobSkills()
		{
			return _cjsLogic.GetAll();
		}

		public List<CompanyLocationPoco> GetAllCompanyLocations()
		{
			return _clLogic.GetAll();
		}

		public List<CompanyProfilePoco> GetAllCompanyProfiles()
		{
			return _cpLogic.GetAll();
		}

		public CompanyDescriptionPoco GetSingleCompanyDescription(Guid Id)
		{
			return _cdLogic.Get(Id);
		}

		public CompanyJobDescriptionPoco GetSingleCompanyJobDescriptions(Guid Id)
		{
			return _cjdLogic.Get(Id);
		}

		public CompanyJobEducationPoco GetSingleCompanyJobEducation(Guid Id)
		{
			return _cjeLogic.Get(Id);
		}

		public CompanyJobPoco GetSingleCompanyJobs(Guid Id)
		{
			return _cjLogic.Get(Id);
		}

		public CompanyJobSkillPoco GetSingleCompanyJobSkills(Guid Id)
		{
			return _cjsLogic.Get(Id);
		}

		public CompanyLocationPoco GetSingleCompanyLocations(Guid Id)
		{
			return _clLogic.Get(Id);
		}

		public CompanyProfilePoco GetSingleCompanyProfiles(Guid Id)
		{
			return _cpLogic.Get(Id);
		}

		public void RemoveCompanyDescription(CompanyDescriptionPoco[] item)
		{
			_cdLogic.Delete(item);
		}

		public void RemoveCompanyJobDescriptions(CompanyJobDescriptionPoco[] item)
		{
			_cjdLogic.Delete(item);
		}

		public void RemoveCompanyJobEducation(CompanyJobEducationPoco[] item)
		{
			_cjeLogic.Delete(item);
		}

		public void RemoveCompanyJobs(CompanyJobPoco[] item)
		{
			_cjLogic.Delete(item);
		}

		public void RemoveCompanyJobSkills(CompanyJobSkillPoco[] item)
		{
			_cjsLogic.Delete(item);
		}

		public void RemoveCompanyLocations(CompanyLocationPoco[] item)
		{
			_clLogic.Delete(item);
		}

		public void RemoveCompanyProfiles(CompanyProfilePoco[] item)
		{
			_cpLogic.Delete(item);
		}

		public void UpdateCompanyDescription(CompanyDescriptionPoco[] items)
		{
			_cdLogic.Update(items);
		}

		public void UpdateCompanyJobDescriptions(CompanyJobDescriptionPoco[] items)
		{
			_cjdLogic.Update(items);
		}

		public void UpdateCompanyJobEducation(CompanyJobEducationPoco[] items)
		{
			_cjeLogic.Update(items);
		}

		public void UpdateCompanyJobs(CompanyJobPoco[] items)
		{
			_cjLogic.Update(items);
		}

		public void UpdateCompanyJobSkills(CompanyJobSkillPoco[] items)
		{
			_cjsLogic.Update(items);
		}

		public void UpdateCompanyLocations(CompanyLocationPoco[] items)
		{
			_clLogic.Update(items);
		}

		public void UpdateCompanyProfiles(CompanyProfilePoco[] items)
		{
			_cpLogic.Update(items);
		}
	}
}