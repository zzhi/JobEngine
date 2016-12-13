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
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);//����

            #region �����ļ�
            var builder  = new ConfigurationBuilder().AddJsonFile("config.json");
            var configuration = builder.Build();
            GetConfig(configuration);
            #endregion

            #region ��־
            Log.Logger = new LoggerConfiguration()
              .MinimumLevel.Debug()//�ȼ�
              .WriteTo.LiterateConsole()//д������̨
              .WriteTo.RollingFile("logs\\{Date}.txt")//д���ı�
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
        /// ��ȡ������Ϣ
        /// </summary>
        /// <param name="configuration"></param>
        private static void GetConfig(IConfigurationRoot configuration)
        {
            //���м���¼��Ϣ
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
            //��������ַ
            Model.Config.IELessServer = String.IsNullOrEmpty(configuration["IELessServer"]) ? "127.0.0.1:8088" : configuration["IELessServer"];

        }


    }
}