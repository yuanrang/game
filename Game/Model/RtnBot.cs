using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Game.Model
{
    public class RtnBot
    {
        /// <summary>
        /// 语言信息
        /// </summary>
        public List<RtnUlang> Ulangs { get; set; } = new List<RtnUlang>();
        /// <summary>
        /// 公开键盘展示的语言详情分类的数据
        /// </summary>
        public List<RtnULangDetails> UlangPublic { get; set; }=new List<RtnULangDetails>();
        /// <summary>
        /// 个人中心的语言详情分类的数据
        /// </summary>
        public List<RtnULangDetails> UlangGRZX { get; set; } = new List<RtnULangDetails>();

    }
    public class RtnUlang
    {
        /// <summary>
        /// 语言id
        /// </summary>
        public int UlangId { get; set; }
        public int IsVaild { get; set; }

        /// <summary>
        /// 语言名称 列 中文 英文
        /// </summary>
        public string UlangName { get; set; }
    }
    public class RtnULangDetails
    {
        /// <summary>
        /// 语言详情id
        /// </summary>
        public string ULangDetailsId { get; set; }
        public int IsVaild { get; set; }

        /// <summary>
        /// 语言详情名称
        /// </summary>
        public string ULangDetailsName { get; set; }
    }

    public class RtnCreateBot:RtnBot
    {
        [Required(ErrorMessage = "Token Not Null")]
        public string BotToken { get; set; }
        [Required(ErrorMessage = "Name Not Null")]
        public string BotName { get; set; }
        [Required(ErrorMessage = "OpenId Not Null")]
        public string OpenId { get; set; }
        [Required(ErrorMessage = "Address Not Null")]

        public string UnBindHashAddress { get; set; }
    }
    public class RtnCreateBots
    {
        [Required(ErrorMessage = "Token Not Null")]
        public string BotToken { get; set; }
        [Required(ErrorMessage = "Name Not Null")]
        public string BotName { get; set; }
        [Required(ErrorMessage = "OpenId Not Null")]
        public string OpenId { get; set; }
        [Required(ErrorMessage = "Address Not Null")]

        public string UnBindHashAddress { get;set; }
        public string ShopName { get; set; }
        public int Id { get; set; }
    }
    
}
