using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Linq.Expressions;

using Tangsem.Data.Domain;

using Sample.Core.Domain.Entities;

using Tangsem.Identity.Domain.Repositories;

namespace Sample.Core.Domain.Repositories
{
	/// <summary>
	/// The ISampleHostRepository interface.
	/// </summary>
	public partial interface ISampleHostRepository : IIdentityRepository
	{
	}
}