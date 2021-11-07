using System;

namespace team_double_trouble_backend.Authorization
{
    //Attribute allows access to a specified action method in the controller, used for giving unauthorized users access to the register and login actions
    [AttributeUsage(AttributeTargets.Method)]
    public class AllowAnonymousAttribute : Attribute
    { }
}