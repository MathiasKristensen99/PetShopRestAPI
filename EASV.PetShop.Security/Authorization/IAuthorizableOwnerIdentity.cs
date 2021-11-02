namespace EASV.PetShop.Security.Authorization
{
    public interface IAuthorizableOwnerIdentity
    {
        long GetAuthorizedOwnerId();
        string GetAuthorizedOwnerName();
    }
}