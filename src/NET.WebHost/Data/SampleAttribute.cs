using System;

namespace lennybacon.MyFood.Data
{
  [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
  public class SampleAttribute : Attribute
  {
    public SampleAttribute(string value)
    {
      Value = value;
    }

    public string Value { get; }
  }
}