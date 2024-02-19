using CommuPoint.Core.Domain.Entities;
using CommuPoint.Core.Domain.Models.Abstract;

namespace CommuPoint.Core.Application.Services
{
    public interface ICommentService : IBaseService<Comment>
    {
        Task<List<Comment>> GetAllByAnswerId(int id);
    }
}
