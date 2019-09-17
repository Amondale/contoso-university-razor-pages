//using System;
//using AutoMapper;
//using ContosoUniversity.Infrastructure.DbContexts;
//using Xunit;

//namespace ContosoUniversity.Infrastructure.Tests.Infrastructure
//{
//    public class TestFixture : IDisposable
//    {
//        public SchoolContext Context { get; private set; }
//        public IMapper Mapper { get; private set; }

//        public TestFixture()
//        {
//            //Context = SchoolContextFactory.Create();
//            //Mapper = AutoMapperFactory.Create();
//        }

//        public void Dispose()
//        {
//            //SchoolContextFactory.Destroy(Context);
//        }
//    }

//    [CollectionDefinition("QueryCollection")]
//    public class QueryCollection : ICollectionFixture<TestFixture> { }
//}
