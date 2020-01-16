using System;

namespace Cine.Modules.Movies.Api.Mongo.Documents
{
    [Flags]
    public enum Genre : byte
    {
        None,
        Action,
        Comedy,
        Drama,
        Fantasy,
        Thriller,
    }
}
