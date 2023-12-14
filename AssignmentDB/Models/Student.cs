using System;
using System.Collections.Generic;

namespace AssignmentDB.Models;

public partial class Student
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Dob { get; set; }

    public string? Address { get; set; }

    public int? ClassId { get; set; }
}
