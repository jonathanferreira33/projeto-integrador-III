using PI.Domain;
using PI.Domain.Entities;

namespace PI.CrossCutting.Auth
{
    public class AuthBusiness
    {
        public AuthBusiness()
        {

        }

        public bool Login(UserEntity u)
        {
            return true;
        }

        public bool LogOut(UserEntity u)
        {
            return true;
        }

    }
}
