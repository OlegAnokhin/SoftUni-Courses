﻿namespace ValidationAttributes.Utilities
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public abstract class MyValidationAttribute : Attribute
    {
        public abstract bool IsValid(object obj);
    }
}
