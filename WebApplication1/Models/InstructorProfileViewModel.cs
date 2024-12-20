using System.Collections.Generic;
using WebApplication1.Models;

public class InstructorProfileViewModel
{
    public int InstructorId { get; set; }
    public string Name { get; set; }
    public string ExpertiseAreas { get; set; }
    public string Qualifications { get; set; }
    public List<string> Emails { get; set; } = new List<string>(); // List of emails


    public string? Rules { get; set; }
    public string? LearnerStatus { get; set; }
    public string? PathDescription { get; set; }
    public int? LearnerId { get; set; }



    public List<LearningPathViewModel> LearningPaths { get; set; } // New property
    // Add more instructor-specific details here if needed

}