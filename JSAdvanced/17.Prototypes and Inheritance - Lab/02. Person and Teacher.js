function personAndTeacher() {
    class Person  {
        constructor(name, email){            
            this.name = name;
            this.email = email;
        }
    }
    class Teacher extends Person {
        constructor(tName, tEmail,subject){
            super(tName, tEmail);
            this.subject = subject;
        }
    }
    return {
        Person,
        Teacher
    }
}