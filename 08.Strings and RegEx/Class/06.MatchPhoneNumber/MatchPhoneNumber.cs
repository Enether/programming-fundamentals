/*
 Write a regular expression to match a valid phone number from Sofia. 
 A valid number will start with "+359" followed by the area code (2) and then the number itself, 
 consisting of 7 digits (separated in two group of 3 and 4 digits respectively).
 The different parts of the number are separated by either a space or a hyphen ('-'). 
 Refer to the examples to get the idea. 
 
Match ALL of these
+359 2 222 2222
+359-2-222-2222

Match NONE of these
359-2-222-2222, +359/2/222/2222, +359-2 222 2222
+359 2-222-2222, +359-2-222-222, +359-2-222-22222
  */

class MatchPhoneNumber
{
    static void Main()
    {
        string pattern = @"^\+359(-| )2\1\d{3}\1\d{4}$";
    }
}
