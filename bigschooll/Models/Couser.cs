namespace bigschooll.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Couser")]
    public partial class Couser
    {
        public int Id { get; set; }

        [Required]
        [StringLength(128)]
        public string LectuserId { get; set; }

        [Required]
        [StringLength(255)]
        public string Place { get; set; }

        public DateTime DateTime { get; set; }

        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }

        public List<Category> ListCategory = new List<Category>();
    }
}
