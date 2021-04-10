namespace Rebbit.Core.ValueObject
{
    public class RatingInfo
    {
        public int NumberOfLikes { get; set; }
        public int NumberOfDislikes { get; set; }

        public int GetRating() => NumberOfLikes - NumberOfDislikes;
    }
}
