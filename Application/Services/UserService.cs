// using Application.Abstractions.Services;
// using Application.Dto.Users;
// using Domain.Users;
//
// namespace Application.Services;
//
// internal sealed class UserService : IUserService
// {
//     private readonly AppDbContext _context;
//
//     public UserService(AppDbContext context)
//     {
//         _context = context;
//     }
//
//     public Guid CreateUser(UserDto dto)
//     {
//         // TODO: Dodać sprawdzenie czy Username już nie istnieje w bazie
//
//         var user = User.Create(dto.Username, dto.BirthDate);
//
//         _context.Users.Add(user);
//         _context.SaveChanges();
//
//         return user.Id;
//     }
// }