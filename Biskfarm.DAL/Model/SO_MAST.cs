using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biskfarm.DAL.Model
{
    public class SO_MAST
    {
        [Key]
        public int SO_ID { get; set; }
        [DisplayName("SO Name")]
        public string? SO_NAME { get; set; }
        [DisplayName("ASM ID")]
        public Nullable<int> ASM_ID { get; set; }
        [DisplayName("Active")]
        public string? active { get; set; }
        [DisplayName("Head Quarter")]
        public string? Head_Qtr { get; set; }
        [DisplayName("Home Town")]
        public string? Home_Town { get; set; }
        [DisplayName("Designation Code")]
        public string? Desig_Code { get; set; }
        [DisplayName("FC ID")]
        public Nullable<int> FC_ID { get; set; }
        [DisplayName("DOCT")]
        public Nullable<System.DateTime> DOCT { get; set; }
        [DisplayName("Home Town Name")]
        public string? HomeTown_Name { get; set; }
        [DisplayName("RELOCATION")]
        public Nullable<bool> ReLoc_Allow { get; set; }
        [DisplayName("Merchandiser")]
        public string? Merchandiser_yn { get; set; }
        [DisplayName("Image")]
        public string? large_img { get; set; }
    }
}
