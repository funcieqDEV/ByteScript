using ByteScript.Src.Frontend;

namespace ByteScript
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("ByteScript v0.0.1 alpha");
            Lexer ByteScriptLexer = new(File.ReadAllText("C:\\Users\\HP\\source\\repos\\ByteScript\\ByteScript\\example.bys"));
            Console.WriteLine("tokenizing....");
            var toks = ByteScriptLexer.Tokenize();
            Console.WriteLine("amount of tokens: "+toks.Count);
            foreach (var tok in toks) { 
                Console.WriteLine(tok.ToString());
            }
        }
    }
}
