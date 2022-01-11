using System;
using System.Threading.Tasks;

namespace MyCatsDemo.Services.Interfaces
{
    public interface IAsyncUseCase<TArguments, TResult>
    {
        Task<TResult> Execute(TArguments args);
    }

    public abstract class AsyncUseCase<TArguments, TResult> : IAsyncUseCase<TArguments, TResult>
    {
        public abstract Task<TResult> Execute(TArguments args);
    }
}
