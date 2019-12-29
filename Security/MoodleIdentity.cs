using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;

namespace Moodle.Security
{
    public class MoodleIdentity: IIdentity
    {

            private string userid;

            private string password;



            public MoodleIdentity(string currentuserid, string currentpassword)
            {
                userid = currentuserid;
                password = currentpassword;
            }



            private bool canpass()
            {
                //这里朋友们可以根据自己的需要改为从数据库中验证用户名和密码， 
                //这里为了方便我直接指定的字符串 
                if (userid == "Admin" && password == "Admin")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }



            public string Password
            {
                get
                {
                    return password;
                }

                set
                {
                    password = value;
                }
            }



            #region iidentity 成员 



            public bool IsAuthenticated

            {

                get

                {

                    // todo: 添加 myidentity.isauthenticated getter 实现 

                    return canpass();

                }

            }



            public string Name

            {

                get

                {

                    // todo: 添加 myidentity.name getter 实现 

                    return userid;

                }

            }



            //这个属性我们可以根据自己的需要来灵活使用,在本例中没有用到它 

            public string AuthenticationType

            {

                get

                {

                    // todo: 添加 myidentity.authenticationtype getter 实现 

                    return null;

                }

            }



            #endregion

        }
    }