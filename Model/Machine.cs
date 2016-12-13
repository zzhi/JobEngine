using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Model
{
    public class Machine
    {
        private string _ipOuter;
        /// <summary>
        /// 外网ip
        /// </summary>
        public string IpOuter { get { return _ipOuter; } }

        public string MachineName { get; set; }

        /// <summary>
        /// 内网ip
        /// </summary>
        public string IpInter { get; set; }

        private string _machineType;
        /// <summary>
        /// 机器所在的环境
        /// </summary>
        public string MachineType { get { return _machineType; } }
        /// <summary>
        /// 机器运行的服务
        /// </summary>
        public MachineService MachineService { get; set; }
        /// <summary>
        /// 支持的银行
        /// </summary>
        public List<IEBankType> BankTypeList { get; set; }

        public Machine(string ipOuter, string machineType)
        {
            _ipOuter = ipOuter;
            _machineType = machineType;
            MachineService = MachineService.BankService;
        }
    }

    public enum MachineService
    {
        /// <summary>
        /// 插件版爬虫
        /// </summary>
        BankService = 0,
        /// <summary>
        /// 脱离IE
        /// </summary>
        IeLess = 1,
    }
}
