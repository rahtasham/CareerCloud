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
	public interface ICompany
	{
		[OperationContract]
		void AddCompanyDescription(CompanyDescriptionPoco[] item);
		[OperationContract]
		List<CompanyDescriptionPoco> GetAllCompanyDescription();
		[OperationContract]
		CompanyDescriptionPoco GetSingleCompanyDescription(Guid Id);
		[OperationContract]
		void RemoveCompanyDescription(CompanyDescriptionPoco[] item);
		[OperationContract]
		void UpdateCompanyDescription(CompanyDescriptionPoco[] items);

		[OperationContract]
		void AddCompanyJobEducation(CompanyJobEducationPoco[] item);
		[OperationContract]
		List<CompanyJobEducationPoco> GetAllCompanyJobEducation();
		[OperationContract]
		CompanyJobEducationPoco GetSingleCompanyJobEducation(Guid Id);
		[OperationContract]
		void RemoveCompanyJobEducation(CompanyJobEducationPoco[] item);
		[OperationContract]
		void UpdateCompanyJobEducation(CompanyJobEducationPoco[] items);

		[OperationContract]
		void AddCompanyJobSkills(CompanyJobSkillPoco[] item);
		[OperationContract]
		List<CompanyJobSkillPoco> GetAllCompanyJobSkills();
		[OperationContract]
		CompanyJobSkillPoco GetSingleCompanyJobSkills(Guid Id);
		[OperationContract]
		void RemoveCompanyJobSkills(CompanyJobSkillPoco[] item);
		[OperationContract]
		void UpdateCompanyJobSkills(CompanyJobSkillPoco[] items);

		[OperationContract]
		void AddCompanyJobs(CompanyJobPoco[] item);
		[OperationContract]
		List<CompanyJobPoco> GetAllCompanyJobs();
		[OperationContract]
		CompanyJobPoco GetSingleCompanyJobs(Guid Id);
		[OperationContract]
		void RemoveCompanyJobs(CompanyJobPoco[] item);
		[OperationContract]
		void UpdateCompanyJobs(CompanyJobPoco[] items);

		[OperationContract]
		void AddCompanyJobDescriptions(CompanyJobDescriptionPoco[] item);
		[OperationContract]
		List<CompanyJobDescriptionPoco> GetAllCompanyJobDescriptions();
		[OperationContract]
		CompanyJobDescriptionPoco GetSingleCompanyJobDescriptions(Guid Id);
		[OperationContract]
		void RemoveCompanyJobDescriptions(CompanyJobDescriptionPoco[] item);
		[OperationContract]
		void UpdateCompanyJobDescriptions(CompanyJobDescriptionPoco[] items);

		[OperationContract]
		void AddCompanyLocations(CompanyLocationPoco[] item);
		[OperationContract]
		List<CompanyLocationPoco> GetAllCompanyLocations();
		[OperationContract]
		CompanyLocationPoco GetSingleCompanyLocations(Guid Id);
		[OperationContract]
		void RemoveCompanyLocations(CompanyLocationPoco[] item);
		[OperationContract]
		void UpdateCompanyLocations(CompanyLocationPoco[] items);

		[OperationContract]
		void AddCompanyProfiles(CompanyProfilePoco[] item);
		[OperationContract]
		List<CompanyProfilePoco> GetAllCompanyProfiles();
		[OperationContract]
		CompanyProfilePoco GetSingleCompanyProfiles(Guid Id);
		[OperationContract]
		void RemoveCompanyProfiles(CompanyProfilePoco[] item);
		[OperationContract]
		void UpdateCompanyProfiles(CompanyProfilePoco[] items);
	}
}
