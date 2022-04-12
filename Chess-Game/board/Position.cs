namespace board
{
    class Position
    {
        public int Y { get; set; }
        public int X { get; set; }

        public Position(int row, int column)
        {
            Y = row;
            X = column;
        }

        public void DefineValues(int row, int column)
        {
            Y = row;
            X = column;
        }

        public override string ToString()
        {
            return Y
                + ", "
                + X;
        }
    }
}
