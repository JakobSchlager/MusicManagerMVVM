using System;
using System.ComponentModel;
using System.Diagnostics;

namespace MVVM.Tools
{
  public class ObservableObject : INotifyPropertyChanged
  {
    public event PropertyChangedEventHandler PropertyChanged;

    protected void RaisePropertyChangedEvent(string propertyName)
    {
      PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
    protected void RaisePropertyChangedEvent()
    {
      string setterName = "Unknown";
      int frameNr = 1; //this is the calling method
      while (true)
      {
        var frame = new StackTrace().GetFrame(frameNr);
        if (frame == null) throw new ArgumentException($"RaisePropertyChangedEvent called outside of any setter!");
        string callingMethodName = frame.GetMethod().Name;
        if (callingMethodName.StartsWith("set_"))
        {
          Console.WriteLine($"Found setter in frame {frameNr}");
          setterName = callingMethodName[4..]; //Name is "set_Xxx"
          break;
        }
        frameNr++;
      }
      RaisePropertyChangedEvent(setterName);
    }
  }

}
