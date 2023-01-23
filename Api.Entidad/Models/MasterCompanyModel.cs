using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Api.Entidad.Models
{
    
    public class MasterCompanyModel : IEquatable<MasterCompanyModel>
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Document { get; set; }
        [Required]
        public double Salary { get; set; }

        [Required]
        public string Gender { get; set; }

        [Required]
        public string Position { get; set; }

        [Required]
        public string StartDate { get; set; }

        public bool Equals(MasterCompanyModel other)
        {
            return Document.Equals(other.Document);
        }
        public override int GetHashCode()
        {
            return Document.GetHashCode();
        }
    }
}