using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace DefiningClasses
{
    public class Family
    {
        public List<Person> familyMembers;
            
        public Family()
        {
            this.familyMembers = new List<Person>();
        }
        public void AddMember(Person member)
        {
            this.familyMembers.Add(member);
        }
        public Person GetOldestMember()
        {
            int maxAge = this.familyMembers.Max(member => member.Age);
            return this.familyMembers.First(member => member.Age == maxAge);
        }
    }
}
