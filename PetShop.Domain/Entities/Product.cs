using PetShop.Domain.Validations;

namespace PetShop.Domain.Entities
{
    public sealed class Product
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public decimal Price { get; private set; }
        public ICollection<Purchase> Purchases { get; private set; }

        public Product(string name, decimal price)
        {
            Validation(name, price);
            Purchases = new List<Purchase>();
        }

        public Product(int id, string name, decimal price)
        {
            DomainValidationException.When(id > 0, "Id não pode ser menor do que zero");
            Id = id;
            Validation(name, price);
            Purchases = new List<Purchase>();
        }

        private void Validation(string name, decimal price)
        {
            DomainValidationException.When(string.IsNullOrEmpty(name), "O nome deve ser informado!");
            DomainValidationException.When(price > 0, "O Preço nao pode ser menor que 0");

            Name = name;
            Price = price;
        }
    }
}