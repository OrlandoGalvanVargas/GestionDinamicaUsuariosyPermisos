namespace BaseDeDatosDinamicas.Models
{
    public class DatabaseCreationModel
    {
        public string NombreDB { get; set; }
        public string RutaMDF { get; set; }
        public int TamanioInicialMDF { get; set; }
        public int CrecimientoMDF { get; set; }
        public int TamanioMaximoMDF { get; set; }
        public string RutaLDF { get; set; }
        public int TamanioInicialLDF { get; set; }
        public int CrecimientoLDF { get; set; }
    }
}
