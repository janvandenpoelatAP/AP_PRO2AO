namespace Voorbeeld_07_01_EFSamurai;
public class Quote
{
    public int Id { get; set; }
    public string Text { get; set; }
    public Samurai Samurai { get; set; }
    public int SamuraiId { get; set; }
}
