using AllInOne.Data.Entity.Moive.Enums;

namespace AllInOne.Models.Movie.Movie
{
    public class AddCastModel
    {
        public AddCastModel(string fullName, CastTypeKind castType)
        {
            FullName = fullName;
            CastType = castType;
        }
        public CastTypeKind CastType { get; set; }
        public string FullName { get; set; }
    }
}