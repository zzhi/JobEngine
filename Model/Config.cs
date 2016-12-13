using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;

namespace Model
{
    public class Config
    {
        /// <summary>
        /// 服务器信息
        /// </summary>
        public static String IELessServer;
        /// <summary>
        /// 银行信息
        /// </summary>
        public static List<BankInfo> Banks;
    }
}
