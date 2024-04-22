using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFExtra;

public class Tag
{
    public int Id { get; set; }
    public List<Post> Posts { get; } = [];
}
