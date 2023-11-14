namespace Oefening_7_2_BlogEF.Entities;
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
