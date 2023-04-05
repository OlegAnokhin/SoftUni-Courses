namespace Boardgames.Common
{
    public static class ValidationConstants
    {
        //Boardgame
        public const int BoardgameNameMinLenght = 10;
        public const int BoardgameNameMaxLenght = 20;
        public const double BoardgameRatingMinValue = 1;
        public const double BoardgameRatingMaxValue = 10.00;
        public const int BoardgameYearMinValue = 2018;
        public const int BoardgameYearMaxValue = 2023;

        //Seller
        public const int SellerNameMinLenght = 5;
        public const int SellerNameMaxLenght = 20;
        public const int SellerAddressMinLenght = 2;
        public const int SellerAddressMaxLenght = 30;
        public const string SellerWebsiteRegex = @"^[w]{3}.{1}[A-Za-z0-9|-]+.{1}[c]{1}[o]{1}[m]{1}";

        //Creator
        public const int CreatorFirstNameMinLenght = 2;
        public const int CreatorFirstNameMaxLenght = 7;
        public const int CreatorLastNameMinLenght = 2;
        public const int CreatorLastNameMaxLenght = 7;
    }
}