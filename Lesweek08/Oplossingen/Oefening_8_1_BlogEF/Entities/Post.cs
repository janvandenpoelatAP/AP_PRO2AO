namespace Oefening_8_1_BlogEF.Entities;
public class Post
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public int CategoryId { get; set; }
    public DateTime CreatedDate { get; set; }
    public Category Category { get; set; }  
}
