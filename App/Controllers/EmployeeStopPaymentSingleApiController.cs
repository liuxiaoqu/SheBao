﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Common;
using Langben.BLL;
using Langben.DAL;
using Langben.IBLL;
using Models;

namespace Langben.App.Controllers
{
    public class EmployeeStopPaymentSingleApiController : BaseApiController
    {
        /// <summary>
        /// 异步加载数据
        /// </summary>
        /// <param name="getParam"></param>
        /// <returns></returns>
        public Common.ClientResult.DataResult PostData([FromBody]GetDataParam getParam)
        {
            int total = 0;

            List<SingleStopPaymentView> queryData = m_BLL.GetSingleStopPaymentInfo(LoginInfo.UserID, getParam.page, getParam.rows, getParam.search, ref total);
            var data = new Common.ClientResult.DataResult
            {
                total = total,
                rows = queryData.Select(s => new SingleStopPaymentView()
                {
                    CompanyID = s.CompanyID,
                    CompanyName = s.CompanyName,
                    EmployeeID = s.EmployeeID,
                    EmployeeName = s.EmployeeName,
                    CertificateNumber = s.CertificateNumber,
                    CanSotpInsuranceKindName = s.CanSotpInsuranceKindName,
                    EmployeeAddId = s.EmployeeAddId,
                    CompanyEmployeeRelationId = s.CompanyEmployeeRelationId,
                    CityName = s.CityName,
                    YearMonth = s.YearMonth,

                })
            };
            return data;
        }
        [HttpPost]
        public List<CRM_Company> PostCompanyData()
        {
            IBLL.ICRM_CompanyBLL compBll = new CRM_CompanyBLL();

            return compBll.GetCompanyDateForZrUser(LoginInfo.UserID);
        }

        /// <summary>
        /// 根据ID获取数据模型
        /// </summary>
        /// <param name="id">企业员工编号</param>
        /// <returns></returns>
        public StopPaymentEmployeeInfo Get(int id)
        {
            StopPaymentEmployeeInfo item = m_BLL.GetStopPaymentEmployeeInfo(id);
            return item;
        }

        public Common.ClientResult.DataResult PostPoliceOperation(int kindId)
        {
            IInsuranceKindBLL kindBll = new InsuranceKindBLL();
            List<PoliceOperation> items = kindBll.GetRefPoliceOperationForStop(kindId);
            var data = new Common.ClientResult.DataResult
            {
                rows = items.Select(s => new
                {
                    ID = s.Id,
                    Name = s.Name
                })
            };
            return data;

        }

        /// <summary>
        /// 创建
        /// </summary>
        /// <param name="entity">实体对象</param>
        /// <returns></returns>
        public Common.ClientResult.Result Post(string parameters)
        {

            Common.ClientResult.Result result = new Common.ClientResult.Result();
            if (!string.IsNullOrEmpty(parameters))
            {
                List<EmployeeStopPaymentSingle> list = new List<EmployeeStopPaymentSingle>();
                string[] kinds = parameters.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (string kind in kinds)
                {
                    string[] param = kind.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);//EmployeeAddID,社保月,报减类型,报减自然月,险种，政策,企业员工关系

                    // 获取报增信息，判断是否为供应商的，若为供应商的，则状态设为“待供应商客服提取”
                    IBLL.IEmployeeAddBLL add_bll = new EmployeeAddBLL();
                    EmployeeAdd employeeAddModel = add_bll.GetById(Convert.ToInt32(param[0]));  // param[0]为EmployeeAddId
                    string stopStatus = employeeAddModel.SuppliersId == null ? EmployeeStopPayment_State.待员工客服确认.ToString() : EmployeeStopPayment_State.待供应商客服提取.ToString();

                    EmployeeStopPaymentSingle single = new EmployeeStopPaymentSingle()
                    {
                        InsuranceKindId = Convert.ToInt32(param[4]),
                        PoliceInsuranceId = Convert.ToInt32(param[5]),
                        CompanyEmployeeRelationId = Convert.ToInt32(param[6]),
                        StopPayment = new EmployeeStopPayment()
                        {
                            EmployeeAddId = Convert.ToInt32(param[0]),
                            InsuranceMonth = Convert.ToDateTime(param[1] + "-01"),
                            PoliceOperationId = Convert.ToInt32(param[2]),
                            //State = EmployeeStopPayment_State.待员工客服确认.ToString(),
                            State = stopStatus,
                            YearMonth = Convert.ToInt32(param[3].Replace("-", "")),
                            CreateTime = DateTime.Now,
                            CreatePerson = LoginInfo.UserName,
                            UpdateTime = DateTime.Now,
                            UpdatePerson = LoginInfo.UserName,
                        },
                    };
                    list.Add(single);
                }


                //string currentPerson = GetCurrentPerson();
                //entity.CreateTime = DateTime.Now;
                //entity.CreatePerson = currentPerson;


                string returnValue = string.Empty;
                if (m_BLL.InsertStopPayment(list))
                {
                    //LogClassModels.WriteServiceLog(Suggestion.InsertSucceed + "，员工停缴的信息的Id为" + entity.Id, "员工停缴");//写入日志 
                    result.Code = Common.ClientCode.Succeed;
                    result.Message = Suggestion.InsertSucceed;
                    return result; //提示创建成功
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
                    LogClassModels.WriteServiceLog(Suggestion.InsertFail + "，员工停缴的信息，" + returnValue, "员工停缴");//写入日志                      
                    result.Code = Common.ClientCode.Fail;
                    result.Message = Suggestion.InsertFail + returnValue;
                    return result; //提示插入失败
                }
            }

            result.Code = Common.ClientCode.FindNull;
            result.Message = Suggestion.InsertFail + "，请核对输入的数据的格式"; //提示输入的数据的格式不对 
            return result;
        }

        // PUT api/<controller>/5
        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>  
        public Common.ClientResult.Result Put([FromBody]EmployeeStopPayment entity)
        {
            Common.ClientResult.Result result = new Common.ClientResult.Result();
            if (entity != null && ModelState.IsValid)
            {   //数据校验

                //string currentPerson = GetCurrentPerson();
                //entity.UpdateTime = DateTime.Now;
                //entity.UpdatePerson = currentPerson;

                string returnValue = string.Empty;
                if (m_BLL.Edit(ref validationErrors, entity))
                {
                    LogClassModels.WriteServiceLog(Suggestion.UpdateSucceed + "，员工停缴信息的Id为" + entity.Id, "员工停缴"
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
                    LogClassModels.WriteServiceLog(Suggestion.UpdateFail + "，员工停缴信息的Id为" + entity.Id + "," + returnValue, "员工停缴"
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

        // DELETE api/<controller>/5
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="collection"></param>
        /// <returns></returns>  
        public Common.ClientResult.Result Delete(string query)
        {
            Common.ClientResult.Result result = new Common.ClientResult.Result();

            string returnValue = string.Empty;
            int[] deleteId = Array.ConvertAll<string, int>(query.Split(','), delegate(string s) { return int.Parse(s); });
            if (deleteId != null && deleteId.Length > 0)
            {
                if (m_BLL.DeleteCollection(ref validationErrors, deleteId))
                {
                    LogClassModels.WriteServiceLog(Suggestion.DeleteSucceed + "，信息的Id为" + string.Join(",", deleteId), "消息"
                        );//删除成功，写入日志
                    result.Code = Common.ClientCode.Succeed;
                    result.Message = Suggestion.DeleteSucceed;
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
                    LogClassModels.WriteServiceLog(Suggestion.DeleteFail + "，信息的Id为" + string.Join(",", deleteId) + "," + returnValue, "消息"
                        );//删除失败，写入日志
                    result.Code = Common.ClientCode.Fail;
                    result.Message = Suggestion.DeleteFail + returnValue;
                }
            }
            return result;
        }

        IBLL.IEmployeeStopPaymentBLL m_BLL;

        ValidationErrors validationErrors = new ValidationErrors();

        public EmployeeStopPaymentSingleApiController()
            : this(new EmployeeStopPaymentBLL()) { }

        public EmployeeStopPaymentSingleApiController(EmployeeStopPaymentBLL bll)
        {
            m_BLL = bll;
        }


    }
}
