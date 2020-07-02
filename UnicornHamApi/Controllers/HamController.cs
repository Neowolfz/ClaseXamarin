using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UnicornHamApi.Entities.Models;
using UnicornHamApi.Services;

namespace UnicornHamApi.Controllers
{
    [Route("api/v1/UnicornHamApi/[controller]")]
    public class HamController : Controller
    {
        private DemoContext _context = new DemoContext();
        private UnitOfWork _unitOfWork = new UnitOfWork(new DemoContext());

        [HttpGet]
        public IActionResult GetAllHam()
        {
            var hamburguesas = _unitOfWork.Hamburguesa.Get();

            if (hamburguesas != null)
            {
                return Ok(hamburguesas);
            }
            else
            {
                return Ok();
            }
        }

        [HttpGet("id")]
        public IActionResult GetbyId(int id)
        {
            Hamburguesas hamburguesas = _unitOfWork.Hamburguesa.GetById(id);

            if (hamburguesas != null)
            {
                return Ok(hamburguesas);
            }
            else
            {
                return BadRequest("No se ha encontrado un registro con este id");
            }
        }

        [HttpPut]
        public IActionResult UpdateHam([FromBody] Hamburguesas hamburguesas)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _unitOfWork.Hamburguesa.Update(hamburguesas);
                    _unitOfWork.Save();
                    return Ok();
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (DataException ex)
            {

                return BadRequest(ex);
            }
        }

        [HttpDelete("id")]
        public IActionResult DeleteHam(int id)
        {
            if (id !=0)
            {
                _unitOfWork.Hamburguesa.Delete(id);
                _unitOfWork.Save();
                return Ok("Hamburguesa Eliminada");
            }
            else
            {
                return BadRequest("Hamburguesa con id invalido"); 
            }
        }
    }
}
