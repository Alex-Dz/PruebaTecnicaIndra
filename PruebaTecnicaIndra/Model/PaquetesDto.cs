namespace PruebaTecnicaIndra.Model
{
    public class PaquetesDto
    {
        public List<int> lstPaquetes { get; set; }
        public int tamanioCamion { get; set; }

        public PaquetesDto(List<int> lstPaquetes, int tamanioCamion)
        {
            this.lstPaquetes = lstPaquetes;
            this.tamanioCamion = tamanioCamion;
        }

        public PaquetesDto()
        {
            this.lstPaquetes = new List<int>();
            this.tamanioCamion = 0;
        }
    }
}
