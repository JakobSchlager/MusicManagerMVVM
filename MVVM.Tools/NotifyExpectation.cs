using System;
using System.ComponentModel;
using System.Diagnostics;
//using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MVVM.Tools
{
  public class NotifyExpectation<T> where T : INotifyPropertyChanged
  {
    private readonly T owner;
    private readonly string propertyName;
    private readonly bool eventExpected;

    public NotifyExpectation(T owner, string propertyName, bool eventExpected)
    {
      this.owner = owner;
      this.propertyName = propertyName;
      this.eventExpected = eventExpected;
    }

    public void When(Action<T> action)
    {
      bool eventWasRaised = false;
      owner.PropertyChanged += (sender, e) =>
      {
        if (e.PropertyName == propertyName) eventWasRaised = true;
      };
      action(owner);
      Debug.Assert(eventExpected == eventWasRaised, $"PropertyChanged on {propertyName}");
    }
  }
}
