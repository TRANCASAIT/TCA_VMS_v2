using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static TCA_VMS.Models.VisitorsReport;
using TCA_VMS.Models.DAO;
using TCA_VMS.Models;

namespace TCA_VMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VisitorsReportController : ControllerBase
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly ILogger<VisitorsReportController> _logger;

        public VisitorsReportController(IWebHostEnvironment webHostEnvironment, ILogger<VisitorsReportController> logger)
        {
            _webHostEnvironment = webHostEnvironment;
            _logger = logger;
        }

        [HttpGet("GetVisitorsReports/{userId}")]
        public IActionResult Get_VisitorsReports(int userId)
        {
            List<VisitorsReport> lstVisitorsReport = TCA_VMS_DAO.GetVisitorsReports(userId);
            if (lstVisitorsReport == null)
            {
                Result result = new Result();
                result.NumberRecords = 0;
                return Ok(result);
            }
            else
            {
                return Ok(lstVisitorsReport);
            }
        }

        [HttpGet("GetVisitorsReportsHistory")]
        public IActionResult Get_VisitorsReportsHistory()
        {
            List<VisitorsReport> lstVisitorsReport = TCA_VMS_DAO.GetVisitorsReportsHistory();
            if (lstVisitorsReport == null)
            {
                Result result = new Result();
                result.NumberRecords = 0;
                return Ok(result);
            }
            else
            {
                return Ok(lstVisitorsReport);
            }
        }

        [HttpGet("GetVisitorsReportsHistoryFiltered/{startDate}/{endDate}")]
        public IActionResult Get_VisitorsReportsHistoryFiltered(string startDate, string endDate)
        {
            List<VisitorsReport> lstVisitorsReport = TCA_VMS_DAO.GetVisitorsReportsHistoryFiltered(startDate, endDate);
            if (lstVisitorsReport == null)
            {
                Result result = new Result();
                result.NumberRecords = 0;
                return Ok(result);
            }
            else
            {
                return Ok(lstVisitorsReport);
            }
        }

        [HttpGet("GetVisitorsReport/{id}")]
        public IActionResult Get_VisitorsReport(int id)
        {
            var _visitorsReport = TCA_VMS_DAO.GetVisitorsReport(id);
            if (_visitorsReport.VisitorsReport_Id == 0)
            {
                return NotFound();
            }
            else
            {
                return Ok(_visitorsReport);
            }
        }

        [HttpPost("CreateVisitorsReport")]
        public async Task<IActionResult> Create_VisitorsReport([FromBody] VisitorsReportPost visitorsReport)
        {
            Result result = new Result();
            if (visitorsReport.Company_Id > 0 && visitorsReport.IDType_Id > 0 && visitorsReport.User_Id > 0 &&
                 visitorsReport.VisitorType_Id > 0 && visitorsReport.VisitorsReport_Name.Length > 0 && visitorsReport.VisitorsReport_LastName.Length > 0
                 && visitorsReport.VisitorsReport_Subject.Length > 0 && visitorsReport.VisitorsReport_Photo.Length > 0
                 && visitorsReport.VisitorsReport_RecievedBy > 0)
            {
                if (visitorsReport.VisitorsReport_Laptop == true)
                {
                    if (visitorsReport.VisitorsReport_Laptop_Brand.Length > 0 && visitorsReport.VisitorsReport_Laptop_Serial_Number.Length > 0)
                    {
                        result = TCA_VMS_DAO.StoreVisitorsReport(visitorsReport);
                        return Ok(result);
                    }
                    else
                    {
                        result.Message = "Campos incompletos.";
                        result.State = 400;
                        return BadRequest(result);
                    }
                }
                else if (visitorsReport.VisitorsReport_Laptop == false)
                {
                    result = TCA_VMS_DAO.StoreVisitorsReport(visitorsReport);
                    return Ok(result);
                }
                return Ok(result);
            }
            else
            {
                result.Message = "Campos incompletos.";
                result.State = 400;
                return BadRequest(result);
            }
        }

        //[HttpPost("CreateVisitorsReport")]
        //public async Task<IActionResult> Create_VisitorsReport([FromForm] VisitorsReportPost _vr)
        //{
        //    Result result = new Result();
        //    //Create Date For Folder
        //    var dt = DateTime.Now.ToString("MM_dd_yyyy");
        //    //Create identifier for file
        //    var dtFile = "File-" + DateTime.Now.ToString("MM_dd_yyyy_HH_mm_ss");

        //    //_vr.VisitorsReport_Photo.FileName = dtFile;
        //    if (_vr.Company_Id > 0 && _vr.IDType_Id > 0 && _vr.User_Id > 0 && _vr.VisitorType_Id > 0 &&
        //        _vr.VisitorsReport_Name.Length > 0 && _vr.VisitorsReport_LastName.Length > 0 && _vr.VisitorsReport_Subject.Length > 0 &&
        //        _vr.VisitorsReport_RecievedBy > 0)
        //    {
        //        if (_vr.VisitorsReport_Laptop == true)
        //        {
        //            if (_vr.VisitorsReport_Laptop_Brand?.Length > 0 && _vr.VisitorsReport_Laptop_Serial_Number?.Length > 0)
        //            {
        //                //result = TCA_VMS_DAO.StoreVisitorsReport(visitorsReport);
        //                return Ok(result);
        //            }
        //            else
        //            {
        //                result.Message = "Campos incompletos.";
        //                result.State = 400;
        //                return BadRequest(result);
        //            }
        //        }
        //        else if (_vr.VisitorsReport_Laptop == false)
        //        {
        //            var filePath = Path.Combine(@"/976827-WEB2/tca_vms/App_Data/TCA_VMS_Photos/" + "Base-" + Convert.ToString(_vr.Base_Id) + "/" + dt + "/" + _vr.VisitorsReport_Photo.FileName);
        //            new FileInfo(filePath).Directory?.Create();
        //            await using (var stream = new FileStream(filePath, FileMode.Create))
        //            {
        //                _logger.LogInformation($"Saving file [{_vr.VisitorsReport_Photo.FileName}]");
        //                await _vr.VisitorsReport_Photo.CopyToAsync(stream);
        //                _logger.LogInformation($"\t The uploaded file is saved as [{filePath}].");
        //            }
        //            if (System.IO.File.Exists(filePath))
        //            {
        //                var url = filePath;
        //                result = TCA_VMS_DAO.StoreVisitorsReport(_vr, url);
        //                return Ok(result);
        //            }
        //            else
        //            {
        //                result.State = 1;
        //                result.Message = "El archivo no fue subido";
        //                return BadRequest(result);
        //            }
        //        }
        //    }


            //result = TCA_VMS_DAO.StoreVisitorsReport(visitorsReport);
        //    return Ok();
        //}



        [HttpPut("UpdateVisitorsReportStatus")]
        public IActionResult Update_VisitorsReport_Status(VisitorsReportStatus visitorsReportStatus)
        {
            Result result = new Result();

            if (visitorsReportStatus.VisitorsReport_Id > 0 && visitorsReportStatus.User_Logged.Length > 0)
            {
                result = TCA_VMS_DAO.UpdateVisitorsReport_Status(visitorsReportStatus);
                return Ok(result);
            }
            else
            {
                result.Message = "Identificador no valido.";
                result.State = 400;
                return BadRequest(result);
            }
        }
    }
}
