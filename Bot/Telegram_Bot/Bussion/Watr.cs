using Game.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace Telegram_Bot.Bussion
{
    internal class Watr
    {
        private static object locks = new object();
        private readonly Send.SendMessage send;

        public Watr()
        {
            if (send == null)
            {
                lock (locks)
                {
                    if (send == null)
                        send = new Send.SendMessage();
                }
            }
        }
        public async Task GetMeWatr(SqlSugar.SqlSugarScope db, ReplyKeyboardMarkup markup ,ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            var _info = db.Queryable<UserInfo>().ToList();
            var my = _info.Where(x => x.UserName == update.Message.Chat.Id.ToString()).FirstOrDefault();
            StringBuilder str = new StringBuilder();
            if (my == null) str.Append("Error");
            else
            {
                List<UserInfo> _infolist = new List<UserInfo>();
                TreeInfo(_info, my.PassportId, ref _infolist);
                //var bets = db.Queryable<Bet>().Where(x => x.BetResult != 2&&x.AddTime>=DateTime.Today.AddDays(-1)
                //&& _infolist.Select(d => d.PassportId).Contains(x.PassportId)).ToList();

                var bets = db.Queryable<Bet>().LeftJoin<RechargeCashOrder>((c, v) =>
                c.OrderID == "R" + v.OrderID.ToString().Replace("BET", ""))
                    .Where((c, v) => c.AddTime >= DateTime.Today.AddDays(-1)
                    && _infolist.Select(d => d.PassportId).Contains(c.PassportId))
                    .Select((c, v) => new {
                        GameDetailsId = c.GameDetailsId,
                        AddDatetime = c.AddTime,
                        CoinNumber = v.CoinNumber,
                        CoinType = v.CoinType,
                        RCType = v.RCType
                    }).ToList().GroupBy(x => x.AddDatetime.Date).OrderBy(x => x.Key).ToList();
                var game = db.Queryable<GameDetails>().ToList();
                int i = 0;
                str.Append("代理人数: ");
                str.Append(_infolist.Count);
                str.Append("人 \n");
                str.Append("今日新增代理");
                str.Append(_infolist.Where(x => x.AddTime >= DateTime.Today).Count());
                str.Append("人 \n");
                bets.ForEach(x =>
                {
                    game.ForEach(d =>
                    {
                        //游戏流水 Usdt
                        var usdtY = x.ToList().Where(s => s.GameDetailsId == d.Id && s.CoinType == 0 && s.RCType == 0).Sum(s => s.CoinNumber);
                        var trxY = x.ToList().Where(s => s.GameDetailsId == d.Id && s.CoinType == 1 && s.RCType == 0).Sum(s => s.CoinNumber);
                        str.Append((i == 0) ? "昨日" : "今日");
                        str.Append(d.GameName + "流水: ");
                        str.Append(usdtY + "U、" + trxY + "TRX \n ");
                        //游戏盈利
                        var usdtN = usdtY - (x.ToList().Where(s => s.GameDetailsId == d.Id && s.CoinType == 0 && s.RCType == 1).Sum(s => s.CoinNumber));
                        var TRXN = trxY - ((x.ToList().Where(s => s.GameDetailsId == d.Id && s.CoinType == 1 && s.RCType == 1).Sum(s => s.CoinNumber)));
                        str.Append((i == 0) ? "昨日" : "今日");
                        str.Append(d.GameName + "盈利: ");
                        str.Append(usdtN + "U、" + TRXN + "TRX \n\n\n ");
                    });
                    i++;
                });
                if (!str.ToString().Contains("昨日"))
                {
                    game.ForEach(x =>
                    {
                        str.Append("昨日");
                        str.Append(x.GameName + "流水: ");
                        str.Append( "0U、0TRX \n ");
                        str.Append( "今日");
                        str.Append(x.GameName + "盈利: ");
                        str.Append("0U、0TRX \n\n\n ");
                    });
                }
            }
           await send.SendUsTextMessageAsync(str.ToString(), botClient, update, cancellationToken,markup);
        }

        private void TreeInfo(List<UserInfo> list, long PassportId, ref List<UserInfo> infos)
        {
            var result = list.Where(x => x.ParentId == PassportId).ToList();
            foreach (var item in result)
            {
                TreeInfo(list, item.PassportId, ref infos);
                infos.Add(item);
            }
        }

        internal async void GetReta(SqlSugar.SqlSugarScope db, ReplyKeyboardMarkup markup, ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            StringBuilder str = new StringBuilder();
            var _info = db.Queryable<UserInfo>().ToList();
            var my = _info.Where(x => x.UserName == update.Message.Chat.Id.ToString()).FirstOrDefault();
            
            var lv1 = _info.Where(x => x.ParentId == my.PassportId).ToList();
            var lv2 = _info.Where(d => lv1.Select(x => x.PassportId).Contains(d.ParentId)).ToList();
            var rate = db.Queryable<RebateDetails>().Where(x=>x.PassportId==my.PassportId).ToList();

            var lv_ra1 = rate.Where(x => lv1.Select(d => d.PassportId).Contains(x.BetPassportId)).ToList();
            var lv_ra2 = rate.Where(x => lv2.Select(d => d.PassportId).Contains(x.BetPassportId)).ToList();
            str.Append("一级推广" + lv1.Count + "人，佣金比例0.8% \n");
            str.Append("共下注"+lv_ra1.Sum(x=>x.BetAmount)+"USDT,获得佣金");
            str.Append(lv_ra1.Sum(x => x.RebateAmount)+"USDT \n\n");
            str.Append("二级推广"+lv2.Count+"人，佣金比例0.2% \n");
            str.Append("共下注"+lv_ra2.Sum(x=>x.BetAmount)+"USDT,获得佣金");
            str.Append(lv_ra2.Sum(x => x.RebateAmount) + "USDT \n\n");
            str.Append("--------------------------------------------- \n");
            str.Append("佣金总金额："+rate.Sum(x=>x.RebateAmount)+"USDT \n");
            str.Append("已提现金额："+rate.Where(x=>x.CalculationState==1).Sum(x=>x.RebateAmount)+"USDT \n");
            var txp = rate.Sum(x => x.RebateAmount) - (rate.Where(x => x.CalculationState == 1).Sum(x => x.RebateAmount));
            str.Append("待提现金额：" + txp+ "USDT");
            await send.SendNTextMessageAsync(str.ToString(), botClient, update, cancellationToken, markup);

        }
    }
}
