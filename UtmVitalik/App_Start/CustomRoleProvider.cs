using System;
using System.Collections.Specialized;
using System.Linq;
using System.Web.Security;
using UtmVitalik.BusinessLogic.DB;

public class CustomRoleProvider : RoleProvider
{
    private ApplicationContext db = new ApplicationContext(); // Обновите это, чтобы соответствовать вашему контексту базы данных
 
    public override string ApplicationName { get; set; }

    public override void Initialize(string name, NameValueCollection config)
    {
        if (config == null)
            throw new ArgumentNullException("config");

        if (string.IsNullOrEmpty(name))
            name = "CustomRoleProvider";

        if (string.IsNullOrEmpty(config["description"]))
        {
            config.Remove("description");
            config.Add("description", "Custom Role Provider");
        }

        base.Initialize(name, config);

        ApplicationName = config["applicationName"] ?? "/";
    }

    public override bool IsUserInRole(string username, string roleName)
    {
        var user = db.Actor.FirstOrDefault(u => u.Email == username);
        return user != null && user.Role.Equals(roleName, StringComparison.InvariantCultureIgnoreCase);
    }

    public override string[] GetRolesForUser(string username)
    {
        var user = db.Actor.FirstOrDefault(u => u.Email == username);
        return user != null ? new[] { user.Role } : new string[] { };
    }

    public override void CreateRole(string roleName)
    {
        throw new NotImplementedException();
    }

    public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
    {
        throw new NotImplementedException();
    }

    public override bool RoleExists(string roleName)
    {
        throw new NotImplementedException();
    }

    public override void AddUsersToRoles(string[] usernames, string[] roleNames)
    {
        throw new NotImplementedException();
    }

    public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
    {
        throw new NotImplementedException();
    }

    public override string[] GetUsersInRole(string roleName)
    {
        throw new NotImplementedException();
    }

    public override string[] GetAllRoles()
    {
        throw new NotImplementedException();
    }

    public override string[] FindUsersInRole(string roleName, string usernameToMatch)
    {
        throw new NotImplementedException();
    }
}
