using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment_5.DataAccess
{
    public interface IReadConfiguration
    {
        string GetConnectionString(string configName);
    }
}

