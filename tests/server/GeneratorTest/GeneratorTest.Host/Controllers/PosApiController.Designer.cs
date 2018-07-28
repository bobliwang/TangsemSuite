using System.Linq;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using GeneratorTest.Common.Domain.Repositories;
using GeneratorTest.Common.Domain.Entities;
using GeneratorTest.Common.Domain.Entities.DTOs;
using GeneratorTest.Common.Domain.ViewModels.SearchParams;

using Tangsem.Data;
using Tangsem.NHibernate.Extenstions;
using GeneratorTest.Host.Filters;
using GeneratorTest.Host.Controllers.Base;

namespace GeneratorTest.Host.Controllers
{
	public partial class PosApiController : PosApiControllerBase
	{	
		public PosApiController(IGeneratorTestRepository repository, IMapper mapper): base(repository, mapper) {
		}

		[HttpGet("_api/repo/Pos")]
		public override IActionResult GetPosList(PosSearchParams filterModel) {
            return base.GetPosList(filterModel);
		}
     
		[HttpGet("_api/repo/Pos/{id}")]
		public override IActionResult GetPosById(int id) {
			return base.GetPosById(id);
		}

		[HttpPost("_api/repo/Pos/{id}")]
		[TransactionFilter]
		public override IActionResult UpdatePos(int id, [FromBody] PosDTO model) {
		    return base.UpdatePos(id, model);
		}
     
		[HttpPost("_api/repo/Pos")]
		[TransactionFilter]
		public override IActionResult CreatePos([FromBody] PosDTO model) {
			return base.CreatePos(model);
		}

		[HttpPost("_api/repo/Pos/{id}/delete")]
		[TransactionFilter]
		public override IActionResult DeletePos(int id, bool isHardDelete) {
            return base.DeletePos(id, isHardDelete);
		}

		public override IQueryable<Pos> FilterBySearchParams(IQueryable<Pos> qry, PosSearchParams filterModel) {
            return base.FilterBySearchParams(qry, filterModel);
		}
	}

}