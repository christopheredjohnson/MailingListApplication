using MailingListApplication.Core.Entities;
using MailingListApplication.UnitTests;
using System.Linq;
using Xunit;


namespace MailingListApplication.IntegrationTests.Data
{
    public class EfRepositoryAdd : BaseEfRepoTestFixture
    {
        [Fact]
        public void AddsItemAndSetsId()
        {
            var repository = GetRepository();
            var item = new ContactBuilder().Build();

            repository.Add(item);

            var newItem = repository.List<Contact>().FirstOrDefault();

            Assert.Equal(item, newItem);

            Assert.True(newItem?.Id > 0);
        }
    }
}
