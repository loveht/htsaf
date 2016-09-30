using System;

namespace Ataoge.Data
{
    [AttributeUsage(AttributeTargets.Property)]
    public class DbFieldAttribute : Attribute
    {
        public string Name 
        {
            get;
            set;
        }
    }
}