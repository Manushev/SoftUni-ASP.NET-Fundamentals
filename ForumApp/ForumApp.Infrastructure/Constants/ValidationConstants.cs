namespace ForumApp.Infrastructure.Constants
{
    public static class ValidationConstants
    {
        public const int TitleMinLength = 10;
        public const int TitleMaxLength = 50;
        public const string TitleMinLengthErrorMessage = "The title must be at least 10 characters long.";
        public const string TitleMaxLengthErrorMessage = "The title cannot exceed 50 characters.";

        public const int ContentMinLength = 30;
        public const int ContentMaxLength = 150;
        public const string ContentMinLengthErrorMessage = "The content must be at least 30 characters long.";
        public const string ContentMaxLengthErrorMessage = "The content cannot exceed 150 characters.";
    }
}
