using System.Threading.Tasks;

using Moq.AutoMock;

namespace SystemUnderTestUnitTesting {
    public class UnderTest<TClass> where TClass : class {
        protected AutoMocker AutoMocker = new();
        protected TClass SystemUnderTest;

        public UnderTest(bool enablePrivate = default) {
            Setup();
            SetupAsync().Wait();

            SystemUnderTest = AutoMocker.CreateInstance<TClass>(enablePrivate);

            Arrange();
            ArrangeAsync().Wait();

            Act();
            ActAsync().Wait();
        }

#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        /// <summary>
        /// Called before <see cref="SystemUnderTest"/> is created.
        /// </summary>
        protected virtual async Task SetupAsync() { }

        /// <summary>
        /// Called before <see cref="SystemUnderTest"/> is created.
        /// </summary>
        protected virtual void Setup() { }

        /// <summary>
        /// Called after <see cref="SystemUnderTest"/> is created.
        /// </summary>
        protected virtual async Task ArrangeAsync() { }

        /// <summary>
        /// Called after <see cref="SystemUnderTest"/> is created.
        /// </summary>
        protected virtual void Arrange() { }

        protected virtual async Task ActAsync() { }

        protected virtual void Act() { }
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
    }
}
