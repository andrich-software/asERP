using Microsoft.AspNetCore.Mvc;

namespace asERP.Server.Models;

public class CustomProblemDetails : ProblemDetails
{
    public List<string> Errors { get; set; } = new();
}