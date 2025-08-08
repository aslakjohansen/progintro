int ada_lovelace      = 36; // https://en.wikipedia.org/wiki/Ada_Lovelace
int dennis_ritchie    = 70; // https://en.wikipedia.org/wiki/Dennis_Ritchie
int grace_hopper      = 85; // https://en.wikipedia.org/wiki/Grace_Hopper
int hedy_lamarr       = 85; // https://en.wikipedia.org/wiki/Hedy_Lamarr
int edsger_dijkstra   = 72; // https://en.wikipedia.org/wiki/Edsger_W._Dijkstra
int douglas_engelbart = 88; // https://en.wikipedia.org/wiki/Douglas_Engelbart

float male_avg   = (float)(dennis_ritchie + edsger_dijkstra + douglas_engelbart) / 3;
float female_avg = (float)(ada_lovelace + grace_hopper + hedy_lamarr) / 3;
float avg = (male_avg + female_avg) / 2;
float diff = male_avg - female_avg;

Console.Write("Average lifespan of a male computer scientist: ");
Console.WriteLine(male_avg);
Console.Write("Average lifespan of a female computer scientist: ");
Console.WriteLine(female_avg);
Console.Write("Average lifespan of a computer scientist: ");
Console.WriteLine(avg);
Console.Write("Males live this much longer than females: ");
Console.WriteLine(diff);
