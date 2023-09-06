using DFDSBooking.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DFDSBooking.Application
{
    public interface IDispatcher
    {
        Task<Result<T>> Dispatch<T>(IQuery<T> query);
        Task<Result> Dispatch(ICommand command);
    }
}
