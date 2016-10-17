/*
 Write a regular expression to match a valid full name. 
 A valid full name consists of two words, each word starts with a capital letter and 
 contains only lowercase letters afterwards; each word should be at least two letters long; 
 the two words should be separated by a single space. 
In order to check your regex, use these values for reference (paste all of them in the Test String field):
 */
class MatchFullName
{
    static void Main()
    {
        string fullNameRegexPattern = @"^[A-Z][a-z]+? [A-Z][a-z]+?$";
    }
}
