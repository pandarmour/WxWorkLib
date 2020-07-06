using System;
using System.Collections.Generic;
using System.Text;
using WxWorkLib.Base;
using WxWorkLib.Department.Models;

namespace WxWorkLib.Department
{
    interface IClient
    {
        /// <summary>
        /// 创建部门
        /// </summary>
        DepartmentCreateResponseModel DepartmentCreate(DepartmentModel department);

        /// <summary>
        /// 更新部门
        /// </summary>
        ResponseBaseModel DepartmentUpdate(DepartmentModel department);

        /// <summary>
        /// 删除部门
        /// </summary>
        ResponseBaseModel DepartmentDelete(int id);

        /// <summary>
        /// 获取部门列表
        /// </summary>
        DepartmentListResponseModel DepartmentList(int? id = null);
    }
}
