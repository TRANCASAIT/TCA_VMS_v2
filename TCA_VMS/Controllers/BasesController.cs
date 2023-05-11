using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static TCA_VMS.Models.Base;
using TCA_VMS.Models.DAO;
using TCA_VMS.Models;

namespace TCA_VMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasesController : ControllerBase
    {
        //->Bases + / + Nombre del endpoint
        //FE -> FrontEnd
        //HttpGet Requests
        [HttpGet("GetBases")] //Nombre del endpoint que sera tomado a la hora de hacer la peticion
        public IActionResult Get_Bases()
        {
            //Lista creada con base en el modelo y generando una instancia de ella, para asignar el valor del metodo
            //get bases el cual trae un listado de las bases disponibles en la BD.

            List<Base> lstBases = TCA_VMS_DAO.GetBases();
            if (lstBases == null) //se verifica si el listado viene nulo, en ese caso de envia un resultado a el FE
            {
                //Se crea una instancia del modelo Result para acceder a sus propiedades y se asigna un valor de 0 en caso de no contener registros
                Result result = new Result();
                result.NumberRecords = 0;
                return Ok(result);
            }
            else
            {
                return Ok(lstBases);
            }
        }

        [HttpGet("GetBasesForms")] //Nombre del endpoint que sera tomado a la hora de hacer la peticion
        public IActionResult Get_Bases_Forms()
        {
            //Lista creada con base en el modelo y generando una instancia de ella, para asignar el valor del metodo
            //get bases el cual trae un listado de las bases disponibles en la BD.

            List<Base> lstBases = TCA_VMS_DAO.GetBasesForms();
            if (lstBases == null) //se verifica si el listado viene nulo, en ese caso de envia un resultado a el FE
            {
                //Se crea una instancia del modelo Result para acceder a sus propiedades y se asigna un valor de 0 en caso de no contener registros
                Result result = new Result();
                result.NumberRecords = 0;
                return Ok(result);
            }
            else
            {
                return Ok(lstBases);
            }
        }

        [HttpGet("GetBase/{id}")]
        public IActionResult Get_Base(int id)
        {
            // se asigna a la variable _base el objeto que venga devuelto de la BD con el metodo GetBase usando de referencia la Id.
            var _base = TCA_VMS_DAO.GetBase(id);
            if (_base.Base_Id == 0)
            {
                //Retornar not found en caso de no encontrarlo
                return NotFound();
            }
            else
            {
                //retornar oK y el objeto en caso de encontrarlo
                return Ok(_base);
            }

        }

        [HttpPost("CreateBase")]
        public IActionResult Create_Base([FromBody] Base _base)
        {
            //
            Result result = new Result();
            if (_base.Base_Location.Length > 0 && _base.Base_Name.Length > 0)
            {
                result = TCA_VMS_DAO.StoreBase(_base);
                return Ok(result);
            }
            else
            {
                result.State = 1;
                result.Message = "Verifique los datos";
                return Ok(result);
            }
        }

        [HttpPut("UpdateBase")]
        public IActionResult Update_Base(BaseEdit _base)
        {
            Result result = new Result();
            if (_base.Base_Location.Length > 0 && _base.Base_Name.Length > 0)
            {
                result = TCA_VMS_DAO.UpdateBase(_base);
                return Ok(result);
            }
            else
            {
                result.State = 1;
                result.Message = "Verifique los datos";
                return Ok(result);
            }

        }

        [HttpPut("UpdateBaseState")]
        public IActionResult Update_Base_State(BaseStatus _base)
        {
            Result result = new Result();
            if (_base.Base_Id > 0)
            {
                result = TCA_VMS_DAO.UpdateBaseStatus(_base);
                return Ok(result);
            }
            else
            {

            }
            return Ok();
        }
    }
}
