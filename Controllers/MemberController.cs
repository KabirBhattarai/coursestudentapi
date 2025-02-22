using efcore.Data;
using efcore.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace efcore.Controllers;

[Route("api/[controller]")]
public class MemberController : ControllerBase
{
    private readonly EfcoreDbContext _context;

    public MemberController(EfcoreDbContext context)
    {
        _context = context;
        
    }

    [HttpGet]
    public async Task<IActionResult> GetMembers()
    {
        var member = new Member
        {
            Name = "John Doe",
            Email = "johndoe@gmail.com",
            Phone = "123456789",
            Address = "123 Main Street"

        };
        await _context.Members.AddAsync(member);
        await _context.SaveChangesAsync();
        
        var members = await _context.Members.ToListAsync();
        return Ok(members);
    }
    
}