using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ServerME.Models;

namespace ServerME.Data
{
    public class AuthorizationRepository
    {
        public List<User> GetUsers()
        {
            using (var dbContext = new Context())
            {
                return dbContext.Users
                    .Include(p => p.Role)
                    .Include(p => p.Organization.TypeOrganization)
                    .Include(p => p.Organization.Locality.Municipality)
                    .ToList();
            }

        }
    }
}
