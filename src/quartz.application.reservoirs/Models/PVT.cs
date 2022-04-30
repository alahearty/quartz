namespace quartz.wpf.domain.Models.Reservoirs
{
    public class PVT : ModelBase
    {
        private string _modelType;
        private string _rsandBo;
        private string _viscosity;

        public string ModelType { get => _modelType; set { _modelType = value; OnPropertyChanged("Viscosity"); } }
        public string RsandBo { get => _rsandBo; set { _rsandBo = value; OnPropertyChanged("Viscosity"); } }
        public string Viscosity { get => _viscosity; set { _viscosity = value; OnPropertyChanged("Viscosity"); } }
    }
}