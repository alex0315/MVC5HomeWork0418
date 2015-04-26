//------------------------------------------------------------------------------
// <auto-generated>
//     這個程式碼是由範本產生。
//
//     對這個檔案進行手動變更可能導致您的應用程式產生未預期的行為。
//     如果重新產生程式碼，將會覆寫對這個檔案的手動變更。
// </auto-generated>
//------------------------------------------------------------------------------

namespace MVC5HomeWork0418.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Data.Entity;
    
    public partial class 客戶聯絡人 : IValidatableObject
    {
        public int Id { get; set; }
        public int 客戶Id { get; set; }
        [Required]
        public string 職稱 { get; set; }
        [Required]
        public string 姓名 { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [RegularExpression(@"^09\d{2}-\d{6}", ErrorMessage = "手機 必須符合09xx-xxxxxx格式( e.g. 0911-111111 )。")]
        public string 手機 { get; set; }
        [Phone]
        public string 電話 { get; set; }
        public bool 是否已刪除 { get; set; }
    
        public virtual 客戶資料 客戶資料 { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            客戶資料Entities db = new 客戶資料Entities();
            var contact = db.客戶聯絡人.Include(客 => 客.客戶資料)
                .Where(c => !c.客戶資料.是否已刪除 
                    && !c.是否已刪除 
                    && c.Email == Email 
                    && c.客戶Id == 客戶Id
                    && c.Id != Id).FirstOrDefault();
            if (contact != null)
            {
                yield return new ValidationResult("同客戶的客戶聯絡人Email不能重複", new string[] { "Email" });
            }

        }
    }
}
