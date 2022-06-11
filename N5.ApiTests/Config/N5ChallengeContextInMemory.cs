using Microsoft.EntityFrameworkCore;
using N5.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N5.ApiTests.Config
{
    public static class N5ChallengeContextInMemory
    {
        public static N5ChallengeContext Get()
        {
            var options = new DbContextOptionsBuilder<N5ChallengeContext>()
                .UseSqlServer("Server=.;Database=N5Challenge;Trusted_Connection=True;").Options;

            return new N5ChallengeContext(options);
        }
    }
}
