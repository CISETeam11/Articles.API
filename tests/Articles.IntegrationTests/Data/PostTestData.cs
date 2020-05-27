using System.Collections.Generic;

namespace Articles.IntegrationTests.Data
{
    public class PostTestData
    {
        #region User Rating Test Data

        public static IEnumerable<object[]> SuccessUserRatingTestData()
        {
            yield return new object[]
            {
                1,
                new
                {
                    Rating = 3
                }
            };

            yield return new object[]
            {
                2,
                new
                {
                    Rating = 5
                }
            };
        }

        public static IEnumerable<object[]> BadRequestUserRatingTestData()
        {
            yield return new object[]
            {
                1,
                new
                {
                    Rating = 0
                }
            };

            yield return new object[]
            {
                1,
                new
                {
                    Rating = 6
                }
            };

            yield return new object[]
            {
                "two",
                new
                {
                    Rating = 2
                }
            };

            yield return new object[]
            {
                1,
                new { }
            };

            yield return new object[]
            {
                1,
                2
            };

            yield return new object[]
            {
                1,
                null
            };
        }

        public static IEnumerable<object[]> NotFoundUserRatingTestData()
        {
            yield return new object[]
            {
                "",
                new
                {
                    Rating = 2
                }
            };

            yield return new object[]
            {
                null,
                new
                {
                    Rating = 2
                }
            };

            yield return new object[]
            {
                0,
                new
                {
                    Rating = 2
                }
            };

            yield return new object[]
            {
                7,
                new
                {
                    Rating = 2
                }
            };
        }

        #endregion
    }
}