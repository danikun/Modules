using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Module.A.Domain;
using Module.A.Infrastructure;

namespace Module.A.Application
{
    public record GetEntities : IRequest<IEnumerable<ModuleAEntity>>;

    public class GetEntitiesHandler : IRequestHandler<GetEntities, IEnumerable<ModuleAEntity>>
    {
        private readonly ModuleAContext _context;

        public GetEntitiesHandler(ModuleAContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ModuleAEntity>> Handle(GetEntities request, CancellationToken cancellationToken)
        {
            return await _context
                .Set<ModuleAEntity>()
                .ToListAsync(cancellationToken);
        }
    }
}