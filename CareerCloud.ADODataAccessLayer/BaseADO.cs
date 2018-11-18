using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerCloud.ADODataAccessLayer
{
	public abstract class BaseADO
	{
		protected string connString;

		public BaseADO()
		{
			connString = @"Data Source=LAPTOP-NO2P841J\HUMBERBRIDGING;
							Initial Catalog=JOB_PORTAL_DB;Integrated Security=True;";
		}
	}
}
