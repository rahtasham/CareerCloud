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
	[RoutePrefix("api/careercloud/system/v1")]
	public class SystemLanguageCodeController : ApiController
    {
		private SystemLanguageCodeLogic _logic;

		public SystemLanguageCodeController()
		{
			EFGenericRepository<SystemLanguageCodePoco> repo =
				new EFGenericRepository<SystemLanguageCodePoco>(false);

			_logic = new SystemLanguageCodeLogic(repo);
		}

		[HttpGet]
		[Route("languageCode/{systemLanguageCodeLanguageId}")]
		[ResponseType(typeof(SystemLanguageCodePoco))]

		public IHttpActionResult GetSystemLanguageCode(string systemLanguageCodeLanguageId)
		{
			try
			{
				SystemLanguageCodePoco poco = _logic.Get(systemLanguageCodeLanguageId);
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
		[Route("languageCode")]
		[ResponseType(typeof(List<SystemLanguageCodePoco>))]
		public IHttpActionResult GetAllSystemLanguageCode()
		{
			try
			{
				List<SystemLanguageCodePoco> pocos = _logic.GetAll();
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
		[Route("languageCode")]
		public IHttpActionResult PostSystemLanguageCode([FromBody] SystemLanguageCodePoco[] pocos)
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
		[Route("languageCode")]
		public IHttpActionResult PutSystemLanguageCode([FromBody] SystemLanguageCodePoco[] pocos)
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
		[Route("languageCode")]
		public IHttpActionResult DeleteSystemLanguageCode([FromBody] SystemLanguageCodePoco[] pocos)
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
