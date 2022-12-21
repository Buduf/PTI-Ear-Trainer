using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PTI_Ear_Trainer_Model;

namespace PTI_Ear_Trainer.ViewModel
{
    public partial class IntervalInfo : ObservableObject
    {
        private EarTrainer model;

        public Interval Interval { get; private set; }
        public string IntervalShortName { get => Interval.ToString(); }

        public IntervalInfo(EarTrainer model, Interval interval)
        {
            this.model = model;
            Interval = interval;
        }

        [RelayCommand]
        private void GuessInterval()
        {
            model.GuessInterval(Interval);
        }
    }
}
