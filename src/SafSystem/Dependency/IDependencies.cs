namespace Ataoge.Dependency
{
    /// <summary>
    /// All classes implement this interface are automatically registered to dependency injection as transient object.
    /// </summary>
    public interface ITransientDependency
    {

    }

    /// <summary>
    /// All classes implement this interface are automatically registered to dependency injection as scoped object.
    /// </summary>
    public interface IScopedDependency
    {

    }

    /// <summary>
    /// All classes implement this interface are automatically registered to dependency injection as singleton object.
    /// </summary>
    public interface ISingletonDependency
    {

    }
}