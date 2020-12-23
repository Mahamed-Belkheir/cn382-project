using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CN382_Project.exceptions
{
    public class NotFound: Exception
    {
        public NotFound(string item): base(item + " not found")
        {
        }

    }

    public class NotPermitted: Exception
    {
        public NotPermitted(string reason): base(reason) 
        {
        }

    }
}