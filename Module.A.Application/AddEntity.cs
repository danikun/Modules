using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Module.A.Domain;
using Module.A.Infrastructure;

namespace Module.A.Application
{
    public record AddEntity(string Name) : IRequest;

    public class AddEntityHandler : IRequestHandler<AddEntity>
    {
        private ModuleAContext _context;

        public AddEntityHandler(ModuleAContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(AddEntity request, CancellationToken cancellationToken)
        {
            _context.Set<ModuleAEntity>().Add(new ModuleAEntity {Name = request.Name});
            await _context.SaveChangesAsync(cancellationToken);
            
            return Unit.Value;
        }
    }
}