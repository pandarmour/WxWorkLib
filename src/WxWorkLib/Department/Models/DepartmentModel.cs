using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace WxWorkLib.Department.Models
{
    public class DepartmentModel
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "name_en")]
        public string NameEnglish { get; set; }

        [JsonProperty(PropertyName = "parentid")]
        public int ParentId { get; set; }

        [JsonProperty(PropertyName = "order")]
        public int Order { get; set; }
    }
}
