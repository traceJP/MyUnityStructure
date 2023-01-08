using Role.Entities;
using UnityEngine;

namespace Role
{
    
    /// <summary>
    ///  角色管理器
    ///
    /// 用户生成各种角色，如玩家，怪物等角色
    /// </summary>
    public class RoleManager
    {

        private RoleEntity _rolePrefab;

        public void Init(RoleEntity rolePrefab)
        {
            this._rolePrefab = rolePrefab;
        }
        
        
        public RoleEntity SpawnRole()
        {
            RoleEntity role = GameObject.Instantiate(_rolePrefab);
            return role;
        }


    }
}