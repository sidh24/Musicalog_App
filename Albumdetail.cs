namespace Musicalog_App
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Albumdetail")]
    public partial class Albumdetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int AlbumId { get; set; }

        [StringLength(50)]
        public string AlbumName { get; set; }

        [StringLength(50)]
        public string Artist { get; set; }

        [StringLength(50)]
        public string Type { get; set; }

        public int? Stock { get; set; }
    }
}
