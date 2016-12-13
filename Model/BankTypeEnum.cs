using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// 银行枚举
    /// </summary>
    public enum BankType
    {
        /// <summary>
        /// 农业银行
        /// </summary>
        [BankTypeDesc("农业银行")]
        Abc = 0,

        /// <summary>
        /// 工商银行
        /// </summary>
        [BankTypeDesc("工商银行")]
        Icbc = 1,

        /// <summary>
        /// 中国银行
        /// </summary>
        [BankTypeDesc("中国银行")]
        Boc = 2,

        /// <summary>
        /// 交通银行
        /// </summary>
        [BankTypeDesc("交通银行")]
        Bcm = 3,

        /// <summary>
        /// 北京银行
        /// </summary>
        [BankTypeDesc("北京银行")]
        Bob = 6,

        /// <summary>
        /// 邮政储蓄
        /// </summary>
        [BankTypeDesc("邮政储蓄")]
        Psbc = 9,

        /// <summary>
        /// 中信银行
        /// </summary>
        [BankTypeDesc("中信银行")]
        Citic = 10,

        /// <summary>
        /// 光大银行
        /// </summary>
        [BankTypeDesc("光大银行")]
        Ceb = 11,

        /// <summary>
        /// 广发银行
        /// </summary>
        [BankTypeDesc("广发银行")]
        Cgb = 14

    }

    /// <summary>
    /// 
    /// </summary>
    public class BankTypeDescAttribute : Attribute
    {
        /// <summary>
        /// 描述
        /// </summary>
        public string Description { get; private set; }

        public BankTypeDescAttribute(string description)
        {
            this.Description = description;
        }
    }
    /// <summary>
    /// 插件版
    /// </summary>
    public enum IEBankType
    {
        /************************************************************************/
        /*                         借记卡                                       */
        /************************************************************************/
        BT_DT_ABC = 0,        // 农业银行
        BT_DT_ICBC = 1,        // 工商银行
        BT_DT_BOC = 2,        // 中国银行
        BT_DT_BCM = 3,        // 交通银行
        BT_DT_CCB = 4,        // 建设银行
        BT_DT_CMB = 5,        // 招商银行
        BT_DT_BOB = 6,        // 北京银行
        BT_DT_SPDB = 7,        // 浦发银行
        BT_DT_CMBC = 8,        // 民生银行
        BT_DT_PSBC = 9,        // 邮政储蓄
        BT_DT_CITIC = 10,       // 中信银行
        BT_DT_CEB = 11,       // 光大银行
        BT_DT_PAB = 12,       // 平安银行
        BT_DT_HXB = 13,       // 华夏银行
        BT_DT_CGB = 14,       // 广发银行
        BT_DT_CIB = 15,       // 兴业银行
        BT_DT_BOS = 16,       // 上海银行 


        /************************************************************************/
        /*                         信用卡                                       */
        /************************************************************************/
        BT_CT_ABC = 100,        // 农业银行
        BT_CT_ICBC = 101,        // 工商银行
        BT_CT_BOC = 102,        // 中国银行
        BT_CT_BCM = 103,        // 交通银行
        BT_CT_CCB = 104,        // 建设银行
        BT_CT_CMB = 105,        // 招商银行
        BT_CT_BOB = 106,        // 北京银行
        BT_CT_SPDB = 107,        // 浦发银行
        BT_CT_CMBC = 108,        // 民生银行
        BT_CT_PSBC = 109,        // 邮政储蓄
        BT_CT_CITIC = 110,        // 中信银行
        BT_CT_CEB = 111,        // 光大银行
        BT_CT_PAB = 112,        // 平安银行
        BT_CT_HXB = 113,        // 华夏银行
        BT_CT_CGB = 114,        // 广发银行
        BT_CT_CIB = 115,        // 兴业银行
        BT_CT_BOS = 116,        // 上海银行 
    }
}
