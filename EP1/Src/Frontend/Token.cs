using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteScript.Src.Frontend
{
    public enum TokenType
    {
        Id, // identifiter
        Assign, // =
        NumberLiteral,// 999.999
        Semi,//;
        FunKeyword,//fun
        RetKeyword, //ret
        PrintKeyword, //print
        LParen, //(
        RParen, //)
        LBrace, // {
        RBrace, // }
        Operator, // + - * / %
        Comma, // ,
        StringLiteral,// "text"
        EOF // end of file
    }
    //x = 5; -> (identifiter, Assign, number, semicolon)
    public class Token
    {
        String Value;
        TokenType Type;

        public Token(String value, TokenType type)
        {
            this.Value = value;
            this.Type = type;
        }

        public override string ToString() {
            return $"(type: {this.Type}, value: {this.Value})";
        }
    }
}
