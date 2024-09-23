using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Helpline.Shared.Models
{
    public class Tags : BaseModel
    {
        public string TagName { get; set; } = string.Empty;
    }
}
