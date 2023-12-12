namespace Oefening_08_01_BlogEF.Entities;
public class Category
{
    public Category()
    {
        Posts = new List<Post>();
    }
    public int Id { get; set; }
    public string Name { get; set; }
    public List<Post> Posts { get; set; } 
}
