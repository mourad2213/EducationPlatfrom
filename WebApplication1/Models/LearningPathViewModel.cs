using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Models
{
    public class LearningPathViewModel
    {
        public int PathId { get; set; }
        public string? Rules { get; set; }
        public string? LearnerStatus { get; set; }
        public string? PathDescription { get; set; }
        public int? InstructorId { get; set; }
        public int? LearnerId { get; set; }
    }

}