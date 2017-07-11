namespace Shop.Core.Interfaces
{
    public interface IReferenceGenerator
    {
        string CreateReference(int size);
        string CreateReference(string prefix, int size);
    }
}