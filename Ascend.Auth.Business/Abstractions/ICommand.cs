using MediatR;

namespace Ascend.Auth.Business.Abstractions;

public interface IBaseCommand { }

public interface ICommand : IRequest<Unit>, IBaseCommand { }

public interface ICommand<TResponse> : IRequest<TResponse>, IBaseCommand { }

public interface IQuery<TResponse> : IRequest<TResponse> { }
