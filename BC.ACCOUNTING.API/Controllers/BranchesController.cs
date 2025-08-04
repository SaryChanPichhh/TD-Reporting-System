using BC.ACCOUNTING.API.Helper;
using BC.ACCOUNTING.API.Models;
using BC.ACCOUNTING.APPLICATION.Interfaces.General;
using BC.ACCOUNTING.CORE.DTO.General;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;
using System.Net;
using BC.ACCOUNTING.CORE.Entities;
using BC.ACCOUNTING.LOGGING;

namespace BC.ACCOUNTING.API.Controllers
{
    [Helper.Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BranchesController : ControllerBase
    {
        #region ===[ Private Members ]=============================================================

        private readonly IUnitOfWork _unitOfWork;
        private readonly AppSettings _appSettings;

        #endregion

        #region ===[ Constructor ]=================================================================
        public BranchesController(IUnitOfWork unitOfWork, IOptions<AppSettings> appSettings)
        {
            this._unitOfWork = unitOfWork;
            this._appSettings = appSettings.Value;
        }
        #endregion

        #region ===[ Public Methods ]==============================================================
        [AllowAnonymous]
        [HttpGet("dbcodes")]
        public async Task<ApiResponse<List<BranchDTO>>> GetLoginBranch([FromQuery] string username, string appCode)
        {
            var apiResponse = new ApiResponse<List<BranchDTO>>();

            try
            {
                var data = await _unitOfWork.Branches.GetLoginBranchAsync(username, appCode);
                if (!data.Any())
                {
                    apiResponse.Success = true;
                    apiResponse.Message = "No branches";
                    apiResponse.StatusCode = (int)HttpStatusCode.BadRequest;
                    apiResponse.Result = new List<BranchDTO>();
                    return apiResponse;
                }

                apiResponse.Success = true;
                apiResponse.Message = "Branches fetched successfully.";
                apiResponse.StatusCode = (int)HttpStatusCode.OK;
                apiResponse.Result = data.ToList();
            }
            catch (SqlException ex)
            {
                apiResponse.Success = false;
                apiResponse.Message = ex.Message;
                apiResponse.StatusCode = (int)HttpStatusCode.InternalServerError;
                Logger.Instance.Error("SQL Exception:", ex);
            }
            catch (Exception ex)
            {
                apiResponse.Success = false;
                apiResponse.Message = ex.Message;
                apiResponse.StatusCode = (int)HttpStatusCode.InternalServerError;
                Logger.Instance.Error("Exception:", ex);
            }

            return apiResponse;
        }

        [HttpGet("")]
        public async Task<ApiResponse<List<Branch>>> GetAllBranchesAsync()
        {
            var apiResponse = new ApiResponse<List<Branch>>();

            try
            {
                var data = await _unitOfWork.Branches.GetAllAsync();
                if (!data.Any())
                {
                    apiResponse.Success = true;
                    apiResponse.Message = "No branches";
                    apiResponse.StatusCode = (int)HttpStatusCode.BadRequest;
                    apiResponse.Result = new List<Branch>();
                    return apiResponse;
                }

                apiResponse.Success = true;
                apiResponse.Message = "Branches fetched successfully.";
                apiResponse.StatusCode = (int)HttpStatusCode.OK;
                apiResponse.Result = data.ToList();
            }
            catch (SqlException ex)
            {
                apiResponse.Success = false;
                apiResponse.Message = ex.Message;
                apiResponse.StatusCode = (int)HttpStatusCode.InternalServerError;
                Logger.Instance.Error("SQL Exception:", ex);
            }
            catch (Exception ex)
            {
                apiResponse.Success = false;
                apiResponse.Message = ex.Message;
                apiResponse.StatusCode = (int)HttpStatusCode.InternalServerError;
                Logger.Instance.Error("Exception:", ex);
            }

            return apiResponse;
        }
        [HttpPost("")]
        public async Task<ApiResponse<int>> CreateBranchesAsync([FromBody] Branch branch)
        {
            var apiResponse = new ApiResponse<int>();

            try
            {
                var data = await _unitOfWork.Branches.AddAsync(branch);
                if (data < 1)
                {
                    apiResponse.Success = true;
                    apiResponse.Message = "No branches";
                    apiResponse.StatusCode = (int)HttpStatusCode.BadRequest;
                    apiResponse.Result = data;
                    return apiResponse;
                }

                apiResponse.Success = true;
                apiResponse.Message = "Branches created successfully.";
                apiResponse.StatusCode = (int)HttpStatusCode.OK;
                apiResponse.Result = data;
            }
            catch (SqlException ex)
            {
                apiResponse.Success = false;
                apiResponse.Message = ex.Message;
                apiResponse.StatusCode = (int)HttpStatusCode.InternalServerError;
                Logger.Instance.Error("SQL Exception:", ex);
            }
            catch (Exception ex)
            {
                apiResponse.Success = false;
                apiResponse.Message = ex.Message;
                apiResponse.StatusCode = (int)HttpStatusCode.InternalServerError;
                Logger.Instance.Error("Exception:", ex);
            }

            return apiResponse;
        }

        //[HttpGet("")]
        //public async Task<ApiResponse<List<Branch>>> GetAllBranches()
        //{
        //    var apiResponse = new ApiResponse<List<Branch>>();

        //    try
        //    {
        //        var data = await _unitOfWork.Branches.GetAllAsync();
        //        if (!data.Any())
        //        {
        //            apiResponse.Success = true;
        //            apiResponse.Message = "No branches";
        //            apiResponse.StatusCode = (int)HttpStatusCode.BadRequest;
        //            apiResponse.Result = new List<Branch>();
        //            return apiResponse;
        //        }

        //        apiResponse.Success = true;
        //        apiResponse.Message = "Branches fetched successfully.";
        //        apiResponse.StatusCode = (int)HttpStatusCode.OK;
        //        apiResponse.Result = data.ToList();
        //    }
        //    catch (SqlException ex)
        //    {
        //        apiResponse.Success = false;
        //        apiResponse.Message = ex.Message;
        //        apiResponse.StatusCode = (int)HttpStatusCode.InternalServerError;
        //        Logger.Instance.Error("SQL Exception:", ex);
        //    }
        //    catch (Exception ex)
        //    {
        //        apiResponse.Success = false;
        //        apiResponse.Message = ex.Message;
        //        apiResponse.StatusCode = (int)HttpStatusCode.InternalServerError;
        //        Logger.Instance.Error("Exception:", ex);
        //    }

        //    return apiResponse;
        //}
        #endregion
    }
}
