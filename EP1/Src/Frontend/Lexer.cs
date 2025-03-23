using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteScript.Src.Frontend
{
    public class Lexer
    {
        string input;
        int i = 0;

        Dictionary<string, TokenType> Keywords = new Dictionary<string, TokenType>()
        {
            {"fun",TokenType.FunKeyword },
            {"ret",TokenType.RetKeyword },
            {"print", TokenType.PrintKeyword },
        };
        public Lexer(string inp) {
            this.input = inp;
        }
        public List<Token> Tokenize()
        {
            List<Token> tokens = new List<Token>();
            while (i < input.Length) {
                if (input[(int)i] == '#')
                {
                    while (input[(int)i] != '\n') {
                        i++;
                    }
                    i++;
                }
                else if (Char.IsLetter(input[i]))
                {
                    int start = i;
                    while (i < input.Length && (Char.IsDigit(input[i]) || Char.IsLetter(input[i]))) {
                        i++;
                    }
                    string value = input.Substring(start, i - start);
                    if (Keywords.ContainsKey(value)) {
                        tokens.Add(new Token(value, Keywords[value]));
                    }
                    else
                    {
                        tokens.Add(new Token(value, TokenType.Id));
                    }
                    
                }
                else if (Char.IsDigit(input[i]))
                {
                    int start = i;
                    bool IsFloat = false;

                    while (i < input.Length && (char.IsDigit(input[i]) || input[i] == '.')) {
                        if (input[i] == '.')
                        {
                            if (IsFloat || i + 1 >= input.Length || !Char.IsDigit(input[i + 1]))
                            {
                                throw new Exception("why are you tring to put multiple '.' in number");
                            }
                            IsFloat = true;
                        }
                        i++;
                    }
                    string value = input.Substring(start, i - start);
                    tokens.Add(new Token(value, TokenType.NumberLiteral));
                }
                else if (input[i] == '=')
                {
                    tokens.Add(new Token("=", TokenType.Assign));
                    i++;
                }
                else if (Char.IsWhiteSpace(input[i]))
                {
                    i++;
                }
                else if ("-+/*%".Contains(input[i]))
                {
                    tokens.Add(new Token(input[i].ToString(), TokenType.Operator));
                    i++;
                }
                else if (input[i] == ';')
                {
                    tokens.Add(new Token(";", TokenType.Semi));
                    i++;
                }
                else if (input[i] == '(')
                {
                    tokens.Add(new Token("(", TokenType.LParen));
                    i++;
                }
                else if (input[i] == ')')
                {
                    tokens.Add(new Token(")", TokenType.RParen));
                    i++;
                }
                else if (input[i] == '{')
                {
                    tokens.Add(new Token("{", TokenType.LBrace));
                    i++;
                }
                else if (input[i] == '}')
                {
                    tokens.Add(new Token("}", TokenType.RBrace));
                    i++;
                }
                else if (input[i] == ',')
                {
                    tokens.Add(new Token(",", TokenType.Comma));
                    i++;
                }
                else if (input[i] == '\"')
                {
                    int start = ++i;
                    while (i < input.Length && input[i] != '\"')
                    {
                        i++;
                    }
                    string value = input.Substring(start, i - start);
                    i++;
                    tokens.Add(new Token(value, TokenType.StringLiteral));
                }
                else
                {
                    throw new Exception("Error during tokenizing " + input[(int)i]);
                }

            }
            return tokens;
        }

        public bool IsAtEnd()
        {
            return i < input.Length;
        }
    }
}
