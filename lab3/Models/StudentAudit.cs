﻿using System;
using System.Collections.Generic;

namespace lab3.Models;

public partial class StudentAudit
{
    public string? ServerUserName { get; set; }

    public DateOnly? Date { get; set; }

    public string? Note { get; set; }
}
