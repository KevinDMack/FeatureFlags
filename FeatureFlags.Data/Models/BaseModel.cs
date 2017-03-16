using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeatureFlags.Data.Models
{
    public class BaseModel
    {
        [Key]
        public Guid Key { get; set; }

        [Required]
        [DisplayName("Effective Date")]
        public DateTime EffectiveDate { get; set; }

        [DisplayName("End Date")]
        public DateTime? EndDate { get; set; }

        //[Required]
        //[DisplayName("Date Added")]
        //public DateTime DateAdded { get; set; }

        //[Required]
        //[DisplayName("Added By")]
        //public string AddedBy { get; set; }

        //[DisplayName("Date Modified")]
        //public DateTime? DateModified { get; set; }

        //[DisplayName("Modified By")]
        //public string ModifiedBy { get; set; }
    }
}
