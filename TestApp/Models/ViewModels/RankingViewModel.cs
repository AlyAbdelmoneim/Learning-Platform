namespace TestApp.Models.ViewModels;

public class RankingViewModel
{
    public int BoardID { get; set; }
    public int LearnerID { get; set; }
    public int? rankNum { get; set; }
    public int? total_points { get; set; }
}