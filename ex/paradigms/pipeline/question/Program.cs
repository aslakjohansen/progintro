Human[] humans = new Human[] {
  new Human {sex=Sex.Female, age=17, name="Buffy Summers"},
  new Human {sex=Sex.Male, age=12, name="Luca"},
  new Human {sex=Sex.Female, age=22, name="Sofie"},
  new Human {sex=Sex.Male, age=34, name="Klaus"},
  new Human {sex=Sex.Female, age=19, name="Perinne"},
  new Human {sex=Sex.Female, age=23, name="Fie"},
  new Human {sex=Sex.Male, age=20, name="Asger"},
  new Human {sex=Sex.Female, age=27, name="Pernille"},
  new Human {sex=Sex.Male, age=21, name="Peter"},
  new Human {sex=Sex.Female, age=26, name="Dominika"},
  new Human {sex=Sex.Male, age=7, name="Mathias"},
};

int minAge (Human[] humans) {
  int best = -1;
  
  foreach (Human human in humans) {
    if (human.sex==Sex.Male && human.age>=18 && (best==-1 || human.age<best)) {
      best = human.age;
    }
  }
  
  return best;
}

Console.WriteLine(minAge(humans));

enum Sex {
  Female,
  Male,
};

struct Human {
  public Sex sex;
  public int age;
  public string name;
}
