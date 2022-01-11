using System;
using NUnit.Framework;

namespace MyCatsDemo.UnitTest
{
    public abstract class AbstractTest<T> where T : class
    {
        [SetUp]
        protected virtual void BeforeEachTest()
        {
            Imp = GetImp();
        }

        protected T Imp;

        protected abstract T GetImp();
    }
}
