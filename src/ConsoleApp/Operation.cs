using System;

namespace ConsoleApplication
{
    public interface IOperation
    {
        Guid OperationId { get; }
    }

    public interface IOperationTransient : IOperation
    {
    }
    public interface IOperationScoped : IOperation
    {
    }
    public interface IOperationSingleton : IOperation
    {
    }
    public interface IOperationSingletonInstance  : IOperation
    {
    }

    public class Operation: IOperationTransient, IOperationSingleton, IOperationScoped, IOperationSingletonInstance, IOperation
    {
        public Operation(): this(Guid.NewGuid())
        {
            
        }

        public Operation(Guid guid)
        {
            this.OperationId = guid;
        }

        public Guid OperationId
        {
            get;
            private set;
        }
    }

    public class OperationService
    {
        public IOperationTransient TransientOperation { get; }
        public IOperationScoped ScopedOperation { get; }
        public IOperationSingleton SingletonOperation { get; }
        public IOperationSingletonInstance SingletonInstanceOperation { get; }

        public OperationService(IOperationTransient transientOperation,
            IOperationScoped scopedOperation,
            IOperationSingleton singletonOperation,
            IOperationSingletonInstance instanceOperation)
        {
            TransientOperation = transientOperation;
            ScopedOperation = scopedOperation;
            SingletonOperation = singletonOperation;
            SingletonInstanceOperation = instanceOperation;
        }
    }
}