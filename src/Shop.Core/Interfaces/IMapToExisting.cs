namespace Shop.Core.Interfaces
{
    public interface IMapToExisting<in TSource, in TTarget>
    {
        bool Map(TSource source, TTarget target);
    }
}