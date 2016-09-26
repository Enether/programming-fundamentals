using System;

/*
This problem is from the Programming Fundamentals Retake Exam (11 September 2016).
Thea is a photographer. She takes pictures of people on special events. She is a good friend and you want to help her.
She wants to inform her clients when their pictures will be ready. Since the number of pictures is big and it requires time 
for editing (#nofilter, #allnatural) every single picture - you decide to write a program in order to help her.
Thea follows this pattern: first she takes all pictures. Then she goes through every single picture to filter these pictures
that are considered "good". Then she needs to upload every single filtered picture to her cloud. She is considered ready when all filtered pictures are uploaded in her picture storage.
You will receive the amount of pictures she had taken. Then the approximate time in seconds for every picture to be filtered.
Then a filter factor – a percentage (integer number) of the total photos
(rounded to the nearest bigger integer value e.g. 5.01 -> 6) that are good enough to be given to her clients 
(Photoshop may do miracles but Thea does not). Approximate time for every picture to be uploaded will be given again in seconds.
Your task is: based on this input to display total time needed for her to be ready with the pictures in given below format. 
*/

class TheaThePhotographer
{
    static void Main()
    {
        // read the input
        long totalPictures = long.Parse(Console.ReadLine());
        long filterTime = long.Parse(Console.ReadLine());
        int filterPercentage = int.Parse(Console.ReadLine());
        long uploadTime = long.Parse(Console.ReadLine());

        // calculate what we need
        long secondsPassedFiltering = filterTime * totalPictures;
        long filteredPictures = (long)Math.Ceiling((filterPercentage / 100.0) * totalPictures);  // TODO: TEST
        long secondsPassedUploading = uploadTime * filteredPictures;
        long totalSecondsPassed = secondsPassedFiltering + secondsPassedUploading;

        // convert the total seconds to a properly formatted string
        TimeSpan time = TimeSpan.FromSeconds(totalSecondsPassed);

        // here the backslash is a must in order to tell that the colon is not a part of the format,
        // it's just a character that we want in output
        string output = time.ToString(@"d\:hh\:mm\:ss");


        Console.WriteLine(output);
    }
}
