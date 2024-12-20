using WebApplication1.Models;

internal class ForumViewModel
{
    public int ForumId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public List<PostViewModel> Posts { get; set; }
}