public class Course
{
  string    name;
  Student[] participants;
  int       id;
  
  public Course (string nameValue) {
    name = nameValue;
    participants = new Student[10]; // NOTE: This constant is BAD!
  }
  
  public void Enroll (Student student) {
    for (int i=0 ; i<participants.Length ; i++) {
      if (participants[i] == null) {
        participants[i] = student;
        return;
      }
    }
  }
  
  public void Remove (Student student) {
    for (int i=0 ; i<participants.Length ; i++) {
      if (participants[i] == student) {
        participants[i] = null;
      }
    }
  }
  
  public Student[] GetParticipants () {
    // count number of entries
    int count = 0;
    foreach (Student student in participants) {
      if (student != null) {
        count++;
      }
    }
    
    // make a copy
    Student[] result = new Student[count];
    int index = 0;
    foreach (Student student in participants) {
      if (student != null) {
        result[index++] = student;
      }
    }
    
    return result;
  }
}
