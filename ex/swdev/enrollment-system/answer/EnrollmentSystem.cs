public class EnrollmentSystem
{
  public Student[] students;
  public Course[]  courses;
  
  public void Enroll (Student student, Course course) {
    students = new Student[0];
    courses = new Course[0];
    course.Enroll(student);
  }
  
  public void Remove (Student student, Course course) {
    course.Remove(student);
  }
  
  public void ShowParticipants (Course course) {
    foreach (Student student in course.GetParticipants()) {
      Console.WriteLine(student.GetName());
    }
  }
  
  public void GetCourses () {
    for (int i=0 ; i<courses.Length ; i++) {
      Console.WriteLine(courses[i]);
    }
  }
  
  public void GetStudents () {
    for (int i=0 ; i<students.Length ; i++) {
      Console.WriteLine(students[i].GetName());
    }
  }
  
  public void AddStudent (Student student) {
    // avoid duplicates
    foreach (Student entry in students) {
      if (entry == student) {
        return;
      }
    }
    
    // create new list
    Student[] newList = new Student[students.Length + 1];
    for (int i=0 ; i<students.Length ; i++) {
      newList[i] = students[i];
    }
    newList[students.Length] = student;
    
    // override old reference
    students = newList;
  }
  
  public void RemoveStudent (Student student) {
    int i;
    
    // find index of student
    for (i=0 ; i<students.Length ; i++) {
      if (students[i] == student) {
        break;
      }
    }
    
    // guard: student not in list
    if (i == students.Length) {
      return;
    }
    
    // create new list
    Student[] newList = new Student[students.Length - 1];
    int n = 0;
    for (int o=0 ; o<students.Length ; o++) {
      if (o != i) {
        newList[n++] = students[o];
      }
      o++;
    }
    newList[students.Length] = student;
    
    // override old reference
    students = newList;
  }
}
