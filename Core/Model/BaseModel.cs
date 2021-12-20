using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Model
{
    public class BaseModel : IEntity
    {
        public DateTime? CreateDate { get; set; }
        public Guid Id { get; set; }
        public bool IsActive { get; set; }
        public BaseModel()
        {
            
            this.IsActive = true;
            this.Id = Guid.NewGuid();
        }


    }
}
