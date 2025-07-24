namespace AnimalApi.Models
{
    public class AnimalModel
    {
        public AnimalModel(string name)
        {
            Name = name;
            Id = Guid.NewGuid();
        }
        public Guid Id { get; init; }
        public string Name { get; private set; }


        public void ChangeName(string name)
        {
            Name = name;
        }

        public void DeleteAnimal()
        {
            Name = Name + " Animal Deleted";
        }
    }
}
