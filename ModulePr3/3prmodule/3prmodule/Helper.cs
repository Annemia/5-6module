using _3prmodule.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3prmodule
{
    internal class Helper
    {
        private static BuildingBaseEntities _context;
        public static BuildingBaseEntities GetContext()
        {
            if (_context == null)
                _context = new BuildingBaseEntities();
            return _context;
        }
    }
}
