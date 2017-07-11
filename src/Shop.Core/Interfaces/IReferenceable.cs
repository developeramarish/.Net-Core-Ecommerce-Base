namespace Shop.Core.Interfaces
{
    public interface IReferenceable<out T>
    {
        T CreateReference(IReferenceGenerator referenceGenerator);
    }

}