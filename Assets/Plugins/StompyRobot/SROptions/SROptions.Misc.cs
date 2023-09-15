using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using SRDebugger;
using UnityEngine;

public partial class SROptions
{
    [Category("Misc")]
    public void TestException()
    {
        throw new System.Exception("test exception please ignore");
    }
}