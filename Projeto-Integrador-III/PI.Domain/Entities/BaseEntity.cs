using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PI.Domain.Entities
{
    public class BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime? CreateAt {
            get { return _createAt; }
            set { _createAt = (value == null) ? DateTime.Now : value ; }
        }
        public DateTime? UpdateAt { get; set; }

        private DateTime? _createAt;
    }
}