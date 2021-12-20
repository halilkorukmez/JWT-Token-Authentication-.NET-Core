using Core.Model.DtoModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dto
{
    public class UserListDto : DtoGetBase
    {
        public IList<User> User { get; set; }
    }
}
