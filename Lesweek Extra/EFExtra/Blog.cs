using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFExtra;

public class Blog
{
    public int Id { get; set; }
    public string Name { get; set; }
    public virtual Uri? SiteUri { get; set; }

    public ICollection<Post> Posts { get; set; } = new List<Post>();
}
