using System;
using System.Collections.Generic;

namespace AssignmentDB.Models;

public partial class Class
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Subject { get; set; }

    public int? TeacherId { get; set; }
}
