using PrjBase.Data;
using PrjBase.Models;
using Microsoft.EntityFrameworkCore;

namespace PrjBase.Services;

public interface IUserService
{
    Task<User?> ValidateUserAsync(string username, string password);
    Task<bool> UserExistsAsync(string username);
    Task<User> CreateUserAsync(string username, string password, string role);
}

public class UserService : IUserService
{
    private readonly AppDbContext _context;

    public UserService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<User?> ValidateUserAsync(string username, string password)
    {
        var user = await _context.Users.FirstOrDefaultAsync(u => u.Username == username);
        if (user is null)
            return null;

        return PasswordHasher.VerifyPassword(password, user.PasswordHash, user.PasswordSalt)
            ? user
            : null;
    }

    public async Task<bool> UserExistsAsync(string username) =>
        await _context.Users.AnyAsync(u => u.Username == username);

    public async Task<User> CreateUserAsync(string username, string password, string role)
    {
        var (hash, salt) = PasswordHasher.HashPassword(password);

        var user = new User
        {
            Username = username,
            PasswordHash = hash,
            PasswordSalt = salt,
            Role = role
        };

        _context.Users.Add(user);
        await _context.SaveChangesAsync();

        return user;
    }
}
