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
	public class CompanyProfileController : ApiController
    {
		private CompanyProfileLogic _logic;

		public CompanyProfileController()
		{
			EFGenericRepository<CompanyProfilePoco> repo =
				new EFGenericRepository<CompanyProfilePoco>(false);

			_logic = new CompanyProfileLogic(repo);
		}

		[HttpGet]
		[Route("profile/{companyProfileId}")]
		[ResponseType(typeof(CompanyProfilePoco))]

		public IHttpActionResult GetCompanyProfile(Guid companyProfileId)
		{
			try
			{
				CompanyProfilePoco poco = _logic.Get(companyProfileId);
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
		[Route("profile")]
		[ResponseType(typeof(List<CompanyProfilePoco>))]
		public IHttpActionResult GetAllCompanyProfile()
		{
			try
			{
				List<CompanyProfilePoco> pocos = _logic.GetAll();
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
		[Route("profile")]
		public IHttpActionResult PostCompanyProfile([FromBody] CompanyProfilePoco[] pocos)
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
		[Route("profile")]
		public IHttpActionResult PutCompanyProfile([FromBody] CompanyProfilePoco[] pocos)
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
		[Route("profile")]
		public IHttpActionResult DeleteCompanyProfile([FromBody] CompanyProfilePoco[] pocos)
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
