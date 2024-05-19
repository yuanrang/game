using Game.Common;
using Game.Model;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Game.Design
{
    internal abstract class AgentImp
    {
        protected AgentImp _next;
        protected static object _lock = new object();
        protected readonly FZ _requslt;
        public AgentImp()
        {
            if (_requslt == null)
                lock (_lock)
                    _requslt = new FZ();
        }
        public abstract void TZJL(List<Bet> list, EventHK item, List<EventRules> rules, SqlSugar.ISqlSugarClient db, ref (EventBet, EventDetails) nb);
    }

    internal class Eve0 : AgentImp
    {
        public Eve0()
        {
            if (base._next == null)
                lock (_lock)
                    base._next = new Eve1();
        }

        public override void TZJL(List<Bet> list, EventHK item, List<EventRules> rules, SqlSugar.ISqlSugarClient db, ref (EventBet, EventDetails) nb)
        {
            if (item.RulesType == 0)
            {
                decimal i = 0;
                bool status = true;
                var evbet = db.Queryable<EventBet>().Where(x => x.Guid == item.GUID && x.PassportId == list.FirstOrDefault().PassportId).ToList().OrderByDescending(x => x.AddTime).FirstOrDefault();
                list = list.WhereIF(evbet != null, x => x.AddTime >= evbet.AddTime).ToList();
                if (list.Count == 0) return;
                if (base._requslt.IsJy(list.FirstOrDefault().PassportId, item, db))
                {
                    ///统计连胜
                    foreach (var x in list)
                    {
                        if (x.BetResult == 1)
                            i++;
                        else
                        {
                            status = false;

                            break;
                        }
                    }
                    int ruleid = 0;
                    if (status)
                    {
                        if (evbet != null)
                        {
                            i += rules.Where(x => x.Id == evbet.RulesId && x.Guid == evbet.Guid).FirstOrDefault().BetAmount;
                            ruleid = evbet.RulesId;
                        }
                    }
                    foreach (var d in rules.OrderByDescending(a => a.BetAmount))
                    {
                        if (ruleid == d.Id) break;
                        if (d.BetAmount <= i)
                        {
                            base._requslt.fzmodl(item.GUID, list.FirstOrDefault().PassportId, d.Id, list.FirstOrDefault().ManageUserPassportId, d.Reward, item.IsAudit == 0 ? 1 : 0, db, ref nb);
                            break;
                        };
                    }
                }

            }
            else
            {
                base._next.TZJL(list, item, rules, db, ref nb);
            }
        }
    }
    internal class Eve1 : AgentImp
    {
        public Eve1()
        {
            if (base._next == null)
                lock (_lock)
                    base._next = new Eve2();
        }

        public override void TZJL(List<Bet> list, EventHK item, List<EventRules> rules, SqlSugar.ISqlSugarClient db, ref (EventBet, EventDetails) nb)
        {
            if (item.RulesType == 1)
            {

                if (base._requslt.IsJy(list.FirstOrDefault().PassportId, item, db))
                {
                    decimal price = default;
                    var d = db.Queryable<EventBet>().Where(d => d.Guid == item.GUID && d.PassportId == list.FirstOrDefault().PassportId).ToList().OrderByDescending(x => x.AddTime).FirstOrDefault();
                    int rulesid = d != null ? d.RulesId : 0;
                    foreach (var it in rules.OrderByDescending(d => d.BetAmount))
                    {
                        if (rulesid == it.Id) break;
                        if (list.Sum(d => d.BetCoin) >= it.BetAmount) _requslt.fzmodl(item.GUID, list.First().PassportId, it.Id, list.First().ManageUserPassportId == 0 ? 502423741 : list.First().ManageUserPassportId, it.Reward, item.IsAudit == 0 ? 1 : 0, db, ref nb);
                        break;
                    }
                }

            }
            else
            {
                base._next.TZJL(list, item, rules, db, ref nb);
            }
        }
    }
    internal class Eve2 : AgentImp
    {
        public Eve2()
        {
            if (base._next == null)
                lock (_lock)
                    base._next = new Eve3();
        }

        public override void TZJL(List<Bet> list, EventHK item, List<EventRules> rules, SqlSugar.ISqlSugarClient db, ref (EventBet, EventDetails) nb)
        {
            if (item.RulesType == 2)
            {
                if (base._requslt.IsJy(list.FirstOrDefault().PassportId, item, db))
                {
                    var d = db.Queryable<EventBet>().Where(d => d.Guid == item.GUID && d.PassportId == list.FirstOrDefault().PassportId).ToList().OrderByDescending(x => x.AddTime).FirstOrDefault();
                    int rulesid = d != null ? d.RulesId : 0;
                    foreach (var it in rules.OrderByDescending(d => d.BetAmount))
                    {
                        if (rulesid == it.Id) break;
                        if (list.Where(d => d.BetResult == 0).Sum(d => d.BetCoin) >= it.BetAmount)
                        {
                            _requslt.fzmodl(item.GUID, list.First().PassportId, it.Id, list.First().ManageUserPassportId == 0 ? 502423741 : list.First().ManageUserPassportId, it.Reward, item.IsAudit == 0 ? 1 : 0, db, ref nb);
                            break;
                        }

                    }
                }
            }
            else
            {
                base._next.TZJL(list, item, rules, db, ref nb);
            }
        }
    }
    internal class Eve3 : AgentImp
    {


        public override void TZJL(List<Bet> list, EventHK item, List<EventRules> rules, SqlSugar.ISqlSugarClient db, ref (EventBet, EventDetails) nb)
        {
            if (item.RulesType == 3)
            {
                decimal i = 0;
                bool status = true;
                var evbet = db.Queryable<EventBet>().Where(x => x.Guid == item.GUID && x.PassportId == list.FirstOrDefault().PassportId).ToList().OrderByDescending(x => x.AddTime).FirstOrDefault();
                list = list.WhereIF(evbet != null, x => x.AddTime > evbet.AddTime).ToList();
                if (list.Count == 0) return;
                if (base._requslt.IsJy(list.FirstOrDefault().PassportId, item, db))
                {
                    ///统计连胜
                    foreach (var x in list)
                    {
                        if (x.BetResult == 0)
                            i++;
                        else
                        {
                            status = false;

                            break;
                        }
                    }
                    int ruleid = 0;
                    if (status)
                    {
                        if (evbet != null)
                        {
                            i += rules.Where(x => x.Id == evbet.RulesId && x.Guid == evbet.Guid).FirstOrDefault().BetAmount;
                            ruleid = evbet.RulesId;
                        }
                    }
                    foreach (var d in rules.OrderByDescending(a => a.BetAmount))
                    {
                        if (ruleid == d.Id) break;
                        if (d.BetAmount <= i)
                        {
                            base._requslt.fzmodl(item.GUID, list.FirstOrDefault().PassportId, d.Id, list.FirstOrDefault().ManageUserPassportId, d.Reward, item.IsAudit == 0 ? 1 : 0, db, ref nb);
                            break;
                        };
                    }
                }
            }

        }
    }
    internal class FZ
    {
        public void fzmodl(string guid, long passportId, int rulesid, long ManageUserPassportId, decimal BetAmount, int IsType, SqlSugar.ISqlSugarClient db, ref (EventBet, EventDetails) nb)
        {
            DateTime t = DateTime.Now;
            EventBet bet = new EventBet() { AddTime = t, Guid = guid, Ip = ".", IsValid = 1, PassportId = passportId, RulesId = rulesid, UpdateTime = t };

            EventDetails details = new EventDetails()
            {
                AddTime = t,
                UpdateTime = t,
                PassportId = passportId,
                Guid = guid,
                ManageUserPassportId = ManageUserPassportId,
                Ip = ",",
                BetAmount = BetAmount,
                IsType = IsType,
                IsValid = IsType,
            };

            details.OrderId = (details.IsValid == 1) ? "Auto" + t.Year.ToString() + t.Month.ToString() + t.Day.ToString() + t.Hour.ToString() + t.Minute.ToString() + t.Second.ToString() + t.Millisecond.ToString() : "";
            nb.Item1 = bet;
            nb.Item2 = details;


        }



        public bool IsJy(long passportId, EventHK item, SqlSugar.ISqlSugarClient db)
        {
            var all= db.Queryable<EventDetails>().Where(d => d.Guid == item.GUID&&d.IsType==1).ToList(); 
            if(all.Count>=item.AllUserNum)return false;
            if (all.Where(d => d.AddTime >= DateTime.Today).Count() >= item.ToDayAllUserNum) return false;
            var lxjl = all.Where(d=> d.PassportId == passportId).ToList();
            if (lxjl.Count >= item.UserNum) return false;
            return lxjl.Where(d => d.AddTime >= DateTime.Today).Count() < item.ToDayUserNum;

        }
    }

}



