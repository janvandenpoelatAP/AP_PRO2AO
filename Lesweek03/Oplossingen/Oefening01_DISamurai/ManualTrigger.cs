﻿namespace Oefening01_DISamurai;
public class ManualTrigger : ITrigger
{
    public void Pull()
    {
        Console.WriteLine("Pulling the manual trigger");
    }
}
