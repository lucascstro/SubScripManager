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
            Signatures = new List<Signature>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }   
        public string Email { get; set; }

        public List<Signature> Signatures { get; set; } = new ();
    }
}
