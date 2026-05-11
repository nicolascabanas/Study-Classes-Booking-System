namespace Study_Classes_Booking_System.src.Decorators
{
    public class ArCondicionadoDecorator : SalaDecorator
    {
        public ArCondicionadoDecorator(Sala sala) : base(sala)
        {
            this.Nome = $"{sala.Nome} + Ar Condicionado";
        }

        public override double PrecoBase => _sala.PrecoBase + 15.0;
    }

    public class BebedouroDecorator : SalaDecorator
    {
        public BebedouroDecorator(Sala sala) : base(sala)
        {
            this.Nome = $"{sala.Nome} + Bebedouro";
        }

        public override double PrecoBase => _sala.PrecoBase + 10.0;
    }
}