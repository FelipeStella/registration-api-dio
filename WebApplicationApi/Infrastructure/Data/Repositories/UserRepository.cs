﻿using WebApplicationAPI.Business.Entities;
using WebApplicationAPI.Infrastructure.Data.Repositories.Interfaces;

namespace WebApplicationAPI.Infrastructure.Data.Repositories
{
  public class UserRepository : IUserRepository
  {
    private readonly ApiDbContext _context;

    public UserRepository(ApiDbContext context)
    {
      _context = context;
    }

    public void Add(User user)
    {
      _context.User.Add(user);
      _context.SaveChanges();
    }

    public User Find(string username)
    {   
      return _context.User.FirstOrDefault(u => u.Name == username);
    }
  }
  
}
