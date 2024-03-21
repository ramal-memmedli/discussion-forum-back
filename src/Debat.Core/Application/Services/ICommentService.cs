using Debat.Core.Domain.Entities;
using Debat.Core.Domain.Models.Abstract;

namespace Debat.Core.Application.Services;

public interface ICommentService : IBaseService<Comment>
{
    Task<List<Comment>> GetAllByAnswerId(int id);
}