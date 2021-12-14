namespace PruebaTecnicaIndra.Model
{
    public class CasasResponse
    {
        public int dias { get; set; }
        public IEnumerable<int> entrada { get; set; }
        public IEnumerable<int> salida { get; set; }

        public CasasResponse(int dias, IEnumerable<int> entrada, IEnumerable<int> salida)
        {
            this.dias = dias;
            this.entrada = entrada;
            this.salida = salida;
        }
    }
}
