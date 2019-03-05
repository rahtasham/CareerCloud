using CareerCloud.Pocos;
using System;
using System.Collections.Generic;
using System.ServiceModel;


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
		CompanyDescriptionPoco GetSingleCompanyDescription(string Id);
		[OperationContract]
		void RemoveCompanyDescription(CompanyDescriptionPoco[] item);
		[OperationContract]
		void UpdateCompanyDescription(CompanyDescriptionPoco[] items);

		[OperationContract]
		void AddCompanyJobEducation(CompanyJobEducationPoco[] item);
		[OperationContract]
		List<CompanyJobEducationPoco> GetAllCompanyJobEducation();
		[OperationContract]
		CompanyJobEducationPoco GetSingleCompanyJobEducation(string Id);
		[OperationContract]
		void RemoveCompanyJobEducation(CompanyJobEducationPoco[] item);
		[OperationContract]
		void UpdateCompanyJobEducation(CompanyJobEducationPoco[] items);

		[OperationContract]
		void AddCompanyJobSkill(CompanyJobSkillPoco[] item);
		[OperationContract]
		List<CompanyJobSkillPoco> GetAllCompanyJobSkill();
		[OperationContract]
		CompanyJobSkillPoco GetSingleCompanyJobSkill(string Id);
		[OperationContract]
		void RemoveCompanyJobSkill(CompanyJobSkillPoco[] item);
		[OperationContract]
		void UpdateCompanyJobSkill(CompanyJobSkillPoco[] items);

		[OperationContract]
		void AddCompanyJob(CompanyJobPoco[] item);
		[OperationContract]
		List<CompanyJobPoco> GetAllCompanyJob();
		[OperationContract]
		CompanyJobPoco GetSingleCompanyJob(string Id);
		[OperationContract]
		void RemoveCompanyJob(CompanyJobPoco[] item);
		[OperationContract]
		void UpdateCompanyJob(CompanyJobPoco[] items);

		[OperationContract]
		void AddCompanyJobDescription(CompanyJobDescriptionPoco[] item);
		[OperationContract]
		List<CompanyJobDescriptionPoco> GetAllCompanyJobDescription();
		[OperationContract]
		CompanyJobDescriptionPoco GetSingleCompanyJobDescription(string Id);
		[OperationContract]
		void RemoveCompanyJobDescription(CompanyJobDescriptionPoco[] item);
		[OperationContract]
		void UpdateCompanyJobDescription(CompanyJobDescriptionPoco[] items);

		[OperationContract]
		void AddCompanyLocation(CompanyLocationPoco[] item);
		[OperationContract]
		List<CompanyLocationPoco> GetAllCompanyLocation();
		[OperationContract]
		CompanyLocationPoco GetSingleCompanyLocation(string Id);
		[OperationContract]
		void RemoveCompanyLocation(CompanyLocationPoco[] item);
		[OperationContract]
		void UpdateCompanyLocation(CompanyLocationPoco[] items);

		[OperationContract]
		void AddCompanyProfile(CompanyProfilePoco[] item);
		[OperationContract]
		List<CompanyProfilePoco> GetAllCompanyProfile();
		[OperationContract]
		CompanyProfilePoco GetSingleCompanyProfile(string Id);
		[OperationContract]
		void RemoveCompanyProfile(CompanyProfilePoco[] item);
		[OperationContract]
		void UpdateCompanyProfile(CompanyProfilePoco[] item);
	}
}
