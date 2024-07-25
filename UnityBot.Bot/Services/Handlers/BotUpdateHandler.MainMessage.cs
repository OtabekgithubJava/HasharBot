using Telegram.Bot.Types;
using Telegram.Bot;
using Telegram.Bot.Types.Enums;
using UnityBot.Bot.Models.Entities;
using UnityBot.Bot.Services.ReplyKeyboards;
using Telegram.Bot.Types.ReplyMarkups;
using UnityBot.Bot.Models.Enums;

namespace UnityBot.Bot.Services.Handlers
{
    public partial class BotUpdateHandler
    {
        #region SherikKerak
        private async Task HandleSherikKerakAsync(ITelegramBotClient client, Message message, CancellationToken cancellationToken)
        {
            if (_userService.GetUser(message.Chat.Id) == null)
            {
                var user = new UserModel()
                {
                    ChatId = message.Chat.Id,
                    Username = message.From.Username,
                    Status = Models.Enums.Status.MainPage
                };
                await _userService.CreateUser(user);
            }
            await _userService.ChangeStatus(message.Chat.Id, Models.Enums.Status.SherikKerak);

            await client.SendTextMessageAsync(
                chatId: message.Chat.Id,
                text: $"<strong>🎗 SHERIK KERAK</strong>\r\n" +
                "\r\nSherik kerakligi haqida e'lon joylashtirish uchun bir nechta savollarga javob bering. Har bir javobingiz to'g'ri va ishonchli ma'lumotlardan iborat bo'lishi kerak ekanligiga e'tiborli bo'ling.\r\n" +
                "\r\nSo'rovnoma yakunida, agarda kiritilgan barcha ma'lumotlar to'g'ri bo'lsa \"✅ To'g'ri\" tugmasini bosing, aksincha bo'lsa \"❌ Noto'g'ri\" tugmasini bosing va so'rovnomani qaytadan to'ldiring.\r\n" +
                $"\r\nE'lon tayor bo'lgandan kegin \"✅ E'lonni joylash\" tugmasi bosilsa e'lon o'sha zaxotiyoq \"EFFECT | Katta mehnat bozori\" kanaliga joylashtiriladi.",
                 parseMode: ParseMode.Html,
                cancellationToken: cancellationToken);

            await client.SendTextMessageAsync(
                chatId: message.Chat.Id,
                text: "\r\n⭐️ <strong>Sherik:</strong> \r\nSherikning Ism Familiyasini yozing.",
                replyMarkup: new ReplyKeyboardRemove(),
                parseMode: ParseMode.Html,
                cancellationToken: cancellationToken);
        }
        private async Task HandleSherikKerakBotAsync(ITelegramBotClient client, Message message, UserModel user, CancellationToken cancellationToken)
        {
            switch (user.SherikKerakCount)
            {
                case 0:
                    user.Messages.Add(message.Text!.ToString());

                    await _userService.IncSherikKerak(message.Chat.Id);
                    goto case 1;
                case 1:

                    await client.SendTextMessageAsync(
                       chatId: message.Chat.Id,
                       text: "📋 <strong>Sheriklik yo'nalishi:</strong> \r\nQanday yo'nalish bo'yicha sherik qidirilayotgan bo'lsa, shu yo'nalishni kiriting, misol uchun:\r\n\r\n" +
                       "• <i>IT yo'nalishi</i>\r\n" +
                       "• <i>Savdo-sotiq yo'nalishi</i>\r\n" +
                       "• <i>Ishlab chiqarish yo'nalishi</i>\r\n" +
                       "• <i>Qimmatbaho toshlar yo'nalishi</i>",
                       parseMode: ParseMode.Html,
                       cancellationToken: cancellationToken);
                    await _userService.IncSherikKerak(message.Chat.Id);
                    return;
                case 2:
                    user.Messages.Add(message.Text!.ToString());

                    await client.SendTextMessageAsync(
                       chatId: message.Chat.Id,
                       text: "💰 <strong>Hisob-kitob:</strong> \r\nHisob-kitob alohida muzokara qilinsa \"Alohida muzokara qilinadi\" deb yozing. Hisob-kitob e'lon qilinsa ma'lumotlarini kiriting. Misol uchun:\r\n\r\n" +
                       "• <i>Alohida muzokara qilinadi</i>\r\n" +
                       "\r\n• <i>50/50 ishlanadi</i>" +
                       "\r\n• <i>Har sotuvdan 20%</i>",
                       parseMode: ParseMode.Html,
                       cancellationToken: cancellationToken);
                    await _userService.IncSherikKerak(message.Chat.Id);
                    return;
                case 3:
                    user.Messages.Add(message.Text!.ToString());

                    await client.SendTextMessageAsync(
                       chatId: message.Chat.Id,
                       text: "🌏 <strong>Manzil:</strong> \r\nQaysi manzil bo'yicha sherik qidirilayotgan bo'lsa, shu manzilni kiriting, misol uchun:\r\n" +
                       "\r\n• <i>Toshkent shahar, Chilonzor tumani</i>",
                       parseMode: ParseMode.Html, cancellationToken: cancellationToken);
                    await _userService.IncSherikKerak(message.Chat.Id);
                    return;
                case 4:
                    user.Messages.Add(message.Text!.ToString());

                    await client.SendTextMessageAsync(
                       chatId: message.Chat.Id,
                       text: "📑 <strong>Sheriklik haqida:</strong> \r\nSheriklik haqida qisqacha ma'lumot bering. Misol uchun, nimalar qilinishi haqida yozing.",
                       parseMode: ParseMode.Html, cancellationToken: cancellationToken);
                    await _userService.IncSherikKerak(message.Chat.Id);
                    return;
                case 5:
                    user.Messages.Add(message.Text!.ToString());

                    await client.SendTextMessageAsync(
                       chatId: message.Chat.Id,
                       text: "📞 <strong>Aloqa:</strong> \r\nBog'lanish uchun telefon raqam yoki elektron pochta manzilini kiriting. Misol uchun:\r\n" +
                       "\r\n• <i>+998912345678</i>" +
                       "\r\n• <i>example@gmail.com</i>",
                       parseMode: ParseMode.Html,
                       cancellationToken: cancellationToken);
                    await _userService.IncSherikKerak(message.Chat.Id);
                    return;
                case 6:
                    user.Messages.Add(message.Text!.ToString());

                    await client.SendTextMessageAsync(
                       chatId: message.Chat.Id,
                       text: "🕰 <strong>Murojaat qilish vaqti:</strong> \r\nMurojaat qilish mumkin bo'lgan vaqtlarni kiriting. Misol uchun:\r\n" +
                       "\r\n• <i>9:00 - 18:00</i>",
                       parseMode: ParseMode.Html, cancellationToken: cancellationToken);
                    await _userService.IncSherikKerak(message.Chat.Id);
                    return;
                case 7:
                    user.Messages.Add(message.Text!.ToString());

                    var msg = await client.SendTextMessageAsync(
                       chatId: message.Chat.Id,
                       text: "📌 <strong>Qo'shimcha ma'lumotlar:</strong>\r\n" +
                       "Qo'shimcha ma'lumotlarni kiriting. Agarda ular yo'q bo'lsa \"Qo'shimcha ma'lumotlar yo'q\" tugmasini bosing.",
                       parseMode: ParseMode.Html,
                       replyMarkup: await InlineKeyBoards.AdditionalInfo(),
                       cancellationToken: cancellationToken);

                    user.LastMessages = msg.MessageId;
                    await _userService.IncSherikKerak(message.Chat.Id);
                    return;
                case 8:
                    user.Messages.Add(message.Text!.ToString());
                    var telegramLine = user.Username != null ? $"\n<strong>✉️ Telegram: @{user.Username} </strong>" : "";

                    await client.SendTextMessageAsync(
                        chatId: message.Chat.Id,
                        text: @$" <strong>🎗 SHERIK KERAK</strong> 

<strong>⭐️ Sherik:</strong> {user.Messages[0]}
<strong>📋 Sheriklik yo'nalishi:</strong> {user.Messages[1]}
<strong>💰 Hisob-kitob:</strong> {user.Messages[2]}
<strong>🌏 Manzil:</strong> {user.Messages[3]}

<strong>📑 Sheriklik haqida:</strong> {user.Messages[4]}

<strong>📞 Aloqa:</strong> {user.Messages[5]}{telegramLine}
<strong>🕰 Murojaat qilish vaqti:</strong> {user.Messages[6]}

<strong>📌 Qo'shimcha ma'lumotlar:</strong> {user.Messages[7]}

#SherikKerak

<strong><a href='{LINK}'>🌐 ""EFFECT | Katta mehnat bozori"" kanaliga obuna bo'lish</a></strong>
•
<strong><a href='{BotLINK}'>⏺ ""EFFECT | Katta mehnat bozori"" kanaliga e'lon joylash</a></strong>",
                        parseMode: ParseMode.Html,
                        disableWebPagePreview: true,
                        cancellationToken: cancellationToken);


                    var res = await client.SendTextMessageAsync(
                           chatId: message.Chat.Id,
                           text: "Barcha ma'lumotlar to'g'rimi?",
                           replyMarkup: await InlineKeyBoards.ForHaYuqButton(),
                           parseMode: ParseMode.Html,
                           cancellationToken: cancellationToken);

                    user.LastMessages = res.MessageId;

                    return;
            }
        }

        #endregion

        #region UstozKerak
        private async Task HandleUstozkerakAsync(ITelegramBotClient client, Message message, CancellationToken cancellationToken)
        {
            if (_userService.GetUser(message.Chat.Id) == null)
            {
                var user = new UserModel()
                {
                    ChatId = message.Chat.Id,
                    Username = message.From.Username,
                    Status = Models.Enums.Status.MainPage
                };
                await _userService.CreateUser(user);
            }
            await _userService.ChangeStatus(message.Chat.Id, Models.Enums.Status.UstozKerak);


            await client.SendTextMessageAsync(
                       chatId: message.Chat.Id,
                       text: @$"🧑🏻‍🏫 <strong>USTOZ KERAK</strong>

Ustoz kerakligi haqida e'lon joylashtirish uchun bir nechta savollarga javob bering. Har bir javobingiz to'g'ri va ishonchli ma'lumotlardan iborat bo'lishi kerak ekanligiga e'tiborli bo'ling.

So'rovnoma yakunida, agarda kiritilgan barcha ma'lumotlar to'g'ri bo'lsa ""✅ To'g'ri"" tugmasini bosing, aksincha bo'lsa ""❌ Noto'g'ri"" tugmasini bosing va so'rovnomani qaytadan to'ldiring.

E'lon tayor bo'lgandan kegin ""✅ E'lonni joylash"" tugmasi bosilsa e'lon o'sha zaxotiyoq ""EFFECT | Katta mehnat bozori"" kanaliga joylashtiriladi.",
                       parseMode: ParseMode.Html,
                       cancellationToken: cancellationToken);

            await client.SendTextMessageAsync(
                chatId: message.Chat.Id,
                text: "\U0001f9d1🏻 <strong>Shogirt:</strong> \r\nShogirtning Ism Familiyasini kiriting.",
                replyMarkup: new ReplyKeyboardRemove(),
                parseMode: ParseMode.Html,
                cancellationToken: cancellationToken);
        }
        private async Task HandleUstozKerakBotAsync(ITelegramBotClient client, Message message, UserModel user, CancellationToken cancellationToken)
        {
            switch (user.UstozkerakCount)
            {
                case 0:
                    user.Messages.Add(message.Text!.ToString());
                    await _userService.IncUstozKerak(message.Chat.Id);
                    goto case 1;

                case 1:
                    await client.SendTextMessageAsync(
                        chatId: message.Chat.Id,
                        text: "🗓 <strong>Tug'ilgan sana:</strong>\r\nShogirtning tug'ilgan sanasini kiriting. Misol uchun:\r\n" +
                        "\r\n• <i>12.06.2005</i>",
                        parseMode: ParseMode.Html, cancellationToken: cancellationToken);
                    await _userService.IncUstozKerak(message.Chat.Id);
                    return;

                case 2:
                    user.Messages.Add(message.Text!.ToString());
                    await client.SendTextMessageAsync(
                        chatId: message.Chat.Id,
                        text: "💠 <strong>Shogirtlik yo'nalishi:</strong>\r\nQanday yo'nalish bo'yicha ustoz qidirilayotgan bo'lsa, shu yo'nalishni kiriting, misol uchun:\r\n" +
                        "\r\n• <i>IT yo'nalishi</i>" +
                        "\r\n• <i>Sotuv menejeri</i>" +
                        "\r\n• <i>Santexnika ustasi</i>",
                        parseMode: ParseMode.Html, cancellationToken: cancellationToken);
                    await _userService.IncUstozKerak(message.Chat.Id);
                    return;

                case 3:
                    user.Messages.Add(message.Text!.ToString());
                    await client.SendTextMessageAsync(
                        chatId: message.Chat.Id,
                        text: "🌏 <strong>Manzil: </strong>\r\nQaysi manzil bo'yicha ustoz qidirilayotgan bo'lsa, shu manzilni kiriting, misol uchun:\r\n" +
                        "\r\n• <i>Toshkent shahar, Chilonzor tumani</i>",
                        parseMode: ParseMode.Html, cancellationToken: cancellationToken);
                    await _userService.IncUstozKerak(message.Chat.Id);
                    return;

                case 4:
                    user.Messages.Add(message.Text!.ToString());
                    await client.SendTextMessageAsync(
                        chatId: message.Chat.Id,
                        text: "💰 <strong>Ish haqi:</strong>\r\nIsh haqi kerak bo'lmasa \"Ish haqi kerak emas\" deb yozing. Ish haqi kerak bo'lsa miqdori, valyutasi va davriyligini kiriting. " +
                        "Misol uchun:\r\n" +
                        "\r\n• <i>Ish haqi kerak emas</i>\r\n" +
                        "\r\n• <i>3.000.000 so'm - 1 oyga</i>" +
                        "\r\n• <i>100 dollar - 1 ishga</i>",
                        parseMode: ParseMode.Html,
                        cancellationToken: cancellationToken);
                    await _userService.IncUstozKerak(message.Chat.Id);
                    return;
                case 5:
                    user.Messages.Add(message.Text!.ToString());
                    var tmsg = await client.SendTextMessageAsync(
                        chatId: message.Chat.Id,
                        text: "<strong>\U0001f9d1‍🎓 Talaba:</strong>\r\nShogirt talaba bo'lsa \"Ha\" tugmasini, aksincha bo'lsa \"Yo'q\" tugmasini bosing.",
                        parseMode: ParseMode.Html,
                        replyMarkup: await InlineKeyBoards.ForTalaba(),
                        cancellationToken: cancellationToken);
                    await _userService.IncUstozKerak(message.Chat.Id);
                    user.LastMessages = tmsg.MessageId;
                    return;
                case 6:
                    var wmsg = await client.SendTextMessageAsync(
                        chatId: message.Chat.Id,
                        text: "<strong>\U0001f9d1‍🎓 Talaba:</strong>\r\nShogirt talaba bo'lsa \"Ha\" tugmasini, aksincha bo'lsa \"Yo'q\" tugmasini bosing.",
                        parseMode: ParseMode.Html,
                        replyMarkup: await InlineKeyBoards.ForTalaba(),
                        cancellationToken: cancellationToken);

                    user.LastMessages = wmsg.MessageId;
                    return;

                case 7:
                    await client.SendTextMessageAsync(
                        chatId: message.Chat.Id,
                        text: "<strong>📑 Shogirt haqida:</strong> \r\nShogirt haqida qisqacha ma'lumot bering. Misol uchun, qanday bilim va qobiliyatlarga ega ekanligi haqida yozing.",
                        parseMode: ParseMode.Html, cancellationToken: cancellationToken);
                    await _userService.IncUstozKerak(message.Chat.Id);
                    return;

                case 8:
                    user.Messages.Add(message.Text!.ToString());
                    await client.SendTextMessageAsync(
                        chatId: message.Chat.Id,
                        text: "📞 <strong>Aloqa:</strong> \r\nBog'lanish uchun telefon raqam yoki elektron pochta manzilini kiriting. Misol uchun:\r\n" +
                        "\r\n• <i>+998912345678</i>" +
                        "\r\n• <i>example@gmail.com</i>",
                        parseMode: ParseMode.Html, cancellationToken: cancellationToken);
                    await _userService.IncUstozKerak(message.Chat.Id);
                    return;

                case 9:
                    user.Messages.Add(message.Text!.ToString());
                    await client.SendTextMessageAsync(
                        chatId: message.Chat.Id,
                        text: "🕰 <strong>Murojaat qilish vaqti:</strong> \r\nMurojaat qilish mumkin bo'lgan vaqtlarni kiriting. Misol uchun:\r\n" +
                        "\r\n• <i>9:00 - 18:00</i>",
                        parseMode: ParseMode.Html, cancellationToken: cancellationToken);
                    await _userService.IncUstozKerak(message.Chat.Id);
                    return;

                case 10:
                    user.Messages.Add(message.Text!.ToString());
                    var msg = await client.SendTextMessageAsync(
                        chatId: message.Chat.Id,
                        text: "📌 <strong>Qo'shimcha ma'lumotlar: </strong>\r\nQo'shimcha ma'lumotlarni kiriting. Agarda ular yo'q bo'lsa \"Qo'shimcha ma'lumotlar yo'q\" tugmasini bosing. ",
                        parseMode: ParseMode.Html,
                        replyMarkup: await InlineKeyBoards.AdditionalInfo(),
                        cancellationToken: cancellationToken);
                    await _userService.IncUstozKerak(message.Chat.Id);
                    user.LastMessages = msg.MessageId;
                    return;
                case 11:
                    user.Messages.Add(message.Text!.ToString());

                    var telegramLine = user.Username != null ? $"\n<strong>✉️ Telegram: @{user.Username} </strong>" : "";

                    await client.SendTextMessageAsync(
    chatId: message.Chat.Id,
    text: @$"
🧑🏻‍🏫 <strong>USTOZ KERAK</strong>

<strong>🧑🏻 Shogirt:</strong> {user.Messages[0]}
<strong>🗓 Tug'ilgan sana:</strong> {user.Messages[1]}
<strong>💠 Shogirtlik yo'nalishi:</strong> {user.Messages[2]}
<strong>🌏 Manzil:</strong> {user.Messages[3]}
<strong>💰 Ish haqi:</strong> {user.Messages[4]}

<strong>🧑‍🎓 Talaba:</strong> {user.Messages[5]}
<strong>📑 Shogirt haqida:</strong> {user.Messages[6]}

<strong>📞 Aloqa:</strong> {user.Messages[7]}{telegramLine}
<strong>🕰 Murojaat qilish vaqti:</strong> {user.Messages[8]}

<strong>📌 Qo'shimcha ma'lumotlar:</strong> {user.Messages[9]}

#UstozKerak

<strong><a href='{LINK}'>🌐 ""EFFECT | Katta mehnat bozori"" kanaliga obuna bo'lish</a></strong>
•
<strong><a href='{BotLINK}'>⏺ ""EFFECT | Katta mehnat bozori"" kanaliga e'lon joylash</a></strong>",
    parseMode: ParseMode.Html,
    disableWebPagePreview: true,
    cancellationToken: cancellationToken);


                    var res = await client.SendTextMessageAsync(
                         chatId: message.Chat.Id,
                         text: "Barcha ma'lumotlar to'g'rimi?",
                         replyMarkup: await InlineKeyBoards.ForHaYuqButton(),
                         parseMode: ParseMode.Html,
                         cancellationToken: cancellationToken);

                    user.LastMessages = res.MessageId;

                    return;
            }
        }
        #endregion

        #region RezumeJoylash
        private async Task HandleRezumeJoylashAsync(ITelegramBotClient client, Message message, CancellationToken cancellationToken)
        {
            if (_userService.GetUser(message.Chat.Id) == null)
            {
                var user = new UserModel()
                {
                    ChatId = message.Chat.Id,
                    Username = message.From.Username,
                    Status = Models.Enums.Status.MainPage
                };
                await _userService.CreateUser(user);
            }
            await _userService.ChangeStatus(message.Chat.Id, Models.Enums.Status.RezumeJoylash);


            await client.SendTextMessageAsync(
                       chatId: message.Chat.Id,
                       text: "\U0001f9d1🏻‍💼 <strong>REZYUME</strong>\r\n\r\nRezyume joylashtirish uchun bir nechta savollarga javob bering." +
                       " Har bir javobingiz to'g'ri va ishonchli ma'lumotlardan iborat bo'lishi kerak ekanligiga e'tiborli bo'ling.\r\n" +
                       "\r\nSo'rovnoma yakunida, agarda kiritilgan barcha ma'lumotlar to'g'ri bo'lsa \"✅ To'g'ri\" tugmasini bosing, aksincha bo'lsa \"❌ Noto'g'ri\" tugmasini bosing va so'rovnomani qaytadan to'ldiring.\r\n" +
                       $"\r\nE'lon tayor bo'lgandan kegin \"✅ E'lonni joylash\" tugmasi bosilsa e'lon o'sha zaxotiyoq \"EFFECT | Katta mehnat bozori\" kanaliga joylashtiriladi.",
                       parseMode: ParseMode.Html,
                       cancellationToken: cancellationToken);
            await client.SendTextMessageAsync(
               chatId: message.Chat.Id,
               text: "⭐️ <strong>Ish qidiruvchi:</strong> \r\nIsh qidiruvchining Ism Familiyasini kiriting.",
               replyMarkup: new ReplyKeyboardRemove(),
               parseMode: ParseMode.Html,
               cancellationToken: cancellationToken
                );
        }
        private async Task HandleRezumeJoylashBotAsync(ITelegramBotClient client, Message message, UserModel user, CancellationToken cancellationToken)
        {
            switch (user.RezumeCount)
            {
                case 0:
                    user.Messages.Add(message.Text!.ToString());
                    await _userService.IncRezumeCount(message.Chat.Id);
                    goto case 1;
                case 1:
                    await client.SendTextMessageAsync(
                        chatId: message.Chat.Id,
                        text: "🗓 <strong>Tug'ilgan sana: </strong>\r\nIsh qidiruvchining tug'ilgan sanasini kiriting. " +
                        "Misol uchun:\r\n" +
                        "\r\n• <i>12.06.2000</i>",
                        parseMode: ParseMode.Html, cancellationToken: cancellationToken);
                    await _userService.IncRezumeCount(message.Chat.Id);
                    return;

                case 2:
                    user.Messages.Add(message.Text!.ToString());
                    await client.SendTextMessageAsync(
                        chatId: message.Chat.Id,
                        text: "💠 <strong>Mutaxassislik:</strong>\r\nIsh qidiruvchining mutaxassisligini kiriting. " +
                        "Misol uchun:\r\n" +
                        "\r\n• <i>Sotuv menejeri</i>" +
                        "\r\n• <i>Santexnika ustasi</i>" +
                        "\r\n• <i>Haydovchi</i>",
                        parseMode: ParseMode.Html, cancellationToken: cancellationToken);
                    await _userService.IncRezumeCount(message.Chat.Id);
                    return;

                case 3:
                    user.Messages.Add(message.Text!.ToString());
                    await client.SendTextMessageAsync(
                        chatId: message.Chat.Id,
                        text: "🌏 <strong>Manzil:</strong> \r\nIsh qidiruvchining manzilini kiriting." +
                        " Misol uchun:\r\n" +
                        "\r\n• <i>Toshkent shahar, Chilonzor tumani</i>",
                        parseMode: ParseMode.Html, cancellationToken: cancellationToken);
                    await _userService.IncRezumeCount(message.Chat.Id);
                    return;


                case 4:
                    user.Messages.Add(message.Text!.ToString());
                    await client.SendTextMessageAsync(
                        chatId: message.Chat.Id,
                        text: "💰 <strong>Ish haqi:</strong> \r\nIsh qidiruvchiga maqul ish haqini kiriting. Ish haqi miqdori, valyutasi va davriyligini yozing." +
                        " Misol uchun:\r\n" +
                        "\r\n• 3.000.000 so'm - 1 oyga" +
                        "\r\n• 100 dollar - 1 ishga",
                        parseMode: ParseMode.Html, cancellationToken: cancellationToken);
                    await _userService.IncRezumeCount(message.Chat.Id);
                    return;

                case 5:
                    user.Messages.Add(message.Text!.ToString());
                    var tmsg = await client.SendTextMessageAsync(
                        chatId: message.Chat.Id,
                        text: "\U0001f9d1‍🎓 <strong>Talaba:</strong> \r\nIsh qidiruvchi talaba bo'lsa \"Ha\" tugmasini, aksincha bo'lsa \"Yo'q\" tugmasini bosing.",
                        parseMode: ParseMode.Html,
                        replyMarkup: await InlineKeyBoards.ForTalaba(),
                        cancellationToken: cancellationToken);
                    await _userService.IncRezumeCount(message.Chat.Id);
                    return;
                case 6:
                    var wmsg = await client.SendTextMessageAsync(
                        chatId: message.Chat.Id,
                        text: "\U0001f9d1‍🎓 <strong>Talaba:</strong> \r\nIsh qidiruvchi talaba bo'lsa \"Ha\" tugmasini, aksincha bo'lsa \"Yo'q\" tugmasini bosing.",
                        parseMode: ParseMode.Html,
                        replyMarkup: await InlineKeyBoards.ForTalaba(),
                        cancellationToken: cancellationToken);
                    user.LastMessages = wmsg.MessageId;
                    return;
                case 7:
                    await client.SendTextMessageAsync(
                        chatId: message.Chat.Id,
                        text: "📑 <strong>Ish qidiruvchi haqida:</strong> \r\nIsh qidiruvchi haqida qisqacha ma'lumot bering. Misol uchun, qanday bilim va qibiliyatlarga ega ekanligi haqida yozing.",
                        parseMode: ParseMode.Html, cancellationToken: cancellationToken);
                    await _userService.IncRezumeCount(message.Chat.Id);
                    return;
                case 8:
                    user.Messages.Add(message.Text!.ToString());
                    await client.SendTextMessageAsync(
                        chatId: message.Chat.Id,
                        text: "📞 <strong>Aloqa:</strong> \r\nBog'lanish uchun telefon raqam yoki elektron pochta manzilini kiriting. " +
                        "Misol uchun:\r\n" +
                        "\r\n• <i>+998912345678</i>" +
                        "\r\n• <i>example@gmail.com</i>",
                        parseMode: ParseMode.Html, cancellationToken: cancellationToken);
                    await _userService.IncRezumeCount(message.Chat.Id);
                    return;

                case 9:
                    user.Messages.Add(message.Text!.ToString());
                    await client.SendTextMessageAsync(
                        chatId: message.Chat.Id,
                        text: "🕰 <strong>Murojaat qilish vaqti:</strong> \r\nMurojaat qilish mumkin bo'lgan vaqtlarni kiriting. " +
                        "Misol uchun:\r\n" +
                        "\r\n• <i>9:00 - 18:00</i>",
                        parseMode: ParseMode.Html, cancellationToken: cancellationToken);
                    await _userService.IncRezumeCount(message.Chat.Id);
                    return;

                case 10:
                    user.Messages.Add(message.Text!.ToString());
                    var msg = await client.SendTextMessageAsync(
                        chatId: message.Chat.Id,
                        text: "📌 <strong>Qo'shimcha ma'lumotlar:</strong> \r\nQo'shimcha ma'lumotlarni kiriting. Agarda ular yo'q bo'lsa \"Qo'shimcha ma'lumotlar yo'q\" tugmasini bosing. ",
                        parseMode: ParseMode.Html,
                        replyMarkup: await InlineKeyBoards.AdditionalInfo(),
                        cancellationToken: cancellationToken);
                    await _userService.IncRezumeCount(message.Chat.Id);
                    user.LastMessages = msg.MessageId;
                    return;
                case 11:
                    user.Messages.Add(message.Text!.ToString());
                    var telegramLine = user.Username != null ? $"\n<strong>✉️ Telegram: @{user.Username} </strong>" : "";

                    await client.SendTextMessageAsync(
                       chatId: message.Chat.Id,
                       text: @$"<strong>🧑🏻‍💼 REZYUME</strong>

<strong>⭐️ Ish qidiruvchi:</strong> {user.Messages[0]}
<strong>🗓 Tug'ilgan sana:</strong> {user.Messages[1]}
<strong>💠 Mutaxassislik:</strong> {user.Messages[2]}
<strong>🌏 Manzil:</strong> {user.Messages[3]}
<strong>💰 Ish haqi:</strong> {user.Messages[4]}

<strong>🧑‍🎓 Talaba:</strong> {user.Messages[5]}
<strong>📑 Ish qidiruvchi haqida:</strong> {user.Messages[6]}

<strong>📞 Aloqa:</strong> {user.Messages[7]}{telegramLine}
<strong>🕰 Murojaat qilish vaqti:</strong> {user.Messages[8]}

<strong>📌 Qo'shimcha ma'lumotlar:</strong> {user.Messages[9]}

#Rezyume

<strong><a href='{LINK}'>🌐 ""EFFECT | Katta mehnat bozori"" kanaliga obuna bo'lish</a></strong>
•
<strong><a href='{BotLINK}'>⏺ ""EFFECT | Katta mehnat bozori"" kanaliga e'lon joylash</a></strong>",
                       parseMode: ParseMode.Html,
                       disableWebPagePreview: true,
                       cancellationToken: cancellationToken);


                    var res = await client.SendTextMessageAsync(
                        chatId: message.Chat.Id,
                        text: "Barcha ma'lumotlar to'g'rimi?",
                        replyMarkup: await InlineKeyBoards.ForHaYuqButton(),
                        parseMode: ParseMode.Html,
                        cancellationToken: cancellationToken);

                    user.LastMessages = res.MessageId;

                    return;
            }


        }
        #endregion

        #region ShogirtKerak
        private async Task HandleShogirtKerakAsync(ITelegramBotClient client, Message message, CancellationToken cancellationToken)
        {
            if (_userService.GetUser(message.Chat.Id) == null)
            {
                var user = new UserModel()
                {
                    ChatId = message.Chat.Id,
                    Username = message.From.Username,
                    Status = Models.Enums.Status.MainPage
                };
                await _userService.CreateUser(user);
            }
            await _userService.ChangeStatus(message.Chat.Id, Models.Enums.Status.ShogirtKerak);


            await client.SendTextMessageAsync(
                       chatId: message.Chat.Id,
                       text: @$"🧑🏻 <strong>SHOGIRT KERAK</strong>

Shogirt kerakligi haqida e'lon joylashtirish uchun bir nechta savollarga javob bering. Har bir javobingiz to'g'ri va ishonchli ma'lumotlardan iborat bo'lishi kerak ekanligiga e'tiborli bo'ling.

So'rovnoma yakunida, agarda kiritilgan barcha ma'lumotlar to'g'ri bo'lsa ""✅ To'g'ri"" tugmasini bosing, aksincha bo'lsa ""❌ Noto'g'ri"" tugmasini bosing va so'rovnomani qaytadan to'ldiring.

E'lon tayor bo'lgandan kegin ""✅ E'lonni joylash"" tugmasi bosilsa e'lon o'sha zaxotiyoq ""EFFECT | Katta mehnat bozori"" kanaliga joylashtiriladi.",
                       parseMode: ParseMode.Html,
                       cancellationToken: cancellationToken);

            await client.SendTextMessageAsync(
                chatId: message.Chat.Id,
                text: "\U0001f9d1🏻‍🏫 <strong>Ustoz:</strong> \r\nUstozning Ism Familiyasini yozing.",
                parseMode: ParseMode.Html,
                replyMarkup: new ReplyKeyboardRemove(),
                cancellationToken: cancellationToken);
            await _userService.IncShogirtKerakCount(message.Chat.Id);
        }
        private async Task HandleShogirtKerakBotAsync(ITelegramBotClient client, Message message, UserModel user, CancellationToken cancellationToken)
        {
            if (user.ShogirtKerakCount == 0)
            {
                user.Messages.Add(message.Text!.ToString());
                await _userService.IncShogirtKerakCount(message.Chat.Id);
            }
            if (user.ShogirtKerakCount == 1)
            {
                user.Messages.Add(message.Text!.ToString());
                await _userService.IncShogirtKerakCount(message.Chat.Id);
                await client.SendTextMessageAsync(
                  chatId: message.Chat.Id,
                  text: "📋 <strong>Ustozlik yo'nalishi:</strong> \r\n" +
                  "Qanday yo'nalish bo'yicha shogirt olinsa, shu yo'nalishni kiriting, " +
                  "misol uchun:\r\n" +
                  "\r\n• <i>IT yo'nalishi</i>" +
                  "\r\n• <i>Sotuv menejeri</i>" +
                  "\r\n• <i>Santexnika ustasi</i>",
                  parseMode: ParseMode.Html, cancellationToken: cancellationToken);

                return;
            }

            else if (user.ShogirtKerakCount == 2)
            {
                user.Messages.Add(message.Text!.ToString());
                await _userService.IncShogirtKerakCount(message.Chat.Id);
                await client.SendTextMessageAsync(
                  chatId: message.Chat.Id,
                  text: "💰 <strong>Ish haqi:</strong> \r\nIsh haqi yo'q bo'lsa \"Yo'q\" deb yozing. Ish haqi bor bo'lsa miqdori, valyutasi va davriyligini kiriting. " +
                  "Misol uchun:\r\n" +
                  "\r\n• <i>Yo'q</i>\r\n" +
                  "\r\n• <i>3.000.000 so'm - 1 oyga</i>" +
                  "\r\n• <i>100 dollar - 1 ishga</i>",
                  parseMode: ParseMode.Html, cancellationToken: cancellationToken);
                return;

            }

            if (user.ShogirtKerakCount == 3)
            {
                user.Messages.Add(message.Text!.ToString());
                await _userService.IncShogirtKerakCount(message.Chat.Id);
                await client.SendTextMessageAsync(
                  chatId: message.Chat.Id,
                  text: "🌏 <strong>Manzil:</strong> \r\nFaoliyat yuritish manzilini kiriting. Misol uchun:\r\n" +
                  "\r\n• <i>Toshkent shahar, Chilonzor tumani</i>",
                  parseMode: ParseMode.Html, cancellationToken: cancellationToken);
                return;

            }

            if (user.ShogirtKerakCount == 4)
            {
                user.Messages.Add(message.Text!.ToString());
                await _userService.IncShogirtKerakCount(message.Chat.Id);
                await client.SendTextMessageAsync(
                  chatId: message.Chat.Id,
                  text: "📑 <strong>Ustozlik haqida:</strong> \r\nUstozlik haqida qisqacha ma'lumot bering. Misol uchun, nimalar qilinishi haqida yoki ustozlik davri qanday o'tishi haqida yozing.",
                  parseMode: ParseMode.Html, cancellationToken: cancellationToken);
                return;

            }

            if (user.ShogirtKerakCount == 5)
            {

                user.Messages.Add(message.Text!.ToString());
                await _userService.IncShogirtKerakCount(message.Chat.Id);
                await client.SendTextMessageAsync(
                  chatId: message.Chat.Id,
                  text: "📞 <strong>Aloqa:</strong> \r\nBog'lanish uchun telefon raqam yoki elektron pochta manzilini kiriting. " +
                  "Misol uchun:\r\n" +
                  "\r\n• <i>+998912345678</i>" +
                  "\r\n• <i>example@gmail.com</i>",
                  parseMode: ParseMode.Html, cancellationToken: cancellationToken);
                return;

            }

            if (user.ShogirtKerakCount == 6)
            {

                user.Messages.Add(message.Text!.ToString());
                await _userService.IncShogirtKerakCount(message.Chat.Id);
                await client.SendTextMessageAsync(
                  chatId: message.Chat.Id,
                  text: "🕰 <strong>Murojaat qilish vaqti:</strong> \r\nMurojaat qilish mumkin bo'lgan vaqtlarni kiriting. " +
                  "Misol uchun:\r\n" +
                  "\r\n• <i>9:00 - 18:00</i>",
                  parseMode: ParseMode.Html, cancellationToken: cancellationToken);

                return;

            }

            if (user.ShogirtKerakCount == 7)
            {

                user.Messages.Add(message.Text!.ToString());
                await _userService.IncShogirtKerakCount(message.Chat.Id);
                var msg = await client.SendTextMessageAsync(
                  chatId: message.Chat.Id,
                  text: "📌 <strong>Qo'shimcha ma'lumotlar:</strong> \r\nQo'shimcha ma'lumotlarni kiriting. Agarda ular yo'q bo'lsa \"Qo'shimcha ma'lumotlar yo'q\" tugmasini bosing.",
                  parseMode: ParseMode.Html,
                  replyMarkup: await InlineKeyBoards.AdditionalInfo(),
                  cancellationToken: cancellationToken);

                user.LastMessages = msg.MessageId;

                return;

            }
            if (user.ShogirtKerakCount == 8)
            {
                user.Messages.Add(message.Text!.ToString());
                var telegramLine = user.Username != null ? $"\n<strong>✉️ Telegram: @{user.Username}</strong>" : "";

                await client.SendTextMessageAsync(
    chatId: message.Chat.Id,
    text: @$"<strong>🧑🏻 SHOGIRT KERAK</strong>

<strong>🧑🏻‍🏫 Ustoz:</strong> {user.Messages[0]}
<strong>📋 Ustozlik yo'nalishi:</strong> {user.Messages[1]}
<strong>💰 Ish haqi:</strong> {user.Messages[2]}
<strong>🌏 Manzil:</strong> {user.Messages[3]}

<strong>📑 Ustozlik haqida:</strong> {user.Messages[4]}

<strong>📞 Aloqa:</strong> {user.Messages[5]}{telegramLine}
<strong>🕰 Murojaat qilish vaqti:</strong> {user.Messages[6]}

<strong>📌 Qo'shimcha ma'lumotlar:</strong> {user.Messages[7]}

#ShogirtKerak

<strong><a href='{LINK}'>🌐 ""EFFECT | Katta mehnat bozori"" kanaliga obuna bo'lish</a></strong>
•
<strong><a href='{BotLINK}'>⏺ ""EFFECT | Katta mehnat bozori"" kanaliga e'lon joylash</a></strong>",
    parseMode: ParseMode.Html,
    disableWebPagePreview: true);


                var res = await client.SendTextMessageAsync(
                    chatId: message.Chat.Id,
                    text: "Barcha ma'lumotlar to'g'rimi?",
                    replyMarkup: await InlineKeyBoards.ForHaYuqButton(),
                    parseMode: ParseMode.Html,
                    cancellationToken: cancellationToken);

                user.LastMessages = res.MessageId;

                return;
            }
        }
        #endregion

        #region IshJoylash
        private async Task HandleIshJoylashAsync(ITelegramBotClient client, Message message, CancellationToken cancellationToken)
        {

            var user = await _userService.GetUser(message.Chat.Id);

            if (user == null)
            {
                user = new UserModel
                {
                    ChatId = message.Chat.Id,
                    Username = message.From.Username,
                    Status = Models.Enums.Status.IshJoylash
                };

                await _userService.CreateUser(user);
            }

            await _userService.ChangeStatus(message.Chat.Id, Status.IshJoylash);


            await client.SendTextMessageAsync(
                chatId: message.Chat.Id,
                text: $@"<strong>🏢 ISH</strong>

Ish joylashtirish uchun bir nechta savollarga javob bering. Har bir javobingiz to'g'ri va ishonchli ma'lumotlardan iborat bo'lishi kerak ekanligiga e'tiborli bo'ling.

So'rovnoma yakunida, agarda kiritilgan barcha ma'lumotlar to'g'ri bo'lsa ""✅ To'g'ri"" tugmasini bosing, aksincha bo'lsa ""❌ Noto'g'ri"" tugmasini bosing va so'rovnomani qaytadan to'ldiring.

E'lon tayor bo'lgandan kegin ""✅ E'lonni joylash"" tugmasi bosilsa e'lon o'sha zaxotiyoq ""EFFECT | Katta mehnat bozori"" kanaliga joylashtiriladi.",
                parseMode: ParseMode.Html,
                cancellationToken: cancellationToken);

            await client.SendTextMessageAsync(
                chatId: message.Chat.Id,
                text: "⭐️ <strong>Ish beruvchi:</strong>\r\nTashkilot nomini kiriting. Tashkilot bo'lmasa ish beruvchining Ism Familiyasini yozing.",
                parseMode: ParseMode.Html,
                replyMarkup: new ReplyKeyboardRemove(),
                cancellationToken: cancellationToken);
        }
        private async Task HandleIshJoylashBotAsync(ITelegramBotClient client, Message message, UserModel user, CancellationToken cancellationToken)
        {
            switch (user.IshJoylashCount)
            {
                case 0:
                    user.Messages.Add(message.Text!.ToString());
                    await _userService.IncIshJoylashCount(message.Chat.Id);
                    goto case 1;

                case 1:
                    await client.SendTextMessageAsync(
                        chatId: message.Chat.Id,
                        text: "📋 <strong>Vakansiya nomi:</strong> \r\nVakansiya nomini kiriting, " +
                        "misol uchun:\r\n" +
                        "\r\n• <i>Sotuv menejeri</i>" +
                        "\r\n• <i>Santexnika ustasi</i>" +
                        "\r\n• <i>Haydovchi</i>",
                        parseMode: ParseMode.Html,
                        cancellationToken: cancellationToken);
                    await _userService.IncIshJoylashCount(message.Chat.Id);
                    return;

                case 2:
                    user.Messages.Add(message.Text!.ToString());

                    await client.SendTextMessageAsync(
                        chatId: message.Chat.Id,
                        text: "<strong>⏰ Ish vaqti:</strong> \r\nIsh vaqtini kiriting. " +
                        "Misol uchun:\r\n" +
                        "\r\n• <i>9:00 - 18:00</i>",
                        parseMode: ParseMode.Html,
                        cancellationToken: cancellationToken);
                    await _userService.IncIshJoylashCount(message.Chat.Id);
                    return;

                case 3:
                    user.Messages.Add(message.Text!.ToString());

                    await client.SendTextMessageAsync(
                        chatId: message.Chat.Id,
                        text: "💰 <strong>Ish haqi:</strong> \r\nIsh haqi miqdori, valyutasi va davriyligini kiriting. " +
                        "Misol uchun:\r\n" +
                        "\r\n• <i>3.000.000 so'm - 1 oyga</i>" +
                        "\r\n• <i>100 dollar - 1 ishga</i>",
                        parseMode: ParseMode.Html,
                        cancellationToken: cancellationToken);
                    await _userService.IncIshJoylashCount(message.Chat.Id);
                    return;

                case 4:
                    user.Messages.Add(message.Text!.ToString());

                    await client.SendTextMessageAsync(
                        chatId: message.Chat.Id,
                        text: "🌏 <strong>Manzil:</strong> \r\nIsh joyi manzilini kiriting. " +
                        "Misol uchun:\r\n" +
                        "\r\n• <i>Toshkent shahar, Chilonzor tumani</i>",
                        parseMode: ParseMode.Html,
                        cancellationToken: cancellationToken);
                    await _userService.IncIshJoylashCount(message.Chat.Id);
                    return;

                case 5:
                    user.Messages.Add(message.Text!.ToString());

                    await client.SendTextMessageAsync(
                        chatId: message.Chat.Id,
                        text: "📑 <strong>Vakansiya haqida</strong>: \r\nVakansiya haqida qisqacha ma'lumot bering. " +
                        " \r\nMisol uchun, nima qilinishi kerakligi haqida yozing.",
                        parseMode: ParseMode.Html,
                        cancellationToken: cancellationToken);
                    await _userService.IncIshJoylashCount(message.Chat.Id);
                    return;

                case 6:
                    user.Messages.Add(message.Text!.ToString());

                    await client.SendTextMessageAsync(
                        chatId: message.Chat.Id,
                        text: "📞 <strong>Aloqa:</strong> \r\nBog'lanish uchun telefon raqam yoki elektron pochta manzilini kiriting. " +
                        "Misol uchun:\r\n" +
                        "\r\n• <i>+998912345678</i>" +
                        "\r\n• <i>example@gmail.com</i>",
                        parseMode: ParseMode.Html,
                        cancellationToken: cancellationToken);
                    await _userService.IncIshJoylashCount(message.Chat.Id);
                    return;

                case 7:
                    user.Messages.Add(message.Text!.ToString());

                    await client.SendTextMessageAsync(
                        chatId: message.Chat.Id,
                        text: "🕰 <strong>Murojaat qilish vaqti:</strong> \r\nMurojaat qilish mumkin bo'lgan vaqtlarni kiriting. " +
                        "Misol uchun:\r\n" +
                        "\r\n• <i>9:00 - 18:00</i>",
                        parseMode: ParseMode.Html,
                        cancellationToken: cancellationToken);
                    await _userService.IncIshJoylashCount(message.Chat.Id);
                    return;

                case 8:
                    user.Messages.Add(message.Text!.ToString());

                    var msg = await client.SendTextMessageAsync(
                        chatId: message.Chat.Id,
                        text: "📌 <strong>Qo'shimcha ma'lumotlar:</strong> \r\nQo'shimcha ma'lumotlarni kiriting. Agarda ular yo'q bo'lsa \"Qo'shimcha ma'lumotlar yo'q\" tugmasini bosing.",
                        parseMode: ParseMode.Html,
                        replyMarkup: await InlineKeyBoards.AdditionalInfo(),
                        cancellationToken: cancellationToken);
                    await _userService.IncIshJoylashCount(message.Chat.Id);

                    user.LastMessages = msg.MessageId;

                    return;

                case 9:
                    user.Messages.Add(message.Text!.ToString());
                    var telegramLine = user.Username != null ? $"\n<strong>✉️ Telegram: @{user.Username}</strong>" : "";

                    await client.SendTextMessageAsync(
                        chatId: message.Chat.Id,
                        text: @$"🏢 <strong>ISH</strong>

<strong>⭐️ Ish beruvchi:</strong> {user.Messages[0]} 
<strong>📋 Vakansiya nomi:</strong> {user.Messages[1]}
<strong>⏰ Ish vaqti:</strong> {user.Messages[2]}
<strong>💰 Ish haqi:</strong> {user.Messages[3]}
<strong>🌏 Manzil:</strong> {user.Messages[4]}

<strong>📑 Vakansiya haqida:</strong> {user.Messages[5]}

<strong>📞 Aloqa:</strong> {user.Messages[6]}{telegramLine}
<strong>🕰 Murojaat qilish vaqti:</strong> {user.Messages[7]}

<strong>📌 Qo'shimcha ma'lumotlar:</strong> {user.Messages[8]}

#Ish

<strong><a href='{LINK}'>🌐 ""EFFECT | Katta mehnat bozori"" kanaliga obuna bo'lish</a></strong>
•
<strong><a href='{BotLINK}'>⏺ ""EFFECT | Katta mehnat bozori"" kanaliga e'lon joylash</a></strong>",
                        parseMode: ParseMode.Html,
                        disableWebPagePreview: true);


                    var res = await client.SendTextMessageAsync(
                        chatId: message.Chat.Id,
                        text: "Barcha ma'lumotlar to'g'rimi?",
                        replyMarkup: await InlineKeyBoards.ForHaYuqButton(),
                        parseMode: ParseMode.Html,
                        cancellationToken: cancellationToken);

                    user.LastMessages = res.MessageId;
                    return;
            }
        }
        #endregion

        private async Task HandleRandomTextAsync(ITelegramBotClient client, Message message, CancellationToken cancellationToken)
        {
            var user = await _userService.GetUser(message.Chat.Id);

            if (user == null)
            {
                user = new UserModel()
                {
                    ChatId = message.Chat.Id,
                    Username = message.From.Username,
                    Status = Status.MainPage
                };
                await _userService.CreateUser(user);
            }

            switch (user.Status)
            {
                case Status.IshJoylash:
                    await HandleIshJoylashBotAsync(client, message, user, cancellationToken);
                    break;

                case Status.UstozKerak:
                    await HandleUstozKerakBotAsync(client, message, user, cancellationToken);
                    break;

                case Status.SherikKerak:
                    await HandleSherikKerakBotAsync(client, message, user, cancellationToken);
                    break;

                case Status.ShogirtKerak:
                    await HandleShogirtKerakBotAsync(client, message, user, cancellationToken);
                    break;

                case Status.RezumeJoylash:
                    await HandleRezumeJoylashBotAsync(client, message, user, cancellationToken);
                    break;

                case Status.MainPage:
                    var msg = await client.SendTextMessageAsync(
                        chatId: message.Chat.Id,
                        text: "<strong>Yo'nalishlar:\r\nYangi e'lon berish uchun yo'nalishni tanlang 👇</strong>\r\n• \"🏢 Ish joylash\" - ishchi topish uchun.\r\n• \"\U0001f9d1🏻‍💼 Rezyume joylash\" - ish topish uchun.\r\n• \"\U0001f9d1🏻 Shogirt kerak\" - shogirt topish uchun.\r\n• \"\U0001f9d1🏻‍🏫 Ustoz kerak\" - ustoz topish uchun.\r\n• \"🎗 Sherik kerak\" - sherik topish uchun.",
                        replyMarkup: await InlineKeyBoards.ForMainState(),
                        parseMode: ParseMode.Html,
                        cancellationToken: cancellationToken);
                    user.LastMessages = msg.MessageId;
                    user.Messages.Clear();
                    break;
            }
        }

        private async Task NoAdditionalInfo(ITelegramBotClient client, Message message, CancellationToken cancellationToken)
        {
            var user = await _userService.GetUser(message.Chat.Id);
            if (user == null)
            {
                Console.WriteLine("Undefined User");
                return;
            }


            user.Messages.Add("Yo'q");

            if (user.Status == Status.ShogirtKerak)
            {
                await HandleShogirtKerakBotAsync(client, message, user, cancellationToken);
            }
            else if (user.Status == Status.SherikKerak)
            {
                await HandleSherikKerakBotAsync(client, message, user, cancellationToken);
            }
            else if (user.Status == Status.RezumeJoylash)
            {

                await HandleRezumeJoylashBotAsync(client, message, user, cancellationToken);
            }
            else if (user.Status == Status.IshJoylash)
            {
                await HandleIshJoylashBotAsync(client, message, user, cancellationToken);
            }
            else if (user.Status == Status.UstozKerak)
            {
                await HandleUstozKerakBotAsync(client, message, user, cancellationToken);
            }
            return;
        }
    }
}
