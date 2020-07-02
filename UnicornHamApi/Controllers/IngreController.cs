using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using UnicornHamApi.Entities.DTOs;
using UnicornHamApi.Entities.Models;
using UnicornHamApi.Services;

namespace UnicornHamApi.Controllers
{
    [Route("api/v1/UnicornHamApi/[controller]")]

    public class IngreController : Controller
    {
        private UnitOfWork unitOfWork = new UnitOfWork(new DemoContext());

        [HttpGet ("idHam")]

        public IActionResult GetIngre(int idIngre)
        {
            if (idIngre != 0)
            {
                var user = unitOfWork.Ingrediente.Get(x => x.Id == idIngre);
                if (user != null)
                {
                    var ingredientes = unitOfWork.Ingrediente.Get(x => x.HamId == idIngre);
                    var result = CreateMappedObject(ingredientes, idIngre);
                    var serializedList = JsonConvert.SerializeObject(result, Formatting.Indented,
                    new JsonSerializerSettings()
                    {
                        ReferenceLoopHandling = ReferenceLoopHandling.Serialize
                    });
                    return Ok(serializedList);
                }
                else
                {
                    return BadRequest();
                }
            }
            else
            {
                return BadRequest();
            }
        }

        private IngredienteList CreateMappedObject(IEnumerable<Ingredientes> ingredientes, int idIngre)
        {
            IngredienteList listaIngredientes = new IngredienteList();
            foreach (var item in ingredientes)
            {
                Hamburguesas ingrediente = unitOfWork.Hamburguesa.GetById(item.Id);
                listaIngredientes.ingredientesAgregados.Add(ingrediente);

            }
            listaIngredientes.idHam = idIngre;
            return listaIngredientes;
        }
    }
}
