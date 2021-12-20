using Core.Model.DtoModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dto
{
    public class UserDto : DtoGetBase
    {
        public User User { get; set; }
    }
}
