using Newtonsoft.Json;

namespace Api.Entidad.Models
{
    
    public class MasteryCompanymodeljson : IEquatable<MasteryCompanymodeljson>
    {
    
        public string? Name { get; set; }

       
        public string? LastName { get; set; }

        
        public string Document { get; set; }

        public double? Salary { get; set; }

     
        public string? Gender { get; set; }

       
        public string? Position { get; set; }

       
        public string? StartDate { get; set; }

        public bool Equals(MasteryCompanymodeljson other)
        {
            return Document.Equals(other.Document);
        }
        public override int GetHashCode()
        {
            return Document.GetHashCode();
        }
    }
}