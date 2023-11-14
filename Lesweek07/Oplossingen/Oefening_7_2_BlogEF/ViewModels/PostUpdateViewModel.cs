namespace Oefening_7_2_BlogEF.ViewModels;
public class PostUpdateViewModel
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public int CategoryId { get; set; }
    public DateTime CreatedDate { get; set; }
}
