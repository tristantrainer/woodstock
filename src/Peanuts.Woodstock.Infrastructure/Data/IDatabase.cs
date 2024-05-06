using System.Collections;

namespace Peanuts.Woodstock.Infrastructure.Data;

public class DbTable<TRecord> : IEnumerable<TRecord>
{


    public IEnumerator<TRecord> GetEnumerator()
    {
        throw new NotImplementedException();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        throw new NotImplementedException();
    }
}
