using System;

namespace Ataoge.Data
{
    public class DbRelationshipAttribute : Attribute
    {
        public string Name 
        {
            get;
            set;
        }
    }
}