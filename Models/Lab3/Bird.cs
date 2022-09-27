namespace OOP.Models.Lab3
{
    public abstract class Bird
    {
        public virtual string Eat()
            => "The Bird is eating";

        public virtual string Move()
            => "The Bird is moving";
    }
}
