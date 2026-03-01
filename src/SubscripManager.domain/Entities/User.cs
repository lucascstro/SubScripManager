namespace SubscripManager.domain.Entities
{
    public class User
    {
        public User(string name, string email)
        {
            if(string.IsNullOrEmpty(name)) throw new Exception("Nome inválido");

            Id = Guid.NewGuid();
            Name = name;
            Email = email;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }   
        public string Email { get; set; }

        public List<Signature> Signatures { get; private set; } = new ();
    }
}
