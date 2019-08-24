namespace Game2048
{
    public class SquareItem
    {
        public int Number { get; set; }

        public bool IsNew { get; set; }

        public bool IsMerged { get; set; }

        public SquareItem(int number, bool isNew = true, bool isMerged = false)
        {
            (Number, IsNew, IsMerged) = (number, isNew, isMerged);
        }

        public static SquareItem Copy(SquareItem item)
        {
            return item == null
                ? null
                : new SquareItem(item.Number, item.IsNew, item.IsMerged);
        }
    }
}
