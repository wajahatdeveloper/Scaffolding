/* Copyright Kupio Limited. Registered in Scotland; SC426881.
 * All rights reserved. Not for distribution. */

namespace com.kupio.declarativeorder
{
    using System;

    [AttributeUsage(AttributeTargets.Class)]
    public class RunLast : Attribute
    {
        public RunLast()
        {
            /* noop */
        }
    }
}
