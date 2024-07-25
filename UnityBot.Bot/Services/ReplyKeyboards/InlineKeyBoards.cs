using Telegram.Bot.Types.ReplyMarkups;

namespace UnityBot.Bot.Services.ReplyKeyboards
{
    public class InlineKeyBoards
    {
        public static Task<InlineKeyboardMarkup> ForMainState()
        {
            List<List<InlineKeyboardButton>> inlineKeyboardButtons = new List<List<InlineKeyboardButton>>
            {
                new List<InlineKeyboardButton>
                {
                    InlineKeyboardButton.WithCallbackData("🏢 Ish joylash", "ish_joylash"),
                    InlineKeyboardButton.WithCallbackData("🧑🏻‍💼 Rezyume joylash", "rezyume_joylash"),
                },
                new List<InlineKeyboardButton>
                {
                    InlineKeyboardButton.WithCallbackData("🧑🏻 Shogirt kerak", "shogirt_kerak"),
                    InlineKeyboardButton.WithCallbackData("🧑🏻‍🏫 Ustoz kerak", "ustoz_kerak"),
                },
                new List<InlineKeyboardButton>
                {
                    InlineKeyboardButton.WithCallbackData("🎗 Sherik kerak", "sherik_kerak"),
                },
            };

            InlineKeyboardMarkup inlineKeyboardMarkup = new InlineKeyboardMarkup(inlineKeyboardButtons);
            return Task.FromResult(inlineKeyboardMarkup);
        }

        public static Task<InlineKeyboardMarkup> ForConfirmation()
        {
            List<List<InlineKeyboardButton>> inlineKeyboardButtons = new List<List<InlineKeyboardButton>>{
            new List<InlineKeyboardButton>
            {
                InlineKeyboardButton.WithCallbackData("✅ E'lonni joylash", "togrri"),
                InlineKeyboardButton.WithCallbackData("❌ Bekor qilish", "notogrri"),
            }
        };


            InlineKeyboardMarkup inlineKeyboardMarkup = new InlineKeyboardMarkup(inlineKeyboardButtons);
            return Task.FromResult(inlineKeyboardMarkup);
        }
        
        public static Task<InlineKeyboardMarkup> ActualConfirmation()
        {
            List<List<InlineKeyboardButton>> inlineKeyboardButtons = new List<List<InlineKeyboardButton>>{
                new List<InlineKeyboardButton>
                {
                    InlineKeyboardButton.WithCallbackData("✅ E'lonni joylash", "adminT"),
                    InlineKeyboardButton.WithCallbackData("❌ Bekor qilish", "adminF"),
                }
            };


            InlineKeyboardMarkup inlineKeyboardMarkup = new InlineKeyboardMarkup(inlineKeyboardButtons);
            return Task.FromResult(inlineKeyboardMarkup);
        }
        
        
        public static InlineKeyboardMarkup ForAdminReview()
        {
            return new InlineKeyboardMarkup(new[]
            {
                new[]
                {
                    InlineKeyboardButton.WithCallbackData("✅ Tasdiqlash", "admintrue"),
                    InlineKeyboardButton.WithCallbackData("❌ Rad etish", "adminfalse")
                }
            });
        }


        public static Task<InlineKeyboardMarkup> ForHaYuqButton()
        {
            List<List<InlineKeyboardButton>> inlineKeyboardButtons = new List<List<InlineKeyboardButton>>{
            new List<InlineKeyboardButton>
            {
                InlineKeyboardButton.WithCallbackData("✅ To’g’ri", "hatextcorrect"),
                InlineKeyboardButton.WithCallbackData("❌ Noto’g’ri", "yoqtextincorrect"),
            }
        };


            InlineKeyboardMarkup inlineKeyboardMarkup = new InlineKeyboardMarkup(inlineKeyboardButtons);
            return Task.FromResult(inlineKeyboardMarkup);
        }

        public static Task<InlineKeyboardMarkup> AdminButtons()
        {
            List<List<InlineKeyboardButton>> inlineKeyboardButtons = new List<List<InlineKeyboardButton>>
            {
                new List<InlineKeyboardButton>
                {
                    new InlineKeyboardButton("Tasdiqlash") { CallbackData = $"approve_" },
                    new InlineKeyboardButton("Rad etish") { CallbackData = $"reject_" }
                }
            };
            
            InlineKeyboardMarkup inlineKeyboardMarkup = new InlineKeyboardMarkup(inlineKeyboardButtons);
            return Task.FromResult(inlineKeyboardMarkup);
        }

        public static Task<InlineKeyboardMarkup> ForSendToChanel()
        {
            List<List<InlineKeyboardButton>> inlineKeyboardButtons = new List<List<InlineKeyboardButton>>{
            new List<InlineKeyboardButton>
            {
                InlineKeyboardButton.WithCallbackData("✅Elonni Joylash", "joyla"),
                InlineKeyboardButton.WithCallbackData("❌ O'tkazib yuboarish", "skip"),
            }
        };

            InlineKeyboardMarkup inlineKeyboardMarkup = new InlineKeyboardMarkup(inlineKeyboardButtons);
            return Task.FromResult(inlineKeyboardMarkup);
        }
        public static Task<InlineKeyboardMarkup> AdditionalInfo()
        {
            List<List<InlineKeyboardButton>> inlineKeyboardButtons = new List<List<InlineKeyboardButton>>{
            new List<InlineKeyboardButton>
            {
                InlineKeyboardButton.WithCallbackData("Qo'shimcha ma'lumotlar yo'q", "noinfo"),
            }
        };

            InlineKeyboardMarkup inlineKeyboardMarkup = new InlineKeyboardMarkup(inlineKeyboardButtons);
            return Task.FromResult(inlineKeyboardMarkup);
        }
        public static Task<InlineKeyboardMarkup> ForTalaba()
        {
            List<List<InlineKeyboardButton>> inlineKeyboardButtons = new List<List<InlineKeyboardButton>>{
            new List<InlineKeyboardButton>
            {
                InlineKeyboardButton.WithCallbackData("Ha", "talabaekan"),
                InlineKeyboardButton.WithCallbackData("Yo'q", "talabaemas"),
            }
        };

            InlineKeyboardMarkup inlineKeyboardMarkup = new InlineKeyboardMarkup(inlineKeyboardButtons);
            return Task.FromResult(inlineKeyboardMarkup);
        }
    }
}
