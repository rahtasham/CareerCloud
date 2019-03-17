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
	[RoutePrefix("api/careercloud/company/v1")]
	public class CompanyJobsDescriptionsController : ApiController
    {
		private CompanyJobDescriptionLogic _logic;

		public CompanyJobsDescriptionsController()
		{
			EFGenericRepository<CompanyJobDescriptionPoco> repo =
				new EFGenericRepository<CompanyJobDescriptionPoco>(false);

			_logic = new CompanyJobDescriptionLogic(repo);
		}

		[HttpGet]
		[Route("jobDescription/{companyJobDescriptionId}")]
		[ResponseType(typeof(CompanyJobDescriptionPoco))]

		public IHttpActionResult GetCompanyJobDescription(Guid companyJobDescriptionId)
		{
			try
			{
				CompanyJobDescriptionPoco poco = _logic.Get(companyJobDescriptionId);
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
		[Route("jobDescription")]
		[ResponseType(typeof(List<CompanyJobDescriptionPoco>))]
		public IHttpActionResult GetAllCompanyJobDescription()
		{
			try
			{
				List<CompanyJobDescriptionPoco> pocos = _logic.GetAll();
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
		[Route("jobDescription")]
		public IHttpActionResult PostCompanyJobDescription([FromBody] CompanyJobDescriptionPoco[] pocos)
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
		[Route("jobDescription")]
		public IHttpActionResult PutCompanyJobDescription([FromBody] CompanyJobDescriptionPoco[] pocos)
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
		[Route("jobDescription")]
		public IHttpActionResult DeleteCompanyJobDescription([FromBody] CompanyJobDescriptionPoco[] pocos)
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
