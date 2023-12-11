public void fill(Bitmap bmp, Point origin, Color fillColor)
{
    Point[] directions = { new Point(-1, 0), new Point(0, -1), new Point(1, 0), new Point(0, 1) };
    Queue<Point> pointsToFill = new Queue<Point>();
    pointsToFill.Enqueue(origin);

    while(pointsToFill.Any())
    {
        Point current = pointsToFill.Dequeue();

        if(bmp.GetPixel(current.X, current.Y) != Figura.ShapeColor)
        {
            bmp.SetPixel(current.X, current.Y, fillColor);
        }

        foreach (Point d in directions)
        {
            Point neighbour = new Point(current.X + d.X, current.Y + d.Y);
            if (inside(bmp, neighbour) && validPoint(bmp, current, neighbour) && !pointsToFill.Contains(neighbour))
            {
                pointsToFill.Enqueue(neighbour);
            }
        }
    }   
}