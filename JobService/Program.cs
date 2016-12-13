#region License

/* 
 * Copyright 2009- Marko Lahma
 * 
 * Licensed under the Apache License, Version 2.0 (the "License"); you may not 
 * use this file except in compliance with the License. You may obtain a copy 
 * of the License at 
 * 
 *   http://www.apache.org/licenses/LICENSE-2.0 
 *   
 * Unless required by applicable law or agreed to in writing, software 
 * distributed under the License is distributed on an "AS IS" BASIS, WITHOUT 
 * WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. See the 
 * License for the specific language governing permissions and limitations 
 * under the License.
 * 
 */

#endregion

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using System.Text;
using Quartz.Logging;
using Microsoft.Extensions.Configuration;
using Model;
using Serilog;

namespace JobService
{
    /// <summary>
    /// Console main runner.
    /// </summary>
    /// <author>Marko Lahma</author>
    public class Program
    {
        public static void Main()
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);//编码

            #region 配置文件
            var builder  = new ConfigurationBuilder().AddJsonFile("config.json");
            var configuration = builder.Build();
            GetConfig(configuration);
            #endregion

            #region 日志
            Log.Logger = new LoggerConfiguration()
              .MinimumLevel.Debug()//等级
              .WriteTo.LiterateConsole()//写到控制台
              .WriteTo.RollingFile("logs\\{Date}.txt")//写到文本
              .CreateLogger();
            #endregion
            try
            {
               
                SchedulerService service = new SchedulerService();
                service.Run().Wait();
                Log.Information("Service run successfully.");
            }
            catch (Exception ex)
            {
                Log.Information("Error: " + ex.Message);
            }
            Console.Read();
        }
         /// <summary>
        /// 获取配置信息
        /// </summary>
        /// <param name="configuration"></param>
        private static void GetConfig(IConfigurationRoot configuration)
        {
            //银行及登录信息
            Model.Config.Banks = new List<Model.BankInfo>();
            var Infos = configuration.GetSection("BankInfo");
            var BankList = Infos.GetChildren();
            foreach (var bank in BankList)
            {
                BankInfo b = new BankInfo();
                b.Id= int.Parse(bank.Key);
                b.BankName = bank["BankName"];
                b.IsTest = bank["IsTest"];
                var users = bank["UserInfo"].Split('|');
                for (int i = 0; i < users.Length; i++)
                {
                    var userInfoStr = users[i].Split(',');
                    var userInfo = new UserInfo
                    {
                        CardNo = userInfoStr[0],
                        CardPwd = userInfoStr[1],
                        IsTest = userInfoStr[2],
                    };
                    b.UserInfos.Add(userInfo);
                }
                Model.Config.Banks.Add(b);
            }
            //服务器地址
            Model.Config.IELessServer = String.IsNullOrEmpty(configuration["IELessServer"]) ? "127.0.0.1:8088" : configuration["IELessServer"];

        }


    }
}