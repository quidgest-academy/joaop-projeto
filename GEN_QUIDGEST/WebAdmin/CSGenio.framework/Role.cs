using System;
using System.Collections.Generic;
using System.Linq;

namespace CSGenio.framework
{

    public enum RoleType {
        LEVEL,
        ROLE,
        SYSTEM
    }

	public class Role
	{
		//Access Levels
        public static readonly Role UNAUTHORIZED;
        public static readonly Role ADMINISTRATION;
        public static readonly Role AUTHORIZED;
        public static readonly Role INVALID;

        public static readonly Role ROLE_20; //Consulta
        public static readonly Role ROLE_40; //Agent
        public static readonly Role ROLE_50; //Player
        public static readonly Role ROLE_70; //Developer
        //Roles

        public static readonly Dictionary<string, Role> ALL_ROLES = new Dictionary<string, Role>();

		private readonly List<Role> directSubRoles;
        private List<Role> allSubRoles;
        private readonly LevelAccess level;

        public RoleType Type
        {
            get;
        }

        public List<string> AvaiableModules
        {
            get; private set;
        }

		public Role(RoleType type, string title, params Role[] subRoles)
        {
            directSubRoles = new List<Role>(subRoles);
            Type = type;
			Title = title;
        }

        public Role(LevelAccess level, string title, params Role[] subRoles)
        {
            directSubRoles = new List<Role>(subRoles);
            Type = RoleType.LEVEL;
            this.level = level;
			Title = title;
        }

		static Role()
		{
            //Hardcoded role to represent admin priviliges
            ADMINISTRATION = new Role(RoleType.SYSTEM, "ADMINISTRADOR57294");
            //Hardcoded role to represent unauthorized access. This can also be interpreted as the public access
            UNAUTHORIZED = new Role(RoleType.SYSTEM, "DESAUTORIZADO34584");
            //A role that is below every role except unauthorized. Used when no role was definied in an item.
            AUTHORIZED = new Role(RoleType.SYSTEM, "AUTORIZADO16093");
            //Represents an invalid role
            INVALID = new Role(RoleType.SYSTEM, "INVALID40876");

            //Create all roles
            ROLE_20 = new Role(LevelAccess.NV20, "CONSULTA40695");
            ALL_ROLES.Add("20", ROLE_20);

            ROLE_40 = new Role(LevelAccess.NV40, "AGENT00994");
            ALL_ROLES.Add("40", ROLE_40);

            ROLE_50 = new Role(LevelAccess.NV50, "PLAYER57424");
            ALL_ROLES.Add("50", ROLE_50);

            ROLE_70 = new Role(LevelAccess.NV70, "DEVELOPER60750");
            ALL_ROLES.Add("70", ROLE_70);

            //These roles are hardcoded and have these values for backwards compatibility reasons
            ALL_ROLES.Add("0", UNAUTHORIZED);
            ALL_ROLES.Add("99", ADMINISTRATION);
            ALL_ROLES.Add("SYSTEM_AUTHORIZED", AUTHORIZED);

            //Add subroles

			UNAUTHORIZED.Add(ROLE_20);
			UNAUTHORIZED.Add(ROLE_40);
			UNAUTHORIZED.Add(ROLE_50);
			UNAUTHORIZED.Add(ROLE_70);
			UNAUTHORIZED.Add(ADMINISTRATION);
			ROLE_20.Add(ROLE_40);
			ROLE_20.Add(ROLE_50);
			ROLE_20.Add(ROLE_70);
			ROLE_20.Add(ADMINISTRATION);
			ROLE_40.Add(ROLE_50);
			ROLE_40.Add(ROLE_70);
			ROLE_40.Add(ADMINISTRATION);
			ROLE_50.Add(ROLE_70);
			ROLE_50.Add(ADMINISTRATION);
			ROLE_70.Add(ADMINISTRATION);

			foreach(Role role in ALL_ROLES.Values)
				role.FlattenRole();
        }

		private void FlattenRole()
        {
            if (allSubRoles == null)
            {
                allSubRoles = new List<Role>();
                allSubRoles.Add(this);

                foreach (Role child in directSubRoles)
                {
                    allSubRoles.Add(child);

                    if (child.Type == RoleType.LEVEL)
                        continue;

                    child.FlattenRole();
                    allSubRoles.AddRange(child.allSubRoles.Where(x => !allSubRoles.Contains(x)));
                }
            }
        }

        private void Add(Role role)
        {
            directSubRoles.Add(role);
        }

        public string Id
        {
            get
            {
                return ALL_ROLES.First(p=>p.Value == this).Key;
            }
        }

		public string Title { get; private set; }

        public bool IsAdmin
        {
            get { return ADMINISTRATION.HasRole(this); }
        }

        /// <summary>
        /// Returns a list of all roles that have permissions to do whatever this role can. It includes the role itself.
        /// </summary>
        public List<Role> AllRolesAbove()
        {
            return allSubRoles;
        }

		/// <summary>
        /// Returns a list of all roles below this role. It includes the role itself.
        /// </summary>
        public List<Role> AllRolesBelow()
        {
            IEnumerable<Role> rolesBelow = (from Role role in ALL_ROLES.Values
                                     where role.directSubRoles.Contains(this)
                                     select role).ToList();

            List<Role> allRolesBelow = new List<Role>(rolesBelow);

            // Recursive
            foreach (var role in rolesBelow)
                foreach(Role roleBelow in role.AllRolesBelow())
                    if (!allRolesBelow.Contains(roleBelow))
                        allRolesBelow.Add(roleBelow);

            // Add the role itself
            if (!allRolesBelow.Contains(this))
                allRolesBelow.Add(this);

            return allRolesBelow;
        }

        /// <summary>
        /// Checks if role @other is in the hierarchy above this role.
        /// For example ROLE_3.HasRole(ROLE_4) should return true
        /// </summary>
		public bool HasRole(Role other)
        {
            //First check system roles
            if (this == INVALID || other == INVALID)//Check invalid roles
                return false;
            else if (this == UNAUTHORIZED) //Unauthorized is below everything
                return true;
            else if(this == AUTHORIZED) //Authorized is below everything except Unauthorized
                return other != UNAUTHORIZED;
            else if(other == ADMINISTRATION && this.Type != RoleType.ROLE) //Administration is above all levels
                return true;

            return this.allSubRoles.Contains(other);
        }

        public bool HasRole(string other)
        {
            Role otherRole = GetRole(other);
            return HasRole(otherRole);
        }

        public bool HasLevel(LevelAccess levelAccess)
        {
            return this.allSubRoles.Contains(GetRole(levelAccess));
        }

        public int GetLevelInt()
        {
            if (Type == RoleType.LEVEL)
                return level.LevelValue;
            else if (this == Role.ADMINISTRATION)
                return 99;
            else if (this == Role.UNAUTHORIZED)
                return 0;
            else
                throw new InvalidOperationException();
        }

        public static Role GetRole(LevelAccess levelAccess)
        {
            return ALL_ROLES.Values.First(x => x.level == levelAccess);
        }

        /// <summary>
        /// Returns a role with the specified id. If it doesn't exist returns UNAUTHORIZED role
        /// </summary>
        public static Role GetRole(string roleId)
        {
            if (ALL_ROLES.TryGetValue(roleId?.Trim(), out Role result))
                return result;
            return INVALID;
        }

        /// <summary>
        /// Returns the role ID
        /// </summary>
        public override string ToString()
        {
            return this.Id;
        }
	}
}
