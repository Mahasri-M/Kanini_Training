using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basic
{
    internal class LINQDemo
    {
        public void ShowResults()
        {
            // Data source.
            int[] scores = { 90, 71, 82, 93, 75, 82 };

            // Query Expression.
            int highScoreCount = (
            from score in scores
            where score > 80
            select score  ).Count();
            Console.WriteLine( highScoreCount );

            /*
            IEnumerable<int> scoreQuery =
                from score in scores
                where score > 80
                orderby score descending
                select score;

            // Execute the query to produce the results
            foreach (int testScore in scoreQuery)
            {
                Console.WriteLine(testScore);
            }
            */
            /*
             IEnumerable<int> highScoresQuery =
            from score in scores
            where score > 80
            select score;
            int scoreCount = highScoresQuery.Count();
            Console.WriteLine(scoreCount);
            */
}
}
}
