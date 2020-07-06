using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using WxWorkLib.Base;

namespace WxWorkLib.Department.Models
{
    public class DepartmentCreateResponseModel : ResponseBaseModel
    {
        [JsonProperty(PropertyName = "id")]

        public int Id { get; set; }
    }

    public class DepartmentListResponseModel : ResponseBaseModel
    {
        [JsonProperty(PropertyName = "department")]

        public DepartmentModel[] Departments { get; set; }
    }
}
