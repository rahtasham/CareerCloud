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
	[RoutePrefix("api/careercloud/security/v1")]
	public class SecurityLoginsLogController : ApiController
    {
		private SecurityLoginsLogLogic _logic;

		public SecurityLoginsLogController()
		{
			EFGenericRepository<SecurityLoginsLogPoco> repo =
				new EFGenericRepository<SecurityLoginsLogPoco>(false);

			_logic = new SecurityLoginsLogLogic(repo);
		}

		[HttpGet]
		[Route("loginsLog/{securityLoginsLogId}")]
		[ResponseType(typeof(SecurityLoginsLogPoco))]

		public IHttpActionResult GetSecurityLoginsLog(Guid securityLoginsLogId)
		{
			try
			{
				SecurityLoginsLogPoco poco = _logic.Get(securityLoginsLogId);
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
		[Route("loginsLog")]
		[ResponseType(typeof(List<SecurityLoginsLogPoco>))]
		public IHttpActionResult GetAllSecurityLoginsLog()
		{
			try
			{
				List<SecurityLoginsLogPoco> pocos = _logic.GetAll();
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
		[Route("loginsLog")]
		public IHttpActionResult PostSecurityLoginsLog([FromBody] SecurityLoginsLogPoco[] pocos)
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
		[Route("loginsLog")]
		public IHttpActionResult PutSecurityLoginsLog([FromBody] SecurityLoginsLogPoco[] pocos)
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
		[Route("loginsLog")]
		public IHttpActionResult DeleteSecurityLoginsLog([FromBody] SecurityLoginsLogPoco[] pocos)
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
