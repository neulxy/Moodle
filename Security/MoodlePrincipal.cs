using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;

namespace Moodle.Security
{
    public class MoodlePrincipal: IPrincipal
    {
        private IIdentity identity;
        private ArrayList rolelist;


        public MoodlePrincipal(string userid, string password)
        {
            identity = new MoodleIdentity(userid, password);

            if (identity.IsAuthenticated)
            {

                //如果通过验证则获取该用户的role，这里可以修改为从数据库中 

                //读取指定用户的role并将其添加到role中，本例中直接为用户添加一个admin角色 

                rolelist = new ArrayList();

                //rolelist.Add("Admin");

            }

            else

            {

                // do nothing 

            }

        }



        public ArrayList RoleList
        {
            get
            {
                return rolelist;
            }

            set
            {
                rolelist = value;
            }
        }

        #region iprincipal 成员 



        public IIdentity Identity
        {
            get
            {
                // todo: 添加 myprincipal.identity getter 实现 
                return identity;
            }

            set
            {
                identity = value;
            }
        }



        public bool IsInRole(string role)
        {
            // todo: 添加 myprincipal.isinrole 实现 
            return rolelist.Contains(role); ;
        }



        #endregion

    }
}
