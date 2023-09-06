using DFDSBooking.Domain.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DFDSBooking.Application
{
    public interface ICommandHandler<TCommand>
        : IRequestHandler<TCommand, Result> where TCommand : ICommand
    {
        new Task<Result> Handle(TCommand command, CancellationToken cancellationToken = default);

    }
}
