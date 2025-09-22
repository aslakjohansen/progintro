public class EnrollmentSystem
{
  public Student[] students;
  public Course[] courses;
  
  public void Enroll(Student student, Course course) {
    course.Enroll(student);
  }
  
  public void Remove(Student student, Course course) {
    course.Remove(student);
  }
  
  public void ShowParticipants(Course course) {
    foreach (Student student in course.GetParticipants()) {
      Console.WriteLine(student.GetName());
    }
  }
  
  public void GetCourses() {
    Console.WriteLine("void for a getter?");
  }
  
  public void GetStudents() {
    Console.WriteLine("void for a getter?");
  }
}
