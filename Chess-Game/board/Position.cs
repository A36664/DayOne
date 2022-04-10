namespace board
{
    class Position
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Position(int row, int column)
        {
            X = row;
            Y = column;
        }

        public void DefineValues(int row, int column)
        {
            X = row;
            Y = column;
        }

        public override string ToString()
        {
            return X
                + ", "
                + Y;
        }
    }
}
