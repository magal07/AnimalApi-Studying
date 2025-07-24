namespace AnimalApi.Models
{
    public class AnimalRequest
    {
        public AnimalRequest(string name)
        {
            Name = name;
        }
        public string Name { get; set; }
    }
}
 // ou simplesmente crie um record animalreq(string name)