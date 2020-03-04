using MailingListApplication.Core.Entities;


namespace MailingListApplication.UnitTests
{
    public class ContactBuilder
    {
        private Contact _contact = new Contact();

        public ContactBuilder Id(int id)
        {
            _contact.Id = id;
            return this;
        }

        public ContactBuilder FirstName(string firstName)
        {
            _contact.FirstName = firstName;
            return this;
        }

        public ContactBuilder LastName(string lastName)
        {
            _contact.LastName = lastName;
            return this;
        }

        public ContactBuilder Email(string email)
        {
            _contact.Email = email;
            return this;
        }

        public ContactBuilder WithDefaultValues()
        {
            _contact = new Contact() { Id = 1, FirstName = "Test", LastName = "McTesterson", Email = "tmctesterson@example.com" };

            return this;
        }

        public Contact Build() => _contact;

    }
}
