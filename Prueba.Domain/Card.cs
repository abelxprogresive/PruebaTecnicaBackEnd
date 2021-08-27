using System.ComponentModel.DataAnnotations;

namespace Prueba.Domain
{
    public class Card
    {
        public Card(string name, string pan, string pin)
        {
            Id = System.Guid.NewGuid();
            Name = name;
            Pan = pan;
            Pin = pin;
        }

        

        public System.Guid Id { get; private set; }
        public string Name { get; private set; }        
        public string Pan { get; private set; }
        public string Pin { get; set; }
        public decimal Amount { get; set; }
    }
}
