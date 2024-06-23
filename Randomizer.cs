class RandomInputComponent : IInputComponent
{
    Random rng;

    public RandomInputComponent()
    {
        rng = new Random();
    }
    
    public Point GetDirection()
    {
        return new Point(rng.Next(-1, 4),  rng.Next(-1, 4));
    }
}