﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Status
{
    public string name;
    public int[] effect;
    public int button;

    public static string[] creatureUpdateName = new string[]
    {
        "FROZEN",
        "STUNNED",
        "READY"
    };
}
