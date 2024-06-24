public startingPosition position{get; set;}

 public player(int x, int y)
 {
        position = new Punkt(5, 5);
    }

 public player(point startingPosition)
 {
      position = new point(startingPosition);
 }