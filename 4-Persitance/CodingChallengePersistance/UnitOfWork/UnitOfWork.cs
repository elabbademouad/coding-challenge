using CodingChallengeBusiness.Interfaces;
using CodingChallengePersistance.Context;
using CodingChallengePersistance.Repositories;
using Microsoft.Extensions.Configuration;

namespace CodingChallengePersistance
{
    public class UnitOfWork : IUnitOfWork
    {
        private IUserRepository _userRepository;
        private IUserShopPreferenceRepository _userShopPreference;
        private IShopRepository _shopRepository;
        private DataContext _context;
        public UnitOfWork(IConfiguration config)
        {
            _context = new DataContext(config["DataBaseSettings:ConnectionsString"]);
        }
        public UnitOfWork()
        {
            _context = new DataContext();
        }
        public IUserRepository UserRepository
        {
            get
            {
                if (_userRepository == null)
                {
                    _userRepository = new UserRepository(_context);
                }
                return _userRepository;
            }
        }

        public IShopRepository ShopRepository
        {
            get
            {
                if (_shopRepository == null)
                {
                    _shopRepository = new ShopRepository(_context);
                }
                return _shopRepository;
            }
        }
        public IUserShopPreferenceRepository UserShopPreferenceRepository
        {
            get
            {
                if (_userShopPreference == null)
                {
                    _userShopPreference = new UserShopPreferenceRepository(_context);
                }
                return _userShopPreference;
            }
        }
    }
}