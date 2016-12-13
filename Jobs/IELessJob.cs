using Quartz;
using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Model;
using System.Text;
using System.Net.Http;
using System.Collections.Generic;
using Utility;
using Serilog;

namespace Jobs
{
    [DisallowConcurrentExecution]
    public class IELessJob : IJob
    {
        public Task Execute(IJobExecutionContext context)
        {
            List<BankInfo> banks = Model.Config.Banks;
            if (banks != null)
            {
                foreach (var bank in banks)
                {
                    if (bank.IsTest.Equals("0"))
                    {
                        continue;
                    }
                    var str = ((BankType)bank.Id).GetAttribute<BankTypeDescAttribute>().Description;
                    var userInfos = bank.UserInfos;
                    if (userInfos.Count > 0)
                    {
                        foreach (var userInfo in userInfos)
                        {
                            if (userInfo.IsTest.Equals("1")) //1,测试;0,不测试
                            {

                                run(bank, userInfo);
                            }
                        }
                    }
                    
                }
            }
            else
            {
                Log.Information("IELess:银行信息不存在。");
            }
            return Task.FromResult(0);
        }

        private void run(BankInfo bank, UserInfo userInfo)
        {
            var str = ((BankType)bank.Id).GetAttribute<BankTypeDescAttribute>().Description;
            try
            {
                var startTime = DateTime.Now.AddMonths(-3);
                var crawlId = Guid.NewGuid().ToString().Replace("-", "");
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(string.Format("http://{0}", Model.Config.IELessServer));
                    var content = new FormUrlEncodedContent(new[]
                    {
                         new KeyValuePair<string, string>("bankType", bank.Id.ToString()),
                         new KeyValuePair<string, string>("crawlId", crawlId),
                         new KeyValuePair<string, string>("cardNo", userInfo.CardNo),
                         new KeyValuePair<string, string>("cardPwd", userInfo.CardPwd),
                         new KeyValuePair<string, string>("queryDate", startTime.ToString("yyyyMMdd")),
                    });
                    var result = client.PostAsync("/login_auto", content).Result;
                    string resultContent = result.Content.ReadAsStringAsync().Result;
                    
                    Model.IELess.DATA d = JsonFormat.DeSerializerFromJson<Model.IELess.DATA>(resultContent);
                    if (d.ERRCODE == 0)
                    {
                        Log.Information(resultContent);
                    }
                    else if (d.ERRCODE == 4002)
                    {
                        Log.Information("需要短息");
                        //需要短信
                    }
                    else
                    {
                        Log.Information(str + "失败");
                    }
                }
            }
            catch (Exception ex)
            {
                var err = ex.Message;
                Log.Information(str + ":" + err);
            }
        }
    }
}
