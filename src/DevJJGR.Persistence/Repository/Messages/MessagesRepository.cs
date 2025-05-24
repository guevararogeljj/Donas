using Donouts.Application.Common.Interfaces;
using Donouts.Persistence.Common;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Donouts.Application.Dto.Messages;
using Donouts.Domain.Entities.Messages;

namespace Donouts.Persistance.Repository.Messages;

public class MessagesRepository :  Repository<MessagesChat>, IMessagesRepository
{
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;
    public MessagesRepository(ApplicationDbContext dbContext,
        ApplicationDbContext context, IMapper mapper) : base(dbContext)
    {
        this._context = context;
        this._mapper = mapper;
    }

    public async Task<IEnumerable<MessagesChatDTO>> GetAll(int PageNumber, int PageSize)
    {
        var data = await this._mapper.ProjectTo<MessagesChatDTO>(this._context.MessagesChats
                .Skip((PageNumber - 1) * PageSize)
                .Take(PageSize)
                .OrderBy(x=> x.CreatedAt)
                .AsNoTracking())
            .ToListAsync();
        return data;
    }

    public async Task<IEnumerable<MessagesChatDTO>> GetByIdAsync(int id)
    {
        var data = await  this._mapper.ProjectTo<MessagesChatDTO>(this._context.MessagesChats
                .Where(x => x.Id == id)
                .AsNoTracking())
            .ToListAsync();
        return data;
    }

    public async Task<bool> CreateMessage(string user, string content)
    {
        var message = new Domain.Entities.Messages.MessagesChat
        {
            User = user,
            Content = content,
            CreatedAt = DateTime.UtcNow
        };
        _context.MessagesChats.Add(message);
        return await _context.SaveChangesAsync() > 0;
    }

    public Task<bool> CreateMessageChat(string user, string content)
    {
        throw new NotImplementedException();
    }

    public Task<bool> CreateMessageGroup(string user, string content)
    {
        throw new NotImplementedException();
    }

    public Task<bool> CreateMessagePrivate(string user, string content)
    {
        throw new NotImplementedException();
    }

    public Task<bool> CreateMessageChannel(string user, string content)
    {
        throw new NotImplementedException();
    }
    
}