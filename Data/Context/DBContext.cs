using Data.Entites;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Context
{
    public partial class DBContext: IdentityDbContext<User>
    {
    }
}
