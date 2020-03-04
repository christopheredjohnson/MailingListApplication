using MailingListApplication.Core.Entities;
using MailingListApplication.UnitTests;
using System;
using Xunit;


namespace MailingListApplication.IntegrationTests.Data
{
    public class EfRepositoryDelete : BaseEfRepoTestFixture
    {
        [Fact]
        public void DeletesItemAfterAddingIt()
        {
            // add an item
            var repository = GetRepository();

            // set firstname to a guid

            var initialFirstName = Guid.NewGuid().ToString();
            var item = new ContactBuilder().FirstName(initialFirstName).Build();
            repository.Add(item);
            

            // delete the item
            repository.Delete(item);

            // verify it's no longer there
            Assert.DoesNotContain(repository.List<Contact>(),
                i => i.FirstName == initialFirstName);
        }
    }
}
