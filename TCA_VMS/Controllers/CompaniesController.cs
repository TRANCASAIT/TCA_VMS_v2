using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static TCA_VMS.Models.Company;
using TCA_VMS.Models.DAO;
using TCA_VMS.Models;

namespace TCA_VMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompaniesController : ControllerBase
    {
        [HttpGet("GetCompanies/{userId}")]
        public IActionResult Get_Companies(int userId)
        {
            List<Company> lstCompanies = TCA_VMS_DAO.GetCompanies(userId);
            if (lstCompanies == null)
            {
                Result result = new Result();
                result.NumberRecords = 0;
                return Ok(result);
            }
            else
            {
                return Ok(lstCompanies);
            }
        }


        [HttpGet("GetCompaniesForms/{userId}")]
        public IActionResult Get_Companies_Forms(int userId)
        {
            List<Company> lstCompanies = TCA_VMS_DAO.GetCompaniesForms(userId);
            if (lstCompanies == null)
            {
                Result result = new Result();
                result.NumberRecords = 0;
                return Ok(result);
            }
            else
            {
                return Ok(lstCompanies);
            }
        }

        [HttpGet("GetCompany/{id}")]
        public IActionResult Get_Company(int id)
        {
            var _company = TCA_VMS_DAO.GetCompany(id);
            if (_company.Company_Id == 0)
            {
                return NotFound();
            }
            else
            {
                return Ok(_company);
            }
        }


        [HttpPost("CreateCompany")]
        public IActionResult Create_Company([FromBody] CompanyPost _company)
        {

            Result result = new Result();
            if (_company.Company_Name.Length > 0 && _company.Company_Address.Length > 0 && _company.Company_Phone_Number.Length > 0 && _company.Base_Id > 0)
            {
                result = TCA_VMS_DAO.StoreCompany(_company);
                return Ok(result);
            }
            else
            {
                result.Message = "Campos incompletos.";
                result.State = 400;
                return BadRequest(result);
            }
        }

        [HttpPut("UpdateCompany")]
        public IActionResult Update_Company(CompanyPost _company)
        {

            Result result = new Result();
            if (_company.Company_Name.Length > 0 && _company.Company_Address.Length > 0 && _company.Company_Phone_Number.Length > 0 && _company.Base_Id > 0)
            {
                result = TCA_VMS_DAO.UpdateCompany(_company);
                return Ok(result);
            }
            else
            {
                result.Message = "Campos incompletos.";
                result.State = 400;
                return BadRequest(result);
            }
        }

        [HttpPut("UpdateCompanyState")]
        public IActionResult Update_Base_State(CompanyStatus _company)
        {
            Result result = new Result();
            if (_company.Company_Id > 0)
            {
                result = TCA_VMS_DAO.UpdateCompanyStatus(_company);
                return Ok(result);
            }
            else
            {

            }
            return Ok();
        }
    }
}
