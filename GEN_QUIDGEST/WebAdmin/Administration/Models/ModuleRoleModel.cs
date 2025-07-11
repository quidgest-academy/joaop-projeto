
using CSGenio.framework;
using System.Collections.Generic;
using System.Linq;

namespace Administration.Models
{
    public class ModuleRoleModel : ModelBase
    {
        public string Module { get;  set; }
        public string Designation { get; set; }
        public string Description { get; set; }
        public string Role { get; set; }

        public static bool IsInModule(Role role, string module)
        {
            return ALL_MODULE_ROLES.Any(mr => mr.Role == role.Id && mr.Module == module);
        }

        public static ModuleRoleModel GetRole(string module, string role, int level = 0)
        {
            //If the role is empty get the level. This means it was set by backoffice
            if (string.IsNullOrEmpty(role))
                role = level.ToString();
            return ALL_MODULE_ROLES.Find(x => x.Module == module && x.Role == role);
        }

        public static List<ModuleRoleModel> ALL_MODULE_ROLES { get; } = new List<ModuleRoleModel>()
        {
            new ModuleRoleModel() {
                Role = "20",
                Designation = "CONSULTA40695",
                Description = "",              
                Module = "AJF"
            },
            new ModuleRoleModel() {
                Role = "40",
                Designation = "AGENT00994",
                Description = "",              
                Module = "AJF"
            },
            new ModuleRoleModel() {
                Role = "50",
                Designation = "PLAYER57424",
                Description = "",              
                Module = "AJF"
            },
            new ModuleRoleModel() {
                Role = "70",
                Designation = "DEVELOPER60750",
                Description = "",              
                Module = "AJF"
            },
            new ModuleRoleModel() {
                Role = "99",
                Designation = "ADMINISTRADOR57294",
                Description = "",              
                Module = "AJF"
            }
        };
    }
}