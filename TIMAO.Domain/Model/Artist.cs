using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TIMAO.Domain.Model
{
    public class Artist
    {
        public Guid Id { get; set; }
        public string NickName { get; set; } =string.Empty;
        public string ExWorks { get; set; }=string.Empty;
    }
}
