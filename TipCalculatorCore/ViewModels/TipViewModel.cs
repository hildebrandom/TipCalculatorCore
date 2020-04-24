using MvvmCross.ViewModels;
using System.Threading.Tasks;
using TipCalculatorCore.Services;

namespace TipCalculatorCore.ViewModels
{
    public class TipViewModel : MvxViewModel
    {
        private readonly ICalculationService _calculationService;
        private decimal _SubTotal;
        private int _generosity;
        private decimal _tip;

        public TipViewModel(ICalculationService calculationService)
        {
            _calculationService = calculationService;
        }

        public decimal SubTotal
        {
            get => _SubTotal;
            set
            {
                _SubTotal = value;
                RaisePropertyChanged(() => SubTotal);
                Recalculate();

            }

        }

        public decimal Tip
        {
            get => _tip;
            set
            {
                _tip = value;
                RaisePropertyChanged(() => Tip);


            }

        }

        public int Generosity
        {
            get => _generosity;
            set
            {
                _generosity = value;
                RaisePropertyChanged(() => Generosity);
                Recalculate();


            }

        }

        public async override Task Initialize()
        {
            await base.Initialize();
            SubTotal = 100;
            Generosity = 10;
            Recalculate();
        }


        private void Recalculate()
        {
            Tip = _calculationService.TipAmount(SubTotal, Generosity);
        }
    }
}
