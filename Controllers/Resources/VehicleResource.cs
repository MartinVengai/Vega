using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace vega.Controllers.Resources
{
    public class VehicleResource
    {
        public int Id { get; set; }
        [Required]
        public int ModelId { get; set; }
        [Required]
        public bool IsRegistered { get; set; }
        [Required]
        public ContactResource Contact { get; set; }
        public virtual ICollection<int> Features { get; set; }

        public VehicleResource()
        {
            Features = new Collection<int>();
        }
    }
}