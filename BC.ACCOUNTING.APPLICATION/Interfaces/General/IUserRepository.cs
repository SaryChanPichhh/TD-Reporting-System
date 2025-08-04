using BC.ACCOUNTING.CORE.DTO.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BC.ACCOUNTING.CORE.DTO.Login;
using BC.ACCOUNTING.CORE.Entities;

namespace BC.ACCOUNTING.APPLICATION.Interfaces.General
{
    public interface IUserRepository
    {
        public Task<User> GetBcUserCredential(LoginRequestDTO requestDto);
        public Task<User> GetUserByIdAsync(ContextDTO contextDto);
        public Task<string> GetUserForOTP(string username);

    }
}
