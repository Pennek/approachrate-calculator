using System;
using System.Collections;
using System.Collections.Generic;

namespace densityCalculator
{
    class Program
    {
      static double ar = 0;
      static double bpm = 0;
      static int snapdivisor = 0;

        static void Main(string[] args)
        {
          try{
            ar = Convert.ToDouble(args[0]);
            bpm = Convert.ToDouble(args[1]);
            snapdivisor = Convert.ToInt32(args[2]);
          }catch(IndexOutOfRangeException){
            Console.WriteLine("Too few arguments given. Arguments must include: approach rate, bpm and snapdivisor.");
            System.Environment.Exit(0);
          }catch(System.FormatException){
            Console.WriteLine("Snapdivisor must be a whole number.");
            System.Environment.Exit(0);
          }

          List<Circle> circles = new List<Circle>();
          circles = CreateCircles(getPreempt(ar), getIncrement(bpm, snapdivisor), getFadein(ar), getPreempt(ar));
          Print(circles);
        }

      private static int getPreempt(double ar){
        double result = 0;
        if(ar<5 && ar>=0){
          result = Math.Round(1200d + 600 * (5 - ar) / 5);
        }
        else if(ar==5){
          result = Math.Round(1200d);
        }
        else if(ar>5 && ar<=13){ //AR13 will give 0ms reaction time, so no point in going above that
          result = Math.Round(1200d - 750 * (ar - 5) / 5);
        }
        if(result<=0){
          return(0);
        } else {
          return (Convert.ToInt32(result));
        }
      }

      // Calculate the getFadein value and pass it off to the Circle constructor which then calculates an individual visibilty percentage
      private static int getFadein(double ar){
        double result = 0;
        if(ar<5 && ar>=0){
          result = Math.Round(800d + 400 * (5 - ar) / 5);
        }
        else if(ar==5){
          result = Math.Round(800d);
        }
        else if(ar>5 && ar<=13){ //AR13 will give 0ms reaction time, so no point in going above that
          result = Math.Round(800d - 500 * (ar - 5) / 5);
        }
        if(result<=0){
          return(0);
        } else {
          return (Convert.ToInt32(result));
        }
      }

    // Create correct amount of Circles with correct startTimes from bpm 
      private static List<Circle> CreateCircles(int endTime, int increment, int fadeinTime, int preempt){
        var objects = new List<Circle>();
        for(int currentTime = 0; currentTime <= endTime; currentTime+=increment){
          Circle x = new Circle(currentTime, fadeinTime, preempt);
          objects.Add(x);
        }
        return(objects);
      }

      private static void Print(List<Circle> circles){
        Console.WriteLine("Settings: AR" + Convert.ToString(ar) + ", BPM: " + Convert.ToString(bpm) + ", Snapdivisor: " + Convert.ToString(snapdivisor));
        Console.WriteLine("Preempt: " + Convert.ToString(getPreempt(ar)) + "ms");
        Console.WriteLine("Fadein: " + Convert.ToString(getFadein(ar)) + "ms");
        Console.WriteLine("-----------------------------------");
        Console.WriteLine("In total there are " + Convert.ToString(circles.Count) + " circles visible at once:");
        for(int i=0; i < circles.Count; i++){
          Console.WriteLine("#" + Convert.ToString(i+1) + " at " + circles[i].getObjectTime() + "ms is visible for " + circles[i].getVisibilityTime() + "ms (" + circles[i].getVisibilityPercentage() + "% visible)");
          // #1 at 0ms is visible for 15ms (87.5% visible)
        }
        
      }

      private static int getIncrement(double bpm, int snap){
        int eBPM = Convert.ToInt32(Math.Round(bpm * snap));
        return(60000/eBPM);
      }
    }
}
