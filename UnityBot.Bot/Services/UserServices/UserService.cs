using Microsoft.EntityFrameworkCore;
using Telegram.Bot.Types;
using UnityBot.Bot.Models.Entities;
using UnityBot.Bot.Models.Enums;
using UnityBot.Bot.Persistanse;

namespace UnityBot.Bot.Services.UserServices
{
    public class UserService : IUserService
    {
        private List<UserModel> _users;

        public UserService()
        {
            _users = new List<UserModel>();
        }

        public async Task ChangeStatus(long chatId, Status status)
        {
            var user = _users.FirstOrDefault(x => x.ChatId == chatId);
            if (user != null)
            {
                user.Status = status;
            }
            else
            {
                throw new Exception($"User with ChatId {chatId} not found.");
            }
        }

        public async Task  CreateUser(UserModel user)
        {
            _users.Add(user);
        }

        public async Task<UserModel> GetUser(long chatId)
        {
            var user = _users.FirstOrDefault(x => x.ChatId == chatId);
            return user;
        }

        public async Task IncIshJoylashCount(long ChatId)
        {
            var user = _users.FirstOrDefault(x => x.ChatId == ChatId);
            if (user != null)
            {
                user.IshJoylashCount += 1;
            }
        }

        public async Task IncRezumeCount(long ChatId)
        {
            var user = _users.FirstOrDefault(x => x.ChatId == ChatId);
            if (user != null)
            {
                user.RezumeCount += 1;
            }
        }

        public async Task IncSherikKerak(long ChatId)
        {
            var user = _users.FirstOrDefault(x => x.ChatId == ChatId);
            if (user != null)
            {
                user.SherikKerakCount += 1;
            }
        }

        public async Task IncShogirtKerakCount(long ChatId)
        {
            var user = _users.FirstOrDefault(x => x.ChatId == ChatId);
            if (user != null)
            {
                user.ShogirtKerakCount += 1;
            }
        }

        public async Task IncUstozKerak(long ChatId)
        {
            var user = _users.FirstOrDefault(x => x.ChatId == ChatId);
            if (user != null)
            {
                user.UstozkerakCount += 1;
            }
        }

        public async Task NolIshJoylashCount(long ChatId)
        {
            var user = _users.FirstOrDefault(x => x.ChatId == ChatId);
            if (user != null)
            {
                user.IshJoylashCount = 0;
            }
        }

        public async Task NolRuzumeCount(long ChatId)
        {
            var user = _users.FirstOrDefault(x => x.ChatId == ChatId);
            if (user != null)
            {
                user.RezumeCount = 0;
            }
        }

        public async Task NolSherikKerakCount(long ChatId)
        {
            var user = _users.FirstOrDefault(x => x.ChatId == ChatId);
            if (user != null)
            {
                user.SherikKerakCount = 0;
            }
        }

        public async Task NolShogirtKerakCount(long ChatId)
        {
            var user = _users.FirstOrDefault(x => x.ChatId == ChatId);
            if (user != null)
            {
                user.ShogirtKerakCount = 0;
            }
        }

        public async Task NolUstozKerakCount(long ChatId)
        {
            var user = _users.FirstOrDefault(x => x.ChatId == ChatId);
            if (user != null)
            {
                user.UstozkerakCount = 0;
            }
        }
    }
}
