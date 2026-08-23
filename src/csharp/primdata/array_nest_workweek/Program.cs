bool[] workday = [false, false, false, false, false, false, false, false, false, false, false, false,
                  false, false, false, false, false, false, false, false, false, false, false, false];
bool[] friday  = [false, false, false, false, false, false, false, false, false, true , true , true ,
                  true , true , true , true , false, false, false, false, false, false, false, false];
bool[] weekend = [false, false, false, false, false, false, false, false, false, true , true , true ,
                  true , true , true , true , true , false, false, false, false, false, false, false];

bool[][] workweek = [
  workday,
  workday,
  workday,
  workday,
  friday,
  weekend,
  weekend,
];
