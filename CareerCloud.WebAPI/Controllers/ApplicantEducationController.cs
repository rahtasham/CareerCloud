using CareerCloud.BusinessLogicLayer;
using CareerCloud.EntityFrameworkDataAccess;
using CareerCloud.Pocos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace CareerCloud.WebAPI.Controllers
{
	[RoutePrefix("api/careercloud/applicant/v1")]
	public class ApplicantEducationController : ApiController
	{
		private ApplicantEducationLogic _logic;

		public ApplicantEducationController()
		{
			EFGenericRepository<ApplicantEducationPoco> repo =
				new EFGenericRepository<ApplicantEducationPoco>(false);

			_logic = new ApplicantEducationLogic(repo);
		}

		[HttpGet]
		[Route("education/{applicantEducationId}")]
		[ResponseType(typeof(ApplicantEducationPoco))]

		public IHttpActionResult GetApplicantEducation(Guid applicantEducationId)
		{
			try
			{
				ApplicantEducationPoco poco = _logic.Get(applicantEducationId);
				if (poco == null)
				{
					return NotFound();
				}

				return Ok(poco);
			}
			catch (Exception e)
			{
				return InternalServerError(e);
			}
		}

		[HttpGet]
		[Route("education")]
		[ResponseType(typeof(List<ApplicantEducationPoco>))]
		public IHttpActionResult GetAllApplicantEducation()
		{
			try
			{
				List<ApplicantEducationPoco> pocos = _logic.GetAll();
				if (pocos == null)
				{
					return NotFound();
				}

				return Ok(pocos);
			}
			catch (Exception e)
			{
				return InternalServerError(e);
			}
		}

		[HttpPost]
		[Route("education")]
		public IHttpActionResult PostApplicantEducation([FromBody] ApplicantEducationPoco[] pocos)
		{
			try
			{
				_logic.Add(pocos);
				return Ok();
			}
			catch (Exception e)
			{
				return InternalServerError(e);
			}

		}

		[HttpPut]
		[Route("education")]
		public IHttpActionResult PutApplicantEducation([FromBody] ApplicantEducationPoco[] pocos)
		{
			try
			{
				_logic.Update(pocos);
				return Ok();
			}
			catch (Exception e)
			{
				return InternalServerError(e);
			}

		}

		[HttpDelete]
		[Route("education")]
		public IHttpActionResult DeleteApplicantEducation([FromBody] ApplicantEducationPoco[] pocos)
		{
			try
			{
				_logic.Delete(pocos);
				return Ok();
			}
			catch (Exception e)
			{
				return InternalServerError(e);
			}

		}
	}
}
