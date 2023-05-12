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
                for(int i = 0; i < lstVisitorsReport.Count; i++)
                {
                    byte[] bytes = System.IO.File.ReadAllBytes(lstVisitorsReport[i].VisitorsReport_Photo!);
                    string image = Convert.ToBase64String(bytes);
                    lstVisitorsReport[i].VisitorsReport_Photo = image;
                }
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
                for (int i = 0; i < lstVisitorsReport.Count; i++)
                {
                    byte[] bytes = System.IO.File.ReadAllBytes(lstVisitorsReport[i].VisitorsReport_Photo!);
                    string image = Convert.ToBase64String(bytes);
                    lstVisitorsReport[i].VisitorsReport_Photo = image;
                }
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
                for (int i = 0; i < lstVisitorsReport.Count; i++)
                {
                    byte[] bytes = System.IO.File.ReadAllBytes(lstVisitorsReport[i].VisitorsReport_Photo!);
                    string image = Convert.ToBase64String(bytes);
                    lstVisitorsReport[i].VisitorsReport_Photo = image;
                }
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
                byte[] bytes = System.IO.File.ReadAllBytes(_visitorsReport.VisitorsReport_Photo!);
                string image = Convert.ToBase64String(bytes);
                _visitorsReport.VisitorsReport_Photo = image;
                return Ok(_visitorsReport);
            }
        }

        //[HttpPost("CreateVisitorsReport")]
        //public async Task<IActionResult> Create_VisitorsReport([FromForm] VisitorsReportPost visitorsReport)
        //{
        //    Result result = new Result();
        //    if (visitorsReport.Company_Id > 0 && visitorsReport.IDType_Id > 0 && visitorsReport.User_Id > 0 &&
        //         visitorsReport.VisitorType_Id > 0 && visitorsReport.VisitorsReport_Name.Length > 0 && visitorsReport.VisitorsReport_LastName.Length > 0
        //         && visitorsReport.VisitorsReport_Subject.Length > 0 && visitorsReport.VisitorsReport_Photo.Length > 0
        //         && visitorsReport.VisitorsReport_RecievedBy > 0)
        //    {
        //        if (visitorsReport.VisitorsReport_Laptop == true)
        //        {
        //            if (visitorsReport.VisitorsReport_Laptop_Brand.Length > 0 && visitorsReport.VisitorsReport_Laptop_Serial_Number.Length > 0)
        //            {
        //                //result = TCA_VMS_DAO.StoreVisitorsReport(visitorsReport);
        //                return Ok();
        //            }
        //            else
        //            {
        //                result.Message = "Campos incompletos.";
        //                result.State = 400;
        //                return BadRequest(result);
        //            }
        //        }
        //        else if (visitorsReport.VisitorsReport_Laptop == false)
        //        {
        //            //result = TCA_VMS_DAO.StoreVisitorsReport(visitorsReport);
        //            return Ok();
        //        }
        //        return Ok();
        //    }
        //    else
        //    {
        //        result.Message = "Campos incompletos.";
        //        result.State = 400;
        //        return BadRequest(result);
        //    }
        //}

        [HttpPost("CreateVisitorsReport")]
        public async Task<IActionResult> Create_VisitorsReport([FromForm] VisitorsReportPost _vr)
        {
            Result result = new Result();
            //Create Date For Folder
            var dt = DateTime.Now.ToString("MM_dd_yyyy");

            if (_vr.Company_Id > 0 && _vr.IDType_Id > 0 && _vr.User_Id > 0 && _vr.VisitorType_Id > 0 &&
                _vr.VisitorsReport_Name?.Length > 0 && _vr.VisitorsReport_LastName?.Length > 0 && _vr.VisitorsReport_Subject?.Length > 0 &&
                _vr.VisitorsReport_RecievedBy > 0)
            {
                if(_vr.VisitorsReport_Photo_Check == true)
                {
                    var filePath = Path.Combine(@"App_Data/TCA_VMS_Photos/" + "Location-" + Convert.ToString(_vr.Base_Id) + "/" + dt + "/" + _vr.VisitorsReport_Photo?.FileName);
                    new FileInfo(filePath).Directory?.Create();
                    await using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        _logger.LogInformation($"Saving file [{_vr.VisitorsReport_Photo?.FileName}]");
                        await _vr.VisitorsReport_Photo!.CopyToAsync(stream);
                        _logger.LogInformation($"\t The uploaded file is saved as [{filePath}].");
                    }
                    if (System.IO.File.Exists(filePath))
                    {
                        var url = filePath;
                        if(_vr.VisitorsReport_Laptop == true)
                        {
                            if (_vr.VisitorsReport_Laptop_Brand?.Length > 0 && _vr.VisitorsReport_Laptop_Serial_Number?.Length > 0)
                            {
                                result = TCA_VMS_DAO.StoreVisitorsReport(_vr, url);
                                return Ok(result);
                            }
                            else
                            {
                                result.Message = "Campos incompletos.";
                                result.State = 400;
                                return BadRequest(result);
                            }
                        }
                        else
                        {
                            result = TCA_VMS_DAO.StoreVisitorsReport(_vr, url);
                            return Ok(result);
                        }
                    }
                    else
                    {
                        result.Message = "No se logro subir el archivo.";
                        result.State = 400;
                        return BadRequest(result);
                    }
                }
                else
                {
                    var filePath = Path.Combine(@"App_Data/TCA_VMS_Photos/" + "NotImage/" + "not-found.jpg");
                    if (System.IO.File.Exists(filePath))
                    {
                        var url = filePath;
                        if (_vr.VisitorsReport_Laptop == true)
                        {
                            if (_vr.VisitorsReport_Laptop_Brand?.Length > 0 && _vr.VisitorsReport_Laptop_Serial_Number?.Length > 0)
                            {
                                result = TCA_VMS_DAO.StoreVisitorsReport(_vr, url);
                                return Ok(result);
                            }
                            else
                            {
                                result.Message = "Campos incompletos.";
                                result.State = 400;
                                return BadRequest(result);
                            }
                        }
                        else
                        {
                            result = TCA_VMS_DAO.StoreVisitorsReport(_vr, url);
                            return Ok(result);
                        }
                    }
                    else
                    {
                        result.Message = "No se logro subir el archivo.";
                        result.State = 400;
                        return BadRequest(result);
                    }
                }
            }
            else
            {
                result.Message = "Campos incompletos.";
                result.State = 400;
                return BadRequest(result);
            }
        }



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
