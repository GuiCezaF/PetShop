using PetShop.Domain.Validations;

namespace PetShop.Domain.Entities
{
    public sealed class Person
    {
        public int Id { get; private set; }
        public string Name { get; set; }
        public string Email { get; private set; }
        public string ImageUrl { get; private set; }
        public ICollection<Purchase> Purchases { get; private set; }

        public Person(string name, string email, string imageUrl)
        {
            Validation(name, email, imageUrl);
            Purchases = new List<Purchase>();
        }

        public Person(int id, string name, string email, string imageUrl)
        {
            DomainValidationException.When(id < 0, "O Id deve ser maior do que 0!");
            Id = id;
            Validation(name, email, imageUrl);
            Purchases = new List<Purchase>();
        }

        private void Validation(string name, string email, string imageUrl)
        {
            DomainValidationException.When(string.IsNullOrEmpty(name), "O nome deve ser informado!");
            DomainValidationException.When(string.IsNullOrEmpty(email), "O email deve ser informado!");
            DomainValidationException.When(string.IsNullOrEmpty(imageUrl), "A Url da Imagem deve ser informado!");

            Name = name;
            Email = email;
            ImageUrl = imageUrl;
        }
    }
}