using System;
using System.Collections.Generic;
using System.Text;

namespace PandemiC.Web.Repo
{
    public interface ISecurityService<T>
    {
        T Get();
    }
}
