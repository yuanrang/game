using CSRedis;
using Game.Common;
using Game.Model;
using Newtonsoft.Json;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Extensions.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.InputFiles;
using Telegram.Bot.Types.ReplyMarkups;
using Telegram_Bot.lang;
using Telegram_Bot.Model;

namespace Telegram_Bot
{
    class Program
    {
        static async Task Main(string[] args)
        {
           
            await TgBot();
        }

        static CSRedisClient csredis = new CSRedis.CSRedisClient(ConfigurationManager.AppSettings["RedisString"].ToString());
        static Dictionary<long, string> dic = new Dictionary<long, string>();
        static SqlSugarScope db = new SqlSugarScope(new ConnectionConfig()
        {
            DbType = SqlSugar.DbType.SqlServer,
            ConnectionString = ConfigurationManager.AppSettings["connectionString"].ToString(),
            IsAutoCloseConnection = true,
        },
            db =>
            {
                //单例参数配置，所有上下文生效
                db.Aop.OnLogExecuting = (sql, pars) =>
                {
                    //Console.WriteLine(sql);//输出sql
                };
            });
        static CancellationTokenSource cts1 = new CancellationTokenSource();
        static TelegramBotClient boot = new TelegramBotClient(ConfigurationManager.AppSettings["token"].ToString());
        public static long ManageUserPassportId = Convert.ToInt64(db.Queryable<BotSys>().First(c=>c.BotToken== ConfigurationManager.AppSettings["token"].ToString())?.ManageUserPassportId);
        public static async Task TgBot()
        {
            // StartReceiving does not block the caller thread. Receiving is done on the ThreadPool.
            var receiverOptions = new ReceiverOptions
            {
                AllowedUpdates = Array.Empty<UpdateType>() // receive all update types
            };
            boot.StartReceiving(
                updateHandler: HandleUpdateAsync,
                //pollingErrorHandler: HandlePollingErrorAsync,
                errorHandler: HandlePollingErrorAsync,
                receiverOptions: receiverOptions,
                cancellationToken: cts1.Token
            );

            var me = await boot.GetMeAsync();
         
            Console.WriteLine($"Start listening for @{me.Username}");
            Console.ReadLine();
           

            // Send cancellation request to stop bot
            cts1.Cancel();
        }
        static async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            List<ULangDetails> list = new List<ULangDetails>();
            if (!csredis.Exists($"{ManageUserPassportId}Lang"))
            {
                list = db.Queryable<ULangDetails>().Where(c => c.ManageUserPassportId == ManageUserPassportId).ToList();
                csredis.Set($"{ManageUserPassportId}Lang", list, 3600 * 24 * 30);
            }
            if (csredis.Get<List<ULangDetails>>($"{ManageUserPassportId}Lang")?.Count < 1)
            {
                list = db.Queryable<ULangDetails>().Where(c => c.ManageUserPassportId == ManageUserPassportId).ToList();
                csredis.Set($"{ManageUserPassportId}Lang", list, 3600 * 24 * 30);
            }
            list = csredis.Get<List<ULangDetails>>($"{ManageUserPassportId}Lang");
            
            #region CallbackQuery
            if (update.Type == UpdateType.CallbackQuery)
            {
                if (!csredis.Exists(update.CallbackQuery.Message.Chat.Id.ToString()))
                {
                    csredis.Set(update.CallbackQuery.Message.Chat.Id.ToString(), update.CallbackQuery.Data);
                }
                if (string.IsNullOrWhiteSpace(csredis.Get(update.CallbackQuery.Message.Chat.Id.ToString())))
                {
                    csredis.Set(update.CallbackQuery.Message.Chat.Id.ToString(), update.CallbackQuery.Data);
                }

                string userLang = update.CallbackQuery.Data;
                switch (userLang)
                {
                    case "CallSChinese":
                        csredis.Set(update.CallbackQuery.Message.Chat.Id.ToString(), "1");
                        break;
                    case "CallTChinese":
                        csredis.Set(update.CallbackQuery.Message.Chat.Id.ToString(), "2");
                        break;
                    case "CallEnglish":
                        csredis.Set(update.CallbackQuery.Message.Chat.Id.ToString(), "3");
                        break;
                    case "CallTaiWen":
                        csredis.Set(update.CallbackQuery.Message.Chat.Id.ToString(), "4");
                        break;
                    default:
                        csredis.Set(update.CallbackQuery.Message.Chat.Id.ToString(), "1");
                        break;
                }
                await GetLang(list, botClient, update, cancellationToken);
            }
            #endregion


            // Only process Message updates: https://core.telegram.org/bots/api#message
            if (update.Type != UpdateType.Message)
                return;
            // Only process text messages
            if (update.Message!.Type != MessageType.Text)
                return;

            
            var chatId = update.Message.Chat.Id;
            Console.WriteLine(chatId);
            var messageText = update.Message.Text;
            var moneyAddress = string.Empty;
            var receiveMessage = messageText;
         
            string lang = "CallSChinese";
            if (!csredis.Exists(update.Message.Chat.Id.ToString()))
            {
                lang = GetDataBaseLang(update);
            }
            if(string.IsNullOrWhiteSpace(csredis.Get(update.Message.Chat.Id.ToString())))
            {
                lang = GetDataBaseLang(update);
            }
            lang = csredis.Get(update.Message.Chat.Id.ToString());
            CallLang.BotLang(db, csredis, ManageUserPassportId, lang, chatId, messageText, moneyAddress, receiveMessage, botClient, update, cancellationToken);
        }

        static Task HandlePollingErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
        {
            var ErrorMessage = exception switch
            {
                ApiRequestException apiRequestException
                    => $"Telegram API Error:\n[{apiRequestException.ErrorCode}]\n{apiRequestException.Message}",
                _ => exception.ToString()
            };

            Console.WriteLine(ErrorMessage);
            return Task.CompletedTask;
        }


        static Task GetLang(List<ULangDetails> list, ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            string ChooseLang = csredis.Get(update.CallbackQuery.Message.Chat.Id.ToString());
            int IntLang = 1;
            if (!string.IsNullOrWhiteSpace(ChooseLang))
            {
                int.TryParse(ChooseLang, out IntLang);
            }
            else
            {
                csredis.Del(update.CallbackQuery.Message.Chat.Id.ToString());
            }

            string DS = (from c in list where c.ULangKey == "DS" && c.ULangId == IntLang select c.ULangValue).FirstOrDefault();
            string DX = (from c in list where c.ULangKey == "DX" && c.ULangId == IntLang select c.ULangValue).FirstOrDefault();
            string SW = (from c in list where c.ULangKey == "SW" && c.ULangId == IntLang select c.ULangValue).FirstOrDefault();
            string BJL = (from c in list where c.ULangKey == "BJL" && c.ULangId == IntLang select c.ULangValue).FirstOrDefault();
            string GRZX = (from c in list where c.ULangKey == "GRZX" && c.ULangId == IntLang select c.ULangValue).FirstOrDefault();
            string WDTG = (from c in list where c.ULangKey == "WDTG" && c.ULangId == IntLang select c.ULangValue).FirstOrDefault();
            string QHCG = (from c in list where c.ULangKey == "QHCG" && c.ULangId == IntLang select c.ULangValue).FirstOrDefault();

            ReplyKeyboardMarkup replyKeyboardMarkup = new
                    (
                        new[]
                            {
                                new KeyboardButton[] { DS, SW},
                                new KeyboardButton[] { DX, BJL },
                                //new KeyboardButton[] { GRZX, WDTG }
                                new KeyboardButton[] { WDTG }
                            }
                    )
            {
                ResizeKeyboard = true
            };
            Task task = botClient.SendTextMessageAsync
            (
                chatId: update.CallbackQuery.Message.Chat.Id,
                text: QHCG,
                parseMode: ParseMode.MarkdownV2,
                replyMarkup: replyKeyboardMarkup,
                cancellationToken: cancellationToken
            );
            return Task.CompletedTask;
        }


        /// <summary>
        /// 获取数据库语言
        /// </summary>
        /// <param name="update"></param>
        /// <returns></returns>
        private static string GetDataBaseLang(Update update)
        {
            int intLang = 1;
            string lang = string.Empty;
            UserInfo info = db.Queryable<UserInfo>().First(c => c.UserName == update.Message.Chat.Id.ToString());
            if (info != null)
            {
                intLang = info.UserLang ?? 1;
            }
            if (intLang == 1)
            {
                lang = "1";
                csredis.Set(update.Message.Chat.Id.ToString(), "1");
            }
            else if (intLang == 2)
            {
                lang = "2";
                csredis.Set(update.Message.Chat.Id.ToString(), "2");
            }
            else if (intLang == 3)
            {
                lang = "3";
                csredis.Set(update.Message.Chat.Id.ToString(), "3");
            }
            else if (intLang == 4)
            {
                lang = "4";
                csredis.Set(update.Message.Chat.Id.ToString(), "4");
            }

            return lang;
        }

    }



}
