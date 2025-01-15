using Microsoft.AspNetCore.Mvc;

namespace biblioteka.Models;

public class StudentViewModel
{
    [HiddenInput]
    public int? Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string IndexNumber { get; set; }
    public DateTime? Birth { get; set; }
}