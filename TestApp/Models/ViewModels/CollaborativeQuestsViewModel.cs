namespace TestApp.Models.ViewModels;

public class CollaborativeQuestsViewModel
{
    public int QuestID { get; set; }
    public string difficulty_level { get; set; }
    public string criteria { get; set; }
    public string quest_description { get; set; }
    public string title { get; set; }
    public int max_num_participants { get; set; }
    public DateTime deadline { get; set; }
}