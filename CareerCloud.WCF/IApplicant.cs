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
		ApplicantEducationPoco GetSingleAppplicantEducation(Guid Id);
		[OperationContract]
		void RemoveApplicantEducation(ApplicantEducationPoco[] items);
		[OperationContract]
		void UpdateApplicantEducation(ApplicantEducationPoco[] items);

		[OperationContract]
		void AddApplicantJobApplication(ApplicantJobApplicationPoco[] item);
		[OperationContract]
		List<ApplicantJobApplicationPoco> GetAllApplicantJobApplication();
		[OperationContract]
		ApplicantJobApplicationPoco GetSingleApplicantJobApplication(Guid Id);
		[OperationContract]
		void RemoveApplicantJobApplication(ApplicantJobApplicationPoco[] item);
		[OperationContract]
		void UpdateApplicantJobApplication(ApplicantJobApplicationPoco[] items);

		[OperationContract]
		void AddApplicantProfiles(ApplicantProfilePoco[] item);
		[OperationContract]
		List<ApplicantProfilePoco> GetAllApplicantProfiles();
		[OperationContract]
		ApplicantProfilePoco GetSingleApplicantProfiles(Guid Id);
		[OperationContract]
		void RemoveApplicantProfiles(ApplicantProfilePoco[] item);
		[OperationContract]
		void UpdateApplicantProfiles(ApplicantProfilePoco[] items);

		[OperationContract]
		void AddApplicantResume(ApplicantResumePoco[] item);
		[OperationContract]
		List<ApplicantResumePoco> GetAllApplicantResume();
		[OperationContract]
		ApplicantResumePoco GetSingleApplicantResume(Guid Id);
		[OperationContract]
		void RemoveApplicantResume(ApplicantResumePoco[] item);
		[OperationContract]
		void UpdateApplicantResume(ApplicantResumePoco[] items);

		[OperationContract]
		void AddApplicantSkills(ApplicantSkillPoco[] item);
		[OperationContract]
		List<ApplicantSkillPoco> GetAllApplicantSkills();
		[OperationContract]
		ApplicantSkillPoco GetSingleApplicantSkills(Guid Id);
		[OperationContract]
		void RemoveApplicantSkills(ApplicantSkillPoco[] item);
		[OperationContract]
		void UpdateApplicantSkills(ApplicantSkillPoco[] items);

		[OperationContract]
		void AddApplicantWorkHistory(ApplicantWorkHistoryPoco[] item);
		[OperationContract]
		List<ApplicantWorkHistoryPoco> GetAllApplicantWorkHistory();
		[OperationContract]
		ApplicantWorkHistoryPoco GetSingleApplicantWorkHistory(Guid Id);
		[OperationContract]
		void RemoveApplicantWorkHistory(ApplicantWorkHistoryPoco[] item);
		[OperationContract]
		void UpdateApplicantWorkHistory(ApplicantWorkHistoryPoco[] items);

	}
}
