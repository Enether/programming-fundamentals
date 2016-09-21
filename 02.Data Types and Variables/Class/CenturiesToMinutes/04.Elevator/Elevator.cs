using System;

/*
 Calculate how many courses will be needed to elevate n persons by using an elevator of capacity of p persons. 
 The input holds two lines: the number of people n and the capacity p of the elevator.
     */
class Elevator
{
    static void Main()
    {
        int peopleCount = int.Parse(Console.ReadLine());
        int elevatorCapacity = int.Parse(Console.ReadLine());

        Console.WriteLine(Math.Ceiling((decimal)peopleCount / elevatorCapacity));
    }
}

