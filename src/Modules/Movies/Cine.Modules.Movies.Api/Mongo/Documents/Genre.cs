using System;

namespace Cine.Modules.Movies.Api.Mongo.Documents
{
    [Flags]
    public enum Genre : byte
    {
        None = 0,
        Action = 1 << 1,
        Comedy = 1 << 2,
        Drama = 1 << 3,
        Fantasy = 1 << 4,
        Thriller = 1 << 5
    }
}
