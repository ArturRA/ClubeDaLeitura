namespace ClubeDaLeitura.ConsoleApp.Compartilhado
{
    public class Tela
    {
        public void ApresentarMensagemColorida(string mensagem, ConsoleColor cor)
        {
            Console.ForegroundColor = cor;
            Console.WriteLine(mensagem);
            Console.ResetColor();
        }

    }
}
