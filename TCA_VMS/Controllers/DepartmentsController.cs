using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TCA_VMS.Models.DAO;
using TCA_VMS.Models;

namespace TCA_VMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        [HttpGet("GetDepartments")]
        public IActionResult Get_Departments()
        {


            List<Department> lstDepartments = TCA_VMS_DAO.GetDepartments();
            if (lstDepartments == null)
            {
                Result result = new Result();
                result.NumberRecords = 0;
                return Ok(result);
            }
            else
            {
                return Ok(lstDepartments);
            }
        }

        [HttpGet("GetDepartmentsForms")]
        public IActionResult Get_Departments_Forms()
        {
            List<Department> lstDepartments = TCA_VMS_DAO.GetDepartmentsForms();
            if (lstDepartments == null)
            {
                Result result = new Result();
                result.NumberRecords = 0;
                return Ok(result);
            }
            else
            {
                return Ok(lstDepartments);
            }
        }

        [HttpPost("CreateDepartment")]
        public IActionResult Create_Department([FromBody] Department _department)
        {
            Result result = new Result();
            if (_department.Department_Name.Length > 0)
            {
                result = TCA_VMS_DAO.StoreDepartment(_department);
                return Ok(result);
            }
            else
            {
                result.State = 1;
                result.Message = "Verifique los datos";
                return Ok(result);
            }
        }

        [HttpPut("UpdateDepartment")]
        public IActionResult Update_Department(DepartmentUpdate _department)
        {
            Result result = new Result();
            if (_department.Department_Name.Length > 0)
            {
                result = TCA_VMS_DAO.UpdateDepartment(_department);
                return Ok(result);
            }
            else
            {
                result.State = 1;
                result.Message = "Verifique los datos";
                return Ok(result);
            }

        }
    }
}
