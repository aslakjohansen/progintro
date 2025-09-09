int[] grades = {4, 7, 02, 00, 10, 4, 12};

int GetGrade (int courseId)
{
  int grade = grades[courseId];
  if (grade >= 02) {
    return grade;
  } else {
    throw new Exception(); // this is an exceptional grade!
  }
}

int count = 0;
int sum   = 0;

for (int courseId=0 ; courseId<grades.Length ; courseId++) {
  try {
    sum += GetGrade(courseId);
    count++;
  } catch (Exception) {
  }
}

Console.WriteLine("Average grade is " + ((float)sum / count));
