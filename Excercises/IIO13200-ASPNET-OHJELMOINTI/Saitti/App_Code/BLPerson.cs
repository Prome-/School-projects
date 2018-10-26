using System;

/// <summary>
/// Summary description for BLPerson
/// </summary>

namespace JAMK.IT
{
    public class Person
    {
        public Person()
        {

        }

        public string Name { get; set; }
        public string Gender { get; set; }
        public string Birthday { get; set; }
    }
    public class Politician: Person
    {
        public string Party { get; set; }
        public string Position { get; set; }
    }
}
