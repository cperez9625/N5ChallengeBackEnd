using Microsoft.EntityFrameworkCore;
using N5.Data;

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
