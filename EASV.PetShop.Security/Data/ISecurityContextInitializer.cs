namespace EASV.PetShop.Security.Data
{
    public interface ISecurityContextInitializer
    {
        void Initialize(SecurityContext context);
    }
}