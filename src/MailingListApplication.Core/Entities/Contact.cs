using MailingListApplication.SharedKernal;


namespace MailingListApplication.Core.Entities
{
    public class Contact : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }
}
