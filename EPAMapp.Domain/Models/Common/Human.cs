namespace EPAMapp.Domain.Models.Common
{
    public class Human : BaseEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }

        public string FullName
        {
            get
            {
                return $"{Name} {Surname}";
            }
        }
    }
}
