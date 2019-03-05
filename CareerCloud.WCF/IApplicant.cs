using CareerCloud.Pocos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace CareerCloud.WCF
{
	
	[ServiceContract]
	public interface IApplicant
	{
		[OperationContract]
		void AddApplicantEducation(ApplicantEducationPoco[] item);
		[OperationContract]
		List<ApplicantEducationPoco> GetAllApplicantEducation();
		[OperationContract]
		ApplicantEducationPoco GetSingleApplicantEducation(string Id);
		[OperationContract]
		void RemoveApplicantEducation(ApplicantEducationPoco[] items);
		[OperationContract]
		void UpdateApplicantEducation(ApplicantEducationPoco[] items);

		[OperationContract]
		void AddApplicantJobApplication(ApplicantJobApplicationPoco[] item);
		[OperationContract]
		List<ApplicantJobApplicationPoco> GetAllApplicantJobApplication();
		[OperationContract]
		ApplicantJobApplicationPoco GetSingleApplicantJobApplication(string Id);
		[OperationContract]
		void RemoveApplicantJobApplication(ApplicantJobApplicationPoco[] item);
		[OperationContract]
		void UpdateApplicantJobApplication(ApplicantJobApplicationPoco[] items);

		[OperationContract]
		void AddApplicantProfile(ApplicantProfilePoco[] item);
		[OperationContract]
		List<ApplicantProfilePoco> GetAllApplicantProfile();
		[OperationContract]
		ApplicantProfilePoco GetSingleApplicantProfile(string Id);
		[OperationContract]
		void RemoveApplicantProfile(ApplicantProfilePoco[] item);
		[OperationContract]
		void UpdateApplicantProfile(ApplicantProfilePoco[] items);

		[OperationContract]
		void AddApplicantResume(ApplicantResumePoco[] item);
		[OperationContract]
		List<ApplicantResumePoco> GetAllApplicantResume();
		[OperationContract]
		ApplicantResumePoco GetSingleApplicantResume(string Id);
		[OperationContract]
		void RemoveApplicantResume(ApplicantResumePoco[] item);
		[OperationContract]
		void UpdateApplicantResume(ApplicantResumePoco[] items);

		[OperationContract]
		void AddApplicantSkill(ApplicantSkillPoco[] item);
		[OperationContract]
		List<ApplicantSkillPoco> GetAllApplicantSkill();
		[OperationContract]
		ApplicantSkillPoco GetSingleApplicantSkill(string Id);
		[OperationContract]
		void RemoveApplicantSkill(ApplicantSkillPoco[] item);
		[OperationContract]
		void UpdateApplicantSkill(ApplicantSkillPoco[] items);

		[OperationContract]
		void AddApplicantWorkHistory(ApplicantWorkHistoryPoco[] item);
		[OperationContract]
		List<ApplicantWorkHistoryPoco> GetAllApplicantWorkHistory();
		[OperationContract]
		ApplicantWorkHistoryPoco GetSingleApplicantWorkHistory(string Id);
		[OperationContract]
		void RemoveApplicantWorkHistory(ApplicantWorkHistoryPoco[] item);
		[OperationContract]
		void UpdateApplicantWorkHistory(ApplicantWorkHistoryPoco[] items);

	}
}
