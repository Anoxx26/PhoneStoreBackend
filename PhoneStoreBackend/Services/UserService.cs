﻿using PhoneStoreBackend.Repositories;

namespace PhoneStoreBackend.Services
{
    public class UserService
    {
        private readonly UserRepository _userRepository;

        public UserService(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }
    }
}