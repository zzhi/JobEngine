
using System.Collections.Generic;
using Newtonsoft.Json;
namespace Model.IELess
{
    public class DATA
    {
        public int ERRCODE { get; set; }

        public string ImageText { get; set; }
        public byte[] PCODE { get; set; }
        public List<CARD> CARD { get; set; }
        ///<summary>
        ///用户名
        ///</summary>
        public string UserName { get; set; }

        public DATA()
        {
            ERRCODE = 0;
            CARD = new List<CARD>();
        }
    }

    public class CARD
    {
        /// <summary>
        /// 卡号
        /// </summary>
        public string NO { get; set; }
        public string cType { get; set; }
        /// <summary>
        /// 币种
        /// </summary>
        public string MONEYUNIT { get; set; }

        /// <summary>
        /// 流水明细
        /// </summary>
        [JsonProperty(PropertyName = "ITEM")]
        public List<ITEM> DETAIL { get; set; }

        /// <summary>
        /// 开户网点
        /// </summary>
        public string OpenAccount { get; set; }

        /// <summary>
        /// 当前余额
        /// </summary>
        public string CURBALENCE { get; set; }
        /// <summary>
        /// 信用额度
        /// </summary>
        public string ctLimit { get; set; }

        public CARD()
        {
            NO = "";
            MONEYUNIT = "";
            OpenAccount = string.Empty;
            CURBALENCE = "";
            DETAIL = new List<ITEM>();
        }
    }

    public class ITEM
    {
        public string DATE { get; set; } // 交易日期

        public string TIME { get; set; } // 交易时间

        public string TradeAmount { get; set; }

        public int TradeType { get; set; } // 支出

        public string BALANCE { get; set; } // 余额

        public string COMMENT { get; set; } // 交易说明

        /// <summary>
        /// 对方账户
        /// </summary>
        public string ReciprocalAccount { get; set; } // 对方账户

        /// <summary>
        /// 对方账户名
        /// </summary>
        public string ReciprocalAccountName { get; set; } // 对方账户名

        public ITEM()
        {
            DATE = "";
            TIME = "";
            TradeAmount = "";
            BALANCE = "";
            COMMENT = "";

        }
    }
}
