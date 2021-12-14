namespace PruebaTecnicaIndra.Model
{
    public class CasasDto
    {
        public List<int> lstCasas { get; set; }
        public int dias { get; set; }
        public int diasTranscurridos { get; set; }

        public CasasDto(List<int> lstCasas, int dias, int diasTranscurridos)
        {
            this.lstCasas = lstCasas;
            this.dias = dias;
            this.diasTranscurridos = diasTranscurridos;
        }

        public CasasDto()
        {
            this.lstCasas = new List<int>();
            this.dias = 0;
            this.diasTranscurridos = 0;
        }
    }
}
