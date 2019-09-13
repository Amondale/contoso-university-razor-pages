using AutoMapper;
using ContosoUniversity.Infrastructure.DbContexts;
using System;
using Xunit;

namespace ContosoUniversity.Application.Tests.Infrastructure
{
    public class TestFixture : IDisposable
    {
        public SchoolContext Context { get; private set; }
        public IMapper Mapper { get; private set; }

        public TestFixture()
        {
            Context = SchoolContextFactory.Create();
            Mapper = AutoMapperFactory.Create();
        }

        public void Dispose()
        {
            SchoolContextFactory.Destroy(Context);
        }
    }

    [CollectionDefinition("QueryCollection")]
    public class QueryCollection : ICollectionFixture<TestFixture> { }
}
