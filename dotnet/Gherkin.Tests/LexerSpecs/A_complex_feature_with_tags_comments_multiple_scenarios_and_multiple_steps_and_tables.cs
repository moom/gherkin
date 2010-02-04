using Xunit;

namespace Gherkin.Tests.LexerSpecs
{
    public class A_complex_feature_with_tags_comments_multiple_scenarios_and_multiple_steps_and_tables : LexerSpec { 
        [Fact] public void should_find_things_in_the_right_order() {
            a_lexer().scan_file("complex.feature").
                should_result_in("(root " + 
                                 "(comment 1  \"#Comment on line 1\" )" +
                                 "(comment 2  \"#Comment on line 2\" )" +
                                 "(tag 3   tag1  )" +
                                 "(tag 3   tag2  )" +
                                 "(feature 4   Feature  \"Feature Text\nIn order to test multiline forms\nAs a ragel writer\nI need to check for complex combinations\" )" +
                                 "(comment 9  \"#Comment on line 9\" )" +
                                 "(comment 11  \"#Comment on line 11\" )" +
                                 "(background 13   Background  \"\" )" +
                                 "(step 14 Given \"Given \" \"this is a background step\" )" +
                                 "(step 15 And \"And \" \"this is another one\" )" +
                                 "(tag 17   tag3 )" +
                                 "(tag 17   tag4 )" +
                                 "(scenario 18   Scenario  \"Reading a Scenario\" )" +
                                 "(step 19 Given \"Given \" \"there is a step\" )" +
                                 "(step 20 But \"But \" \"not another step\" )" +
                                 "(tag 22   tag3  )" +
                                 "(scenario 23   Scenario  \"Reading a second scenario\" )" +
                                 "(comment 24  \"#Comment on line 24\" )" +
                                 "(step 25 Given \"Given \" \"a third step with a table\" )" +
                                 "(table 26  (row (cell a)(cell b)) (row (cell c)(cell d)) (row (cell e)(cell f)) )" +
                                 "(step 29 And \"And \" \"I am still testing things\" )" +
                                 "(table 30  (row (cell g)(cell h)) (row (cell e)(cell r)) (row (cell k)(cell i)) (row (cell n) (cell \"\")) )" +
                                 "(step 34 And \"And \" \"I am done testing these tables\" )" +
                                 "(comment 35  \"#Comment on line 29\" )" +
                                 "(step 36 Then \"Then \" \"I am happy\" )" +
                                 "(scenario 38   Scenario   Hammerzeit  )" +
                                 "(step 39 Given \"Given \" \"All work and no play\" )" +
                                 "(py_string 40  \"Makes Homer something something\" )" +
                                 "(step 43 Then \"Then \"  crazy )" +
                                 "");
        }

        [Fact]
        public void should_report_the_token_positions()
        {
            a_lexer().using_column_positions().
                scan_file("complex.feature").
                should_result_in("(root " +
                                "(comment 1:1  \"#Comment on line 1\" )" +
                                "(comment 2:1  \"#Comment on line 2\" )" +
                                "(tag 3:1   tag1  )" +
                                "(tag 3:7   tag2  )" +
                                "(feature 4:1   Feature 4:9 \"Feature Text\nIn order to test multiline forms\nAs a ragel writer\nI need to check for complex combinations\" )" +
                                "(comment 9:3  \"#Comment on line 9\" )" +
                                "(comment 11:3  \"#Comment on line 11\" )" +
                                "(background 13:3   Background 13:14 \"\" )" +
                                "(step 14:5 Given \"Given \" 14:11 \"this is a background step\" )" +
                                "(step 15:5 And \"And \" 15:9 \"this is another one\" )" +
                                "(tag 17:3   tag3 )" +
                                "(tag 17:9   tag4 )" +
                                "(scenario 18:3   Scenario 18:12 \"Reading a Scenario\" )" +
                                "(step 19:5 Given \"Given \" 19:11 \"there is a step\" )" +
                                "(step 20:5 But \"But \" 20:9 \"not another step\" )" +
                                "(tag 22:3   tag3  )" +
                                "(scenario 23:3   Scenario 23:12 \"Reading a second scenario\" )" +
                                "(comment 24:5  \"#Comment on line 24\" )" +
                                "(step 25:5 Given \"Given \" 25:11 \"a third step with a table\" )" +
                                "(table 26:5  (row (cell 26:6 a)(cell 26:8 b)) (row (cell 27:6 c)(cell 27:8 d)) (row (cell 28:6 e)(cell 28:8 f)) )" +
                                "(step 29:5 And \"And \" 29:9 \"I am still testing things\" )" +
                                "(table 30:7  (row (cell 30:8 g)(cell 30:10 h)) (row (cell 31:8 e)(cell 31:10 r)) (row (cell 32:8 k)(cell 32:10 i)) (row (cell 33:8 n) (cell 33:10 \"\")) )" +
                                "(step 34:5 And \"And \" 34:9 \"I am done testing these tables\" )" +
                                "(comment 35:5  \"#Comment on line 29\" )" +
                                "(step 36:5 Then \"Then \" 36:10 \"I am happy\" )" +
                                "(scenario 38:3   Scenario 38:12  Hammerzeit  )" +
                                "(step 39:5 Given \"Given \" 39:11 \"All work and no play\" )" +
                                "(py_string 40:7  \"Makes Homer something something\" )" +
                                "(step 43:5 Then \"Then \" 43:10 crazy )" +
                                "");
        }
    }
}