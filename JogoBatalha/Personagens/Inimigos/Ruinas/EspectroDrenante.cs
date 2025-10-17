namespace JogoBatalha.Personagens.Inimigos.Ruinas
{
    public class EspectroDrenante : Inimigo
    {
        public EspectroDrenante() : base("Espectro Drenante", 80, 18, 5) { }

        public override void Atacar(Personagem alvo)
        {
            Console.WriteLine($"{this.Nome} tenta drenar a força vital de {alvo.Nome}!");
            int dano = this.ForcaDeAtaque;
            alvo.ReceberDano(dano, this.Tipo);
            int cura = dano / 2;
            this.Curar(cura); 
        }
    }
}