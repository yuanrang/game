using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;
using Telegram_Bot.lang;

namespace Telegram_Bot.Send
{
    internal class SendMessage
    {
        /// <summary>
        /// 引用信息进行回复
        /// </summary>
        /// <param name="ChatId"></param>
        /// <param name="Text"></param>
        /// <param name="botClient"></param>
        /// <param name="update"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        internal virtual  async Task SendUsTextMessageAsync(string Text, ITelegramBotClient botClient, Update update, CancellationToken cancellationToken, ReplyKeyboardMarkup reply)
        {
            //var d = "https://t.me/L_BayMax";
            Message message = await botClient.SendTextMessageAsync(
                              chatId: update.Message.Chat.Id,
                              text: Text,
                              replyToMessageId: update.Message.MessageId,
                              replyMarkup: reply,
                              cancellationToken: cancellationToken);
        }
        internal virtual async Task SendTextMessageAsync(string Text, ITelegramBotClient botClient, Update update, CancellationToken cancellationToken, ReplyKeyboardMarkup reply)
        {
            Message message = await botClient.SendTextMessageAsync(
                            chatId: update.Message.Chat.Id,
                            text: Text,
                            parseMode:ParseMode.MarkdownV2,
                            replyMarkup: reply,
                            cancellationToken: cancellationToken);
        }
        internal virtual async Task SendNTextMessageAsync(string Text, ITelegramBotClient botClient, Update update, CancellationToken cancellationToken, ReplyKeyboardMarkup reply)
        {
            Message message = await botClient.SendTextMessageAsync(
                            chatId: update.Message.Chat.Id,
                            text: Text,
                              //parseMode: ParseMode.MarkdownV2,
                              replyToMessageId: update.Message.MessageId,

                            replyMarkup: reply,
                            cancellationToken: cancellationToken);
        }
    }
}
