using DFDSBooking.Domain.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DFDSBooking.Application
{
    public interface IQuery<T> : IRequest<Result<T>>
    {

    }
}
