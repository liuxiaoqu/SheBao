﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Text;
using System.EnterpriseServices;
using System.Configuration;
using Models;
using Common;
using Langben.DAL;
using Langben.BLL;
using System.Web.Http;
using Langben.App.Models;

namespace Langben.App.Areas.CRM.Controllers
{
    /// <summary>
    /// 客户_企业财务信息
    /// </summary>
    public class CRM_CompanyFinance_PaymentApiController : BaseApiController
    {
        /// <summary>
        /// 异步加载数据
        /// </summary>
        /// <param name="getParam"></param>
        /// <returns></returns>
        public Common.ClientResult.DataResult PostData([FromBody]GetDataParam getParam)
        {
            int intBranchID = LoginInfo.BranchID;
            string strSearch = "";
            //strSearch += "BranchIDDDL_Int&" + intBranchID;
            strSearch += "CRM_Company_IDDDL_Int&" + getParam.search;

            List<CRM_CompanyFinance_Payment> queryData = m_BLL.GetByParam("", getParam.order, getParam.sort, strSearch);
            var data = new Common.ClientResult.DataResult
            {
                total = queryData.Count,
                rows = queryData.Select(s => new
                {
                    ID = s.ID
                    ,
                    CRM_Company_ID = s.CRM_Company_ID
                    ,
                    PaymentName = s.PaymentName
                    ,
                    CreateTime = s.CreateTime
                    ,
                    CreateUserID = s.CreateUserID
                    ,
                    CreateUserName = s.CreateUserName
                    ,
                    Status = s.Status
                    ,
                    BranchID = s.BranchID
                })
            };
            return data;
        }

        /// <summary>
        /// 根据ID获取数据模型
        /// </summary>
        /// <param name="id">编号</param>
        /// <returns></returns>
        public CRM_CompanyFinance_Payment Get(int id)
        {
            CRM_CompanyFinance_Payment item = m_BLL.GetById(id);
            return item;
        }

        /// <summary>
        /// 停用
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Common.ClientResult.Result Stop(int id)
        {
            Common.ClientResult.Result result = new Common.ClientResult.Result();
            if (ModelState.IsValid)
            {   //数据校验

                CRM_CompanyFinance_Payment item = m_BLL.GetById(id);

                item.Status = 0;//停用

                string returnValue = string.Empty;
                if (m_BLL.Edit(ref validationErrors, item))
                {
                    LogClassModels.WriteServiceLog(Suggestion.UpdateSucceed + "，客户_企业财务信息的Id为" + id, "客户_企业财务信息_停用"
                        );//写入日志                   
                    result.Code = Common.ClientCode.Succeed;
                    result.Message = Suggestion.UpdateSucceed;
                    return result; //提示更新成功 
                }
                else
                {
                    if (validationErrors != null && validationErrors.Count > 0)
                    {
                        validationErrors.All(a =>
                        {
                            returnValue += a.ErrorMessage;
                            return true;
                        });
                    }
                    LogClassModels.WriteServiceLog(Suggestion.UpdateFail + "，客户_企业财务信息的Id为" + id + "," + returnValue, "客户_企业财务信息_停用"
                        );//写入日志   
                    result.Code = Common.ClientCode.Fail;
                    result.Message = Suggestion.UpdateFail + returnValue;
                    return result; //提示更新失败
                }
            }
            result.Code = Common.ClientCode.FindNull;
            result.Message = Suggestion.UpdateFail + "请核对输入的数据的格式";
            return result; //提示输入的数据的格式不对         
        }

        /// <summary>
        /// 启用
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Common.ClientResult.Result Start(int id)
        {
            Common.ClientResult.Result result = new Common.ClientResult.Result();
            if (ModelState.IsValid)
            {   //数据校验

                CRM_CompanyFinance_Payment item = m_BLL.GetById(id);

                item.Status = 1;//启用

                string returnValue = string.Empty;
                if (m_BLL.Edit(ref validationErrors, item))
                {
                    LogClassModels.WriteServiceLog(Suggestion.UpdateSucceed + "，客户_企业财务信息的Id为" + id, "客户_企业财务信息_启用"
                        );//写入日志                   
                    result.Code = Common.ClientCode.Succeed;
                    result.Message = Suggestion.UpdateSucceed;
                    return result; //提示更新成功 
                }
                else
                {
                    if (validationErrors != null && validationErrors.Count > 0)
                    {
                        validationErrors.All(a =>
                        {
                            returnValue += a.ErrorMessage;
                            return true;
                        });
                    }
                    LogClassModels.WriteServiceLog(Suggestion.UpdateFail + "，客户_企业财务信息的Id为" + id + "," + returnValue, "客户_企业财务信息_启用"
                        );//写入日志   
                    result.Code = Common.ClientCode.Fail;
                    result.Message = Suggestion.UpdateFail + returnValue;
                    return result; //提示更新失败
                }
            }
            result.Code = Common.ClientCode.FindNull;
            result.Message = Suggestion.UpdateFail + "请核对输入的数据的格式";
            return result; //提示输入的数据的格式不对         
        }

        IBLL.ICRM_CompanyFinance_PaymentBLL m_BLL;

        ValidationErrors validationErrors = new ValidationErrors();

        public CRM_CompanyFinance_PaymentApiController()
            : this(new CRM_CompanyFinance_PaymentBLL()) { }

        public CRM_CompanyFinance_PaymentApiController(CRM_CompanyFinance_PaymentBLL bll)
        {
            m_BLL = bll;
        }

    }
}


