﻿
using System;

public class ValidationException : ApplicationException
{
    public ValidationException(string message) : base(message) { }
}
