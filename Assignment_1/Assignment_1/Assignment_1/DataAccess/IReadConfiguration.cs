using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment_1.DataAccess
{
    public interface IReadConfiguration
    {
        string GetConnectionString(string configName);
    }
}
