using System;
using System.Collections;
using System.Collections.Generic;

class Circle{
  //Instance Variables
  private int objectTime;
  private int fadeinTime;
  private string visibilityPercentage;
  private string visibilityTime;
  private int preempt;

  //Constructor 
  public Circle(int objectTime, int fadeinTime, int preempt){
    this.objectTime = objectTime;
    this.fadeinTime = fadeinTime;
    this.preempt = preempt;
    this.visibilityPercentage = calculateVisibilityPercentage();
    this.visibilityTime = calculateVisibilityTime();
  }

  public string getObjectTime(){
    return(Convert.ToString(objectTime));
  }

  public string getVisibilityTime(){
    return(visibilityTime);
  }

   public string getVisibilityPercentage(){
    return(visibilityPercentage);
  }

  private string calculateVisibilityPercentage(){
    double result = Convert.ToDouble(preempt - objectTime) / Convert.ToDouble(fadeinTime) * 100;
    if(result>100)
      result = 100;
    return result.ToString("F");
  }

  private string calculateVisibilityTime(){
    int result = preempt - objectTime;
    if(result>fadeinTime){
      result = fadeinTime;
    }      
    return Convert.ToString(result);
  }
}