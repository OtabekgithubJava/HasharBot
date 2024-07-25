using Telegram.Bot.Types;
using UnityBot.Bot.Models.Entities;
using UnityBot.Bot.Models.Enums;

namespace UnityBot.Bot.Services.UserServices
{
    public interface IUserService
    {
        Task CreateUser(UserModel user);
        Task<UserModel> GetUser(long ChatId);
        Task ChangeStatus(long ChatId, Status st);
        Task IncIshJoylashCount(long ChatId);
        Task IncShogirtKerakCount(long ChatId);
        Task IncSherikKerak(long ChatId);
        Task IncRezumeCount(long ChatId);
        Task IncUstozKerak(long ChatId);
        Task NolIshJoylashCount(long ChatId);
        Task NolShogirtKerakCount(long ChatId);
        Task NolSherikKerakCount(long ChatId);
        Task NolRuzumeCount(long ChatId);
        Task NolUstozKerakCount(long ChatId);
    }
}
