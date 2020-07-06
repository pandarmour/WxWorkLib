using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using WxWorkLib.Base;
using WxWorkLib.Department;
using WxWorkLib.Department.Models;

namespace WxWorkLib
{
    public partial class WxWorkClient : IClient
    {
        public DepartmentCreateResponseModel DepartmentCreate(DepartmentModel department)
        {
            return HttpPost<DepartmentCreateResponseModel>(new GenericHttpPostRequestModel
            {
                Module = "department",
                Action = "create",
                Data = department,
            });
        }

        public ResponseBaseModel DepartmentDelete(int id)
        {
            return HttpGet<ResponseBaseModel>(new GenericHttpPostRequestModel
            {
                Module = "department",
                Action = "delete",
                Params = new { id },
            });
        }

        public DepartmentListResponseModel DepartmentList(int? id = null)
        {
            return HttpGet<DepartmentListResponseModel>(new GenericHttpGetRequestModel
            {
                Module = "department",
                Action = "list",
                Params = new { id },
            });
        }

        public ResponseBaseModel DepartmentUpdate(DepartmentModel department)
        {
            return HttpPost<ResponseBaseModel>(new GenericHttpPostRequestModel
            {
                Module = "department",
                Action = "update",
                Data = department,
            });
        }
    }
}
