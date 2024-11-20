namespace Simulator.Maps
{
    /// <summary>
    /// Small square map with a side size between 5 and 20 points.
    /// </summary>
    public class SmallSquareMap : SmallMap
    {
        /// <summary>
        /// Size of the map.
        /// </summary>
        public int Size { get; }
        /// <summary>
        /// Constructor for SmallSquareMap.
        /// </summary>
        /// <param name="size">Size of the map side.</param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the size is not within the allowed range.</exception>
        public SmallSquareMap(int size)
        {
            if (size < 5 || size > 20)
            {
                throw new ArgumentOutOfRangeException(nameof(size), "Size must be set as: 5-20.");
            }
            Size = size;
        }
        
        public override Point Next(Point p, Direction d)
        {
            Point nextPoint = d switch
            {
                Direction.Up => new Point(p.X, p.Y + 1),
                Direction.Down => new Point(p.X, p.Y - 1),
                Direction.Left => new Point(p.X - 1, p.Y),
                Direction.Right => new Point(p.X + 1, p.Y),
                _ => p
            };
            return Exist(nextPoint) ? nextPoint : p;
        }
        public override Point NextDiagonal(Point p, Direction d)
        {
            Point nextDiagonalPoint = d switch
            {
                Direction.Up => new Point(p.X + 1, p.Y + 1),
                Direction.Down => new Point(p.X - 1, p.Y - 1),
                Direction.Left => new Point(p.X - 1, p.Y + 1),
                Direction.Right => new Point(p.X + 1, p.Y - 1),
                _ => p
            };
            return Exist(nextDiagonalPoint) ? nextDiagonalPoint : p;
        }
        public override string ToString() => $"Map created! Size: {Size}";
    }
}