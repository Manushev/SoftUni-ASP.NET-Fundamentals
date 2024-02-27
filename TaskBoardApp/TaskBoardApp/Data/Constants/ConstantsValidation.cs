namespace TaskBoardApp.Data.Constants
{
    public static class ConstantsValidation
    {
        public class Task
        {
            //•	Title – a string with min length 5 and max length 70
            public const int TitleMinimumLength = 5;
            public const int TitleMaximumLength = 70;

            //•	Description – a string with min length 10 and max length 1000
            public const int DescriptionMinimumLength = 10;
            public const int DescriptionMaximumLength = 1000;
        }

        public class Board
        {
            //•	Name – a string with min length 3 and max length 30
            public const int NameMinimumLength = 3;
            public const int NameMaximumLength = 30;
        }
    }
}
