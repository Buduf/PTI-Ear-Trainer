using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PTI_Ear_Trainer_Model;

namespace PTI_Ear_Trainer.ViewModel
{
    public class IntervalInfo : ObservableObject
    {
        public IRelayCommand GuessIntervalCommand { get; private set; }
        public Interval Interval { get; private set; }
        public string IntervalShortName { get => Interval.ToString(); }

        public IntervalInfo(IRelayCommand guessIntervalCommand, Interval interval)
        {
            GuessIntervalCommand = guessIntervalCommand;
            Interval = interval;
        }
    }
}
