using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// 银行及账户信息
    /// </summary>
    public class BankInfo
    {

        public int Id { get; set; }
        public string BankName { get; set; }
        public List<UserInfo> UserInfos { get; set; }
        /// <summary>
        /// 是否测试(1,是;0,不测试)
        /// </summary>
        public string IsTest { get; set; }

        public BankInfo()
        {
            UserInfos = new List<UserInfo>();
            IsTest = "0";
        }
    }

    /// <summary>
    /// 账户信息
    /// </summary>
    public class UserInfo
    {
        public string CardNo { get; set; }
        public string CardPwd { get; set; }
        /// <summary>
        /// 是否测试(1,是;0,不测试)
        /// </summary>
        public string IsTest { get; set; }
    }

    public class BankList
    {
        public static List<Bank> List = new List<Bank>()
        {
            new Bank() {Code = "ABC", Id = 0, Name = "农业银行"},
            new Bank() {Code = "ICBC", Id = 1, Name = "工商银行"},
            new Bank() {Code = "BOC", Id = 2, Name = "中国银行"},
            new Bank() {Code = "BCM", Id = 3, Name = "交通银行"},
            new Bank() {Code = "CMB", Id = 5, Name = "招商银行"},
            new Bank() {Code = "BOB", Id = 6, Name = "北京银行"},
            new Bank() {Code = "SPDB", Id = 7, Name = "浦发银行"},
            new Bank() {Code = "CMBC", Id = 8, Name = "民生银行"},
            new Bank() {Code = "PSBC", Id = 9, Name = "邮政储蓄"},
            new Bank() {Code = "CITIC", Id = 10, Name = "中信银行"},
            new Bank() {Code = "CEB", Id = 11, Name = "广大银行"},
            new Bank() {Code = "PAB", Id = 12, Name = "平安银行"},
            new Bank() {Code = "HXB", Id = 13, Name = "华夏银行"},
            new Bank() {Code = "CGB", Id = 14, Name = "广发银行"},
            new Bank() {Code = "CIB", Id = 15, Name = "兴业银行"},
            new Bank() {Code = "BOS", Id = 16, Name = "上海银行"}
        };
    }

    public class Bank
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
    }
}
