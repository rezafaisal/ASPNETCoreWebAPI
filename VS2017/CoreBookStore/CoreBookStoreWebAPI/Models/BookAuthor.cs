using System;
using System.ComponentModel.DataAnnotations;

namespace CoreBookStoreWebAPI.Models
{
    public partial class BookAuthor{

        [Required(ErrorMessage = "{0} harus diisi.")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "{0} harus angka")]
        [StringLength(13, MinimumLength = 10, ErrorMessage = "{0} tidak boleh lebih {1} dan tidak boleh kurang {2} karakter.")]
        public int ISBN {set; get;}
        
        [Required(ErrorMessage = "{0} harus diisi.")]
        public int AuthorID {set; get;}
    }
}
