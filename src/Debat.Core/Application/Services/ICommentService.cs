using Debat.Core.Domain.Entities;

namespace Debat.Core.Application.Services;

public interface ICommentService : IBaseService<Comment>
{
    Task<List<Comment>> GetAllByAnswerId(int id);
}