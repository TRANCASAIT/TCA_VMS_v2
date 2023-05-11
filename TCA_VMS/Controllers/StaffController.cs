using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TCA_VMS.Models.DAO;
using TCA_VMS.Models;

namespace TCA_VMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffController : ControllerBase
    {
        [HttpGet("GetStaff")] //Nombre del endpoint que sera tomado a la hora de hacer la peticion
        public IActionResult Get_Staff()
        {
            //Lista creada con base en el modelo y generando una instancia de ella, para asignar el valor del metodo
            //get bases el cual trae un listado de las bases disponibles en la BD.

            List<Staff> lstStaff = TCA_VMS_DAO.GetStaff();
            if (lstStaff == null) //se verifica si el listado viene nulo, en ese caso de envia un resultado a el FE
            {
                //Se crea una instancia del modelo Result para acceder a sus propiedades y se asigna un valor de 0 en caso de no contener registros
                Result result = new Result();
                result.NumberRecords = 0;
                return Ok(result);
            }
            else
            {
                return Ok(lstStaff);
            }
        }

        [HttpGet("GetStaffForms/{userId}")] //Nombre del endpoint que sera tomado a la hora de hacer la peticion
        public IActionResult Get_Staff_Forms(int userId)
        {
            //Lista creada con base en el modelo y generando una instancia de ella, para asignar el valor del metodo
            //get bases el cual trae un listado de las bases disponibles en la BD.

            List<Staff> lstStaff = TCA_VMS_DAO.GetStaffForms(userId);
            if (lstStaff == null) //se verifica si el listado viene nulo, en ese caso de envia un resultado a el FE
            {
                //Se crea una instancia del modelo Result para acceder a sus propiedades y se asigna un valor de 0 en caso de no contener registros
                Result result = new Result();
                result.NumberRecords = 0;
                return Ok(result);
            }
            else
            {
                return Ok(lstStaff);
            }
        }

        [HttpPost("CreateStaff")]
        public IActionResult Create_Base([FromBody] StaffPost _staff)
        {
            //
            Result result = new Result();
            if (_staff.Staff_Name.Length > 0 && _staff.Staff_LastName.Length > 0 && _staff.Staff_Number.Length > 0 && _staff.Staff_PhoneNumber.Length > 0 && _staff.Staff_Email.Length > 0 && _staff.Base_Id > 0 && _staff.Department_Id > 0)
            {
                result = TCA_VMS_DAO.StoreStaff(_staff);
                return Ok(result);
            }
            else
            {
                result.State = 1;
                result.Message = "Verifique los datos";
                return Ok(result);
            }
        }

        [HttpPut("UpdateStaff")]
        public IActionResult Update_Base(StaffPut _staff)
        {
            Result result = new Result();
            if (_staff.Staff_Id > 0 && _staff.Staff_Name.Length > 0 && _staff.Staff_LastName.Length > 0 && _staff.Staff_Number.Length > 0 && _staff.Staff_PhoneNumber.Length > 0 && _staff.Staff_Email.Length > 0 && _staff.Base_Id > 0 && _staff.Department_Id > 0)
            {
                result = TCA_VMS_DAO.UpdateStaff(_staff);
                return Ok(result);
            }
            else
            {
                result.State = 1;
                result.Message = "Verifique los datos";
                return Ok(result);
            }

        }

        [HttpPut("UpdateStaffState")]
        public IActionResult Update_Staff_State(StaffStatus _staff)
        {
            Result result = new Result();
            if (_staff.Staff_Id > 0)
            {
                result = TCA_VMS_DAO.UpdateStaffStatus(_staff);
                return Ok(result);
            }
            else
            {

            }
            return Ok();
        }
    }
}

