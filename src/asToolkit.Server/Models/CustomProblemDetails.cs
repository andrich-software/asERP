using Microsoft.AspNetCore.Mvc;

namespace asToolkit.Server.Models;

public class CustomProblemDetails : ProblemDetails
{
    public List<string> Errors { get; set; } = new();
}